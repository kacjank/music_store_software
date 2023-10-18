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
    public class ProducenciController : Controller
    {
        private readonly Sklep_muzycznyContext _context;

        public ProducenciController(Sklep_muzycznyContext context)
        {
            _context = context;
        }

        // GET: Producenci
        public async Task<IActionResult> Index()
        {
              return View(await _context.Producent.ToListAsync());
        }

        // GET: Producenci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Producent == null)
            {
                return NotFound();
            }

            var producent = await _context.Producent
                .FirstOrDefaultAsync(m => m.ProducentId == id);
            if (producent == null)
            {
                return NotFound();
            }

            return View(producent);
        }

        // GET: Producenci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producenci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProducentId,Nazwa,Kraj,RokZalozenia")] Producent producent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producent);
        }

        // GET: Producenci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Producent == null)
            {
                return NotFound();
            }

            var producent = await _context.Producent.FindAsync(id);
            if (producent == null)
            {
                return NotFound();
            }
            return View(producent);
        }

        // POST: Producenci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProducentId,Nazwa,Kraj,RokZalozenia")] Producent producent)
        {
            if (id != producent.ProducentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducentExists(producent.ProducentId))
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
            return View(producent);
        }

        // GET: Producenci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Producent == null)
            {
                return NotFound();
            }

            var producent = await _context.Producent
                .FirstOrDefaultAsync(m => m.ProducentId == id);
            if (producent == null)
            {
                return NotFound();
            }

            return View(producent);
        }

        // POST: Producenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Producent == null)
            {
                return Problem("Entity set 'Sklep_muzycznyContext.Producent'  is null.");
            }
            var producent = await _context.Producent.FindAsync(id);
            if (producent != null)
            {
                _context.Producent.Remove(producent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducentExists(int id)
        {
          return _context.Producent.Any(e => e.ProducentId == id);
        }
    }
}
