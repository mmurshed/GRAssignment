using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using GRAssignment.IO;
using System.Net;
using System.Text;
using GRAssignment.DataStructure;
using Newtonsoft.Json;

namespace GRAssignment.GRPersonService.NUnit
{
  [TestFixture]
  public class GRPersonServiceTest
  {
    [TestCase("gender", "001G.csv")]
    [TestCase("birthdate", "001DOB.csv")]
    [TestCase("name", "001LN.csv")]
    public void TestGet(string localurl, string expectedFile)
    {
      // Arrange
      var url = new Uri(GRTestConst.URL, localurl);
      HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create(url);
      GETRequest.Method = "GET";

      expectedFile = Path.Combine(GRTestConst.EXPECTED_DIR, expectedFile);
      var personsExpected = PersonReader.ReadFile(expectedFile, ',');

      // Act
      HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
      Stream GETResponseStream = GETResponse.GetResponseStream();

      var persons = Deserialize< List<Person> >(GETResponseStream);

      // Assert
      Assert.IsTrue(persons.SequenceEqual(personsExpected.List));
    }

    private static object[] TestPerson =
    {
      new object[] {
@"Obama,Barak,Male,NavyBlue,8/4/1961
Clinton,Hillary,Female,Pink,10/26/1947" }
    };
  
    [TestCaseSource(nameof(TestPerson))]
    public static void TestPost(string persons)
    {
      // Arrange
      // Backup data
      File.Copy(PersonService.PERSONFILE, GRTestConst.BACKUPFILE, true);

      var url = GRTestConst.URL;
      byte[] dataByte = Encoding.ASCII.GetBytes(persons); ;

      HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(url);
      POSTRequest.Method = "POST";
      POSTRequest.KeepAlive = false;
      POSTRequest.Timeout = 5000;
      POSTRequest.ContentLength = dataByte.Length;

      // Get the request stream
      Stream POSTstream = POSTRequest.GetRequestStream();
      // Write the data bytes in the request stream
      POSTstream.Write(dataByte, 0, dataByte.Length);

      // Act
      HttpWebResponse POSTResponse = (HttpWebResponse)POSTRequest.GetResponse();

      // Assert
      Assert.IsTrue(POSTResponse.StatusCode == HttpStatusCode.OK);

      var personsExpected = PersonReader.ReadFile(PersonService.PERSONFILE, ',');
      var newPersons = PersonReader.Read(dataByte, ',');
      var expectedPos = personsExpected.List.Count - newPersons.List.Count;
      for (var i = 0; i < newPersons.List.Count; i++)
      {
        Assert.AreEqual(newPersons.List[i], personsExpected.List[expectedPos + i]);
      }

      // Restore data from backup
      File.Copy(GRTestConst.BACKUPFILE, PersonService.PERSONFILE, true);
    }

    /// <summary>
    /// Function to deserialze a http stream
    /// </summary>
    /// <typeparam name="T">The type name to deserialize</typeparam>
    /// <param name="stream">The stream to desearilize from</param>
    /// <returns>The deserialized type</returns>
    public static T Deserialize<T>(Stream stream)
    {
      var serializer = new JsonSerializer();
      T data;
 
      using (var streamReader = new StreamReader(stream))
      {
        data = (T) serializer.Deserialize(streamReader, typeof(T));
      }
      return data;
    }
  }
}
