using System.Collections.Generic;

namespace GRAssignment.ConsoleApp.DataStructure
{
  public class GenderComparer: IComparer<Person>
  {
    public int Compare(Person x, Person y)
    {
      if (x.Gender == y.Gender)
        return x.LastName.CompareTo(y.LastName);

      if (x.Gender == GenderType.Female && y.Gender == GenderType.Male)
        return -1;
      return 1;
    }
  }
}
