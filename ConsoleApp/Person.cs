using System;

namespace GRAssignment.ConsoleApp.DataStructure
{
  public class Person
  {
    public string LastName { get; private set; }
    public string FirstName { get; private set; }
    public GenderType Gender { get; private set; }
    public string FavoriteColor { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public Person(string LastName, string FirstName, string Gender, string FavoriteColor, DateTime DateOfBirth)
    {
      this.LastName = LastName;
      this.FirstName = FirstName;
      this.Gender = Gender.CompareTo(GenderType.Male.ToString()) == 0? GenderType.Male : GenderType.Female;
      this.FavoriteColor = FavoriteColor;
      this.DateOfBirth = DateOfBirth;
    }
  }

  public enum GenderType {Male, Female}
}
