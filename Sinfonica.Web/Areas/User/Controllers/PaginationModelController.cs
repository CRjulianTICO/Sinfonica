using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Pagination
{
    public class PaginationModelController: PageModel
    {
        private readonly INoticiaService _noticiaService;

        public PaginationModelController(INoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        [BindProperty(SupportsGet = true)]
        //Pagina actual con un valor por defecto de 1
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<Noticia> Data { get; set; }

        public async Task OnGetAsync()
        {
            Data = await _noticiaService.GetPaginatedResult(CurrentPage, PageSize);
            Count = await _noticiaService.GetCount();
        }

        /*
        public async Task<IActionResult> Index()
        {

            var view = from progra in await _context.Noticias.ToListAsync() where progra.Estado == true select progra;

            var pagination = _paginationModel.OnGetAsync();
            return View(pagination);
        }
        */


    }
}
