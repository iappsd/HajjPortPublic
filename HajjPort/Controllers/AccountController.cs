using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HajjPort.Models;
using HajjPort.Controllers;
using Microsoft.AspNetCore.Authorization;
using HajjPort.ViewModel;
using HajjPort.Models;
using HajjPort.Data;

namespace HajjPort.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> um;
        private readonly SignInManager<AppUser> sm;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext db;

        public AccountController(
            UserManager<AppUser> um,
            SignInManager<AppUser> sm,
            RoleManager<IdentityRole> roleManager,
            AppDbContext db

            )
        {
            this.um = um;
            this.sm = sm;
            _roleManager = roleManager;
            this.db = db;
        }
        public IActionResult Index() => RedirectToAction("Login");


         public IActionResult AccessDenied()
        {
            return View();
        }

        //[Authorize(Roles = "Administrator")]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/Account/Login");

            RegisterViewModel registerView = new RegisterViewModel();

   
            return View(registerView);
        }


        [HttpPost][AutoValidateAntiforgeryToken]
        //[Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/Account/Login");
            if (ModelState.IsValid)
            {
                var user = new AppUser{UserName = model.Email,Email = model.Email, Name = model.Name };
                var result = await um.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await sm.SignInAsync(user, isPersistent: false);
                   
                    if (model.UserRoles == "User")
                    {
                        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                        if (await _roleManager.RoleExistsAsync(UserRoles.User))
                            await um.AddToRoleAsync(user, UserRoles.User);
                    }

                    if (model.UserRoles == "Admin")
                    {
                        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                            await um.AddToRoleAsync(user, UserRoles.Admin);
                    }

                    // await sm.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Login");

                }

                AddErrors(result);
            }

            return View(model);
        }

        public IActionResult Login(string returnUrl=null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/Account/Login");
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/Home");

            if (ModelState.IsValid)
            {
                var result = await sm.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "بيانات الدخول غير صحيحة");
                    return View(model);
                }

            }

            return View(model);
        }



        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Logoff()
        {
            await sm.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty,error.Description);
            }
        }
    }
}
