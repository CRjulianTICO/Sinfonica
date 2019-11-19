using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Data.Entities
{
    public class ProfesorCurso
    {
        public ProfesorCurso()
        {

        }

        //[Key, Column(Order = 0)]
        public int ProfesorId { get; set; }
        //[Key, Column(Order = 1)]
        public int CursosId { get; set; }

        public Profesor Profesors { get; set; }
        public Curso Cursos { get; set; }
    }
}
