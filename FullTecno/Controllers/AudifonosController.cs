using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullTecno.Data;
using FullTecno.Models;

namespace Audifonos.Controllers
{
    public class AudifonosController : Controller
    {
        private readonly FullTecnoContext _context;

        public AudifonosController(FullTecnoContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Audifonos.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Audifonos = await _context.Audifonos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Audifonos == null)
            {
                return NotFound();
            }

            return View(Audifonos);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Stock,Price")] Audifonos Audifonos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Audifonos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Audifonos);
        }

        // GET: Audifonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Audifonos = await _context.Audifonos.FindAsync(id);
            if (Audifonos == null)
            {
                return NotFound();
            }
            return View(Audifonos);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre_producto,Stock,Price")] Audifonos Audifonos)
        {
            if (id != Audifonos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Audifonos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudifonosExists(Audifonos.Id))
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
            return View(Audifonos);
        }

        // GET: Audifonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Audifonos = await _context.Audifonos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Audifonos == null)
            {
                return NotFound();
            }

            return View(Audifonos);
        }

        // POST: Audifonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Audifonos = await _context.Audifonos.FindAsync(id);
            _context.Audifonos.Remove(Audifonos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Audifonos.Any(e => e.Id == id);
        }
    }
}