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
    public class TarjetasGraficasController : Controller
    {
        private readonly FullTecnoContext _context;

        public  TarjetasGraficasController(FullTecnoContext context)
        {
            _context = context;
        }

        // GET:  TarjetasGraficas
        public async Task<IActionResult> Index()
        {
            return View(await _context. TarjetasGraficas.ToListAsync());
        }

        // GET:  TarjetasGraficas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TarjetasGraficas = await _context. TarjetasGraficas
                .FirstOrDefaultAsync(m => m.Id == id);
            if ( TarjetasGraficas == null)
            {
                return NotFound();
            }

            return View( TarjetasGraficas);
        }

        // GET:  TarjetasGraficas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST:  TarjetasGraficas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre_producto,Stock,Price")]  TarjetasGraficas  TarjetasGraficas)
        {
            if (ModelState.IsValid)
            {
                _context.Add( TarjetasGraficas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View( TarjetasGraficas);
        }

        // GET:   TarjetasGraficas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var  TarjetasGraficas= await _context. TarjetasGraficas.FindAsync(id);
            if ( TarjetasGraficas == null)
            {
                return NotFound();
            }
            return View( TarjetasGraficas);
        }

        // POST:  TarjetasGraficas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre_producto,Stock,Price")]  TarjetasGraficas  TarjetasGraficas)
        {
            if (id !=  TarjetasGraficas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update( TarjetasGraficas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! TarjetasGraficasExists( TarjetasGraficas.Id))
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
            return View( TarjetasGraficas);
        }

        // GET:  TarjetasGraficas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var  TarjetasGraficas = await _context. TarjetasGraficas
                .FirstOrDefaultAsync(m => m.Id == id);
            if ( TarjetasGraficas == null)
            {
                return NotFound();
            }

            return View( TarjetasGraficas);
        }

        // POST: TarjetasGraficas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var  TarjetasGraficas = await _context. TarjetasGraficas.FindAsync(id);
            _context. TarjetasGraficas.Remove( TarjetasGraficas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool  TarjetasGraficasExists(int id)
        {
            return _context. TarjetasGraficas.Any(e => e.Id == id);
        }
    }
}
