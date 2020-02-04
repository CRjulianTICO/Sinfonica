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
using Sinfonica.Web.Areas.Admin.Data.Repositories;
using Sinfonica.Web.Areas.Admin.Helpers;

namespace Sinfonica.Web.Areas.User.Controllers
{
    
    [Area("User")]
    public class InstitucionsController : Controller
    {
        private readonly DataContext _context;
        private readonly IInsititucionRepository institucionRepository;

        public InstitucionsController(DataContext context, IInsititucionRepository institucionRepository)
        {
            _context = context;
            this.institucionRepository = institucionRepository;
        }




        // GET: Admin/Institucions
        public async Task<IActionResult> Index()
        {
            return View(this.institucionRepository.GetAll());
        }


        // GET: Admin/Institucions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var product = await this.institucionRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(product);
        }




        // GET: Admin/Institucions/Create
        public IActionResult Create()
        {
            return View();
        }






        // POST: Admin/Institucions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Bienvenida,Organizacion,Estudia,Informacion,Mision,Vision,Historia,Instituto")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                await this.institucionRepository.CreateAsync(institucion);
                return RedirectToAction(nameof(Index));
            }
            return View(institucion);
        }




        // GET: Admin/Institucions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucion = await this.institucionRepository.GetByIdAsync(id.Value);
            if (institucion == null)
            {
                return NotFound();
            }
            return View(institucion);
        }






        // POST: Admin/Institucions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bienvenida,Organizacion,Estudia,Informacion,Mision,Vision,Historia,Instituto")] Institucion institucion)
        {
            if (id != institucion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await this.institucionRepository.UpdateAsync(institucion);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.institucionRepository.ExistAsync(institucion.Id))
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

            return View(institucion);
        }



        // GET: Admin/Institucions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.institucionRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }






        // POST: Admin/Institucions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this.institucionRepository.GetByIdAsync(id);
            await this.institucionRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }



        private bool InstitucionExists(int id)
        {
            return _context.Institucions.Any(e => e.Id == id);
        }
    }
}
