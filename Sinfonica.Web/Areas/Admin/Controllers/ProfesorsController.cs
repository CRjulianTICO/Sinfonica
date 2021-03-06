﻿using System;
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
using Sinfonica.Web.Areas.Admin.Helpers;
using Sinfonica.Web.Areas.Admin.Models;

namespace Sinfonica.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProfesorsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;

        public ProfesorsController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            this.combosHelper = combosHelper;
        }


        // GET: Admin/Profesors
        public async Task<IActionResult> Index()
        {
            var view = from obj in await _context.Profesors.Include(a => a.Departamentos).Include(a => a.Catedras).ToListAsync() where obj.Estado == true select obj;
            return View(view);
        }




        // GET: Admin/Profesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors.Include(a => a.Departamentos).Include(a => a.Catedras).FirstOrDefaultAsync(m => m.Id == id);

            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }





        // GET: Admin/Profesors/Create
        public IActionResult Create()
        {

            var model = new ProfesorViewModel
            {

                Departaments = combosHelper.GetComboDepartamentos(),
                Catedrass = combosHelper.GetComboCatedras()

            };


            return View(model);
        }







        // POST: Admin/Profesors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfesorViewModel profesor)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (profesor.ImageFile != null && profesor.ImageFile.Length > 0)
                {

                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Profesores",
                        file);



                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await profesor.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Profesores/{file}";
                }

                var obj = new Profesor
                {
                    Estado = profesor.Estado,
                    ImageUrl = path,
                    Informacion = profesor.Informacion,
                    Correo = profesor.Correo,
                    Departamentos = await _context.Departamentos.FindAsync(profesor.DepartamenosId),
                    Catedras = await _context.Catedras.FindAsync(profesor.CatedrasId),
                    Nombre = profesor.Nombre,
                    PrimerApellido = profesor.PrimerApellido,
                    SegundoApellido  = profesor.SegundoApellido,
                    Telefono = profesor.Telefono,
                    Carrera = profesor.Carrera,
                    Estudios = profesor.Estudios,
                    FechaNacimiento = profesor.FechaNacimiento
                };


                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }






        // GET: Admin/Profesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors.FindAsync(id);

            var obj = new ProfesorViewModel
            {
                ImageUrl = profesor.ImageUrl,
                Estado = profesor.Estado,
                Informacion = profesor.Informacion,
                Correo = profesor.Correo,
                Departaments = combosHelper.GetComboDepartamentos(),
                Catedrass = combosHelper.GetComboCatedras(),
                Nombre = profesor.Nombre,
                PrimerApellido = profesor.PrimerApellido,
                SegundoApellido = profesor.SegundoApellido,
                Telefono = profesor.Telefono,
                Carrera = profesor.Carrera,
                Estudios = profesor.Estudios,
                FechaNacimiento = profesor.FechaNacimiento
            };


            if (profesor == null)
            {
                return NotFound();
            }
            return View(obj);
        }





        // POST: Admin/Profesors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ProfesorViewModel profesor)
        {
            if (id != profesor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var path = string.Empty;

                    if (profesor.ImageFile != null && profesor.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Profesores",
                            file);



                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await profesor.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Profesores/{file}";
                    }


                    var obj = new Profesor
                    {
                        Id = profesor.Id,
                        Estado = profesor.Estado,
                        Informacion = profesor.Informacion,
                        Correo = profesor.Correo,
                        Departamentos = await _context.Departamentos.FindAsync(profesor.DepartamenosId),
                        Catedras = await _context.Catedras.FindAsync(profesor.CatedrasId),
                        Nombre = profesor.Nombre,
                        PrimerApellido = profesor.PrimerApellido,
                        SegundoApellido = profesor.SegundoApellido,
                        Telefono = profesor.Telefono,
                        ImageUrl = path,
                        Carrera = profesor.Carrera,
                        Estudios = profesor.Estudios,
                        FechaNacimiento = profesor.FechaNacimiento
                    };
                    _context.Update(obj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.Id))
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
            return View(profesor);
        }







        // GET: Admin/Profesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }





        // POST: Admin/Profesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesor = await _context.Profesors.FindAsync(id);
            profesor.Estado = false;
            _context.Profesors.Update(profesor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesors.Any(e => e.Id == id);
        }
    }
}
