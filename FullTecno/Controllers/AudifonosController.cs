using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullTecno.Data;
using FullTecno.Models;

namespace FullTecno.Controllers
{
    public class AudifonosController : Controller
    {
        private readonly FullTecnoContext _context;

        public AudifonosController(FullTecnoContext context)
        {
            _context = context;
        }

        // GET: Audifonos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Audifonos.ToListAsync());
        }

        // GET: Audifonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audifonos = await _context.Audifonos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audifonos == null)
            {
                return NotFound();
            }

            return View(audifonos);
        }

        // GET: Audifonos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Audifonos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre_producto,Stock,Price")] Audifonos audifonos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audifonos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audifonos);
        }

        // GET: Audifonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audifonos = await _context.Audifonos.FindAsync(id);
            if (audifonos == null)
            {
                return NotFound();
            }
            return View(audifonos);
        }

        // POST: Audifonos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre_producto,Stock,Price")] Audifonos audifonos)
        {
            if (id != audifonos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audifonos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudifonosExists(audifonos.Id))
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
            return View(audifonos);
        }

        // GET: Audifonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audifonos = await _context.Audifonos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audifonos == null)
            {
                return NotFound();
            }

            return View(audifonos);
        }

        // POST: Audifonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var audifonos = await _context.Audifonos.FindAsync(id);
            _context.Audifonos.Remove(audifonos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AudifonosExists(int id)
        {
            return _context.Audifonos.Any(e => e.Id == id);
        }
    }
}
