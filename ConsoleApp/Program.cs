using System;
using GRAssignment.ConsoleApp.IO;
using GRAssignment.ConsoleApp.DataStructure;

namespace GRAssignment.ConsoleApp.Program
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length < 1)
        return;

      var persons = PersonReader.ReadFile(args[0], ',');

      persons.Sort(new GenderComparer());
      Console.WriteLine("Sorted by Gender, Female first, then last name ascending.");
      Console.WriteLine("*********************************************************");
      PersonWriter.WriteToConsole(persons);

      persons.Sort( (x, y) => -1 * x.DateOfBirth.CompareTo(y.DateOfBirth) );
      Console.WriteLine("Sorted by Birth Date, Ascending.");
      Console.WriteLine("*********************************************************");
      PersonWriter.WriteToConsole(persons);

      persons.Sort( (x,y) => -1 * x.LastName.CompareTo(y.LastName) );
      Console.WriteLine("Sorted by Last Name, Descending.");
      Console.WriteLine("*********************************************************");
      PersonWriter.WriteToConsole(persons);
    }
  }
}
