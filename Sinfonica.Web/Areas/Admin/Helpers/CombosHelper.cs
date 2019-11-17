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
                Text = "[Select a pet type...]",
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
                Text = "[Select a service type...]",
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
                Text = "(Select an owner...)",
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


        public IEnumerable<SelectListItem> GetComboPets(int ownerId)
        {
            var list = _dataContext.Conjuntos.Where(p => p.Director.Id == ownerId).Select(p => new SelectListItem
            {
                Text = p.NombreConjunto,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a pet...)",
                Value = "0"
            });

            return list;
        }

    }
}
