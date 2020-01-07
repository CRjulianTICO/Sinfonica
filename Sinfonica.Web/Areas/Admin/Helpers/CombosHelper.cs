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
            var al = from obj in _dataContext.Puestos.ToList() where obj.Estado == true select obj;
            var list = al.Select(pt => new SelectListItem
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

            var al = from obj in _dataContext.Departamentos.ToList() where obj.Estado == true select obj;

            var list = al.Select(pt => new SelectListItem
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

            var al = from obj in _dataContext.Programas.ToList() where obj.Estado == true select obj;
            var list = al.Select(p => new SelectListItem
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
            var al = _dataContext.Pruebas.ToList();
            var list = al.Select(p => new SelectListItem
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
            var al = from obj in _dataContext.Directors.ToList() where obj.Estado == true select obj;

            var list = al.Select(p => new SelectListItem
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

            var al = from obj in _dataContext.Catedras.ToList() where obj.Estado == true select obj;
            var list = al.Select(p => new SelectListItem
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
            var al = from obj in _dataContext.Conjuntos.ToList() where obj.Estado == true select obj;
            var list = al.Where(p => p.Director.Id == ownerId).Select(p => new SelectListItem
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
            var al = from obj in _dataContext.Profesors.ToList() where obj.Estado == true select obj;
            var list = al.Select(p => new SelectListItem
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
            var list = _dataContext.Curso.Where(p => p.Estado == true).Select(p => new SelectListItem
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
