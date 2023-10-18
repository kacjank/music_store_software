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
    public class ProduktyController : Controller
    {
        private readonly Sklep_muzycznyContext _context;

        public ProduktyController(Sklep_muzycznyContext context)
        {
            _context = context;
        }

        // GET: Produkty
        public async Task<IActionResult> Index()
        {
            var sklep_muzycznyContext = _context.Produkt.Include(p => p.Kategoria).Include(p => p.Podkategoria).Include(p => p.Producent);
            return View(await sklep_muzycznyContext.ToListAsync());
        }

        // GET: Produkty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produkt == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt
                .Include(p => p.Kategoria)
                .Include(p => p.Podkategoria)
                .Include(p => p.Producent)
                .FirstOrDefaultAsync(m => m.ProduktId == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // GET: Produkty/Create
        public IActionResult Create()
        {
            ViewData["KategoriaId"] = new SelectList(_context.Set<Kategoria>(), "KategoriaId", "Nazwa");
            ViewData["PodkategoriaId"] = new SelectList(_context.Set<Podkategoria>(), "PodkategoriaId", "Nazwa");
            ViewData["ProducentId"] = new SelectList(_context.Set<Producent>(), "ProducentId", "Nazwa");
            return View();
        }

        // POST: Produkty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduktId,ProducentId,Model,KategoriaId,PodkategoriaId,DataProdukcji,Cena")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriaId"] = new SelectList(_context.Set<Kategoria>(), "KategoriaId", "Nazwa", produkt.KategoriaId);
            ViewData["PodkategoriaId"] = new SelectList(_context.Set<Podkategoria>(), "PodkategoriaId", "Nazwa", produkt.PodkategoriaId);
            ViewData["ProducentId"] = new SelectList(_context.Set<Producent>(), "ProducentId", "Nazwa", produkt.ProducentId);
            return View(produkt);
        }

        // GET: Produkty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produkt == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }
            ViewData["KategoriaId"] = new SelectList(_context.Set<Kategoria>(), "KategoriaId", "Nazwa", produkt.KategoriaId);
            ViewData["PodkategoriaId"] = new SelectList(_context.Set<Podkategoria>(), "PodkategoriaId", "Nazwa", produkt.PodkategoriaId);
            ViewData["ProducentId"] = new SelectList(_context.Set<Producent>(), "ProducentId", "Nazwa", produkt.ProducentId);
            return View(produkt);
        }

        // POST: Produkty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProduktId,ProducentId,Model,KategoriaId,PodkategoriaId,DataProdukcji,Cena")] Produkt produkt)
        {
            if (id != produkt.ProduktId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktExists(produkt.ProduktId))
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
            ViewData["KategoriaId"] = new SelectList(_context.Set<Kategoria>(), "KategoriaId", "Nazwa", produkt.KategoriaId);
            ViewData["PodkategoriaId"] = new SelectList(_context.Set<Podkategoria>(), "PodkategoriaId", "Nazwa", produkt.PodkategoriaId);
            ViewData["ProducentId"] = new SelectList(_context.Set<Producent>(), "ProducentId", "Nazwa", produkt.ProducentId);
            return View(produkt);
        }

        // GET: Produkty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produkt == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt
                .Include(p => p.Kategoria)
                .Include(p => p.Podkategoria)
                .Include(p => p.Producent)
                .FirstOrDefaultAsync(m => m.ProduktId == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // POST: Produkty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produkt == null)
            {
                return Problem("Entity set 'Sklep_muzycznyContext.Produkt'  is null.");
            }
            var produkt = await _context.Produkt.FindAsync(id);
            if (produkt != null)
            {
                _context.Produkt.Remove(produkt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktExists(int id)
        {
          return _context.Produkt.Any(e => e.ProduktId == id);
        }
    }
}
