using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Institucion : IEntity
    {
        public int Id { get; set; }
        [Required]
        public String Bienvenida { get; set; }
        [Required]
        public String Organizacion { get; set; }
        [Required]
        public String Estudia { get; set; }
        [Required]
        public String Informacion { get; set; }
        [Required]
        public String Mision { get; set; }
        [Required]
        public String Vision { get; set; }
        [Required]
        public String Historia { get; set; }
        [Required]
        public String Instituto { get; set; }

    }
}
