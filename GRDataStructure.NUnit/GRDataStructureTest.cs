using System.IO;
using System.Linq;
using NUnit.Framework;
using GRAssignment.IO;

namespace GRAssignment.GRDataStructure.NUnit
{
  /// <summary>
  /// A set of test to validate the reader and
  /// the sorting functions
  /// </summary>
  [TestFixture]
  public class GRDataStructureTest
  {
    /// <summary>
    /// Test the gender sorting
    /// </summary>
    /// <param name="inputFile">The name of the input file</param>
    /// <param name="separator">The character separator for the input file</param>
    /// <param name="expectedFile">The name of the expected file</param>
    [TestCase("001.csv", GRTestConst.COMMA, "001G.csv")]
    [TestCase("001s.txt", GRTestConst.SPACE, "001G.csv")]
    [TestCase("001p.txt", GRTestConst.PIPE, "001G.csv")]
    public void TestGenderSort(string inputFile, char separator, string expectedFile)
    {
      // Arrange
      inputFile = Path.Combine(GRTestConst.INPUT_DIR, inputFile);
      expectedFile = Path.Combine(GRTestConst.EXPECTED_DIR, expectedFile);
      var persons = PersonReader.ReadFile(inputFile, separator);
      var personsExpected = PersonReader.ReadFile(expectedFile, ',');

      // Act
      persons.SortByGender();

      // Assert
      Assert.IsTrue(persons.List.SequenceEqual(personsExpected.List));
    }

    /// <summary>
    /// Test the sorting by date of birth
    /// </summary>
    /// <param name="inputFile">The name of the input file</param>
    /// <param name="separator">The character separator for the input file</param>
    /// <param name="expectedFile">The name of the expected file</param>
    [TestCase("001.csv", GRTestConst.COMMA, "001DOB.csv")]
    [TestCase("001s.txt", GRTestConst.SPACE, "001DOB.csv")]
    [TestCase("001p.txt", GRTestConst.PIPE, "001DOB.csv")]
    public void TestDateOfBirthSort(string inputFile, char separator, string expectedFile)
    {
      // Arrange
      inputFile = Path.Combine(GRTestConst.INPUT_DIR, inputFile);
      expectedFile = Path.Combine(GRTestConst.EXPECTED_DIR, expectedFile);
      var persons = PersonReader.ReadFile(inputFile, separator);
      var personsExpected = PersonReader.ReadFile(expectedFile, ',');

      // Act
      persons.SortByDateOfBirth();

      // Assert
      Assert.IsTrue(persons.List.SequenceEqual(personsExpected.List));
    }

    /// <summary>
    /// Test the sorting by last name
    /// </summary>
    /// <param name="inputFile">The name of the input file</param>
    /// <param name="separator">The character separator for the input file</param>
    /// <param name="expectedFile">The name of the expected file</param>
    [TestCase("001.csv", GRTestConst.COMMA, "001LN.csv")]
    [TestCase("001s.txt", GRTestConst.SPACE, "001LN.csv")]
    [TestCase("001p.txt", GRTestConst.PIPE, "001LN.csv")]
    public void TestLastNameSort(string inputFile, char separator, string expectedFile)
    {
      // Arrange
      inputFile = Path.Combine(GRTestConst.INPUT_DIR, inputFile);
      expectedFile = Path.Combine(GRTestConst.EXPECTED_DIR, expectedFile);
      var persons = PersonReader.ReadFile(inputFile, separator);
      var personsExpected = PersonReader.ReadFile(expectedFile, ',');

      // Act
      persons.SortByLastName();

      // Assert
      Assert.IsTrue(persons.List.SequenceEqual(personsExpected.List));
    }
  }
}
