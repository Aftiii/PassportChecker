using PassportChecker.Common.Models;
using PassportChecker.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportChecker.Common.BusinessLogic.Interfaces
{
    public interface IMrzValidator
    {
        ValidationResults ValidateMrzAndBaseData(PassportBaseData baseData, MrzLine2 mrzLine2);
    }
}
