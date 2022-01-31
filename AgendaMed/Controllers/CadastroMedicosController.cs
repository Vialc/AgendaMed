#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaMed.Models;

namespace AgendaMed.Controllers
{
    public class CadastroMedicosController : Controller
    {
        private readonly AgendaMedContext _context;

        public CadastroMedicosController(AgendaMedContext context)
        {
            _context = context;
        }

        // GET: CadastroMedicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroMedicos.ToListAsync());
        }

        // GET: CadastroMedicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroMedicos = await _context.CadastroMedicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroMedicos == null)
            {
                return NotFound();
            }

            return View(cadastroMedicos);
        }

        // GET: CadastroMedicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroMedicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CRM")] CadastroMedicos cadastroMedicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroMedicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroMedicos);
        }

        // GET: CadastroMedicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroMedicos = await _context.CadastroMedicos.FindAsync(id);
            if (cadastroMedicos == null)
            {
                return NotFound();
            }
            return View(cadastroMedicos);
        }

        // POST: CadastroMedicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CRM")] CadastroMedicos cadastroMedicos)
        {
            if (id != cadastroMedicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroMedicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroMedicosExists(cadastroMedicos.Id))
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
            return View(cadastroMedicos);
        }

        // GET: CadastroMedicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroMedicos = await _context.CadastroMedicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroMedicos == null)
            {
                return NotFound();
            }

            return View(cadastroMedicos);
        }

        // POST: CadastroMedicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroMedicos = await _context.CadastroMedicos.FindAsync(id);
            _context.CadastroMedicos.Remove(cadastroMedicos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroMedicosExists(int id)
        {
            return _context.CadastroMedicos.Any(e => e.Id == id);
        }
    }
}
