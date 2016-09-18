using System.Collections.Generic;

namespace GRAssignment.DataStructure
{
  /// <summary>
  /// A collection class for the Person objects
  /// </summary>
  public class Persons
  {
    /// <summary>
    /// The list containing the person collection
    /// </summary>
    public List<Person> List { get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public Persons()
    {
      List = new List<Person>();
    }
  
    /// <summary>
    /// Add a person to the list
    /// </summary>
    /// <param name="person"></param>
    public void Add(Person person)
    {
      List.Add(person);
    }

    /// <summary>
    /// Sort the list by gender
    /// </summary>
    public void SortByGender()
    {
      List.Sort(new GenderComparer());
    }

    /// <summary>
    /// Sort the list by date of birth
    /// </summary>
    public void SortByDateOfBirth()
    {
      List.Sort(new DOBComparer());
    }

    /// <summary>
    /// Sort the list by last name
    /// </summary>
    public void SortByLastName()
    {
      List.Sort(new NameComparer());
    }
  }
}
