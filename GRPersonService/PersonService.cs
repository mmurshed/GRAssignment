using System;
using System.Web;
using GRAssignment.IO;
using Newtonsoft.Json;

namespace GRAssignment.GRPersonService
{
  /// <summary>
  /// The HTTP Handler service class
  /// </summary>
  public class PersonService : IHttpHandler
  {
    /// <summary>
    /// The data store, A comma seperated file.
    /// </summary>
    public static readonly string PERSONFILE = @"C:\Source\GRAssignment\Input\persons.csv";

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

    /// <summary>
    /// Read data from data store and 
    /// return correctly sorted Person
    /// record.
    /// For the path segment, return
    /// gender: gender sorted records
    /// birthdate: birthdate sorted records
    /// name: last name sorted records
    /// </summary>
    /// <param name="context">The HTTP context</param>
    private void GetPersons(HttpContext context)
    {
      Uri uri = context.Request.Url;
      var pathSegments = uri.Segments;
      if (pathSegments.Length < 4)
        return;
      if (pathSegments[2].Equals("records/") == false)
        return;

      var persons = PersonReader.ReadFile(PERSONFILE, ',');
      if ( pathSegments[3].Equals("gender") )
        persons.SortByGender();
      else if (pathSegments[3].Equals("birthdate"))
        persons.SortByDateOfBirth();
      else if (pathSegments[3].Equals("name"))
        persons.SortByLastName();
      else
        return;

      context.Response.ContentType = "application/json";
      context.Response.Write(JsonConvert.SerializeObject(persons.List));
    }

    /// <summary>
    /// Create a Person object from the comma
    /// separated POST request and store in the
    /// Text file
    /// </summary>
    /// <param name="context">The HTTP context</param>
    private void CreatePerson(HttpContext context)
    {
      var data = context.Request["data"];
      var person = PersonReader.ReadLine(data, ',');

      var persons = PersonReader.ReadFile(PERSONFILE, ',');
      persons.Add(person);
      PersonWriter.WriteToFile(PERSONFILE, persons, ',');
    }
  }
}
