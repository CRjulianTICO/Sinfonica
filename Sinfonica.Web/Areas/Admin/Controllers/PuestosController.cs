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

namespace Sinfonica.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PuestosController : Controller
    {
        private readonly DataContext _context;
        private readonly IPuestoRepository puestoRepository;

        public PuestosController(DataContext context, IPuestoRepository puestoRepository)
        {
            _context = context;
            this.puestoRepository = puestoRepository;
        }





        // GET: Admin/Puestos
        public async Task<IActionResult> Index()
        {
            var view = from progra in this.puestoRepository.GetAll() where progra.Estado == true select progra;
            return View(view.OrderBy(a => a.Nombre));
        }







        // GET: Admin/Puestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("PuestoNotFound");
            }

            var de = await this.puestoRepository.GetByIdAsync(id.Value);
            if (de == null)
            {
                return new NotFoundViewResult("PuestoNotFound");
            }

            return View(de);
        }






        // GET: Admin/Puestos/Create
        public IActionResult Create()
        {
            return View();
        }








        // POST: Admin/Puestos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Informacion,Estado")] Puesto puesto)
        {
            if (ModelState.IsValid)
            {
                await this.puestoRepository.CreateAsync(puesto);
                return RedirectToAction(nameof(Index));
            }
            return View(puesto);
        }







        // GET: Admin/Puestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("PuestoNotFound");
            }

            var institucion = await this.puestoRepository.GetByIdAsync(id.Value);
            if (institucion == null)
            {
                return new NotFoundViewResult("PuestoNotFound");
            }
            return View(institucion);
        }








        // POST: Admin/Puestos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Informacion,Estado")] Puesto puesto)
        {
            if (id != puesto.Id)
            {
                return new NotFoundViewResult("DepartamentoNotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.puestoRepository.UpdateAsync(puesto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoExists(puesto.Id))
                    {
                        return new NotFoundViewResult("DepartamentoNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(puesto);
        }







        // GET: Admin/Puestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("PuestoNotFound");
            }

            var departamento = await this.puestoRepository.GetByIdAsync(id.Value);
            if (departamento == null)
            {
                return new NotFoundViewResult("PuestoNotFound");
            }

            return View(departamento);
        }







        // POST: Admin/Puestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await this.puestoRepository.GetByIdAsync(id);

            departamento.Estado = false;

            await this.puestoRepository.UpdateAsync(departamento);

            return RedirectToAction(nameof(Index));
        }




        private bool PuestoExists(int id)
        {
            return _context.Puestos.Any(e => e.Id == id);
        }
    }
}
