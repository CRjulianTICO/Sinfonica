﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Data.Entities
{
    public class Empleado : IEntity, IPersona
    {

        public int Id { get; set; }

        //
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Puesto Puestos { get; set; }
        //
        //[ForeignKey("PuestoFK")]
        //public int PuestosId { get; set; }

        // public Persona Persona { get; set; }

        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }

        public String NombreCompleto { get { return $"{this.Nombre} {this.PrimerApellido} {this.SegundoApellido}"; } }

    }
}
