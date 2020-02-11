using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Correo:IEntity
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public String Mensaje { get; set; }
        
    }
}
