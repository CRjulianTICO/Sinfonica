using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinfonica.Web.Areas.Admin.Data;
using Sinfonica.Web.Areas.Admin.Data.Entities;

namespace Sinfonica.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AcontecersController : Controller
    {
        private readonly DataContext _context;

        public AcontecersController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Acontecers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Acontecers.ToListAsync());
        }

        // GET: Admin/Acontecers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acontecer = await _context.Acontecers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acontecer == null)
            {
                return NotFound();
            }

            return View(acontecer);
        }

        // GET: Admin/Acontecers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Acontecers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Encabezado,Informacion,Descripcion,Lugar,Fecha,Estado,ImageUrl")] Acontecer acontecer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acontecer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acontecer);
        }

        // GET: Admin/Acontecers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acontecer = await _context.Acontecers.FindAsync(id);
            if (acontecer == null)
            {
                return NotFound();
            }
            return View(acontecer);
        }

        // POST: Admin/Acontecers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Encabezado,Informacion,Descripcion,Lugar,Fecha,Estado,ImageUrl")] Acontecer acontecer)
        {
            if (id != acontecer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acontecer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcontecerExists(acontecer.Id))
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
            return View(acontecer);
        }

        // GET: Admin/Acontecers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acontecer = await _context.Acontecers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acontecer == null)
            {
                return NotFound();
            }

            return View(acontecer);
        }

        // POST: Admin/Acontecers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acontecer = await _context.Acontecers.FindAsync(id);
            _context.Acontecers.Remove(acontecer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcontecerExists(int id)
        {
            return _context.Acontecers.Any(e => e.Id == id);
        }
    }
}
