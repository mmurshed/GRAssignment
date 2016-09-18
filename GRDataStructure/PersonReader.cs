using System;
using GRAssignment.DataStructure;
using System.IO;

namespace GRAssignment.IO
{
  /// <summary>
  /// A class to read Person information from a
  /// delimited file
  /// </summary>
  public static class PersonReader
  {
    /// <summary>
    /// Read a delimited string and create
    /// a Person object from it.
    /// </summary>
    /// <param name="line">A delimited string</param>
    /// <param name="delimeter">The delimiter</param>
    /// <returns>A Person object constructed from the string</returns>
    public static Person ReadLine(string line, char delimeter)
    {
      var values = line.Split(delimeter);

      if (values.Length < 5)
        return null;

      Person person = new Person(
        LastName: values[0].Trim(),
        FirstName: values[1].Trim(),
        Gender: values[2].Trim(),
        FavoriteColor: values[3].Trim(),
        DateOfBirth: values[4].Trim()
      );
      return person;
    }

    /// <summary>
    /// Read a delimited file and create a list of Persons
    /// </summary>
    /// <param name="fileName">The file to read from</param>
    /// <param name="delimeter">The delimiter</param>
    /// <returns>A collection of Persons</returns>
    public static Persons ReadFile(string fileName, char delimeter)
    {
      var persons = new Persons();

      var reader = new StreamReader(File.OpenRead(fileName));

      while (!reader.EndOfStream)
      {
        var person = ReadLine(reader.ReadLine(), delimeter);
        persons?.Add(person);
      }
      reader.Close();

      return persons;
    }
  }
}
