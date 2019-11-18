using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinfonica.Web.Areas.Admin.Data;
using Sinfonica.Web.Areas.Admin.Data.Entities;

namespace Sinfonica.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BecasController : Controller
    {
        private readonly DataContext _context;

        public BecasController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Becas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Becas.ToListAsync());
        }

        // GET: Admin/Becas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beca = await _context.Becas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beca == null)
            {
                return NotFound();
            }

            return View(beca);
        }

        // GET: Admin/Becas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Becas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Requisitos,Informacion")] Beca beca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beca);
        }

        // GET: Admin/Becas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beca = await _context.Becas.FindAsync(id);
            if (beca == null)
            {
                return NotFound();
            }
            return View(beca);
        }

        // POST: Admin/Becas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Requisitos,Informacion")] Beca beca)
        {
            if (id != beca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BecaExists(beca.Id))
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
            return View(beca);
        }

        // GET: Admin/Becas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beca = await _context.Becas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beca == null)
            {
                return NotFound();
            }

            return View(beca);
        }

        // POST: Admin/Becas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beca = await _context.Becas.FindAsync(id);
            _context.Becas.Remove(beca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BecaExists(int id)
        {
            return _context.Becas.Any(e => e.Id == id);
        }
    }
}
