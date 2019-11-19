using Sinfonica.Web.Areas.User.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Helpers
{
    public interface IConvertEntity
    {
        Departamento ConvertDepartamento( Sinfonica.Web.Areas.User.Data.Entities.Departamento departamento);
        Catedra ConvertCatedra(Sinfonica.Web.Areas.User.Data.Entities.Catedra catedra);

    }
}
