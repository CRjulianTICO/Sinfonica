using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public interface IPersona
    {
        String Nombre { get; set; }

        String PrimerApellido { get; set; }

        String SegundoApellido { get; set; }

        Int32 Telefono { get; set; }

        String Correo { get; set; }

        Boolean Estado { get; set; }
    }
}
