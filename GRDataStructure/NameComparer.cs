using System.Collections.Generic;

namespace GRAssignment.DataStructure
{
  public class NameComparer: IComparer<Person>
  {
    public int Compare(Person x, Person y)
    {
      int compare = x.LastName.CompareTo(y.LastName);
      if (compare == 0)
        compare = x.FirstName.CompareTo(y.FirstName);
      return -1 * compare; // Descending: Z to A
    }
  }
}
