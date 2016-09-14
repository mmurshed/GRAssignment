using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRAssignment.DataStructure
{
  public class LastNameComparer : IComparer<Person>
  {
    public int Compare(Person x, Person y)
    {
      return -1 * x.LastName.CompareTo(y.LastName);
    }
  }
}
