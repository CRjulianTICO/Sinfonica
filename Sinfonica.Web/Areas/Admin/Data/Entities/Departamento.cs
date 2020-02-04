using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Departamento : IEntity
    {
        public int Id { get; set; }
        [Required]
        public String NombreDepartamento { get; set; }
        [Required]
        public String Informacion { get; set; }
        [Required]
        public Boolean Estado { get; set; }

        public ICollection<Catedra> Catedras { get; set; }

        public ICollection<Profesor> Profesors { get; set; }
    }
}
