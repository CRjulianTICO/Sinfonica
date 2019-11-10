using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Profesor : IEntity, IPersona
    {

        /*  public Profesor()
          {
              this.ProfesorCursos = new List<ProfesorCurso>();
          }*/
        public int Id { get; set; }

        public Catedra Catedras { get; set; }

        public Departamento Departamentos { get; set; }

        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
        public String Informacion { get; set; }

        public List<ProfesorCurso> ProfesorCursos { get; set; }




    }
}
