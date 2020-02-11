using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Ingreso : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Antes de Aplicar")]
        public String AntesAplicar { get; set; }

        [Required]
        [Display(Name = "Requisitos para Nacionales")]
        public String RequisitosNacionales { get; set; }
        [Required]
        [Display(Name = "Requisitos para Extranjeros")]
        public String RequisitosExtranjeros { get; set; }
        [Required]
        [Display(Name = "Enlace del Formulario")]
        public String Formulario { get; set; }

        public Prueba Pruebas { get; set; }


    }
}
