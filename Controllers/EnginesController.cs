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
    public class EnginesController : Controller
    {
        private readonly DragRacing_WebContext _context;

        public EnginesController(DragRacing_WebContext context)
        {
            _context = context;
        }

        // GET: Engines
        public async Task<IActionResult> Index()
        {
              return _context.Engines != null ? 
                          View(await _context.Engines.ToListAsync()) :
                          Problem("Entity set 'DragRacing_WebContext.Engines'  is null.");
        }

        // GET: Engines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Engines == null)
            {
                return NotFound();
            }

            var engines = await _context.Engines
                .FirstOrDefaultAsync(m => m.Engine_ID == id);
            if (engines == null)
            {
                return NotFound();
            }

            return View(engines);
        }

        // GET: Engines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Engines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Engine_ID,Engine_Type,Stock,N_A,Fuel_Type,Tune")] Engines engines)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(engines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engines);
        }

        // GET: Engines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Engines == null)
            {
                return NotFound();
            }

            var engines = await _context.Engines.FindAsync(id);
            if (engines == null)
            {
                return NotFound();
            }
            return View(engines);
        }

        // POST: Engines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Engine_ID,Engine_Type,Stock,N_A,Fuel_Type,Tune")] Engines engines)
        {
            if (id != engines.Engine_ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(engines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnginesExists(engines.Engine_ID))
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
            return View(engines);
        }

        // GET: Engines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Engines == null)
            {
                return NotFound();
            }

            var engines = await _context.Engines
                .FirstOrDefaultAsync(m => m.Engine_ID == id);
            if (engines == null)
            {
                return NotFound();
            }

            return View(engines);
        }

        // POST: Engines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Engines == null)
            {
                return Problem("Entity set 'DragRacing_WebContext.Engines'  is null.");
            }
            var engines = await _context.Engines.FindAsync(id);
            if (engines != null)
            {
                _context.Engines.Remove(engines);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnginesExists(int id)
        {
          return (_context.Engines?.Any(e => e.Engine_ID == id)).GetValueOrDefault();
        }
    }
}
