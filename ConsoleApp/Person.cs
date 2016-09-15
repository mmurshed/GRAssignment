using System;

namespace GRAssignment.ConsoleApp.DataStructure
{
  public class Person : IEquatable<Person>
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
    public bool Equals(Person other)
    {
      if (other == null)
        return false;

      if (LastName == other.LastName &&
        FirstName == other.FirstName &&
        Gender == other.Gender &&
        FavoriteColor == other.FavoriteColor &&
        DateOfBirth == other.DateOfBirth)
        return true;
      return false;
    }
  }

  public enum GenderType {Male, Female}
}
