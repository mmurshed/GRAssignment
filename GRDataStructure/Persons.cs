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
  
    public Persons(List<Person> List)
    {
      this.List = List;
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
      List.Sort((x, y) => x.DOB.CompareTo(y.DOB));
    }

    public void SortByLastName()
    {
      List.Sort((x, y) => -1 * x.LastName.CompareTo(y.LastName));
    }
  }
}
