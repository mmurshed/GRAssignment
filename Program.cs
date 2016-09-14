using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRAssignment.IO;
using GRAssignment.DataStructure;

namespace GRAssignment.Program
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length < 1)
        return;
      var persons = PersonReader.ReadFile(args[0], ',');
      persons.Sort(new GenderComparer());
      Console.WriteLine("Gender Sort: Female first, then last name ascending.");
      PersonWriter.WriteToConsole(persons);

      persons.Sort(new BirthDateComparer());
      Console.WriteLine("Birth Date Sort Ascending.");
      PersonWriter.WriteToConsole(persons);

      persons.Sort(new LastNameComparer());
      Console.WriteLine("Last Name Sort Descending.");
      PersonWriter.WriteToConsole(persons);
    }
  }
}
