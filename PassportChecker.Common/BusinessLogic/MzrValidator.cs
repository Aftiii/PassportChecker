using PassportChecker.Common.ViewModels;
using PassportChecker.Common.Models;
using PassportChecker.Common.Helpers;
using PassportChecker.Common.BusinessLogic.Interfaces;
using PassportChecker.Common.Extensions;

namespace PassportChecker.Common.BusinessLogic
{
    public class MzrValidator : IMzrValidator
    {
        //Base date mask for all mzrline2 dates
        private static readonly string DateMask = "yyMMdd";
        public ValidationResults ValidateMzrAndBaseData(PassportBaseData baseData, MzrLine2 mzrLine2)
        {

        ValidationResults results = new ValidationResults();
            //Check digits against what was passed into mzrline2
            results.PassportNumberCheckDigit = CheckDigitHelper.CalculateCheckDigit(mzrLine2.PassportNumber) == mzrLine2.CheckDigitPassportNumber ? true : false;
            results.DateOfBirthCheckDigit = CheckDigitHelper.CalculateCheckDigit(mzrLine2.DateOfBirth.ToString("yyMMdd")) == mzrLine2.CheckDigitDateOfBirth ? true : false;
            results.PassportExpirationDateCheckDigit = CheckDigitHelper.CalculateCheckDigit(mzrLine2.DateOfExpiry.ToString("yyMMdd")) == mzrLine2.CheckDigitDateOfExpiry ? true : false;
            results.PersonalNumberCheckDigit = CheckDigitHelper.CalculateCheckDigit(mzrLine2.PersonalNumber) == mzrLine2.CheckDigitPersonalNumber ? true : false;

            //Composite check digit is all fields on line 2 minus nationality and gender
            string compositeCheckDigit =    mzrLine2.PassportNumber + 
                                            mzrLine2.CheckDigitPassportNumber + 
                                            mzrLine2.DateOfBirth.ToString("yyMMdd") + 
                                            mzrLine2.CheckDigitDateOfBirth + 
                                            mzrLine2.DateOfExpiry.ToString("yyMMdd") + 
                                            mzrLine2.CheckDigitDateOfExpiry + 
                                            mzrLine2.PersonalNumber + 
                                            mzrLine2.CheckDigitPersonalNumber;

            results.FinalCheckDigit = CheckDigitHelper.CalculateCheckDigit(compositeCheckDigit) == mzrLine2.CheckDigitOverall ? true : false;

            //Do a cross check between what the user entered vs what's on mzrline2
            results.GenderCrossCheck = baseData.Gender == mzrLine2.Gender ? true : false;
            results.DateOfBirthCrossCheck = baseData.DateOfBirth.ToString(DateMask) == mzrLine2.DateOfBirth.ToString(DateMask) ? true : false;
            results.ExpirationDateCrossCheck = baseData.DateOfExpiry.ToString(DateMask) == mzrLine2.DateOfExpiry.ToString(DateMask) ? true : false;
            results.NationalityCrossCheck = baseData.Nationality == mzrLine2.Nationality ? true : false;
            results.PassportNumberCrossCheck = baseData.PassportNumber.TrimFillerChars() == mzrLine2.PassportNumber ? true : false;

            return results;
        }
    }
}
