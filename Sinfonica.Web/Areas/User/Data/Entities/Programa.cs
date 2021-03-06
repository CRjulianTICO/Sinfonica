﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Data.Entities
{
    public class Programa : IEntity
    {
        public int Id { get; set; }

        public String Nombre { get; set; }

        public String Informacion { get; set; }

        public Boolean Estado { get; set; }

        public ICollection<Costo> Costos { get; set; }

    }
}
