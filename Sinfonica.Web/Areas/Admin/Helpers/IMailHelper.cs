using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Helpers
{
    public interface IMailHelper
    {
        void SendMail(string to, string subject, string body);
    }

}
