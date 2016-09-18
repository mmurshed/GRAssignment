using System.Collections.Generic;

namespace GRAssignment.DataStructure
{
  /// <summary>
  /// A comparer class for comparing two Persons
  /// based on the gender
  /// </summary>
  public class NameComparer: IComparer<Person>
  {
    /// <summary>
    /// Return -1 if the last name of the first Person
    /// comes lexicographically later than that of the
    /// second person. Return 1, if the opposite is true.
    /// When two last names are same, compare 
    /// the first names.
    /// </summary>
    /// <param name="x">The first object to compare</param>
    /// <param name="y">The second object to compare</param>
    /// <returns>An integer, zero if both objects have same values.
    /// A positive value if first object comes after the second object.
    /// A negative value, if first object comes before the second object.</returns>
    public int Compare(Person x, Person y)
    {
      int compare = x.LastName.CompareTo(y.LastName);
      if (compare == 0)
        compare = x.FirstName.CompareTo(y.FirstName);
      return -1 * compare; // Descending: Z to A
    }
  }
}
