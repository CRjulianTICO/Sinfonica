﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Data.Entities
{
    public class Evento : IEntity
    {
        public int Id { get; set; }

        public String Titulo { get; set; }

        public String Encabezado { get; set; }

        public String Informacion { get; set; }

        public String Descripcion { get; set; }

        public DateTime Fecha { get; set; }

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
