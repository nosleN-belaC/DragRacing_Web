using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DragRacing_Web.Areas.Identity.Data;
using DragRacing_Web.Models;

namespace DragRacing_Web.Controllers
{
    public class DriversController : Controller
    {
        private readonly DragRacing_WebContext _context;

        public DriversController(DragRacing_WebContext context)
        {
            _context = context;
        }

        // GET: Drivers
        public async Task<IActionResult> Index()
        {
            var dragRacing_WebContext = _context.Drivers.Include(d => d.Cars);
            return View(await dragRacing_WebContext.ToListAsync());
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var drivers = await _context.Drivers
                .Include(d => d.Cars)
                .FirstOrDefaultAsync(m => m.Driver_ID == id);
            if (drivers == null)
            {
                return NotFound();
            }

            return View(drivers);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            ViewData["Car_ID"] = new SelectList(_context.Cars, "Car_ID", "Car_ID");
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Driver_ID,First_Name,Last_Name,DOB,Hometown,Racing_Team,Car_ID")] Drivers drivers)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(drivers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Car_ID"] = new SelectList(_context.Cars, "Car_ID", "Car_ID", drivers.Car_ID);
            return View(drivers);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var drivers = await _context.Drivers.FindAsync(id);
            if (drivers == null)
            {
                return NotFound();
            }
            ViewData["Car_ID"] = new SelectList(_context.Cars, "Car_ID", "Car_ID", drivers.Car_ID);
            return View(drivers);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Driver_ID,First_Name,Last_Name,DOB,Hometown,Racing_Team,Car_ID")] Drivers drivers)
        {
            if (id != drivers.Driver_ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(drivers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriversExists(drivers.Driver_ID))
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
            ViewData["Car_ID"] = new SelectList(_context.Cars, "Car_ID", "Car_ID", drivers.Car_ID);
            return View(drivers);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var drivers = await _context.Drivers
                .Include(d => d.Cars)
                .FirstOrDefaultAsync(m => m.Driver_ID == id);
            if (drivers == null)
            {
                return NotFound();
            }

            return View(drivers);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drivers == null)
            {
                return Problem("Entity set 'DragRacing_WebContext.Drivers'  is null.");
            }
            var drivers = await _context.Drivers.FindAsync(id);
            if (drivers != null)
            {
                _context.Drivers.Remove(drivers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriversExists(int id)
        {
          return (_context.Drivers?.Any(e => e.Driver_ID == id)).GetValueOrDefault();
        }
    }
}
