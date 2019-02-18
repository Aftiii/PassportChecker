using PassportChecker.Common.ViewModels;
using PassportChecker.Common.Models;
using PassportChecker.Common.Helpers;
using PassportChecker.Common.BusinessLogic.Interfaces;
using PassportChecker.Common.Extensions;

namespace PassportChecker.Common.BusinessLogic
{
    public class MrzValidator : IMrzValidator
    {
        //Base date mask for all mrzline2 dates
        private static readonly string DateMask = "yyMMdd";

        public ValidationResults ValidateMrzAndBaseData(PassportBaseData baseData, MrzLine2 mrzLine2)
        {

            ValidationResults results = new ValidationResults();
            //Check digits against what was passed into mrzline2
            results.PassportNumberCheckDigit = CheckDigitHelper.CalculateCheckDigit(mrzLine2.PassportNumber) == mrzLine2.CheckDigitPassportNumber ? true : false;
            results.DateOfBirthCheckDigit = CheckDigitHelper.CalculateCheckDigit(mrzLine2.DateOfBirth.ToString("yyMMdd")) == mrzLine2.CheckDigitDateOfBirth ? true : false;
            results.PassportExpirationDateCheckDigit = CheckDigitHelper.CalculateCheckDigit(mrzLine2.DateOfExpiry.ToString("yyMMdd")) == mrzLine2.CheckDigitDateOfExpiry ? true : false;
            results.PersonalNumberCheckDigit = CheckDigitHelper.CalculateCheckDigit(mrzLine2.PersonalNumber) == mrzLine2.CheckDigitPersonalNumber ? true : false;

            //Composite check digit is all fields on line 2 minus nationality and gender
            string compositeCheckDigit =    mrzLine2.PassportNumber + 
                                            mrzLine2.CheckDigitPassportNumber + 
                                            mrzLine2.DateOfBirth.ToString("yyMMdd") + 
                                            mrzLine2.CheckDigitDateOfBirth + 
                                            mrzLine2.DateOfExpiry.ToString("yyMMdd") + 
                                            mrzLine2.CheckDigitDateOfExpiry + 
                                            mrzLine2.PersonalNumber + 
                                            mrzLine2.CheckDigitPersonalNumber;

            results.FinalCheckDigit = CheckDigitHelper.CalculateCheckDigit(compositeCheckDigit) == mrzLine2.CheckDigitOverall ? true : false;

            //Do a cross check between what the user entered vs what's on mrzline2
            results.GenderCrossCheck = baseData.Gender == mrzLine2.Gender ? true : false;
            results.DateOfBirthCrossCheck = baseData.DateOfBirth.ToString(DateMask) == mrzLine2.DateOfBirth.ToString(DateMask) ? true : false;
            results.ExpirationDateCrossCheck = baseData.DateOfExpiry.ToString(DateMask) == mrzLine2.DateOfExpiry.ToString(DateMask) ? true : false;
            results.NationalityCrossCheck = baseData.Nationality == mrzLine2.Nationality ? true : false;
            results.PassportNumberCrossCheck = baseData.PassportNumber.ZeroFillerChars() == mrzLine2.PassportNumber ? true : false;

            return results;
        }
    }
}
