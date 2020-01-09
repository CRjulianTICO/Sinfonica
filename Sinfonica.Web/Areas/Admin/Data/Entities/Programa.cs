﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Programa : IEntity
    {
       
        public int Id { get; set; }

        [Required]
        public String Nombre { get; set; }
        [Required]
        public String Informacion { get; set; }
        [Required]
        public Boolean Estado { get; set; }

        public ICollection<Costo> Costos { get; set; }

    }
}
