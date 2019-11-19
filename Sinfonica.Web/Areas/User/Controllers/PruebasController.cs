using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinfonica.Web.Areas.Admin.Data;
using Sinfonica.Web.Areas.User.Data.Entities;
using Sinfonica.Web.Areas.User.Data.Repositories;
using Sinfonica.Web.Areas.User.Helpers;

namespace Sinfonica.Web.Areas.User.Controllers
{

    
    [Area("User")]
    public class PruebasController : Controller
    {
        private readonly DataContext _context;
        private readonly IPruebaRepository pruebaRepository;

        public PruebasController(DataContext context, IPruebaRepository pruebaRepository)
        {
            _context = context;
            this.pruebaRepository = pruebaRepository;
        }

        // GET: Admin/Pruebas
        public async Task<IActionResult> Index()
        {
            var view = from progra in this.pruebaRepository.GetAll()  select progra;
            return View(view.OrderBy(a => a.Titulo));
        }



        // GET: Admin/Pruebas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("PruebaNotFound");
            }

            var de = await this.pruebaRepository.GetByIdAsync(id.Value);
            if (de == null)
            {
                return new NotFoundViewResult("PruebaNotFound");
            }

            return View(de);
        }


        // GET: Admin/Pruebas/Create
        public IActionResult Create()
        {
            return View();
        }






        // POST: Admin/Pruebas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Encabezado,Descripcion,Informacion,PrimeraFecha,SegundaFeacha,TerceraFecha")] Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                await this.pruebaRepository.CreateAsync(prueba);
                return RedirectToAction(nameof(Index));
            }
            return View(prueba);
        }




        // GET: Admin/Pruebas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("PruebaNotFound");
            }

            var institucion = await this.pruebaRepository.GetByIdAsync(id.Value);
            if (institucion == null)
            {
                return new NotFoundViewResult("PruebaNotFound");
            }
            return View(institucion);
        }





        // POST: Admin/Pruebas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Encabezado,Descripcion,Informacion,PrimeraFecha,SegundaFeacha,TerceraFecha")] Prueba prueba)
        {

            if (id != prueba.Id)
            {
                return new NotFoundViewResult("PruebaNotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.pruebaRepository.UpdateAsync(prueba);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PruebaExists(prueba.Id))
                    {
                        return new NotFoundViewResult("PruebaNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(prueba);
        }




        // GET: Admin/Pruebas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return new NotFoundViewResult("PruebaNotFound");
            }

            var departamento = await this.pruebaRepository.GetByIdAsync(id.Value);
            if (departamento == null)
            {
                return new NotFoundViewResult("PruebaNotFound");
            }

            return View(departamento);
        }





        // POST: Admin/Pruebas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await this.pruebaRepository.GetByIdAsync(id);

            await this.pruebaRepository.DeleteAsync(departamento);

            return RedirectToAction(nameof(Index));
        }

        private bool PruebaExists(int id)
        {
            return _context.Pruebas.Any(e => e.Id == id);
        }
    }
}
