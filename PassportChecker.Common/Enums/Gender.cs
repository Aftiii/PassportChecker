using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
