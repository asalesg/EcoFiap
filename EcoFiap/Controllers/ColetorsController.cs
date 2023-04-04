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
    public class ColetorsController : Controller
    {
        private readonly DataBaseContext _context;

        public ColetorsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Coletors
        public async Task<IActionResult> Index()
        {
              return _context.ColetorModel != null ? 
                          View(await _context.ColetorModel.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.ColetorModel'  is null.");
        }

        // GET: Coletors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ColetorModel == null)
            {
                return NotFound();
            }

            var coletorModel = await _context.ColetorModel
                .FirstOrDefaultAsync(m => m.ColetorId == id);
            if (coletorModel == null)
            {
                return NotFound();
            }

            return View(coletorModel);
        }

        // GET: Coletors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coletors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColetorId,Nome,Endereco,email,Telefone")] ColetorModel coletorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coletorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coletorModel);
        }

        // GET: Coletors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ColetorModel == null)
            {
                return NotFound();
            }

            var coletorModel = await _context.ColetorModel.FindAsync(id);
            if (coletorModel == null)
            {
                return NotFound();
            }
            return View(coletorModel);
        }

        // POST: Coletors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColetorId,Nome,Endereco,email,Telefone")] ColetorModel coletorModel)
        {
            if (id != coletorModel.ColetorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coletorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColetorModelExists(coletorModel.ColetorId))
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
            return View(coletorModel);
        }

        // GET: Coletors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ColetorModel == null)
            {
                return NotFound();
            }

            var coletorModel = await _context.ColetorModel
                .FirstOrDefaultAsync(m => m.ColetorId == id);
            if (coletorModel == null)
            {
                return NotFound();
            }

            return View(coletorModel);
        }

        // POST: Coletors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ColetorModel == null)
            {
                return Problem("Entity set 'DataBaseContext.ColetorModel'  is null.");
            }
            var coletorModel = await _context.ColetorModel.FindAsync(id);
            if (coletorModel != null)
            {
                _context.ColetorModel.Remove(coletorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColetorModelExists(int id)
        {
          return (_context.ColetorModel?.Any(e => e.ColetorId == id)).GetValueOrDefault();
        }
    }
}
