﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Models
{
    public class CostosViewModel:Costo
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Programa..")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes escoger un programa.")]
        public int ProgramasId { get; set; }

        public IEnumerable<SelectListItem> Programs { get; set; }


   

        public int SelectedParameter { get; set; }

        public String PartialView { get; set; }



    }
}

