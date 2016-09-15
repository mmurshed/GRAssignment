using System.Linq;
using NUnit.Framework;
using GRAssignment.ConsoleApp.IO;
using GRAssignment.ConsoleApp.DataStructure;

namespace GRAssignment.ConsoleApp.NUnit
{
  [TestFixture]
  public class ConsoleAppTest
  {
    [TestCase(@"C:\Source\GRAssignment\Input\001.csv", ',', @"C:\Source\GRAssignment\Expected\001.csv")]
    public void TestGenderSort(string inputFile, char separator, string expectedFile)
    {
      var persons = PersonReader.ReadFile(inputFile, separator);

      persons.Sort(new GenderComparer());

      var personsExpected = PersonReader.ReadFile(expectedFile, ',');

      Assert.IsTrue(persons.SequenceEqual(personsExpected));

      //persons.Sort((x, y) => -1 * x.DateOfBirth.CompareTo(y.DateOfBirth));

      //persons.Sort((x, y) => -1 * x.LastName.CompareTo(y.LastName));
    }
  }
}
