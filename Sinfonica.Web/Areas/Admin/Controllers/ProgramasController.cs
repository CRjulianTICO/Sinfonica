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
using Sinfonica.Web.Areas.Admin.Helpers;

namespace Sinfonica.Web.Areas.Admin.Data.Repositories
{

    [Authorize]
    [Area("Admin")]
    public class ProgramasController : Controller
    {
        private readonly DataContext _context;
        private readonly IProgramaRepository programaRepository;

        public ProgramasController(DataContext context,IProgramaRepository programaRepository)
        {
            _context = context;
            this.programaRepository = programaRepository;
        }

        // GET: Admin/Programas
        public async Task<IActionResult> Index()
        {

            var view = from progra in this.programaRepository.GetAll() where progra.Estado == true select progra;
            return View(view.OrderBy(a => a.Nombre));
        }

        // GET: Admin/Programas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProgramaNotFound");
            }

            var product = await this.programaRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return new NotFoundViewResult("ProgramaNotFound");
            }

            return View(product);
        }





        // GET: Admin/Programas/Create
        public IActionResult Create()
        {
            return View();
        }





        // POST: Admin/Programas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Informacion,Estado")] Programa programa)
        {
            if (ModelState.IsValid)
            {
                await this.programaRepository.CreateAsync(programa);
                return RedirectToAction(nameof(Index));
            }
            return View(programa);
        }





        // GET: Admin/Programas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProgramaNotFound");
            }

            var programa = await this.programaRepository.GetByIdAsync(id.Value);
            if (programa == null)
            {
                return new NotFoundViewResult("ProgramaNotFound");
            }
            return View(programa);
        }






        // POST: Admin/Programas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Informacion,Estado")] Programa programa)
        {
            if (id != programa.Id)
            {
                return new NotFoundViewResult("ProgramaNotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await this.programaRepository.UpdateAsync(programa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.programaRepository.ExistAsync(programa.Id))
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

            return View(programa);
        }




        // GET: Admin/Programas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProgramaNotFound");
            }

            var product = await this.programaRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }






        // POST: Admin/Programas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this.programaRepository.GetByIdAsync(id);

            product.Estado = false;
            await this.programaRepository.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaExists(int id)
        {
            return _context.Programas.Any(e => e.Id == id);
        }


    }
}
