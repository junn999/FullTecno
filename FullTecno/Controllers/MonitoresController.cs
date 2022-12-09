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
    public class MonitoresController : Controller
    {
        private readonly FullTecnoContext _context;

        public MonitoresController(FullTecnoContext context)
        {
            _context = context;
        }

        // GET: Monitores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monitores.ToListAsync());
        }

        // GET: Monitores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitores = await _context.Monitores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitores == null)
            {
                return NotFound();
            }

            return View(monitores);
        }

        // GET: Monitores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monitores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre_producto,Stock,Price")] Monitores monitores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monitores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monitores);
        }

        // GET: Monitores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitores = await _context.Monitores.FindAsync(id);
            if (monitores == null)
            {
                return NotFound();
            }
            return View(monitores);
        }

        // POST: Monitores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre_producto,Stock,Price")] Monitores monitores)
        {
            if (id != monitores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monitores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonitoresExists(monitores.Id))
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
            return View(monitores);
        }

        // GET: Monitores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitores = await _context.Monitores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitores == null)
            {
                return NotFound();
            }

            return View(monitores);
        }

        // POST: Monitores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monitores = await _context.Monitores.FindAsync(id);
            _context.Monitores.Remove(monitores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonitoresExists(int id)
        {
            return _context.Monitores.Any(e => e.Id == id);
        }
    }
}
