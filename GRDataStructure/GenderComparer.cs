using System.Collections.Generic;

namespace GRAssignment.DataStructure
{
  /// <summary>
  /// A comparer class for comparing two Persons
  /// based on the gender
  /// </summary>
  public class GenderComparer: IComparer<Person>
  {
    /// <summary>
    /// Return -1 if the first Person is female and
    /// second person is male and 1 for the opposite
    /// case.
    /// When two genders are same, compare the last
    /// and the first names, respectively.
    /// </summary>
    /// <param name="x">The first object to compare</param>
    /// <param name="y">The second object to compare</param>
    /// <returns>An integer, zero if both objects have same values.
    /// A positive value if first object comes after the second object.
    /// A negative value, if first object comes before the second object.</returns>
    public int Compare(Person x, Person y)
    {
      int compare = 0;
      if (x.GenderType == y.GenderType)
        compare = 0; // Same Gender
      else if (x.GenderType == GenderType.Female && y.GenderType == GenderType.Male)
        compare = -1; // Female before Male
      else
        compare = 1;

      if (compare == 0)
        compare = x.LastName.CompareTo(y.LastName); // Ascending: A to Z
      if (compare == 0)
        compare = x.FirstName.CompareTo(y.FirstName); // Ascending: A to Z
      return compare;
    }
  }
}
