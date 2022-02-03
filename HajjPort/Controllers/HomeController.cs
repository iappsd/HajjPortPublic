using HajjPort.Data;
using HajjPort.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HajjPort.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext db;

        public HomeController(ILogger<HomeController> logger,AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index(DateTime? from, DateTime? to)
        {
            if (from == null && to == null)
            {

                ViewData["PortOperations"] = db.PortOperations.Include(x => x.Port.AppUser).ToList();
            }
            else
            {
                ViewData["PortOperations"] = db.PortOperations.Include(x => x.Port.AppUser)
                    .Where(x =>
                    from <= x.EntryDate 
                    &&
                    to >= x.EntryDate 
                    )
                    .ToList();
            }

            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
