using System;
using GRAssignment.DataStructure;
using System.IO;

namespace GRAssignment.IO
{
  public static class PersonReader
  {
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
        DOB: Convert.ToDateTime(values[4].Trim())
      );
      return person;
    }

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
