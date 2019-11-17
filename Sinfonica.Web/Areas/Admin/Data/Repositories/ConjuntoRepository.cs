using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Repositories
{
    public class ConjuntoRepository: GenericRepository<Conjunto>, IConjuntoRepository
    {
        private readonly DataContext context;

        public ConjuntoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
