using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sklep_muzyczny.Data;
using Sklep_muzyczny.Models;

namespace Sklep_muzyczny.Controllers
{
    public class WojewodztwaController : Controller
    {
        private readonly Sklep_muzycznyContext _context;

        public WojewodztwaController(Sklep_muzycznyContext context)
        {
            _context = context;
        }

        // GET: Wojewodztwa
        public async Task<IActionResult> Index()
        {
              return View(await _context.Wojewodztwo.ToListAsync());
        }

        // GET: Wojewodztwa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wojewodztwo == null)
            {
                return NotFound();
            }

            var wojewodztwo = await _context.Wojewodztwo
                .FirstOrDefaultAsync(m => m.WojewodztwoId == id);
            if (wojewodztwo == null)
            {
                return NotFound();
            }

            return View(wojewodztwo);
        }

        // GET: Wojewodztwa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wojewodztwa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WojewodztwoId,Nazwa")] Wojewodztwo wojewodztwo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wojewodztwo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wojewodztwo);
        }

        // GET: Wojewodztwa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wojewodztwo == null)
            {
                return NotFound();
            }

            var wojewodztwo = await _context.Wojewodztwo.FindAsync(id);
            if (wojewodztwo == null)
            {
                return NotFound();
            }
            return View(wojewodztwo);
        }

        // POST: Wojewodztwa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WojewodztwoId,Nazwa")] Wojewodztwo wojewodztwo)
        {
            if (id != wojewodztwo.WojewodztwoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wojewodztwo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WojewodztwoExists(wojewodztwo.WojewodztwoId))
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
            return View(wojewodztwo);
        }

        // GET: Wojewodztwa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wojewodztwo == null)
            {
                return NotFound();
            }

            var wojewodztwo = await _context.Wojewodztwo
                .FirstOrDefaultAsync(m => m.WojewodztwoId == id);
            if (wojewodztwo == null)
            {
                return NotFound();
            }

            return View(wojewodztwo);
        }

        // POST: Wojewodztwa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wojewodztwo == null)
            {
                return Problem("Entity set 'Sklep_muzycznyContext.Wojewodztwo'  is null.");
            }
            var wojewodztwo = await _context.Wojewodztwo.FindAsync(id);
            if (wojewodztwo != null)
            {
                _context.Wojewodztwo.Remove(wojewodztwo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WojewodztwoExists(int id)
        {
          return _context.Wojewodztwo.Any(e => e.WojewodztwoId == id);
        }
    }
}
