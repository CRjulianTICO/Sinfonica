using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Prueba : IEntity
    {
        public int Id { get; set; }

        public String Titulo { get; set; }

        public String Encabezado { get; set; }

        public String Descripcion { get; set; }

        public String Informacion { get; set; }

        public DateTime PrimeraFecha { get; set; }

        public DateTime? SegundaFeacha { get; set; }

        public DateTime? TerceraFecha { get; set; }

        public ICollection<Ingreso> Ingresos { get; set; }

    }
}
