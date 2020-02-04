using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinfonica.Web.Areas.Admin.Data;
using Sinfonica.Web.Areas.Admin.Data.Repositories;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using Sinfonica.Web.Areas.Admin.Helpers;

namespace Sinfonica.Web.Areas.User.Controllers
{
    [Area("User")]
    
    public class DirectorsController : Controller
    {
        private readonly DataContext _context;
        private readonly IDirectorRepository directorRepository;

        public DirectorsController(DataContext context, IDirectorRepository directorRepository)
        {
            _context = context;
            this.directorRepository = directorRepository;
        }



        // GET: Admin/Directors
        public async Task<IActionResult> Index()
        {

            var view = from progra in this.directorRepository.GetAll().Include(a => a.Conjuntos) where progra.Estado == true  select progra;

            var questionnaire = _context.Directors
                                            .Select(n => new Director
                                            {
                                                Id = n.Id,
                                                Nombre = n.Nombre,
                                                PrimerApellido = n.PrimerApellido,
                                                SegundoApellido = n.SegundoApellido,
                                                Carrera = n.Carrera,
                                                Correo = n.Correo,
                                                Estudios = n.Estudios,
                                                FechaNacimiento = n.FechaNacimiento,
                                                ImageUrl = n.ImageUrl,
                                                Informacion = n.Informacion,
                                                Telefono = n.Telefono,
                                                Estado = n.Estado,


                                                Conjuntos = n.Conjuntos.Where(p => p.Estado == true).ToList()

                                                



                                            });



            // return View(view.OrderBy(a => a.Nombre));
            return View(questionnaire);
        }



        // GET: Admin/Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }

            var profesor = await _context.Directors.Include(c => c.Conjuntos).FirstOrDefaultAsync(m => m.Id == id);
            var questionnaires = _context.Directors
                                           .Select(n => new Director
                                           {
                                               Id = n.Id,
                                               Nombre = n.Nombre,
                                               PrimerApellido = n.PrimerApellido,
                                               SegundoApellido = n.SegundoApellido,
                                               Carrera = n.Carrera,
                                               Correo = n.Correo,
                                               Estudios = n.Estudios,
                                               FechaNacimiento = n.FechaNacimiento,
                                               ImageUrl = n.ImageUrl,
                                               Informacion = n.Informacion,
                                               Telefono = n.Telefono,
                                               Estado = n.Estado,


                                               Conjuntos = n.Conjuntos.Where(p => p.Estado == true).ToList()

                                            


                                           }).FirstOrDefaultAsync(m => m.Id == id);


            if (profesor == null)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }

            return View(profesor);
        }

        // GET: Admin/Directors/Create
        public IActionResult Create()
        {
            return View();
        }






        // POST: Admin/Directors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,PrimerApellido,SegundoApellido,Telefono,Correo,Estado,Informacion")] Director director)
        {
            if (ModelState.IsValid)
            {
                await this.directorRepository.CreateAsync(director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }



        // GET: Admin/Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }

            var institucion = await this.directorRepository.GetByIdAsync(id.Value);
            if (institucion == null)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }
            return View(institucion);
        }




        // POST: Admin/Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,PrimerApellido,SegundoApellido,Telefono,Correo,Estado,Informacion")] Director director)
        {

            if (id != director.Id)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.directorRepository.UpdateAsync(director);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(director.Id))
                    {
                        return new NotFoundViewResult("DirectorNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }







        // GET: Admin/Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }

            var departamento = await this.directorRepository.GetByIdAsync(id.Value);
            if (departamento == null)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }

            return View(departamento);
        }






        // POST: Admin/Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await this.directorRepository.GetByIdAsync(id);

            departamento.Estado = false;

            await this.directorRepository.UpdateAsync(departamento);

            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(int id)
        {
            return _context.Directors.Any(e => e.Id == id);
        }
    }
}
