using System;

namespace GRAssignment.GRPersonService.NUnit
{
  /// <summary>
  /// A class containing some constants needed by the test
  /// </summary>
  public class GRTestConst
  {
    /// <summary>
    /// The URI
    /// </summary>
    public static readonly Uri URL = new Uri("http://localhost/GRPersonService/records/");

    /// <summary>
    /// The directory containing expected output
    /// </summary>
    public const string EXPECTED_DIR = @"C:\Source\GRAssignment\Expected";
  }
}
