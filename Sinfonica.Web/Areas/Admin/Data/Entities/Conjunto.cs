using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Conjunto:IEntity
    {
        public int Id { get; set; }

        public Director Director { get; set; }

        public String NombreConjunto { get; set; }

        public String Informacion { get; set; }

        public Boolean Estado { get; set; }
    }
}
