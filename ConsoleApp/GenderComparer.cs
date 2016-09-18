using System.Collections.Generic;

namespace GRAssignment.ConsoleApp.DataStructure
{
  public class GenderComparer: IComparer<Person>
  {
    public int Compare(Person x, Person y)
    {
      if (x.GenderType == y.GenderType)
        return x.LastName.CompareTo(y.LastName);

      if (x.GenderType == GenderType.Female && y.GenderType == GenderType.Male)
        return -1;
      return 1;
    }
  }
}
