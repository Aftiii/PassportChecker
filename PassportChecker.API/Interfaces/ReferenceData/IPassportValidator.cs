using PassportChecker.Common.ViewModels;

namespace PassportChecker.API.Interfaces
{
    public interface IPassportValidator
    {
        ValidationResults Validate(PassportInput input);
    }
}
