using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboPuestos();

        IEnumerable<SelectListItem> GetComboDepartamentos();

        IEnumerable<SelectListItem> GetComboProgramas();

        IEnumerable<SelectListItem> GetComboPets(int ownerId);

        IEnumerable<SelectListItem> GetComboDirectors();
    }
}
