using Microsoft.AspNetCore.Mvc.Rendering;
using Sinfonica.Web.Areas.User.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Models
{
    public class IngresoViewModel: Ingreso
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Prueba..")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una prueba.")]
        public int PruebasId { get; set; }

        public IEnumerable<SelectListItem> Pruebs { get; set; }
    }

}
