using Sinfonica.Web.Areas.User.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Sinfonica.Web.Areas.User.Models
{
    public class EmpleadoViewModel:Empleado
    {

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Pet Type")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a puesto.")]
        public int PuestosId { get; set; }

        public IEnumerable<SelectListItem> Puestos { get; set; }


    }
}
