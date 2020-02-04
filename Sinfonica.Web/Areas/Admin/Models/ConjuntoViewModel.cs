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
    public class ConjuntoViewModel:Conjunto
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Director..")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a puesto.")]
        public int DirectorsId { get; set; }

        public IEnumerable<SelectListItem> Directors { get; set; }


        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
