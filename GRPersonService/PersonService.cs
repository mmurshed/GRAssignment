using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GRAssignment.GRPersonService
{
  public class PersonService : IHttpHandler
  {
    bool IHttpHandler.IsReusable
    {
        get { return true; }
    }
    void IHttpHandler.ProcessRequest(HttpContext context)
    {
      try
      {
        switch(context.Request.HttpMethod)
        {
          case "GET":
            GetPersons(context);
            break;
          case "POST":
            CreatePerson(context);
            break;
        }
      }
      catch (Exception ex)
      {
        context.Response.Write(ex.Message);
      }
    }

    private void CreatePerson(HttpContext context)
    {
    }

    private void GetPersons(HttpContext context)
    {
    }
  }
}
