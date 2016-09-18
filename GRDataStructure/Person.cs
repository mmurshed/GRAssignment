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
    public string Gender { get { return GenderType.ToString(); } }
    public GenderType GenderType { get; private set; }
    [DataMember]
    public string FavoriteColor { get; private set; }
    [DataMember]
    public string DateOfBirth { get { return DOB.ToString("M/d/yyyy"); } }
    public DateTime DOB { get; private set; }

    public Person(string LastName, string FirstName, string Gender, string FavoriteColor, DateTime DOB)
    {
      this.LastName = LastName;
      this.FirstName = FirstName;
      this.GenderType = Gender.CompareTo(GenderType.Male.ToString()) == 0? GenderType.Male : GenderType.Female;
      this.FavoriteColor = FavoriteColor;
      this.DOB = DOB;
    }
    public bool Equals(Person other)
    {
      if (other == null)
        return false;

      if (LastName == other.LastName &&
        FirstName == other.FirstName &&
        GenderType == other.GenderType &&
        FavoriteColor == other.FavoriteColor &&
        DOB == other.DOB)
        return true;
      return false;
    }
  }

  public enum GenderType {Male, Female}
}
