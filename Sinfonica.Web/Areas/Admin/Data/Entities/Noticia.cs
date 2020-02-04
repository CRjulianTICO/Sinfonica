using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Noticia : IEntity
    {
        public int Id { get; set; }
        [Required]
        public String Titulo { get; set; }
        [Required]
        public String Encabezado { get; set; }
        [Required]
        public String Informacion { get; set; }
        [Required]
        public String Descripcion { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public Boolean Estado { get; set; }

        public string MonthName
        {
            get
            {
                String mes = Fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));

                mes = char.ToUpper(mes[0]) + mes.Substring(1);
                mes = mes.TrimEnd('.');

                return mes;
            }
        }

        public string MonthShortName
        {
            get
            {
                String mes = Fecha.ToString("MMM", CultureInfo.CreateSpecificCulture("es"));

                mes = char.ToUpper(mes[0]) + mes.Substring(1);
                mes = mes.TrimEnd('.');

                return mes;
            }
        }

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

