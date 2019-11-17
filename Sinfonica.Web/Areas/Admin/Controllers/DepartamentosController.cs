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
    public class DepartamentosController : Controller
    {
        private readonly DataContext _context;
        private readonly IDepartamentoRepository departamentoRepository;

        public DepartamentosController(DataContext context, IDepartamentoRepository departamentoRepository)
        {
            _context = context;
            this.departamentoRepository = departamentoRepository;
        }

        // GET: Admin/Departamentos
        public async Task<IActionResult> Index()
        {
            var view = from progra in this.departamentoRepository.GetAll() where progra.Estado == true select progra;
            return View(view.OrderBy(a => a.NombreDepartamento));
        }





        // GET: Admin/Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("DepartamentoNotFound");
            }

            var de = await this.departamentoRepository.GetByIdAsync(id.Value);
            if (de == null)
            {
                return new NotFoundViewResult("DepartamentoNotFound");
            }

            return View(de);
        }



        // GET: Admin/Departamentos/Create
        public IActionResult Create()
        {
            return View();
        }








        // POST: Admin/Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreDepartamento,Informacion,Estado")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                await this.departamentoRepository.CreateAsync(departamento);
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }





        // GET: Admin/Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("DepartamentoNotFound");
            }

            var institucion = await this.departamentoRepository.GetByIdAsync(id.Value);
            if (institucion == null)
            {
                return new NotFoundViewResult("DepartamentoNotFound");
            }
            return View(institucion);
        }









        // POST: Admin/Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreDepartamento,Informacion,Estado")] Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return new NotFoundViewResult("DepartamentoNotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.departamentoRepository.UpdateAsync(departamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.Id))
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
            return View(departamento);
        }







        // GET: Admin/Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("DepartamentoNotFound");
            }

            var departamento = await this.departamentoRepository.GetByIdAsync(id.Value);
            if (departamento == null)
            {
                return new NotFoundViewResult("DepartamentoNotFound");
            }

            return View(departamento);
        }






        // POST: Admin/Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await this.departamentoRepository.GetByIdAsync(id);

            departamento.Estado = false;

            await this.departamentoRepository.UpdateAsync(departamento);

            return RedirectToAction(nameof(Index));
        }



        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.Id == id);
        }
    }
}
