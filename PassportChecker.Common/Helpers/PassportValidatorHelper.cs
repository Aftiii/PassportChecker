using PassportChecker.Common.Extensions;
using System;
using System.Globalization;

namespace PassportChecker.Common.Helpers
{
    public class PassportValidatorHelper
    {
        public static string ParseForString(string rawMrz, int index, int length)
        {
            //Generic method to get a substring out of the mrz which was passed in. Once done, to allow for check digits, replace all <'s with 0's
            return rawMrz.Substring(index, length).ZeroFillerChars();
        }

        public static object ParseForEnum(string rawMrz, int index, int length, Type enumType)
        {
            //TODO: Fix filler char for gender
            string rawMrzEnum = rawMrz.Substring(index, length).TrimFillerChars();
            if (rawMrzEnum == "") 
            {
                rawMrzEnum = "na";
            }
            try
            {
                return Enum.Parse(enumType, rawMrzEnum);

            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Failed to parse enum from " + rawMrz + " into " + enumType.FullName, rawMrzEnum);
            }
        }

        public static DateTime ParseForDateTime(string rawMrz, int index, int length, string mask)
        {
            string rawMrzDateTime = rawMrz.Substring(index, length).ZeroFillerChars();
            try
            {
                //Force a parse into the mask as this is how it should be when coming from the Mrzline2
                return DateTime.ParseExact(rawMrzDateTime, mask, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new FormatException("Unable to parse exact date time " + rawMrzDateTime);
            }
        }
    }
}
