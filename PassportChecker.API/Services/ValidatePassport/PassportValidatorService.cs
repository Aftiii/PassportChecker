using System;
using PassportChecker.API.Interfaces;
using PassportChecker.Common.ViewModels;

namespace PassportChecker.API.Services
{
    public class PassportValidatorService : IPassportValidator
    {
        public ValidationResults Validate(PassportInput input)
        {
            throw new NotImplementedException();
        }
    }
}
