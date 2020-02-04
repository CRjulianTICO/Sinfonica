using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Sinfonica.Web.Areas.Admin.Data;
using Sinfonica.Web.Areas.Admin.Data.Entities;

namespace Sinfonica.Web.Areas.User.Pagination
{
    public class NoticiaService : INoticiaService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly DataContext _context;

        public NoticiaService(IHostingEnvironment hostingEnvironment, DataContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }


        public async Task<List<Noticia>> GetData()
        {
            var noticia = await _context.Noticias.ToListAsync();

            return noticia;
        }

        public async Task<List<Noticia>> GetPaginatedResult(int currentPage, int pageSize = 10)
        {
            var data = await GetData();

            return data.OrderBy(p => p.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        }

         


        public async Task<int> GetCount()
        {
            var data = await GetData();
            return data.Count;
        }

       
    }
}
