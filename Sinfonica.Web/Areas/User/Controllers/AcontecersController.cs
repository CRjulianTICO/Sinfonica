using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinfonica.Web.Areas.Admin.Data;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using Sinfonica.Web.Areas.Admin.Helpers;
using Sinfonica.Web.Areas.Admin.Models;
using Sinfonica.Web.Areas.User.Pagination;

namespace Sinfonica.Web.Areas.User.Controllers
{
    [Area("User")]
    public class AcontecersController : Controller
    {
        private readonly DataContext _context;

        public AcontecersController(DataContext context)
        {
            _context = context;
        }

        // GET: User/Acontecers
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string currentFilter, string searchString)
        {

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }



            ViewData["CurrentFilter"] = searchString;

            var aconte = from progra in _context.Acontecers.Include(e => e.Estudiantes) where progra.Estado == true && progra.Fecha >= System.DateTime.Now  select progra;

            aconte = aconte.OrderBy(a => a.Fecha);
            


            if (!String.IsNullOrEmpty(searchString))
            {
                aconte = aconte.Where(s => s.Titulo.Contains(searchString));
            }

            int pageSize = 5;

            


            return View(await PaginatedList<Acontecer>.CreateAsync(aconte.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: User/Acontecers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acontecer = await _context.Acontecers.Include(e => e.Estudiantes)
                .FirstOrDefaultAsync(m => m.Id == id);

            acontecer.Estudiantes = await _context.Estudiantes.FirstOrDefaultAsync(e => e.Carnet == acontecer.Estudiantes.Carnet);
            if (acontecer == null)
            {
                return NotFound();
            }

            return View(acontecer);
        }

        // GET: User/Acontecers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Acontecers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AcontecersViewModel acontecer)
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

                acontecer.Estado = true;

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

                var estudiante = await _context.Estudiantes.Where(e => e.Estado == true).FirstOrDefaultAsync(e => e.Carnet == acontecer.Estudiantes.Carnet);

                if (estudiante != null)
                {
                    obj.Estudiantes = estudiante;
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return new NotFoundViewResult("NoAuthorize");
                }
            }
            return View(acontecer);
            
        }

        // GET: User/Acontecers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acontecer = await _context.Acontecers.FindAsync(id);
            if (acontecer == null)
            {
                return NotFound();
            }
            return View(acontecer);
        }

        // POST: User/Acontecers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Encabezado,Informacion,Descripcion,Lugar,Fecha,Estado,ImageUrl")] Acontecer acontecer)
        {
            if (id != acontecer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acontecer);
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

        // GET: User/Acontecers/Delete/5
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

        // POST: User/Acontecers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acontecer = await _context.Acontecers.FindAsync(id);
            _context.Acontecers.Remove(acontecer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcontecerExists(int id)
        {
            return _context.Acontecers.Any(e => e.Id == id);
        }
    }
}
