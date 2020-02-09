using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data.Entities
{
    public class Prueba : IEntity
    {
        public int Id { get; set; }
        [Required]
        public String Titulo { get; set; }
        [Required]
        public String Encabezado { get; set; }
        [Required]
        public String Descripcion { get; set; }
        [Required]
        public String Informacion { get; set; }
        [Required]
        public DateTime PrimeraFecha { get; set; }
        
        public DateTime? SegundaFeacha { get; set; }

        public DateTime? TerceraFecha { get; set; }


        public string MonthName1Fecha
        {
            get
            {
                String mes = PrimeraFecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));

                mes = char.ToUpper(mes[0]) + mes.Substring(1);
                mes = mes.TrimEnd('.');

                return mes;
            }
        }


        public string AMPMFecha
        {
            get
            {
                String mes = PrimeraFecha.ToString("tt", CultureInfo.InvariantCulture);

                return mes;
            }
        }

        public string AMPM2Fecha
        {
            get
            {
                String mes = null;

                if (SegundaFeacha != null)
                {
                   mes = SegundaFeacha.Value.ToString("tt", CultureInfo.InvariantCulture);
                }
                

                return mes;
            }
        }

        public string AMPM3Fecha
        {
            get
            {

                String mes = null;

                if (TerceraFecha !=null)
                {
                     mes = TerceraFecha.Value.ToString("tt", CultureInfo.InvariantCulture);

                }

                

                return mes;
            }
        }


        public string MonthName2Fecha
        {
            get
            {
                String mes = null;
                if (SegundaFeacha != null)
                {
                     mes = SegundaFeacha.Value.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));

                    mes = char.ToUpper(mes[0]) + mes.Substring(1);
                    mes = mes.TrimEnd('.');
                }
                

                return mes;
            }
        }

        public string MonthName3Fecha
        {
            get
            {

                String mes = null;

                if (TerceraFecha!= null)
                {
                    DateTime fecha = TerceraFecha.Value;

                     mes = fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));

                    mes = char.ToUpper(mes[0]) + mes.Substring(1);
                    mes = mes.TrimEnd('.');
                }

                

                return mes;
            }
        }

        


        public ICollection<Ingreso> Ingresos { get; set; }

    }
}
