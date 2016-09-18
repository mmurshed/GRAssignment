using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using GRAssignment.IO;
using System.Net;
using GRAssignment.DataStructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
