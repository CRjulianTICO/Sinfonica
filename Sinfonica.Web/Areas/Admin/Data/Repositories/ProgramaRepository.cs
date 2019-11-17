using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Repositories
{
    public class ProgramaRepository : GenericRepository<Programa>, IProgramaRepository
    {
        private readonly DataContext context;

        public ProgramaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
