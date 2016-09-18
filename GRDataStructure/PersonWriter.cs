using System;
using System.Collections.Generic;
using GRAssignment.DataStructure;
using System.IO;

namespace GRAssignment.IO
{
  /// <summary>
  /// A class to write Person object into 
  /// a delimited file.
  /// </summary>
  public static class PersonWriter
  {
    /// <summary>
    /// Write the Persons collection into the console
    /// </summary>
    /// <param name="persons">A collection of Persons</param>
    public static void WriteToConsole(Persons persons)
    {
      foreach (var person in persons.List)
      {
        Console.WriteLine("Name: {0} {1}", person.FirstName, person.LastName);
        Console.WriteLine("Gender: {0}", person.Gender);
        Console.WriteLine("Date of Birth: {0}", person.DateOfBirth);
        Console.WriteLine("Favorite Color: {0}", person.FavoriteColor);
        Console.WriteLine();
      }
    }

    /// <summary>
    /// Convert a Persons object into a delimited string
    /// </summary>
    /// <param name="person">The person object</param>
    /// <param name="separator">The delimiter</param>
    /// <returns>String containing the delimited Person records</returns>
    public static string WriteLine(Person person, char separator = ',')
    {
      string line = person.LastName + separator;
      line += person.FirstName + separator;
      line += person.Gender + separator;
      line += person.FavoriteColor + separator;
      line += person.DateOfBirth;
      return line;
    }
  
    /// <summary>
    /// Write a Persons collection into a file
    /// </summary>
    /// <param name="fileName">The file name to write to</param>
    /// <param name="persons">A collection of Persons</param>
    /// <param name="separator">The delimiter</param>
    public static void WriteToFile(string fileName, Persons persons, char separator = ',')
    {
      var file = new StreamWriter(fileName);
      foreach (var person in persons.List)
        file.WriteLine(WriteLine(person, separator));
      file.Close();
    }
  }
}
