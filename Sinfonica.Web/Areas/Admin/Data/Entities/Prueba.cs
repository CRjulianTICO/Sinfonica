using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Prueba : IEntity
    {
        public int Id { get; set; }
        [Required]
        public String Titulo { get; set; }
        [Required]
        public String Encabezado { get; set; }
        [Required]
        public String Descripcion { get; set; }
        [Required]
        public String Informacion { get; set; }
        [Required]
        public DateTime PrimeraFecha { get; set; }
        
        public DateTime? SegundaFeacha { get; set; }

        public DateTime? TerceraFecha { get; set; }
        

        public ICollection<Ingreso> Ingresos { get; set; }

    }
}
