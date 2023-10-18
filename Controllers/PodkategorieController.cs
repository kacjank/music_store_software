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
    public class PodkategorieController : Controller
    {
        private readonly Sklep_muzycznyContext _context;

        public PodkategorieController(Sklep_muzycznyContext context)
        {
            _context = context;
        }

        // GET: Podkategorie
        public async Task<IActionResult> Index()
        {
            var sklep_muzycznyContext = _context.Podkategoria.Include(p => p.Kategoria);
            return View(await sklep_muzycznyContext.ToListAsync());
        }

        // GET: Podkategorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Podkategoria == null)
            {
                return NotFound();
            }

            var podkategoria = await _context.Podkategoria
                .Include(p => p.Kategoria)
                .FirstOrDefaultAsync(m => m.PodkategoriaId == id);
            if (podkategoria == null)
            {
                return NotFound();
            }
            ViewData["KategoriaId"] = new SelectList(_context.Kategoria, "KategoriaId", "Nazwa", podkategoria.KategoriaId);
            return View(podkategoria);
        }

        // GET: Podkategorie/Create
        public IActionResult Create()
        {
            ViewData["KategoriaId"] = new SelectList(_context.Kategoria, "KategoriaId", "Nazwa");
            return View();
        }

        // POST: Podkategorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriaId,PodkategoriaId,Nazwa")] Podkategoria podkategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podkategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriaId"] = new SelectList(_context.Kategoria, "KategoriaId", "Nazwa", podkategoria.KategoriaId);
            return View(podkategoria);
        }

        // GET: Podkategorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Podkategoria == null)
            {
                return NotFound();
            }

            var podkategoria = await _context.Podkategoria.FindAsync(id);
            if (podkategoria == null)
            {
                return NotFound();
            }
            ViewData["KategoriaId"] = new SelectList(_context.Kategoria, "KategoriaId", "Nazwa", podkategoria.KategoriaId);
            return View(podkategoria);
        }

        // POST: Podkategorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nazwa,PodkategoriaId,Nazwa")] Podkategoria podkategoria)
        {
            if (id != podkategoria.PodkategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podkategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodkategoriaExists(podkategoria.PodkategoriaId))
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
            ViewData["KategoriaId"] = new SelectList(_context.Kategoria, "KategoriaId", "Nazwa", podkategoria.KategoriaId);
            return View(podkategoria);
        }

        // GET: Podkategorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Podkategoria == null)
            {
                return NotFound();
            }

            var podkategoria = await _context.Podkategoria
                .Include(p => p.Kategoria)
                .FirstOrDefaultAsync(m => m.PodkategoriaId == id);
            if (podkategoria == null)
            {
                return NotFound();
            }

            return View(podkategoria);
        }

        // POST: Podkategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Podkategoria == null)
            {
                return Problem("Entity set 'Sklep_muzycznyContext.Podkategoria'  is null.");
            }
            var podkategoria = await _context.Podkategoria.FindAsync(id);
            if (podkategoria != null)
            {
                _context.Podkategoria.Remove(podkategoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodkategoriaExists(int id)
        {
          return _context.Podkategoria.Any(e => e.PodkategoriaId == id);
        }
    }
}
