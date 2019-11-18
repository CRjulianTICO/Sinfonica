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
    public class ProfesorCursosController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper combosHelper;

        public ProfesorCursosController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            this.combosHelper = combosHelper;
        }

        // GET: Admin/ProfesorCursos
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.ProfesorCursos.Include(p => p.Cursos).Include(p => p.Profesors);
            return View(await dataContext.ToListAsync());
        }




        // GET: Admin/ProfesorCursos/Details/5
        public async Task<IActionResult> Details(int? IdCurso, int? IdProfesor)
        {
            if (IdCurso == null || IdProfesor == null)
            {
                return new NotFoundViewResult("ProfesorCursoNotFound");
            }

            var obj = new ProfesorCurso
            {
                ProfesorId = IdProfesor.Value,
                CursosId = IdCurso.Value,
                Profesors = await _context.Profesors.FindAsync(IdProfesor),
                Cursos = await _context.Curso.FindAsync(IdCurso)
            };
            if (obj == null)
            {
                return new NotFoundViewResult("ProfesorCursoNotFound");
            }

            return View(obj);
        }

        // GET: Admin/ProfesorCursos/Create
        public IActionResult Create()
        {
            var model = new ProfesorCursoViewModel
            {

                Cursoss = combosHelper.GetComboCursos(),
                Profesores = combosHelper.GetComboProfesores()

            };
           /* ViewData["CursosId"] = new SelectList(_context.Curso, "Id", "Id");
            ViewData["ProfesorId"] = new SelectList(_context.Profesors, "Id", "Id");*/
            return View(model);
        }




        // POST: Admin/ProfesorCursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfesorCursoViewModel profesorCurso)
        {
            if (ModelState.IsValid)
            {

                var obj = new ProfesorCurso 
                {

                    Profesors = await _context.Profesors.FindAsync(profesorCurso.ProfesorsId),
                    Cursos = await _context.Curso.FindAsync(profesorCurso.CursossId),
                };

                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["CursosId"] = new SelectList(_context.Curso, "Id", "Id", profesorCurso.CursosId);
            ViewData["ProfesorId"] = new SelectList(_context.Profesors, "Id", "Id", profesorCurso.ProfesorId);*/
            return View(profesorCurso);
        }




        // GET: Admin/ProfesorCursos/Edit/5
        public async Task<IActionResult> Edit(int? IdCurso, int? IdProfesor)
        {
            if (IdCurso == null || IdProfesor == null)
            {
                return new NotFoundViewResult("ProfesorCursoNotFound");
            }

            var profesorCurso = await _context.ProfesorCursos.FindAsync(IdCurso, IdProfesor);


            var model = new ProfesorCursoViewModel
            {

                Cursoss = combosHelper.GetComboCursos(),
                Profesores = combosHelper.GetComboProfesores()

            };

            if (profesorCurso == null)
            {
                return new NotFoundViewResult("ProfesorCursoNotFound");
            }
            
            ViewData["CursosId"] = new SelectList(_context.Curso, "Id", "Id", profesorCurso.CursosId);
            ViewData["ProfesorId"] = new SelectList(_context.Profesors, "Id", "Id", profesorCurso.ProfesorId);


            var profesor = await _context.Profesors.FindAsync(profesorCurso.ProfesorId);
            var curso = await _context.Curso.FindAsync(profesorCurso.CursosId);


            ViewData["CursosNombre"] = curso.NombreCurso;
            ViewData["ProfesorNombre"] = profesor.NombreCompleto;

            return View(model);
        }





        // POST: Admin/ProfesorCursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? IdCurso, int? IdProfesor, ProfesorCursoViewModel profesorCurso)
        {
            if (IdCurso != profesorCurso.CursosId || IdProfesor != profesorCurso.ProfesorId)
            {
                return new NotFoundViewResult("ProfesorCursoNotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var obj = new ProfesorCurso
                    {

                        Profesors = await _context.Profesors.FindAsync(profesorCurso.ProfesorsId),
                        Cursos = await _context.Curso.FindAsync(profesorCurso.CursossId),
                    };



                    _context.Update(obj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorCursoExists(profesorCurso.CursosId))
                    {
                        return new NotFoundViewResult("ProfesorCursoNotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursosId"] = new SelectList(_context.Curso, "Id", "Id", profesorCurso.CursosId);
            ViewData["ProfesorId"] = new SelectList(_context.Profesors, "Id", "Id", profesorCurso.ProfesorId);
            return View(profesorCurso);
        }




        // GET: Admin/ProfesorCursos/Delete/5
        public async Task<IActionResult> Delete(int? IdCurso, int? IdProfesor)
        {
            if (IdCurso == null || IdProfesor == null)
            {
                return new NotFoundViewResult("ProfesorCursoNotFound");
            }

            /*var view = from x in  await _context.ProfesorCursos.Include(p => p.Cursos).Include(p => p.Profesors).ToListAsync()
                       where x.ProfesorId == IdProfesor && x.CursosId == IdCurso  select x;*/


            var obj = new ProfesorCurso {
                ProfesorId = IdProfesor.Value,
                CursosId = IdCurso.Value,
                Profesors = await _context.Profesors.FindAsync(IdProfesor),
                Cursos = await _context.Curso.FindAsync(IdCurso)
            };

           /* var profesorCurso = await _context.ProfesorCursos
                .Include(p => p.Cursos)
                .Include(p => p.Profesors)
                .FirstOrDefaultAsync();*/
            if (obj == null)
            {
                return new NotFoundViewResult("ProfesorCursoNotFound");
            }

            return View(obj);
        }





        // POST: Admin/ProfesorCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? ProfesorId, int? CursosId)
        {
            var profesorCurso = await _context.ProfesorCursos.FindAsync(CursosId, ProfesorId);
            _context.ProfesorCursos.Remove(profesorCurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorCursoExists(int id)
        {
            return _context.ProfesorCursos.Any(e => e.CursosId == id);
        }
    }
}
