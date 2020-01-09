using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Costo : IEntity
    {
        public int Id { get; set; }
        [Required]
        public Programa Programas { get; set; }
        [Required]
        public Double Costo1Semestre { get; set; }
        [Required]
        public Double Costo2Semestre { get; set; }
        [Required]
        public Double Matricula { get; set; }
        [Required]
        public DateTime FechaLim1Sem { get; set; }
        [Required]
        public DateTime FechaLim2Sem { get; set; }
        [Required]
        public String Informacion { get; set; }


    }
}
