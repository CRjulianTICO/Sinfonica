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

namespace Sinfonica.Web.Areas.User.Controllers
{
    
    [Area("User")]
    public class CostosController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;

        public CostosController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            this.combosHelper = combosHelper;
        }



        public  IActionResult _TipoProgramaPartial(decimal Id)
        {
            var model =  _context.Costos.Where(row => row.Programas.Id == Id).ToList();

            var cos = new CostosViewModel
            {
                Programs = this.combosHelper.GetComboProgramas(),

                Id = model.First().Id,

                Costo1Semestre = model.First().Costo1Semestre,
                Costo2Semestre = model.First().Costo2Semestre,
                FechaLim1Sem = model.First().FechaLim1Sem,
                FechaLim2Sem = model.First().FechaLim2Sem,
                Informacion = model.First().Informacion,
                Matricula = model.First().Matricula

            };

            return PartialView(model);
        }


        // GET: Admin/Costos
        public async Task<IActionResult> Index()
        {
            ViewBag.Programas = this.combosHelper.GetComboProgramas();


            return View( _context.Costos.Include(p => p.Programas));
        }



        // GET: Admin/Costos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costo = await _context.Costos.Include(p => p.Programas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costo == null)
            {
                return NotFound();
            }

            return View(costo);
        }



        /*


        // GET: Admin/Costos/Create
        public IActionResult Create()
        {

            var model = new CostosViewModel
            {
                Programs = this.combosHelper.GetComboProgramas()

            };

            return View(model);
        }





        // POST: Admin/Costos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CostosViewModel costo)
        {
            if (ModelState.IsValid)
            {
                var obj = new Costo
                {
                    Matricula = costo.Matricula,
                    Informacion = costo.Informacion,
                    FechaLim2Sem = costo.FechaLim2Sem,
                    FechaLim1Sem = costo.FechaLim1Sem,
                    Costo1Semestre = costo.Costo1Semestre,
                    Costo2Semestre = costo.Costo2Semestre,
                    Programas = await _context.Programas.FindAsync(costo.ProgramasId)
                };

                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(costo);
        }




        // GET: Admin/Costos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var costo = await _context.Costos.FindAsync(id);

            var view = new CostosViewModel
            {
                FechaLim1Sem = costo.FechaLim1Sem,
                FechaLim2Sem = costo.FechaLim2Sem,
                Costo1Semestre = costo.Costo1Semestre,
                Costo2Semestre = costo.Costo2Semestre,
                Matricula = costo.Matricula,
                Programs = this.combosHelper.GetComboProgramas(),
                //Id = costo.Id,
                Informacion = costo.Informacion
            };

            
            if (costo == null)
            {
                return NotFound();
            }
            return View(view);
        }







        // POST: Admin/Costos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CostosViewModel costo)
        {
            if (id != costo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var view = new Costo
                    {
                        FechaLim1Sem = costo.FechaLim1Sem,
                        FechaLim2Sem = costo.FechaLim2Sem,
                        Costo1Semestre = costo.Costo1Semestre,
                        Costo2Semestre = costo.Costo2Semestre,
                        Matricula = costo.Matricula,
                        Programas = await _context.Programas.FindAsync(costo.ProgramasId),
                        Id = costo.Id,
                        Informacion = costo.Informacion
                    };

                    _context.Update(view);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostoExists(costo.Id))
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
            return View(costo);
        }




        // GET: Admin/Costos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costo = await _context.Costos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costo == null)
            {
                return NotFound();
            }

            return View(costo);
        }




        // POST: Admin/Costos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costo = await _context.Costos.FindAsync(id);
            _context.Costos.Remove(costo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostoExists(int id)
        {
            return _context.Costos.Any(e => e.Id == id);
        }*/
    }
}
