using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Catedra : IEntity
    {
        public int Id { get; set; }

        public Departamento Departamentos { get; set; }
        [Required]
        public String NombreCatedra { get; set; }
        [Required]
        public String Informacion { get; set; }
        [Required]
        public Boolean Estado { get; set; }

        public ICollection<Profesor> Profesors { get; set; }


    }
}
