using PassportChecker.Common.Models;
using System;
using PassportChecker.Common.Helpers;
using PassportChecker.Common.Enums;
using PassportChecker.Common.BusinessLogic.Interfaces;

namespace PassportChecker.Common.BusinessLogic
{
    public class ParseMrzLine2 : IParseMrzLine2
    {
        //Declare our pattern here, if our date time doesn't match it then something could be wrong with the mrzline 2
        private static readonly string DateMask = "yyMMdd";

        //Define all locations of strings within the bigger string, here it can be changed easily. Consider putting this in db or config
        private static readonly MrzLocation PassportNumberLookup = new MrzLocation(0, 9);
        private static readonly MrzLocation PassportNumberCheckDigitLookup = new MrzLocation(9, 1);
        private static readonly MrzLocation NationalityLookup = new MrzLocation(10, 3);
        private static readonly MrzLocation DateofBirthLookup = new MrzLocation(13, 6);
        private static readonly MrzLocation CheckDigitDateOfBirthLookup = new MrzLocation(19, 1);
        private static readonly MrzLocation GenderLookup = new MrzLocation(20, 1);
        private static readonly MrzLocation ExpiryDateLookup = new MrzLocation(21, 6);
        private static readonly MrzLocation ExpiryCheckDigitLookup = new MrzLocation(27, 1);
        private static readonly MrzLocation PersonalNumberLookup = new MrzLocation(28, 14);
        private static readonly MrzLocation PersonalNumberCheckDigitLookup = new MrzLocation(42, 1);
        private static readonly MrzLocation CompositeCheckDigitLookup = new MrzLocation(43, 1);

        public MrzLine2 ParseMrzLine2FromString(string rawMrz)
        {
            MrzLine2 mrzLine2 = new MrzLine2();
            try
            {
                //All characters need to be uppercase 
                rawMrz = rawMrz.ToUpper();
                mrzLine2.PassportNumber = PassportValidatorHelper.ParseForString(rawMrz, PassportNumberLookup.Index, PassportNumberLookup.Length);
                mrzLine2.CheckDigitPassportNumber = PassportValidatorHelper.ParseForString(rawMrz, PassportNumberCheckDigitLookup.Index, PassportNumberCheckDigitLookup.Length);
                mrzLine2.Nationality = (Nationality)PassportValidatorHelper.ParseForEnum(rawMrz, NationalityLookup.Index, NationalityLookup.Length, typeof(Nationality));
                mrzLine2.DateOfBirth = PassportValidatorHelper.ParseForDateTime(rawMrz, DateofBirthLookup.Index, DateofBirthLookup.Length, DateMask);
                mrzLine2.CheckDigitDateOfBirth = PassportValidatorHelper.ParseForString(rawMrz, CheckDigitDateOfBirthLookup.Index, CheckDigitDateOfBirthLookup.Length);
                mrzLine2.Gender = (Gender)PassportValidatorHelper.ParseForEnum(rawMrz, GenderLookup.Index, GenderLookup.Length, typeof(Gender));
                mrzLine2.DateOfExpiry = PassportValidatorHelper.ParseForDateTime(rawMrz, ExpiryDateLookup.Index, ExpiryDateLookup.Length, DateMask);
                mrzLine2.CheckDigitDateOfExpiry = PassportValidatorHelper.ParseForString(rawMrz, ExpiryCheckDigitLookup.Index, ExpiryCheckDigitLookup.Length);
                mrzLine2.PersonalNumber = PassportValidatorHelper.ParseForString(rawMrz, PersonalNumberLookup.Index, PersonalNumberLookup.Length);
                mrzLine2.CheckDigitPersonalNumber = PassportValidatorHelper.ParseForString(rawMrz, PersonalNumberCheckDigitLookup.Index, PersonalNumberCheckDigitLookup.Length);
                mrzLine2.CheckDigitOverall = PassportValidatorHelper.ParseForString(rawMrz, CompositeCheckDigitLookup.Index, CompositeCheckDigitLookup.Length);
            }
            catch (Exception)
            {
                //Throw the exception up the stack
                throw;
            }

            return mrzLine2;
        }
    }
}
