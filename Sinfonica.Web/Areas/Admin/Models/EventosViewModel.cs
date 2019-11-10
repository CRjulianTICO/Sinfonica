using Microsoft.AspNetCore.Http;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Models
{
    public class EventosViewModel : Evento
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
