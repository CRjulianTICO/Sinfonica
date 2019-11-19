using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Curso : IEntity
    {

        /*
        public Curso()
        {
            this.ProfesorCursos = new List<ProfesorCurso>();
        }*/

        public int Id { get; set; }

        public String NombreCurso { get; set; }

        [Display(Name ="Codigo del Curso")]
        public String CondigoCurso { get; set; }


        public String Informacion { get; set; }

        public Boolean Estado { get; set; }

        public ICollection<ProfesorCurso> ProfesorCurso { get; set; }

    }
}
