using Microsoft.AspNetCore.Mvc.Rendering;
using Sinfonica.Web.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboPuestos()
        {
            var list = _dataContext.Puestos.Select(pt => new SelectListItem
            {
                Text = pt.Nombre,
                Value = $"{pt.Id}"
            })
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un puesto...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboDepartamentos()
        {
            var list = _dataContext.Departamentos.Select(pt => new SelectListItem
            {
                Text = pt.NombreDepartamento,
                Value = $"{pt.Id}"
            })
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un departamento...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboProgramas()
        {
            var list = _dataContext.Programas.Select(p => new SelectListItem
            {
                Text = p.Nombre,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccioneun programa...)",
                Value = "0"
            });

            return list;
        }


        public IEnumerable<SelectListItem> GetComboPruebas()
        {
            var list = _dataContext.Pruebas.Select(p => new SelectListItem
            {
                Text = p.Titulo,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione una Prueba...)",
                Value = "0"
            });

            return list;
        }




        public IEnumerable<SelectListItem> GetComboDirectors()
        {
            var list = _dataContext.Directors.Select(p => new SelectListItem
            {
                Text = p.Nombre,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Director...)",
                Value = "0"
            });

            return list;
        }



        public IEnumerable<SelectListItem> GetComboCatedras()
        {
            var list = _dataContext.Catedras.Select(p => new SelectListItem
            {
                Text = p.NombreCatedra,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione una Catedra...)",
                Value = "0"
            });

            return list;
        }



        public IEnumerable<SelectListItem> GetComboConjuntosDelDirector(int ownerId)
        {
            var list = _dataContext.Conjuntos.Where(p => p.Director.Id == ownerId).Select(p => new SelectListItem
            {
                Text = p.NombreConjunto,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un conjunto...)",
                Value = "0"
            });

            return list;
        }





        public IEnumerable<SelectListItem> GetComboProfesores()
        {
            var list = _dataContext.Profesors.Select(p => new SelectListItem
            {
                Text = p.NombreCompleto,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Profesor...)",
                Value = "0"
            });

            return list;
        }




        public IEnumerable<SelectListItem> GetComboCursos()
        {
            var list = _dataContext.Curso.Select(p => new SelectListItem
            {
                Text = p.NombreCurso,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Curso...)",
                Value = "0"
            });

            return list;
        }






    }
}
