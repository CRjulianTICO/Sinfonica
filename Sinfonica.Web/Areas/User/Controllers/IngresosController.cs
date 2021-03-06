﻿using System;
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
using Sinfonica.Web.Areas.User.Models;

namespace Sinfonica.Web.Areas.User.Controllers
{

    
    [Area("User")]
    public class IngresosController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;

        public IngresosController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            this.combosHelper = combosHelper;
        }



        // GET: Admin/Ingresos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingresos.Include(p => p.Pruebas).ToListAsync());
        }




        // GET: Admin/Ingresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingresos.Include(a => a.Pruebas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingreso == null)
            {
                return NotFound();
            }

            return View(ingreso);
        }






        /*

        // GET: Admin/Ingresos/Create
        public IActionResult Create()
        {

            var model = new IngresoViewModel{
                Pruebs = combosHelper.GetComboPruebas()
            };

            return View(model);
        }






        // POST: Admin/Ingresos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngresoViewModel ingreso)
        {
            if (ModelState.IsValid)
            {

                var obj = new Ingreso
                {
                    Formulario = ingreso.Formulario,
                    AntesAplicar = ingreso.AntesAplicar,
                    RequisitosExtranjeros = ingreso.RequisitosExtranjeros,
                    RequisitosNacionales= ingreso.RequisitosNacionales,
                    Pruebas = await _context.Pruebas.FindAsync(ingreso.PruebasId)
                };

                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingreso);
        }





        // GET: Admin/Ingresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingresos.FindAsync(id);

            var obj = new IngresoViewModel
            {
                Formulario = ingreso.Formulario,
                AntesAplicar = ingreso.AntesAplicar,
                RequisitosExtranjeros = ingreso.RequisitosExtranjeros,
                RequisitosNacionales = ingreso.RequisitosNacionales,
                Pruebs = combosHelper.GetComboPruebas()
            };


            if (ingreso == null)
            {
                return NotFound();
            }
            return View(obj);
        }






        // POST: Admin/Ingresos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,IngresoViewModel ingreso)
        {
            if (id != ingreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var obj = new Ingreso
                    {
                        Formulario = ingreso.Formulario,
                        Id = ingreso.Id,
                        AntesAplicar = ingreso.AntesAplicar,
                        RequisitosExtranjeros = ingreso.RequisitosExtranjeros,
                        RequisitosNacionales = ingreso.RequisitosNacionales,
                        Pruebas = await _context.Pruebas.FindAsync(ingreso.PruebasId)
                    };

                    _context.Update(obj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngresoExists(ingreso.Id))
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
            return View(ingreso);
        }






        // GET: Admin/Ingresos/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingreso == null)
            {
                return NotFound();
            }

            return View(ingreso);
        }







        // POST: Admin/Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingreso = await _context.Ingresos.FindAsync(id);
            _context.Ingresos.Remove(ingreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        private bool IngresoExists(int id)
        {
            return _context.Ingresos.Any(e => e.Id == id);
        }*/
    }
}
