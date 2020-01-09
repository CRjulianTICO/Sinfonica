
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
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
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string PrimerApellido { get; set; }
        [Required]
        public string SegundoApellido { get; set; }
        [Required]
        public int Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public bool Estado { get; set; }

        public String NombreCompleto { get { return $"{this.Nombre} {this.PrimerApellido} {this.SegundoApellido}"; } }


        [Display(Name = "Image")]
        public string ImageUrl
        {
            get;
            set;
        }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }
                return $"https://xaesw.azurewebsites.net{this.ImageUrl.Substring(1)}";
            }
        }


    }

}

