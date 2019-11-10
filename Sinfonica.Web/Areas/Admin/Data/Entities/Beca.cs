using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Beca:IEntity
    {
        public int Id { get; set; }

        public String Requisitos { get; set; }

        public String Informacion { get; set; }

    }
}
