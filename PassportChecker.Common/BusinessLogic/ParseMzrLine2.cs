using PassportChecker.Common.Models;
using System;
using PassportChecker.Common.Helpers;
using PassportChecker.Common.Enums;
using PassportChecker.Common.BusinessLogic.Interfaces;

namespace PassportChecker.Common.BusinessLogic
{
    public class ParseMzrLine2 : IParseMzrLine2
    {
        //Declare our pattern here, if our date time doesn't match it then something could be wrong with the mzrline 2
        private static readonly string DateMask = "yyMMdd";

        //Define all locations of strings within the bigger string, here it can be changed easily. Consider putting this in db or config
        private static readonly MzrLocation PassportNumberLookup = new MzrLocation(0, 9);
        private static readonly MzrLocation PassportNumberCheckDigitLookup = new MzrLocation(9, 1);
        private static readonly MzrLocation NationalityLookup = new MzrLocation(10, 3);
        private static readonly MzrLocation DateofBirthLookup = new MzrLocation(13, 6);
        private static readonly MzrLocation CheckDigitDateOfBirthLookup = new MzrLocation(19, 1);
        private static readonly MzrLocation GenderLookup = new MzrLocation(20, 1);
        private static readonly MzrLocation ExpiryDateLookup = new MzrLocation(21, 6);
        private static readonly MzrLocation ExpiryCheckDigitLookup = new MzrLocation(27, 1);
        private static readonly MzrLocation PersonalNumberLookup = new MzrLocation(28, 14);
        private static readonly MzrLocation PersonalNumberCheckDigitLookup = new MzrLocation(42, 1);
        private static readonly MzrLocation CompositeCheckDigitLookup = new MzrLocation(43, 1);

        public MzrLine2 ParseMzrLine2FromString(string rawMzr)
        {
            MzrLine2 mzrLine2 = new MzrLine2();
            try
            {
                mzrLine2.PassportNumber = PassportValidatorHelper.ParseForString(rawMzr, PassportNumberLookup.Index, PassportNumberLookup.Length);
                mzrLine2.CheckDigitPassportNumber = PassportValidatorHelper.ParseForString(rawMzr, PassportNumberCheckDigitLookup.Index, PassportNumberCheckDigitLookup.Length);
                mzrLine2.Nationality = (Nationality)PassportValidatorHelper.ParseForEnum(rawMzr, NationalityLookup.Index, NationalityLookup.Length, typeof(Nationality));
                mzrLine2.DateOfBirth = PassportValidatorHelper.ParseForDateTime(rawMzr, DateofBirthLookup.Index, DateofBirthLookup.Length, DateMask);
                mzrLine2.CheckDigitDateOfBirth = PassportValidatorHelper.ParseForString(rawMzr, CheckDigitDateOfBirthLookup.Index, CheckDigitDateOfBirthLookup.Length);
                mzrLine2.Gender = (Gender)PassportValidatorHelper.ParseForEnum(rawMzr, GenderLookup.Index, GenderLookup.Length, typeof(Gender));
                mzrLine2.DateOfExpiry = PassportValidatorHelper.ParseForDateTime(rawMzr, ExpiryDateLookup.Index, ExpiryDateLookup.Length, DateMask);
                mzrLine2.CheckDigitDateOfExpiry = PassportValidatorHelper.ParseForString(rawMzr, ExpiryCheckDigitLookup.Index, ExpiryCheckDigitLookup.Length);
                mzrLine2.PersonalNumber = PassportValidatorHelper.ParseForString(rawMzr, PersonalNumberLookup.Index, PersonalNumberLookup.Length);
                mzrLine2.CheckDigitPersonalNumber = PassportValidatorHelper.ParseForString(rawMzr, PersonalNumberCheckDigitLookup.Index, PersonalNumberCheckDigitLookup.Length);
                mzrLine2.CheckDigitOverall = PassportValidatorHelper.ParseForString(rawMzr, CompositeCheckDigitLookup.Index, CompositeCheckDigitLookup.Length);
            }
            catch (Exception e)
            {
                //Throw the exception up the stack
                throw e;
            }

            return mzrLine2;
        }
    }
}
