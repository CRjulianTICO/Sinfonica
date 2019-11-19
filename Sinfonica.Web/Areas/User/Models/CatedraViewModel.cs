using Microsoft.AspNetCore.Mvc.Rendering;
using Sinfonica.Web.Areas.User.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Models
{
    public class CatedraViewModel:Catedra
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Departamento..")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Departamento.")]
        public int DepartamenosId { get; set; }

        public IEnumerable<SelectListItem> Departaments { get; set; }
    }
}
