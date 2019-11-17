using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Repositories
{
    public class InstitucionRepository : GenericRepository<Institucion>, IInsititucionRepository

    {
        private readonly DataContext context;

        public InstitucionRepository(DataContext context) : base(context)
        {
            this.context = context;
        }


    }
}
