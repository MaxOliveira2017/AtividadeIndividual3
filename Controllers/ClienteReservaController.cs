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
    public class ClienteReservaController : Controller
    {
        private readonly Context _context;

        public ClienteReservaController(Context context)
        {
            _context = context;
        }

        // GET: ClienteReserva
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientereserva.ToListAsync());
        }

        // GET: ClienteReserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteReserva = await _context.Clientereserva
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteReserva == null)
            {
                return NotFound();
            }

            return View(clienteReserva);
        }

        // GET: ClienteReserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteReserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cliente,Destino,Data,Teletone")] ClienteReserva clienteReserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteReserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteReserva);
        }

        // GET: ClienteReserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteReserva = await _context.Clientereserva.FindAsync(id);
            if (clienteReserva == null)
            {
                return NotFound();
            }
            return View(clienteReserva);
        }

        // POST: ClienteReserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cliente,Destino,Data,Teletone")] ClienteReserva clienteReserva)
        {
            if (id != clienteReserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteReserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteReservaExists(clienteReserva.Id))
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
            return View(clienteReserva);
        }

        // GET: ClienteReserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteReserva = await _context.Clientereserva
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteReserva == null)
            {
                return NotFound();
            }

            return View(clienteReserva);
        }

        // POST: ClienteReserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteReserva = await _context.Clientereserva.FindAsync(id);
            _context.Clientereserva.Remove(clienteReserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteReservaExists(int id)
        {
            return _context.Clientereserva.Any(e => e.Id == id);
        }
    }
}
