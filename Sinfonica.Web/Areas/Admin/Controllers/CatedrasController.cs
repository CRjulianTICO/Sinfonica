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
using Sinfonica.Web.Areas.Admin.Helpers;
using Sinfonica.Web.Areas.Admin.Models;

namespace Sinfonica.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CatedrasController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;

        public CatedrasController(DataContext context, ICombosHelper combosHelper )
        {
            _context = context;
            this.combosHelper = combosHelper;
        }

        // GET: Admin/Catedras
        public async Task<IActionResult> Index()
        {

            var view = from obj in await _context.Catedras.Include(a => a.Departamentos).ToListAsync() where obj.Estado == true select obj;

            return View(view);
        }





        // GET: Admin/Catedras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catedra = await _context.Catedras.Include(a => a.Departamentos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catedra == null)
            {
                return NotFound();
            }

            return View(catedra);
        }





        // GET: Admin/Catedras/Create
        public IActionResult Create()
        {

            var model = new CatedraViewModel {
                Departaments = combosHelper.GetComboDepartamentos()
            };
            return View(model);
        }






        // POST: Admin/Catedras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CatedraViewModel catedra)
        {
            if (ModelState.IsValid)
            {

                var obj = new Catedra
                {
                    Estado = catedra.Estado,
                    Informacion = catedra.Informacion,
                    NombreCatedra = catedra.NombreCatedra,
                    Departamentos = await _context.Departamentos.FindAsync(catedra.DepartamenosId)
                };


                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catedra);
        }






        // GET: Admin/Catedras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var catedra = await _context.Catedras.FindAsync(id);


            var obj = new CatedraViewModel
            {
                NombreCatedra = catedra.NombreCatedra,
                Departaments = combosHelper.GetComboDepartamentos(),
                Estado = catedra.Estado,
                Informacion = catedra.Informacion
            };


            if (catedra == null)
            {
                return NotFound();
            }
            return View(obj);
        }





        // POST: Admin/Catedras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CatedraViewModel catedra)
        {
            if (id != catedra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var obj = new Catedra
                    {
                        Id = catedra.Id,
                        Estado = catedra.Estado,
                        Informacion = catedra.Informacion,
                        NombreCatedra = catedra.NombreCatedra,
                        Departamentos = await _context.Departamentos.FindAsync(catedra.DepartamenosId)
                    };



                    _context.Update(obj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatedraExists(catedra.Id))
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
            return View(catedra);
        }






        // GET: Admin/Catedras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catedra = await _context.Catedras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catedra == null)
            {
                return NotFound();
            }

            return View(catedra);
        }






        // POST: Admin/Catedras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catedra = await _context.Catedras.FindAsync(id);

            catedra.Estado = false;

            _context.Catedras.Update(catedra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool CatedraExists(int id)
        {
            return _context.Catedras.Any(e => e.Id == id);
        }
    }
}
