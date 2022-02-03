using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HajjPort.Data;
using HajjPort.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HajjPort.Controllers
{

    [Authorize]
    public class PortOperationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;


        public PortOperationsController(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            _context = context;

            this.httpContextAccessor = httpContextAccessor;
        }

        private string UserId
        {
            get
            {
                return httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        // GET: PortOperations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PortOperations.Include(p => p.Port);
            return View(await appDbContext.ToListAsync());
        }

  
        // GET: PortOperations/Create
        public IActionResult Create()
        {
            ViewData["PortID"] = new SelectList(_context.Port, "id", "Name");
            return View();
        }

        // POST: PortOperations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortOperations portOperations)
        {
            
            if(_context.Port.Include(x=>x.AppUser).Where(x=>x.AppUser.Id == UserId).Any())
            {                
                portOperations.Port = _context.Port.Include(x => x.AppUser).FirstOrDefault(x => x.AppUser.Id == UserId);
                portOperations.PortID = _context.Port.Include(x => x.AppUser).FirstOrDefault(x => x.AppUser.Id == UserId).id;
                portOperations.EntryDate = DateTime.Now;
            }
            else
            {
                return BadRequest();
            }

            
            if (ModelState.IsValid)
            {
                _context.Add(portOperations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PortID"] = new SelectList(_context.Port, "id", "Name", portOperations.PortID);
            return View(portOperations);
        }

        // GET: PortOperations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portOperations = await _context.PortOperations.FindAsync(id);
            if (portOperations == null)
            {
                return NotFound();
            }
            ViewData["PortID"] = new SelectList(_context.Port, "id", "Name", portOperations.PortID);
            return View(portOperations);
        }

        // POST: PortOperations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,   PortOperations portOperations)
        {
            if (id != portOperations.id)
            {
                return NotFound();
            }

            if (_context.Port.Include(x => x.AppUser).Where(x => x.AppUser.Id == UserId).Any())
            {
                portOperations.Port = _context.Port.Include(x => x.AppUser).FirstOrDefault(x => x.AppUser.Id == UserId);
                portOperations.PortID = _context.Port.Include(x => x.AppUser).FirstOrDefault(x => x.AppUser.Id == UserId).id;
             }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portOperations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortOperationsExists(portOperations.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PortID"] = new SelectList(_context.Port, "id", "Name", portOperations.PortID);
            return View(portOperations);
        }

        // GET: PortOperations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portOperations = await _context.PortOperations
                .Include(p => p.Port)
                .FirstOrDefaultAsync(m => m.id == id);
            if (portOperations == null)
            {
                return NotFound();
            }

            return View(portOperations);
        }

        // POST: PortOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portOperations = await _context.PortOperations.FindAsync(id);
            _context.PortOperations.Remove(portOperations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortOperationsExists(int id)
        {
            return _context.PortOperations.Any(e => e.id == id);
        }
    }
}
