using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class LocalesController : Controller
    {
        private readonly DbCrudContext _context;

        public LocalesController(DbCrudContext context)
        {
            _context = context;
        }

        // GET: Locales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locales.ToListAsync());
        }

        // GET: Locales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locale = await _context.Locales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locale == null)
            {
                return NotFound();
            }

            return View(locale);
        }

        // GET: Locales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreDelLocal,Direccion,NumeroDeTelefono")] Locale locale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locale);
        }

        // GET: Locales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locale = await _context.Locales.FindAsync(id);
            if (locale == null)
            {
                return NotFound();
            }
            return View(locale);
        }

        // POST: Locales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreDelLocal,Direccion,NumeroDeTelefono")] Locale locale)
        {
            if (id != locale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocaleExists(locale.Id))
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
            return View(locale);
        }

        // GET: Locales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locale = await _context.Locales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locale == null)
            {
                return NotFound();
            }

            return View(locale);
        }

        // POST: Locales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locale = await _context.Locales.FindAsync(id);
            if (locale != null)
            {
                _context.Locales.Remove(locale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocaleExists(int id)
        {
            return _context.Locales.Any(e => e.Id == id);
        }
    }
}
