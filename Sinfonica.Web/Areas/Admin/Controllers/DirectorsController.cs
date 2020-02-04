using System;
using System.Collections.Generic;
using System.IO;
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
using Sinfonica.Web.Areas.Admin.Models;

namespace Sinfonica.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
            var view = from progra in await this._context.Directors.ToListAsync() where progra.Estado == true select progra;
            return View(questionnaire.OrderBy(a => a.Nombre));
        }



        // GET: Admin/Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }

            var de = await this.directorRepository.GetByIdAsync(id.Value);
            if (de == null)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }

            return View(de);
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
        public async Task<IActionResult> Create( DirectorsViewModel director)
        {
            if (ModelState.IsValid)
            {


                var path = string.Empty;

                if (director.ImageFile != null && director.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Director",
                        file);



                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await director.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Director/{file}";
                }


                var obj = new Director
                {
                    Id = director.Id,
                    Estado = director.Estado,
                    Informacion = director.Informacion,
                    Correo = director.Correo,
                    Nombre = director.Nombre,
                    PrimerApellido = director.PrimerApellido,
                    SegundoApellido = director.SegundoApellido,
                    Telefono = director.Telefono,
                    ImageUrl = path,
                    Carrera = director.Carrera,
                    Estudios = director.Estudios,
                    FechaNacimiento = director.FechaNacimiento
                };

                await this.directorRepository.CreateAsync(obj);
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

            var obj = new DirectorsViewModel
            {
                ImageUrl = institucion.ImageUrl,
                Estado = institucion.Estado,
                Informacion = institucion.Informacion,
                Correo = institucion.Correo,
                Nombre = institucion.Nombre,
                PrimerApellido = institucion.PrimerApellido,
                SegundoApellido = institucion.SegundoApellido,
                Telefono = institucion.Telefono,
                Carrera = institucion.Carrera,
                Estudios = institucion.Estudios,
                FechaNacimiento = institucion.FechaNacimiento
            };


            if (institucion == null)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }
            return View(obj);
        }




        // POST: Admin/Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DirectorsViewModel director)
        {

            if (id != director.Id)
            {
                return new NotFoundViewResult("DirectorNotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {


                    var path = string.Empty;

                    if (director.ImageFile != null && director.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Director",
                            file);



                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await director.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Director/{file}";
                    }


                    var obj = new Director
                    {
                        Id = director.Id,
                        Estado = director.Estado,
                        Informacion = director.Informacion,
                        Correo = director.Correo,
                        Nombre = director.Nombre,
                        PrimerApellido = director.PrimerApellido,
                        SegundoApellido = director.SegundoApellido,
                        Telefono = director.Telefono,
                        ImageUrl = path,
                        Carrera = director.Carrera,
                        Estudios = director.Estudios,
                        FechaNacimiento = director.FechaNacimiento
                    };


                    await this.directorRepository.UpdateAsync(obj);
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
