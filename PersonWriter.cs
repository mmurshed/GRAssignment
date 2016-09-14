using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRAssignment.DataStructure;
using System.IO;

namespace GRAssignment.IO
{
  public static class PersonWriter
  {
    public static void WriteFile(List<Person> persons)
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
