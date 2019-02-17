using PassportChecker.Common.Extensions;
using System;
using System.Globalization;

namespace PassportChecker.Common.Helpers
{
    public class PassportValidatorHelper
    {
        public static string ParseForString(string rawMzr, int index, int length)
        {
            return rawMzr.Substring(index, length).TrimFillerChars();
        }

        public static char ParseForChar(string rawMzr, int index, int length)
        {
            if (length != 1)
            {
                throw new ArgumentException("Unable to parse more than one character for char type");
            }
            string rawMzrChar = rawMzr.Substring(index, length).TrimFillerChars();

            if (!char.TryParse(rawMzrChar, out char parsedChar))
            {
                throw new ArgumentException("Unable to parse value into char", rawMzrChar);
            }

            return parsedChar;
        }

        public static object ParseForEnum(string rawMzr, int index, int length, Type enumType)
        {
            string rawMzrEnum = rawMzr.Substring(index, length);
            if (rawMzrEnum == "<") 
            {
                rawMzrEnum = "LessThan";
            }
            try
            {
                return Enum.Parse(enumType, rawMzrEnum);

            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Failed to parse enum into " + enumType.FullName, rawMzrEnum);
            }
        }

        public static DateTime ParseForDateTime(string rawMzr, int index, int length, string mask)
        {
            string rawMzrDateTime = rawMzr.Substring(index, length).TrimFillerChars();
            try
            {
                return DateTime.ParseExact(rawMzrDateTime, mask, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new FormatException("Unable to parse exact date time " + rawMzrDateTime);
            }
        }
    }
}
