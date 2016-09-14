using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRAssignment.DataStructure;
using System.IO;

namespace GRAssignment.IO
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

        Person person = new Person(values[0].Trim(), values[1].Trim(),
          values[2].Trim(), values[3].Trim(), Convert.ToDateTime(values[4].Trim()) );
        persons.Add(person);
      }
      reader.Close();
  
      return persons
    }
  }
}
