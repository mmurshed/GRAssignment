using System;
using System.Collections.Generic;
using GRAssignment.ConsoleApp.DataStructure;
using System.IO;

namespace GRAssignment.ConsoleApp.IO
{
  public static class PersonReader
  {
    public static List<Person> ReadFile(string fileName, char delimeter)
    {
      List<Person> persons = new List<Person>();

      var reader = new StreamReader(File.OpenRead(fileName));

      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(delimeter);

        if (values.Length < 5)
          continue;

        Person person = new Person(
          LastName:values[0].Trim(),
          FirstName:values[1].Trim(),
          Gender:values[2].Trim(),
          FavoriteColor:values[3].Trim(),
          DateOfBirth:Convert.ToDateTime(values[4].Trim())
        );
        persons.Add(person);
      }
      reader.Close();

      return persons;
    }
  }
}
