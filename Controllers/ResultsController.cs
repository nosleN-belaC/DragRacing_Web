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
    public class ResultsController : Controller
    {
        private readonly DragRacing_WebContext _context;

        public ResultsController(DragRacing_WebContext context)
        {
            _context = context;
        }

        // GET: Results
        public async Task<IActionResult> Index()
        {
            var dragRacing_WebContext = _context.Results.Include(r => r.Drivers).Include(r => r.Tracks);
            return View(await dragRacing_WebContext.ToListAsync());
        }

        // GET: Results/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Results == null)
            {
                return NotFound();
            }

            var results = await _context.Results
                .Include(r => r.Drivers)
                .Include(r => r.Tracks)
                .FirstOrDefaultAsync(m => m.Result_ID == id);
            if (results == null)
            {
                return NotFound();
            }

            return View(results);
        }

        // GET: Results/Create
        public IActionResult Create()
        {
            ViewData["Driver_ID"] = new SelectList(_context.Drivers, "Driver_ID", "Driver_ID");
            ViewData["Track_ID"] = new SelectList(_context.Tracks, "Track_ID", "Track_ID");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Result_ID,Driver_ID,Time,Weather,Date,Track_ID")] Models.Results results)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(results);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Driver_ID"] = new SelectList(_context.Drivers, "Driver_ID", "Driver_ID", results.Driver_ID);
            ViewData["Track_ID"] = new SelectList(_context.Tracks, "Track_ID", "Track_ID", results.Track_ID);
            return View(results);
        }

        // GET: Results/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Results == null)
            {
                return NotFound();
            }

            var results = await _context.Results.FindAsync(id);
            if (results == null)
            {
                return NotFound();
            }
            ViewData["Driver_ID"] = new SelectList(_context.Drivers, "Driver_ID", "Driver_ID", results.Driver_ID);
            ViewData["Track_ID"] = new SelectList(_context.Tracks, "Track_ID", "Track_ID", results.Track_ID);
            return View(results);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Result_ID,Driver_ID,Time,Weather,Date,Track_ID")] Models.Results results)
        {
            if (id != results.Result_ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(results);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultsExists(results.Result_ID))
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
            ViewData["Driver_ID"] = new SelectList(_context.Drivers, "Driver_ID", "Driver_ID", results.Driver_ID);
            ViewData["Track_ID"] = new SelectList(_context.Tracks, "Track_ID", "Track_ID", results.Track_ID);
            return View(results);
        }

        // GET: Results/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Results == null)
            {
                return NotFound();
            }

            var results = await _context.Results
                .Include(r => r.Drivers)
                .Include(r => r.Tracks)
                .FirstOrDefaultAsync(m => m.Result_ID == id);
            if (results == null)
            {
                return NotFound();
            }

            return View(results);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Results == null)
            {
                return Problem("Entity set 'DragRacing_WebContext.Results'  is null.");
            }
            var results = await _context.Results.FindAsync(id);
            if (results != null)
            {
                _context.Results.Remove(results);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultsExists(int id)
        {
          return (_context.Results?.Any(e => e.Result_ID == id)).GetValueOrDefault();
        }
    }
}
