using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinfonica.Web.Areas.User.Data.Entities;

namespace Sinfonica.Web.Areas.User.Helpers
{
    public class ConvertEntity : IConvertEntity
    {
        public Catedra ConvertCatedra(Sinfonica.Web.Areas.User.Data.Entities.Catedra catedra)
        {

            var obj = new Catedra
            {
                NombreCatedra = catedra.NombreCatedra,
                Estado = catedra.Estado,
                Departamentos = catedra.Departamentos,
                Id = catedra.Id,
                Informacion = catedra.Informacion
                
            };


            return obj;
        }

        public Departamento ConvertDepartamento(Sinfonica.Web.Areas.User.Data.Entities.Departamento departamento)
        {
            var obj = new Departamento
            {
                Id = departamento.Id,
                Informacion = departamento.Informacion,
                Estado = departamento.Estado,
                NombreDepartamento = departamento.NombreDepartamento
            };

            return obj;
        }
    }
}
