using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Pagination
{
    public interface INoticiaService
    {
        Task<List<Noticia>> GetPaginatedResult(int currentPage, int pageSize = 10);
        Task<int> GetCount();
    }
}
