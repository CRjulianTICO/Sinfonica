using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Director : IEntity, IPersona
    {
        public int Id { get; set; }
        //public Persona Persona { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
        public String Informacion { get; set; }
        public String Estudios { get; set; }

        [Display(Name = "Trayectoria")]
        public String Carrera { get; set; }

        [Display(Name = "Fecha de Nacimiento: (MM/DD/AAAA)")]
        public DateTime FechaNacimiento { get; set; }


        public String NombreCompleto { get { return $"{this.Nombre} {this.PrimerApellido} {this.SegundoApellido}"; } }

        public ICollection<Conjunto> Conjuntos { get; set; }


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


        public string MonthName
        {
            get
            {
                String mes = FechaNacimiento.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));

                mes = char.ToUpper(mes[0]) + mes.Substring(1);
                mes = mes.TrimEnd('.');

                return mes;
            }
        }

        public string MonthShortName
        {
            get
            {
                String mes = FechaNacimiento.ToString("MMM", CultureInfo.CreateSpecificCulture("es"));

                mes = char.ToUpper(mes[0]) + mes.Substring(1);
                mes = mes.TrimEnd('.');

                return mes;
            }
        }



    }
}
