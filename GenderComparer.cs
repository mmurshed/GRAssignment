using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRAssignment.DataStructure
{
  public class GenderComparer: IComparer<Person>
  {
    public int Compare(Person x, Person y)
    {
      if (x.Gender == y.Gender)
        return x.Gender.CompareTo(y.Gender);

      if (x.Gender == GenderType.Female && y.Gender == GenderType.Male)
        return -1;
      return 1;
    }
  }
}
