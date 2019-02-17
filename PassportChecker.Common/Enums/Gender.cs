using System.ComponentModel;

namespace PassportChecker.Common.Enums
{
    public enum Gender
    {
        [Description("Non-specified")]
        LessThan = 1,
        [Description("Male")]
        M = 2,
        [Description("Female")]
        F = 4
    }
}
