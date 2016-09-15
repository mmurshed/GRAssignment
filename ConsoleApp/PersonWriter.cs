using System;
using System.Collections.Generic;
using GRAssignment.ConsoleApp.DataStructure;
using System.IO;

namespace GRAssignment.ConsoleApp.IO
{
  public static class PersonWriter
  {
    public static void WriteToConsole(List<Person> persons)
    {
      foreach (var person in persons)
      {
        Console.WriteLine("Name: {0} {1}", person.FirstName, person.LastName);
        Console.WriteLine("Gender: {0}", person.Gender.ToString());
        Console.WriteLine("Date of Birth: {0}", person.DateOfBirth.ToString());
        Console.WriteLine("Favorite Color: {0}", person.FavoriteColor);
        Console.WriteLine();
      }
    }

    public static void WriteToFile(string fileName, List<Person> persons, char separator = ',')
    {
      var file = new StreamWriter(fileName);
      foreach (var person in persons)
      {
        string line = person.LastName + separator;
        line += person.FirstName + separator;
        line += person.Gender.ToString() + separator;
        line += person.FavoriteColor + separator;
        line += person.DateOfBirth.ToString() + separator;

        file.WriteLine(line);
      }
    }
  }
}
