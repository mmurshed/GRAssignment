using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace GRAssignment.DataStructure
{
  /// <summary>
  /// A class representing a Person
  /// </summary>
  [DataContract]
  public class Person : IEquatable<Person>
  {
    /// <summary>
    /// The date format to read the data in
    /// </summary>
    public const string DateFormat = "M/d/yyyy";
 
    /// <summary>
    /// The last name of the person
    /// </summary>
    [DataMember]
    public string LastName { get; private set; }

    /// <summary>
    /// The first name of the person
    /// </summary>
    [DataMember]
    public string FirstName { get; private set; }

    /// <summary>
    /// The gender of the person
    /// </summary>
    [DataMember]
    public string Gender { get { return GenderType.ToString(); } }

    /// <summary>
    /// A gender enumerator, not intended for serialization
    /// </summary>
    public GenderType GenderType { get; private set; }


    /// <summary>
    /// Favorite color of the person
    /// </summary>
    [DataMember]
    public string FavoriteColor { get; private set; }

    /// <summary>
    /// String represenation of the date of birth for the person
    /// </summary>
    [DataMember]
    public string DateOfBirth { get { return DOB.ToString(DateFormat); } }

    /// <summary>
    /// Date of birth for the person, not intended for serialization
    /// </summary>
    public DateTime DOB { get; private set; }

    /// <summary>
    /// A person contructor
    /// </summary>
    /// <param name="LastName">The last name</param>
    /// <param name="FirstName">The first name</param>
    /// <param name="Gender">The gender</param>
    /// <param name="FavoriteColor">The favorite color</param>
    /// <param name="DateOfBirth">The date of birth, in M/d/yyy format</param>
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

    /// <summary>
    /// Euality comparasion function.
    /// </summary>
    /// <param name="other">The second Person object to compare to</param>
    /// <returns>True if all the properties of first person is same as the second person. False otherwise.</returns>
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

  /// <summary>
  /// Enumerator to indicate the gender of a Person
  /// </summary>
  public enum GenderType {Male, Female}
}
