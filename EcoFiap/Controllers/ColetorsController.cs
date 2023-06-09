﻿using System;
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
              return _context.Coletor != null ? 
                          View(await _context.Coletor.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.ColetorModel'  is null.");
        }

        // GET: Coletors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Coletor == null)
            {
                return NotFound();
            }

            var coletorModel = await _context.Coletor
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
            if (id == null || _context.Coletor == null)
            {
                return NotFound();
            }

            var coletorModel = await _context.Coletor.FindAsync(id);
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
            if (id == null || _context.Coletor == null)
            {
                return NotFound();
            }

            var coletorModel = await _context.Coletor
                .FirstOrDefaultAsync(m => m.ColetorId == id);
            if (coletorModel == null)
            {
                return NotFound();
            }

            return View(coletorModel);
        }

        // POST: Coletors/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Coletor == null)
            {
                return Problem("Entity set 'DataBaseContext.ColetorModel'  is null.");
            }
            var coletorModel = await _context.Coletor.FindAsync(id);
            if (coletorModel != null)
            {
                _context.Coletor.Remove(coletorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColetorModelExists(int id)
        {
          return (_context.Coletor?.Any(e => e.ColetorId == id)).GetValueOrDefault();
        }
    }
}
