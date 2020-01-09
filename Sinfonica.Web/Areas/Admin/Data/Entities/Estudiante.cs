using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Estudiante : IEntity, IPersona
    {
        public int Id { get ; set ; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string PrimerApellido { get; set; }
        [Required]
        public string SegundoApellido { get; set; }
        [Required]
        public int Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public bool Estado { get; set; }

        public String NombreCompleto { get { return $"{this.Nombre} {this.PrimerApellido} {this.SegundoApellido}"; } }

        [Required]
        public String Carnet { get; set; }

        public ICollection<Acontecer> Acontecer { get; set; }

    }
}
