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
using Sinfonica.Web.Areas.Admin.Models;

namespace Sinfonica.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventosController : Controller
    {
        private readonly DataContext _context;
        private readonly IEventosRepository eventosRepository;

        public EventosController(DataContext context, IEventosRepository eventosRepository)
        {
            _context = context;
            this.eventosRepository = eventosRepository;
        }






        // GET: Eventoes
        public async Task<IActionResult> Index()
        {
            //var view = from wa in this.eventosRepository.GetAll().OrderBy(a => a.Fecha) where wa.Fecha >= System.DateTime.Now select wa;


            return View(this.eventosRepository.GetAll().OrderBy(p => p.Fecha));
        }






        // GET: Eventoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }



        [Authorize]
        // GET: Eventoes/Create
        public IActionResult Create()
        {
            return View();
        }







        // POST: Eventoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventosViewModel view)
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
                        "wwwroot\\images\\Eventos",
                        file);



                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Eventos/{file}";
                }


                var product = this.ToEvento(view, path);
                // TODO: Pending to change to: this.User.Identity.Name
                /* product.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);

                 try
                 {
                     await this.productRepository.CreateAsync(product);
                 }
                 catch (Exception ex)
                 {

                     return new GeneralErrorViewResult("GeneralError", ex.ToString());
                 }*/
                await this.eventosRepository.CreateAsync(product);


                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }








        private Evento ToEvento(EventosViewModel view, string path)
        {
            return new Evento
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








        [Authorize]
        // GET: Eventoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var product = await this.eventosRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            var view = this.ToEventoViewModel(product);

            return View(view);
        }

        private EventosViewModel ToEventoViewModel(Evento product)
        {

            return new EventosViewModel
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

        // POST: Eventoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventosViewModel view)
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
                            "wwwroot\\images\\Eventos",
                            file);



                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Eventos/{file}";
                    }

                    var product = this.ToEvento(view, path);

                    // TODO: Pending to change to: this.User.Identity.Name
                    //product. = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await this.eventosRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.eventosRepository.ExistAsync(view.Id))
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

        // GET: Eventoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
