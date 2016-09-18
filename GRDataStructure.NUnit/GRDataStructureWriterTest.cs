using System.IO;
using System.Linq;
using NUnit.Framework;
using GRAssignment.IO;

namespace GRAssignment.GRDataStructure.NUnit
{
  [TestFixture]
  public class GRDataStructureWriterTest
  {
    [TestCase("001.csv", GRTestConst.COMMA, "001.csv", GRTestConst.COMMA, "001G.csv")]
    [TestCase("001s.txt", GRTestConst.SPACE, "001s.txt", GRTestConst.SPACE, "001G.csv")]
    [TestCase("001p.txt", GRTestConst.PIPE, "001p.txt", GRTestConst.PIPE, "001G.csv")]
    public void TestWriter(string inputFile, char inputSeparator, string outputFile, char outputSeparator, string expectedFile)
    {
      // Arrange
      inputFile = Path.Combine(GRTestConst.INPUT_DIR, inputFile);
      expectedFile = Path.Combine(GRTestConst.EXPECTED_DIR, expectedFile);
      outputFile = Path.Combine(GRTestConst.OUTPUT_DIR, outputFile);
      var persons = PersonReader.ReadFile(inputFile, inputSeparator);
      var personsExpected = PersonReader.ReadFile(expectedFile, ',');

      // Act
      persons.SortByGender();
      PersonWriter.WriteToFile(outputFile, persons, outputSeparator);
      var outputPersons = PersonReader.ReadFile(outputFile, outputSeparator);

      // Assert
      Assert.IsTrue(outputPersons.List.SequenceEqual(personsExpected.List));
    }
  }
}
