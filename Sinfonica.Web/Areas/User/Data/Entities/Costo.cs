using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Data.Entities
{
    public class Costo : IEntity
    {
        public int Id { get; set; }

        public Programa Programas { get; set; }

        public Double Costo1Semestre { get; set; }

        public Double Costo2Semestre { get; set; }

        public Double Matricula { get; set; }

        public DateTime FechaLim1Sem { get; set; }

        public DateTime FechaLim2Sem { get; set; }

        public String Informacion { get; set; }


    }
}
