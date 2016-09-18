using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace GRAssignment.DataStructure
{
  [DataContract]
  public class Person : IEquatable<Person>
  {
    public const string DateFormat = "M/d/yyyy";
 
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
    public string DateOfBirth { get { return DOB.ToString(DateFormat); } }
    public DateTime DOB { get; private set; }

    public Person(string LastName, string FirstName, string Gender, string FavoriteColor, string DateOfBirth)
    {
      this.LastName = LastName;
      this.FirstName = FirstName;
      this.GenderType = Gender.CompareTo(GenderType.Male.ToString()) == 0 ? GenderType.Male : GenderType.Female;
      this.FavoriteColor = FavoriteColor;
      DateTime result = DateTime.Now;
      DateTime.TryParseExact(DateOfBirth, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
      this.DOB = result;
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
