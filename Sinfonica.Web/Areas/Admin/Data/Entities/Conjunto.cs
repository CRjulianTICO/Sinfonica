using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Conjunto:IEntity
    {
        public int Id { get; set; }

        public Director Director { get; set; }
        [Required]
        public String NombreConjunto { get; set; }
        [Required]
        public String Informacion { get; set; }
        [Required]
        public Boolean Estado { get; set; }



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
