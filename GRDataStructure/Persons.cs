using System.Collections.Generic;

namespace GRAssignment.DataStructure
{
  public class Persons
  {
    public List<Person> List { get; private set; }

    public Persons()
    {
      List = new List<Person>();
    }
  
    public void Add(Person person)
    {
      List.Add(person);
    }

    public void SortByGender()
    {
      List.Sort(new GenderComparer());
    }

    public void SortByDateOfBirth()
    {
      List.Sort(new DOBComparer());
    }

    public void SortByLastName()
    {
      List.Sort(new NameComparer());
    }
  }
}
