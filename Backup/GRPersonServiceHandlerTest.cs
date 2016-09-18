using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using GRAssignment.IO;
using System.Net;
using System.Web;
using System.Web.Hosting;
using GRAssignment.DataStructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using GRAssignment.GRPersonService;
using System.Text;

namespace GRAssignment.GRPersonService.NUnit
{
  [TestFixture]
  public class GRPersonServiceHandlerTest
  {
    [TestCase("gender", "001G.csv")]
    [TestCase("birthdate", "001DOB.csv")]
    [TestCase("name", "001LN.csv")]
    public void TestGet(string localurl, string expectedFile)
    {
      var pservice = new PersonService();
      SendRequest(null, localurl, string.Empty);
      // Arrange
      //SimpleWorkerRequest testRequest = new SimpleWorkerRequest("", "", "", null, new StringWriter());
      //HttpContext testContext = new HttpContext(testRequest);
      //// testContext.Response.Filter = new OutputFilterStream(testContext.Response.Filter);

      //// Act
      //var handler = new PersonService();
      //handler.ProcessRequest(testContext);
      //testContext.Response.End();//end request here(if it is not done in your Handler)

      //// Assert
      //var result = ((OutputFilterStream)testContext.Response.Filter).ReadStream();
      //Assert.AreEqual("Hello World", result);

      //// Arrange
      //var url = new Uri(GRTestConst.URL, localurl);
      //HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create(url);
      //GETRequest.Method = "GET";

      //expectedFile = Path.Combine(GRTestConst.EXPECTED_DIR, expectedFile);
      //var personsExpected = PersonReader.ReadFile(expectedFile, ',');

      //// Act
      //HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
      //Stream GETResponseStream = GETResponse.GetResponseStream();

      //var persons = Deserialize< List<Person> >(GETResponseStream);

      //// Assert
      //Assert.IsTrue(persons.SequenceEqual(personsExpected.List));
    }

    protected string SendRequest(IHttpHandler handler, string localUrl, string queryString)
    {
      StringBuilder output = new StringBuilder();
      using (StringWriter sw = new StringWriter(output))
      {
        HttpResponse response = new HttpResponse(sw);
        HttpRequest request = new HttpRequest(localUrl, GRTestConst.URL + localUrl, queryString);
        HttpContext context = new HttpContext(request, response);
        handler.ProcessRequest(context);
      }
      return output.ToString();
    }

    //private static object[] TestPerson =
    //{
    //  new object[] {new Person(LastName: "Obama", FirstName: "Barak", Gender: "Male", FavoriteColor: "NavyBlue", DateOfBirth: "8/4/1961") }
    //};

    //[TestCaseSource(nameof(TestPerson))]
    //public static void TestPost(Person person)
    //{
    //  // Arrange
    //  var url = new Uri(GRTestConst.URL, "?data=" + PersonWriter.WriteLine(person, ','));
    //  HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(url);
    //  POSTRequest.Method = "POST";
    //  POSTRequest.KeepAlive = false;
    //  POSTRequest.Timeout = 5000;
    //  POSTRequest.ContentLength = 0;

    //  // Act
    //  HttpWebResponse POSTResponse = (HttpWebResponse)POSTRequest.GetResponse();

    //  // Assert
    //  Assert.IsTrue(POSTResponse.StatusCode == HttpStatusCode.OK);
    //  var personsExpected = PersonReader.ReadFile(PersonService.PERSONFILE, ',');
    //  Assert.AreEqual(person, personsExpected.List[personsExpected.List.Count-1]);

    //  // Restore data from backup
    //  File.Copy(@"C:\Source\GRAssignment\Input\persons.bak", PersonService.PERSONFILE, true);
    //}


    //public static T Deserialize<T>(Stream stream)
    //{
    //  var serializer = new JsonSerializer();
    //  T data;

    //  using (var streamReader = new StreamReader(stream))
    //  {
    //    data = (T) serializer.Deserialize(streamReader, typeof(T));
    //  }
    //  return data;
    //}
  }
}
