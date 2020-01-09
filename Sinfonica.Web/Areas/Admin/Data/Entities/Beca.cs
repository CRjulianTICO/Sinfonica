using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Beca:IEntity
    {
        public int Id { get; set; }
        [Required]
        public String Requisitos { get; set; }
        [Required]
        public String Informacion { get; set; }

    }
}
