using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Puesto : IEntity
    {
        public int Id { get; set; }

        public ICollection<Empleado> Empleados { get; set; }

        public String Nombre { get; set; }

        public String Informacion { get; set; }

        public Boolean Estado { get; set; }
    }
}
