using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspent.Models;

namespace aspent.Controllers
{
    public class JuridicaController : Controller
    {
        private readonly Context _context;

        public JuridicaController(Context context)
        {
            _context = context;
        }

        // GET: Juridica
        public async Task<IActionResult> Index()
        {
            return View(await _context.Juridica.ToListAsync());
        }

        // GET: Juridica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juridica == null)
            {
                return NotFound();
            }

            return View(juridica);
        }

        // GET: Juridica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juridica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CNPJ,InscricaoEstadual,Fundacao,Id,Nome,Telefone,Endereco")] Juridica juridica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juridica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(juridica);
        }

        // GET: Juridica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridica.FindAsync(id);
            if (juridica == null)
            {
                return NotFound();
            }
            return View(juridica);
        }

        // POST: Juridica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CNPJ,InscricaoEstadual,Fundacao,Id,Nome,Telefone,Endereco")] Juridica juridica)
        {
            if (id != juridica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juridica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuridicaExists(juridica.Id))
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
            return View(juridica);
        }

        // GET: Juridica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juridica == null)
            {
                return NotFound();
            }

            return View(juridica);
        }

        // POST: Juridica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juridica = await _context.Juridica.FindAsync(id);
            _context.Juridica.Remove(juridica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuridicaExists(int id)
        {
            return _context.Juridica.Any(e => e.Id == id);
        }
    }
}
