using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Repositories
{
    public class PruebaRepository : GenericRepository<Prueba>, IPruebaRepository

    {
        private readonly DataContext context;

        public PruebaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }


    }
}
