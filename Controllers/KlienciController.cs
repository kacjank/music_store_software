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
    public class KlienciController : Controller
    {
        private readonly Sklep_muzycznyContext _context;

        public KlienciController(Sklep_muzycznyContext context)
        {
            _context = context;
        }

        // GET: Klienci
        public async Task<IActionResult> Index()
        {
            var sklep_muzycznyContext = _context.Klient.Include(p => p.Wojewodztwo);
            return View(await _context.Klient.ToListAsync());
        }

        // GET: Klienci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Klient == null)
            {
                return NotFound();
            }

            var klient = await _context.Klient
                .Include(p => p.Wojewodztwo)
                .FirstOrDefaultAsync(m => m.KlientId == id);
            if (klient == null)
            {
                return NotFound();
            }
            ViewData["WojewodztwoId"] = new SelectList(_context.Wojewodztwo, "WojewodztwoId", "Nazwa", klient.WojewodztwoId);
            return View(klient);
        }

        // GET: Klienci/Create
        public IActionResult Create(Wojewodztwo wojewodztwo)
        {
            ViewData["WojewodztwoId"] = new SelectList(_context.Wojewodztwo, "WojewodztwoId", "Nazwa");
            return View();
        }

        // POST: Klienci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlientId,Imie,Nazwisko,Email,WojewodztwoId,Miasto,Adres,DataRejestracji")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WojewodztwoId"] = new SelectList(_context.Wojewodztwo, "WojewodztwoId", "Nazwa", klient.WojewodztwoId);
            return View(klient);
        }

        // GET: Klienci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klient == null)
            {
                return NotFound();
            }

            var klient = await _context.Klient.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            ViewData["WojewodztwoId"] = new SelectList(_context.Wojewodztwo, "WojewodztwoId", "Nazwa", klient.WojewodztwoId);
            return View(klient);
        }

        // POST: Klienci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlientId,Imie,Nazwisko,Email,WojewodztwoId,Miasto,Adres,DataRejestracji")] Klient klient)
        {
            if (id != klient.KlientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.KlientId))
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
            ViewData["WojewodztwoId"] = new SelectList(_context.Wojewodztwo, "WojewodztwoId", "Nazwa", klient.WojewodztwoId);
            return View(klient);
        }

        // GET: Klienci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klient == null)
            {
                return NotFound();
            }

            var klient = await _context.Klient
                .Include(p => p.Wojewodztwo)
                .FirstOrDefaultAsync(m => m.KlientId == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // POST: Klienci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klient == null)
            {
                return Problem("Entity set 'Sklep_muzycznyContext.Klient'  is null.");
            }
            var klient = await _context.Klient.FindAsync(id);
            if (klient != null)
            {
                _context.Klient.Remove(klient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientExists(int id)
        {
          return _context.Klient.Any(e => e.KlientId == id);
        }
    }
}
