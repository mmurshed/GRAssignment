using System;
using GRAssignment.IO;
using GRAssignment.DataStructure;

namespace GRAssignment.ConsoleApp
{
  /// <summary>
  /// The class contaning the Main function, entry point to the app.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// The entry point to the application
    /// </summary>
    /// <param name="args">A list of command line arguments</param>
    static void Main(string[] args)
    {
      if (args.Length < 1)
        return;

      var persons = PersonReader.ReadFile(args[0], ',');

      persons.SortByGender();
      Console.WriteLine("Sorted by Gender, Female first, then last name ascending.");
      Console.WriteLine("*********************************************************");
      PersonWriter.WriteToConsole(persons);

      persons.SortByDateOfBirth();
      Console.WriteLine("Sorted by Birth Date, Ascending.");
      Console.WriteLine("*********************************************************");
      PersonWriter.WriteToConsole(persons);

      persons.SortByLastName();
      Console.WriteLine("Sorted by Last Name, Descending.");
      Console.WriteLine("*********************************************************");
      PersonWriter.WriteToConsole(persons);
    }
  }
}
