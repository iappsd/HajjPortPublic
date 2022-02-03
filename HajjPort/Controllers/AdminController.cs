using HajjPort.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using HajjPort.Models;
using HajjPort.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HajjPort.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly AppDbContext db;
        
        private readonly UserManager<AppUser> appUser;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration conf;
        public AdminController(IConfiguration conf, AppDbContext db,UserManager<AppUser> appUser, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.appUser = appUser;
            this.roleManager = roleManager;
            this.conf = conf;
        }

      

        public IActionResult Index() => View(roleManager.Roles.ToList());
        public IActionResult Users() => View(appUser.Users.ToList());

        public IActionResult AddRole() => View();

        [HttpGet]
        public async Task<IActionResult> UserRoles(string Id)
        {
            List<UserRolesVM> userrolesList = new List<UserRolesVM>();

            if (Id != null)
            {
                var role = await roleManager.FindByIdAsync(Id);
                ViewBag.RoleName = role.Name;
                foreach (var user in appUser.Users.ToList())
                {
                    UserRolesVM r = new UserRolesVM
                    {
                        UserId = user.Id,

                        UserName = user.UserName
                    };

                    if (await appUser.IsInRoleAsync(user, role.Name))
                    {
                        r.IsSelected = true;
                    }
                    else { r.IsSelected = false; }
                    userrolesList.Add(r);
                }
                return View(userrolesList);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> UserRoles(string Id, List<UserRolesVM> model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (Id != null)
                    {
                        var role = await roleManager.FindByIdAsync(Id);
                        foreach (var vm in model)
                        {
                            var user = await appUser.FindByIdAsync(vm.UserId);
                            if (await appUser.IsInRoleAsync(user, role.Name) && !vm.IsSelected)
                            {
                                await appUser.RemoveFromRoleAsync(user, role.Name);
                            }
                            else if (!(await appUser.IsInRoleAsync(user, role.Name)) && vm.IsSelected)
                            {
                                await appUser.AddToRoleAsync(user, role.Name);
                            }
                        }
                        return RedirectToAction("Index");
                    }
                }
                return View();

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(RoleVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var role = new IdentityRole();
                    role.Name = model.RoleName;
                    IdentityResult result = await roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return Redirect("Index");
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                return View();

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

        }

        [HttpPost]
        public async Task<ActionResult> DeleteRole(string Id)
        {
            try
            {
                if (Id != null)
                {
                    var role = await roleManager.FindByIdAsync(Id);

                    IdentityResult result = await roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            catch (Exception e)
            {

                ModelState.AddModelError("", e.Message);
            }
            return View();
        }


        public IActionResult Home()
        {
            return View();
        }

    }
}
