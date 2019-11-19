using Sinfonica.Web.Areas.Admin.Data;
using Sinfonica.Web.Areas.User.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Data.Repositories
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository

    {
        private readonly DataContext context;

        public EmpleadoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }

}
