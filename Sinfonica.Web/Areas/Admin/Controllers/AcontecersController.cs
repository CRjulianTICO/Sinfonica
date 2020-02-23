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
using Sinfonica.Web.Areas.Admin.Models;

namespace Sinfonica.Web.Areas.Admin.Controllers
{
    [Authorize]
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
            return View(await _context.Acontecers.Include(e => e.Estudiantes).Where(a => a.Estado == true).ToListAsync());
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
        public async Task<IActionResult> Create( AcontecersViewModel acontecer)
        {
            if (ModelState.IsValid)
            {

                var path = string.Empty;

                if (acontecer.ImageFile != null && acontecer.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Acontecer",
                        file);



                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await acontecer.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Acontecer/{file}";
                }


                var obj = new Acontecer
                {
                    Id = acontecer.Id,
                    Estado = acontecer.Estado,
                    Informacion = acontecer.Informacion,
                    ImageUrl = path,
                    Titulo = acontecer.Titulo,
                    Descripcion = acontecer.Descripcion,
                    Encabezado = acontecer.Encabezado,
                    Estudiantes = acontecer.Estudiantes,
                    Fecha = acontecer.Fecha,
                    Lugar = acontecer.Lugar
                };


                _context.Add(obj);
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

            var obj = new AcontecersViewModel
            {
                ImageUrl = acontecer.ImageUrl,
                Estado = acontecer.Estado,
                Informacion = acontecer.Informacion,
                Titulo = acontecer.Titulo,
                Fecha = acontecer.Fecha,
                Descripcion = acontecer.Descripcion,
                Encabezado = acontecer.Encabezado,
                Estudiantes = acontecer.Estudiantes,
                Lugar = acontecer.Lugar

            };

            if (acontecer == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: Admin/Acontecers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AcontecersViewModel acontecer)
        {
            if (id != acontecer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var path = string.Empty;

                    if (acontecer.ImageFile != null && acontecer.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Acontecer",
                            file);



                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await acontecer.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Acontecer/{file}";
                    }


                    var obj = new Acontecer
                    {
                        Id = acontecer.Id,
                        Estado = acontecer.Estado,
                        Informacion = acontecer.Informacion,
                        ImageUrl = path,
                        Titulo = acontecer.Titulo,
                        Descripcion = acontecer.Descripcion,
                        Encabezado = acontecer.Encabezado,
                        Estudiantes = acontecer.Estudiantes,
                        Fecha = acontecer.Fecha,
                        Lugar = acontecer.Lugar
                    };




                    _context.Update(obj);
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
            acontecer.Estado = false;
            _context.Acontecers.Update(acontecer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcontecerExists(int id)
        {
            return _context.Acontecers.Any(e => e.Id == id);
        }
    }
}
