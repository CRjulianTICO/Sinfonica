using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Data.Entities
{
    public class Institucion : IEntity
    {
        public int Id { get; set; }

        public String Bienvenida { get; set; }

        public String Organizacion { get; set; }

        public String Estudia { get; set; }

        public String Informacion { get; set; }

        public String Mision { get; set; }

        public String Vision { get; set; }

        public String Historia { get; set; }

        public String Instituto { get; set; }

    }
}
