using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Contacto:IEntity
    {
        public int Id { get; set; }
        public String Email { get; set; }

        public String Password { get; set; }

        public String Host { get; set; }

        public int? Puerto { get; set; }
        
    }
}
