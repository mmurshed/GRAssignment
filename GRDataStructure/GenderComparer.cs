﻿using System.Collections.Generic;

namespace GRAssignment.DataStructure
{
  public class GenderComparer: IComparer<Person>
  {
    public int Compare(Person x, Person y)
    {
      int compare = 0;
      if (x.GenderType == y.GenderType)
        compare = 0; // Samel Gender
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