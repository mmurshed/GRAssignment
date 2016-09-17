using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GRAssignment.ConsoleApp.DataStructure;
using GRAssignment.ConsoleApp.IO;

namespace GRAssignment.GRPersonService
{
  public class PersonService : IHttpHandler
  {
    private readonly string PERSONFILE = @"C:\Source\GRAssignment\Input\persons.csv";

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
      Uri uri = context.Request.Url;
      var pathSegments = uri.Segments;
      if (pathSegments.Length < 4)
        return;
      if (pathSegments[2].Equals("records/") == false)
        return;

      var persons = GetPersons();
      if ( pathSegments[3].Equals("gender") )
      {
        persons.Sort(new GenderComparer());
      }
      else if (pathSegments[3].Equals("birthdate"))
      {
        persons.Sort((x, y) => -1 * x.DateOfBirth.CompareTo(y.DateOfBirth));
      }
      else if (pathSegments[3].Equals("name"))
      {
        persons.Sort((x, y) => -1 * x.LastName.CompareTo(y.LastName));
      }

      MemoryStream memoryStream = new MemoryStream();
      DataContractJsonSerializer dcSer = new DataContractJsonSerializer(typeof(List<Person>));

      dcSer.WriteObject(memoryStream, persons);

      memoryStream.Position = 0;
      StreamReader sr = new StreamReader(memoryStream);
      var serializedString = sr.ReadToEnd();
      context.Response.ContentType = "application/json";
      context.Response.Write(serializedString);
    }

    private List<Person> GetPersons()
    {
      return PersonReader.ReadFile(PERSONFILE, ',');
    }
  }
}
