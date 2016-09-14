using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRAssignment.DataStructure
{
  public class Person
  {
    public string LastName { get; private set; }
    public string FirstName { get; private set; }
    public string Gender { get; private set; }
    public string FavoriteColor { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public Person(string LastName, string FirstName, string Gender, string FavoriteColor, DateTime DateOfBirth)
    {
      this.LastName = LastName;
      this.FirstName = FirstName;
      this.Gender = Gender;
      this.FavoriteColor = FavoriteColor;
      this.DateOfBirth = DateOfBirth;
    }
  }
}
