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
using Sinfonica.Web.Areas.Admin.Models;

namespace Sinfonica.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NoticiasController : Controller
    {
        private readonly DataContext _context;

        public NoticiasController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/Noticias
        public async Task<IActionResult> Index()
        {

            var view = from progra in await _context.Noticias.ToListAsync() where progra.Estado == true select progra;
            return View(view);
        }

        // GET: Admin/Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // GET: Admin/Noticias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Noticias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoticiasViewModel view)
        {
            if (ModelState.IsValid)
            {


                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {

                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Noticias",
                        file);



                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Noticias/{file}";
                }


                var product = this.ToNoticia(view, path);
                

                _context.Noticias.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(view);
        }




        private Noticia ToNoticia(NoticiasViewModel view, string path)
        {
            return new Noticia
            {
                Id = view.Id,
                ImageUrl = path,
                Titulo = view.Titulo,
                Encabezado = view.Encabezado,
                Descripcion = view.Descripcion,
                Informacion = view.Informacion,
                Fecha = view.Fecha,
                Estado = view.Estado

            };
        }





        // GET: Admin/Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticias.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }


            var view = this.ToEventoViewModel(noticia);

            return View(view);
        }



        private object ToEventoViewModel(Noticia product)
        {
            return new NoticiasViewModel
            {
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Titulo = product.Titulo,
                Encabezado = product.Encabezado,
                Descripcion = product.Descripcion,
                Informacion = product.Informacion,
                Fecha = product.Fecha,
                Estado = product.Estado

            };
        }










        // POST: Admin/Noticias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( NoticiasViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = string.Empty;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Noticias",
                            file);



                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Noticias/{file}";
                    }

                    var product = this.ToNoticia(view, path);



                    _context.Noticias.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiaExists(view.Id))
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

            return View(view);
        }


        // GET: Admin/Profesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Noticias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }




        // POST: Admin/Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticia = await _context.Noticias.FindAsync(id);

            noticia.Estado = false;
            _context.Noticias.Update(noticia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiaExists(int id)
        {
            return _context.Noticias.Any(e => e.Id == id);
        }
    }
}
