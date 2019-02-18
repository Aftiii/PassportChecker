using System.ComponentModel;

namespace PassportChecker.Common.Enums
{
    public enum Gender
    {
        [Description("Non-specified")]
        //Need to use less than because < is a special symbol
        na = 1,
        [Description("Male")]
        M = 2,
        [Description("Female")]
        F = 4
    }
}
