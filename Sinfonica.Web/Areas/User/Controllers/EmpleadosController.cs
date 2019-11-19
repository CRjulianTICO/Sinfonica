using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinfonica.Web.Areas.Admin.Data;
using Sinfonica.Web.Areas.User.Data.Entities;
using Sinfonica.Web.Areas.User.Data.Repositories;
using Sinfonica.Web.Areas.User.Helpers;
using Sinfonica.Web.Areas.User.Models;

namespace Sinfonica.Web.Areas.User.Controllers
{
    
    [Area("User")]
    public class EmpleadosController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;
        private readonly IPuestoRepository puestoRepository;
        private readonly IEmpleadoRepository empleadoRepository;

        public EmpleadosController(DataContext context, ICombosHelper combosHelper,IPuestoRepository puestoRepository, IEmpleadoRepository empleadoRepository)
        {
            _context = context;
            this.combosHelper = combosHelper;
            this.puestoRepository = puestoRepository;
            this.empleadoRepository = empleadoRepository;
        }

        // GET: Admin/Empleados
        public async Task<IActionResult> Index()
        {
            var view = from x in _context.Empleados.Include(p => p.Puestos) where x.Estado == true select x;
            
       
            return View(view);
        }

        // GET: Admin/Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.Include(p => p.Puestos)
                .FirstOrDefaultAsync(m => m.Id == id.Value);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        /*

        // GET: Admin/Empleados/Create
        public IActionResult Create()
        {


            var model = new EmpleadoViewModel
            {
                Puestos = this.combosHelper.GetComboPuestos()
            };

            return View(model);
        }

        // POST: Admin/Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoViewModel empleado)
        {
            if (ModelState.IsValid)
            {

                var emp = new Empleado {
                    Nombre = empleado.Nombre,
                    PrimerApellido = empleado.PrimerApellido,
                    SegundoApellido = empleado.SegundoApellido,
                    Correo = empleado.Correo,
                    Telefono = empleado.Telefono,
                    Estado = empleado.Estado,
                    Puestos = await _context.Puestos.FindAsync(empleado.PuestosId)
                };


                await this.empleadoRepository.CreateAsync(emp);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }



        // GET: Admin/Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            var view = new EmpleadoViewModel
            {
                Nombre = empleado.Nombre,
                Id = empleado.Id,
                Estado = empleado.Estado,
                Correo = empleado.Correo,
                Telefono = empleado.Telefono,
                PrimerApellido = empleado.PrimerApellido,
                SegundoApellido = empleado.SegundoApellido,
                Puestos = combosHelper.GetComboPuestos()
            };
            return View(view);
        }






        // POST: Admin/Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmpleadoViewModel empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var emp = new Empleado
                {
                    Nombre = empleado.Nombre,
                    Id=empleado.Id,
                    PrimerApellido = empleado.PrimerApellido,
                    SegundoApellido = empleado.SegundoApellido,
                    Correo = empleado.Correo,
                    Telefono = empleado.Telefono,
                    Estado = empleado.Estado,
                    Puestos = await _context.Puestos.FindAsync(empleado.PuestosId)
                };


                _context.Empleados.Update(emp);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }





        // GET: Admin/Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Admin/Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            empleado.Estado = false;
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }*/
    }
}
