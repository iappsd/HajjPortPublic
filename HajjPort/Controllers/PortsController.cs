using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HajjPort.Data;
using HajjPort.Models;

namespace HajjPort.Controllers
{
    public class PortsController : Controller
    {
        private readonly AppDbContext _context;

        public PortsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ports
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Port.Include(p => p.AppUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Ports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Port
                .Include(p => p.AppUser)
                .FirstOrDefaultAsync(m => m.id == id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);
        }

        // GET: Ports/Create
        public IActionResult Create()
        {
            ViewData["AppUserID"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Ports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,PortDescription,AppUserID,IsActive")] Port port)
        {
            if (ModelState.IsValid)
            {
                _context.Add(port);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserID"] = new SelectList(_context.Users, "Id", "Name", port.AppUserID);
            return View(port);
        }

        // GET: Ports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Port.FindAsync(id);
            if (port == null)
            {
                return NotFound();
            }
            ViewData["AppUserID"] = new SelectList(_context.Users, "Id", "Name", port.AppUserID);
            return View(port);
        }

        // POST: Ports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,PortDescription,AppUserID,IsActive")] Port port)
        {
            if (id != port.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(port);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortExists(port.id))
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
            ViewData["AppUserID"] = new SelectList(_context.Users, "Id", "Name", port.AppUserID);
            return View(port);
        }

        // GET: Ports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Port
                .Include(p => p.AppUser)
                .FirstOrDefaultAsync(m => m.id == id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);
        }

        // POST: Ports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var port = await _context.Port.FindAsync(id);
            _context.Port.Remove(port);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortExists(int id)
        {
            return _context.Port.Any(e => e.id == id);
        }
    }
}
