using System;

namespace GRAssignment.GRPersonService.NUnit
{
  public class GRTestConst
  {
    public static readonly Uri URL = new Uri("http://localhost/GRPersonService/records/");
    public const string INPUT_DIR = @"C:\Source\GRAssignment\Input";
    public const string OUTPUT_DIR = @"C:\Source\GRAssignment\Output";
    public const string EXPECTED_DIR = @"C:\Source\GRAssignment\Expected";

    public const char COMMA = ',';
    public const char SPACE = ' ';
    public const char PIPE = '|';
  }
}
