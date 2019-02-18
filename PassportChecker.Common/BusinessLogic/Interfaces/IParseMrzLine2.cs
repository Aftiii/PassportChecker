using PassportChecker.Common.Models;

namespace PassportChecker.Common.BusinessLogic.Interfaces
{
    public interface IParseMrzLine2
    {
        MrzLine2 ParseMrzLine2FromString(string rawMrz);
    }
}
