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
    public class KategorieController : Controller
    {
        private readonly Sklep_muzycznyContext _context;

        public KategorieController(Sklep_muzycznyContext context)
        {
            _context = context;
        }

        // GET: Kategorie
        public async Task<IActionResult> Index()
        {
              return View(await _context.Kategoria.ToListAsync());
        }

        // GET: Kategorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kategoria == null)
            {
                return NotFound();
            }

            var kategoria = await _context.Kategoria
                .FirstOrDefaultAsync(m => m.KategoriaId == id);
            if (kategoria == null)
            {
                return NotFound();
            }

            return View(kategoria);
        }

        // GET: Kategorie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriaId,Nazwa")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoria);
        }

        // GET: Kategorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kategoria == null)
            {
                return NotFound();
            }

            var kategoria = await _context.Kategoria.FindAsync(id);
            if (kategoria == null)
            {
                return NotFound();
            }
            return View(kategoria);
        }

        // POST: Kategorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KategoriaId,Nazwa")] Kategoria kategoria)
        {
            if (id != kategoria.KategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriaExists(kategoria.KategoriaId))
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
            return View(kategoria);
        }

        // GET: Kategorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kategoria == null)
            {
                return NotFound();
            }

            var kategoria = await _context.Kategoria
                .FirstOrDefaultAsync(m => m.KategoriaId == id);
            if (kategoria == null)
            {
                return NotFound();
            }

            return View(kategoria);
        }

        // POST: Kategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kategoria == null)
            {
                return Problem("Entity set 'Sklep_muzycznyContext.Kategoria'  is null.");
            }
            var kategoria = await _context.Kategoria.FindAsync(id);
            if (kategoria != null)
            {
                _context.Kategoria.Remove(kategoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriaExists(int id)
        {
          return _context.Kategoria.Any(e => e.KategoriaId == id);
        }
    }
}
