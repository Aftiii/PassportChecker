using System.ComponentModel;

namespace PassportChecker.Common.Enums
{
    public enum Gender
    {
        [Description("Non-specified")]
        NonSpecified = 1,
        [Description("Male")]
        Male = 2,
        [Description("Female")]
        Female = 4
    }
}
