using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcoFiap.Models;
using EcoFiap.Repository.Context;

namespace EcoFiap.Controllers
{
    public class ColetaController : Controller
    {
        private readonly DataBaseContext _context;

        public ColetaController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Coleta
        public async Task<IActionResult> Index()
        {
              return _context.Coleta != null ? 
                          View(await _context.Coleta.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.Coleta'  is null.");
        }

        // GET: Coleta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Coleta == null)
            {
                return NotFound();
            }

            var coletaModel = await _context.Coleta
                .FirstOrDefaultAsync(m => m.ColetaId == id);
            if (coletaModel == null)
            {
                return NotFound();
            }

            return View(coletaModel);
        }

        // GET: Coleta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coleta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColetaId,Tipo,DataHoraAgendada,Endereco")] ColetaModel coletaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coletaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coletaModel);
        }

        // GET: Coleta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Coleta == null)
            {
                return NotFound();
            }

            var coletaModel = await _context.Coleta.FindAsync(id);
            if (coletaModel == null)
            {
                return NotFound();
            }
            return View(coletaModel);
        }

        // POST: Coleta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColetaId,Tipo,DataHoraAgendada,Endereco")] ColetaModel coletaModel)
        {
            if (id != coletaModel.ColetaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coletaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColetaModelExists(coletaModel.ColetaId))
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
            return View(coletaModel);
        }

        // GET: Coleta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Coleta == null)
            {
                return NotFound();
            }

            var coletaModel = await _context.Coleta
                .FirstOrDefaultAsync(m => m.ColetaId == id);
            if (coletaModel == null)
            {
                return NotFound();
            }

            return View(coletaModel);
        }

        // POST: Coleta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Coleta == null)
            {
                return Problem("Entity set 'DataBaseContext.Coleta'  is null.");
            }
            var coletaModel = await _context.Coleta.FindAsync(id);
            if (coletaModel != null)
            {
                _context.Coleta.Remove(coletaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColetaModelExists(int id)
        {
          return (_context.Coleta?.Any(e => e.ColetaId == id)).GetValueOrDefault();
        }
    }
}
