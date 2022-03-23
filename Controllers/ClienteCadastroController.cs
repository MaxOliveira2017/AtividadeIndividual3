using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtvidadeModuloTres.Models;

namespace AtvidadeModuloTres.Controllers
{
    public class ClienteCadastroController : Controller
    {
        private readonly Context _context;

        public ClienteCadastroController(Context context)
        {
            _context = context;
        }

        // GET: ClienteCadastro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientecadastro.ToListAsync());
        }

        // GET: ClienteCadastro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteCadastro = await _context.Clientecadastro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteCadastro == null)
            {
                return NotFound();
            }

            return View(clienteCadastro);
        }

        // GET: ClienteCadastro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteCadastro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CPF,Endereco")] ClienteCadastro clienteCadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteCadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteCadastro);
        }

        // GET: ClienteCadastro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteCadastro = await _context.Clientecadastro.FindAsync(id);
            if (clienteCadastro == null)
            {
                return NotFound();
            }
            return View(clienteCadastro);
        }

        // POST: ClienteCadastro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CPF,Endereco")] ClienteCadastro clienteCadastro)
        {
            if (id != clienteCadastro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteCadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteCadastroExists(clienteCadastro.Id))
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
            return View(clienteCadastro);
        }

        // GET: ClienteCadastro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteCadastro = await _context.Clientecadastro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteCadastro == null)
            {
                return NotFound();
            }

            return View(clienteCadastro);
        }

        // POST: ClienteCadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteCadastro = await _context.Clientecadastro.FindAsync(id);
            _context.Clientecadastro.Remove(clienteCadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteCadastroExists(int id)
        {
            return _context.Clientecadastro.Any(e => e.Id == id);
        }
    }
}
