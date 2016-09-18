using System.Collections.Generic;

namespace GRAssignment.DataStructure
{
  /// <summary>
  /// A comparer class for comparing two Persons
  /// based on the date of birth
  /// </summary>
  public class DOBComparer: IComparer<Person>
  {
    /// <summary>
    /// Use DateTime compare function to return
    /// an integer, so that oldest date comes
    /// earlier than the newest date, in an ascending
    /// order.
    /// When two birth dates are same, compare the last
    /// and the first names, respectively.
    /// </summary>
    /// <param name="x">The first object to compare</param>
    /// <param name="y">The second object to compare</param>
    /// <returns>An integer, zero if both objects have same values.
    /// A positive value if first object comes after the second object.
    /// A negative value, if first object comes before the second object.</returns>
    public int Compare(Person x, Person y)
    {
      int compare = x.DOB.CompareTo(y.DOB); // Ascending: Oldest to Newest
      if (compare == 0)
        compare = x.LastName.CompareTo(y.LastName); // Ascending: A to Z
      if (compare == 0)
        compare = x.FirstName.CompareTo(y.FirstName); // Ascending: A to Z
      return compare;
    }
  }
}
