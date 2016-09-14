using System;
using System.Collections.Generic;
using GRAssignment.ConsoleApp.DataStructure;

namespace GRAssignment.ConsoleApp.IO
{
  public static class PersonWriter
  {
    public static void WriteToConsole(List<Person> persons)
    {
      foreach(var person in persons)
      {
        Console.WriteLine("Name: {0} {1}", person.FirstName, person.LastName);
        Console.WriteLine("Gender: {0}", person.Gender.ToString());
        Console.WriteLine("Date of Birth: {0}", person.DateOfBirth.ToString());
        Console.WriteLine("Favorite Color: {0}", person.FavoriteColor);
        Console.WriteLine();
      }
    }
  }
}
