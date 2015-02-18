using System;
using System.Globalization;

namespace Replacement_for_Macros.Utilities
{
  public static class IntegerUtility
  {
    private const NumberStyles RationalNumberStyle = NumberStyles.AllowLeadingSign |
  NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowLeadingWhite |
  NumberStyles.AllowTrailingWhite | NumberStyles.AllowThousands;

    public static bool IsNullOrTrimmedEmpty(this string value)
    {
      return value == null || value.Trim() == string.Empty;
    }

    public static int ToInt(this string value)
    {
      if (IsNullOrTrimmedEmpty(value))
      {
        return 0;
      }
      return Int32.Parse(value, RationalNumberStyle, CultureInfo.CurrentCulture);
    }
  }
}
