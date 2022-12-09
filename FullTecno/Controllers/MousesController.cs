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
    public class MousesController : Controller
    {
        private readonly FullTecnoContext _context;

        public MousesController(FullTecnoContext context)
        {
            _context = context;
        }

        // GET: Mouses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mouses.ToListAsync());
        }

        // GET: Mouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Mouses = await _context.Mouses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Mouses == null)
            {
                return NotFound();
            }

            return View(Mouses);
        }

        // GET: Mouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre_producto,Stock,Price")] Mouses Mouses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Mouses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Mouses);
        }

        // GET: Mouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Mouses = await _context.Mouses.FindAsync(id);
            if (Mouses == null)
            {
                return NotFound();
            }
            return View(Mouses);
        }

        // POST: Mouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre_producto,Stock,Price")] Mouses Mouses)
        {
            if (id != Mouses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Mouses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MousesExists(Mouses.Id))
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
            return View(Mouses);
        }

        // GET: Mouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Mouses = await _context.Mouses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Mouses == null)
            {
                return NotFound();
            }

            return View(Mouses);
        }

        // POST: Mouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Mouses = await _context.Mouses.FindAsync(id);
            _context.Mouses.Remove(Mouses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MousesExists(int id)
        {
            return _context.Mouses.Any(e => e.Id == id);
        }
    }
}
