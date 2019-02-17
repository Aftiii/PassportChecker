using PassportChecker.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportChecker.Common.BusinessLogic.Interfaces
{
    public interface IParseMzrLine2
    {
        MzrLine2 ParseMzrLine2FromString(string rawMzr);
    }
}
