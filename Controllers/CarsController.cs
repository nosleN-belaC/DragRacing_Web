﻿using System;
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
    public class CarsController : Controller
    {
        private readonly DragRacing_WebContext _context;

        public CarsController(DragRacing_WebContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var dragRacing_WebContext = _context.Cars.Include(c => c.Engines);
            return View(await dragRacing_WebContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .Include(c => c.Engines)
                .FirstOrDefaultAsync(m => m.Car_ID == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["Engine_ID"] = new SelectList(_context.Engines, "Engine_ID", "Engine_ID");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Car_ID,Make_Name,Model_Name,Tire_Compound,Engine_ID")] Cars cars)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(cars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Engine_ID"] = new SelectList(_context.Engines, "Engine_ID", "Engine_ID", cars.Engine_ID);
            return View(cars);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound();
            }
            ViewData["Engine_ID"] = new SelectList(_context.Engines, "Engine_ID", "Engine_ID", cars.Engine_ID);
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Car_ID,Make_Name,Model_Name,Tire_Compound,Engine_ID")] Cars cars)
        {
            if (id != cars.Car_ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(cars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarsExists(cars.Car_ID))
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
            ViewData["Engine_ID"] = new SelectList(_context.Engines, "Engine_ID", "Engine_ID", cars.Engine_ID);
            return View(cars);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .Include(c => c.Engines)
                .FirstOrDefaultAsync(m => m.Car_ID == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'DragRacing_WebContext.Cars'  is null.");
            }
            var cars = await _context.Cars.FindAsync(id);
            if (cars != null)
            {
                _context.Cars.Remove(cars);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsExists(int id)
        {
          return (_context.Cars?.Any(e => e.Car_ID == id)).GetValueOrDefault();
        }
    }
}
