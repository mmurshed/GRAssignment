using System.Collections.Generic;

namespace GRAssignment.DataStructure
{
  public class DOBComparer: IComparer<Person>
  {
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
