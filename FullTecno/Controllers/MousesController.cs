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

            var mouses = await _context.Mouses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mouses == null)
            {
                return NotFound();
            }

            return View(mouses);
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
        public async Task<IActionResult> Create([Bind("Id,Nombre_producto,Stock,Price")] Mouses mouses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mouses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mouses);
        }

        // GET: Mouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouses = await _context.Mouses.FindAsync(id);
            if (mouses == null)
            {
                return NotFound();
            }
            return View(mouses);
        }

        // POST: Mouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre_producto,Stock,Price")] Mouses mouses)
        {
            if (id != mouses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mouses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MousesExists(mouses.Id))
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
            return View(mouses);
        }

        // GET: Mouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouses = await _context.Mouses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mouses == null)
            {
                return NotFound();
            }

            return View(mouses);
        }

        // POST: Mouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mouses = await _context.Mouses.FindAsync(id);
            _context.Mouses.Remove(mouses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MousesExists(int id)
        {
            return _context.Mouses.Any(e => e.Id == id);
        }
    }
}
