using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Profesor : IEntity, IPersona
    {

        /*  public Profesor()
          {
              this.ProfesorCursos = new List<ProfesorCurso>();
          }*/
        public int Id { get; set; }

        public Catedra Catedras { get; set; }

        public Departamento Departamentos { get; set; }
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
        [Required]
        public String Informacion { get; set; }
        [Required]
        public String  Estudios { get; set; }


        [Display(Name = "Trayectoria")]
        [Required]
        public String  Carrera { get; set; }

        [Display(Name = "Fecha de Nacimiento: (MM/DD/AAAA)")]
        [Required]
        public DateTime FechaNacimiento { get; set; }


        public ICollection<ProfesorCurso> ProfesorCurso { get; set; }

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
