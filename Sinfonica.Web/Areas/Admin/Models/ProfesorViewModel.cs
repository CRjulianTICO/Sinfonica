using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Models
{
    public class ProfesorViewModel:Profesor
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Catedra..")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Catedra.")]
        public int CatedrasId { get; set; }

        public IEnumerable<SelectListItem> Catedrass { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Departamento..")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Departamento.")]
        public int DepartamenosId { get; set; }

        public IEnumerable<SelectListItem> Departaments { get; set; }


        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
