using Microsoft.AspNetCore.Mvc.Rendering;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Models
{
    public class ProfesorCursoViewModel: ProfesorCurso
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Profesor..")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Profesor.")]
        public int ProfesorsId { get; set; }

        public IEnumerable<SelectListItem> Profesores { get; set; }


        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Curso..")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Curso.")]
        public int CursossId { get; set; }

        public IEnumerable<SelectListItem> Cursoss { get; set; }
    }
}
