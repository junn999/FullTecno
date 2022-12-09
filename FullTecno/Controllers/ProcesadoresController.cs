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
    public class ProcesadoresController : Controller
    {
        private readonly FullTecnoContext _context;

        public  ProcesadoresController(FullTecnoContext context)
        {
            _context = context;
        }

        // GET:  Procesadores
        public async Task<IActionResult> Index()
        {
            return View(await _context. Procesadores.ToListAsync());
        }

        // GET:  Procesadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var  Procesadores = await _context. Procesadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if ( Procesadores == null)
            {
                return NotFound();
            }

            return View( Procesadores);
        }

        // GET:  Procesadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST:  Procesadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre_producto,Stock,Price")]  Procesadores  Procesadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add( Procesadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View( Procesadores);
        }

        // GET:  Procesadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var  Procesadores= await _context. Procesadores.FindAsync(id);
            if ( Procesadores == null)
            {
                return NotFound();
            }
            return View( Procesadores);
        }

        // POST:  Procesadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre_producto,Stock,Price")]  Procesadores  Procesadores)
        {
            if (id !=  Procesadores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update( Procesadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! ProcesadoresExists( Procesadores.Id))
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
            return View( Procesadores);
        }

        // GET:  Procesadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var  Procesadores = await _context. Procesadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if ( Procesadores == null)
            {
                return NotFound();
            }

            return View( Procesadores);
        }

        // POST: Procesadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var  Procesadores = await _context. Procesadores.FindAsync(id);
            _context. Procesadores.Remove( Procesadores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool  ProcesadoresExists(int id)
        {
            return _context. Procesadores.Any(e => e.Id == id);
        }
    }
}
