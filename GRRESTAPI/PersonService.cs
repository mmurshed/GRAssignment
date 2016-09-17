using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GRAssignment.GRRESTAPI
{
    public class PersonService : IHttpHandler
    {
      bool IHttpHandler.IsReusable
      {
        get { return true; }
      }
      void IHttpHandler.ProcessRequest(HttpContext context)
      {
      }
    }
}
