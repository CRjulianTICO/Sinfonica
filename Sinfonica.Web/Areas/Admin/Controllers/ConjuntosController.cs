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

    [Authorize]
    [Area("Admin")]
    public class ConjuntosController : Controller
    {
        private readonly DataContext _context;
        private readonly IDirectorRepository directorRepository;
        private readonly ICombosHelper comboHelper;
        private readonly IConjuntoRepository conjuntoRepository;

        public ConjuntosController(DataContext context, IDirectorRepository directorRepository, ICombosHelper comboHelper, IConjuntoRepository conjuntoRepository)
        {
            _context = context;
            this.directorRepository = directorRepository;
            this.comboHelper = comboHelper;
            this.conjuntoRepository = conjuntoRepository;
        }

        // GET: Admin/Conjuntos
        public async Task<IActionResult> Index()
        {
            var view = from x in _context.Conjuntos.Include(p => p.Director) where x.Estado == true select x;


            return View(view);
        }






        // GET: Admin/Conjuntos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conjunto = await _context.Conjuntos.Include(w=>w.Director)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conjunto == null)
            {
                return NotFound();
            }

            return View(conjunto);
        }





        // GET: Admin/Conjuntos/Create
        public IActionResult Create()
        {
            var model = new ConjuntoViewModel
            {
                Directors = this.comboHelper.GetComboDirectors()
                
            };

            return View(model);
        }







        // POST: Admin/Conjuntos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConjuntoViewModel conjunto)
        {

            if (ModelState.IsValid)
            {

                

                var path = string.Empty;

                if (conjunto.ImageFile != null && conjunto.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Conjunto",
                        file);



                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await conjunto.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Conjunto/{file}";
                }


                var emp = new Conjunto
                {
                    NombreConjunto = conjunto.NombreConjunto,
                    Informacion = conjunto.Informacion,
                    Estado = conjunto.Estado,
                    ImageUrl = path,
                    Director = await _context.Directors.FindAsync(conjunto.DirectorsId)
                };


                //Console.WriteLine("*****"+emp.Director);

                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conjunto);
        }







        // GET: Admin/Conjuntos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }






            var conjunto = await _context.Conjuntos.FindAsync(id);





            if (conjunto == null)
            {
                return NotFound();
            }



            var view = new ConjuntoViewModel
            {
                NombreConjunto = conjunto.NombreConjunto,
                Id = conjunto.Id,
                Estado = conjunto.Estado,
                ImageUrl = conjunto.ImageUrl,
                Informacion = conjunto.Informacion,
                Directors = comboHelper.GetComboDirectors()
            };





            return View(view);
        }









        // POST: Admin/Conjuntos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConjuntoViewModel conjunto)
        {

            if (id != conjunto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {




                var path = string.Empty;

                if (conjunto.ImageFile != null && conjunto.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Conjunto",
                        file);



                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await conjunto.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Conjunto/{file}";
                }




                var emp = new Conjunto
                {
                    Id = conjunto.Id,
                    NombreConjunto = conjunto.NombreConjunto,
                    Informacion = conjunto.Informacion,
                    Estado = conjunto.Estado,
                    ImageUrl = path,
                    Director = await _context.Directors.FindAsync(conjunto.DirectorsId)
                };




                _context.Conjuntos.Update(emp);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conjunto);

           
        }







        // GET: Admin/Conjuntos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conjunto = await _context.Conjuntos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conjunto == null)
            {
                return NotFound();
            }

            return View(conjunto);
        }





        // POST: Admin/Conjuntos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var empleado = await _context.Conjuntos.FindAsync(id);
            empleado.Estado = false;
            _context.Conjuntos.Update(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool ConjuntoExists(int id)
        {
            return _context.Conjuntos.Any(e => e.Id == id);
        }
    }
}
