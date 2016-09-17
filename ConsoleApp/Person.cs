using System;
using System.Runtime.Serialization;

namespace GRAssignment.ConsoleApp.DataStructure
{
  [DataContract]
  public class Person : IEquatable<Person>
  {
    [DataMember]
    public string LastName { get; private set; }
    [DataMember]
    public string FirstName { get; private set; }
    [DataMember]
    public GenderType Gender { get; private set; }
    [DataMember]
    public string FavoriteColor { get; private set; }
    [DataMember]
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
