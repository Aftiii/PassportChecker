using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PassportChecker.Common.Enums;

namespace PassportChecker.Common.Helpers
{
    public class CheckDigitHelper
    {
        //These weightings are set by the standard, can be added or removed from here
        private static readonly int[] _weightings = new int[] { 7, 3, 1 };
        //This is the pattern which is the current standard
        private static readonly string _pattern = @"^([a-zA-Z0-9<]+)$";
        //The current standard for the modulus division
        private static readonly int _modulus = 10;

        public static char CalculateCheckDigit(string input)
        {
            if (!Regex.Match(input, _pattern).Success)
            {
                throw new ArgumentException("Input is not a valid input, must be alpha numeric and could contain <", input);
            }

            char[] inputs = input.ToCharArray();
            List<int> digitsToCalculate = new List<int>(inputs.Length);
            bool isNumeric = false;
            //arrange an array of numbers, because we can use a-zA-Z here we need to work out the mapping
            foreach (char character in inputs)
            {
                int num = 0;
                isNumeric = int.TryParse(character.ToString(), out num);
                if (!isNumeric)
                {
                    num = GetNonDigitNumber(character);
                }
                digitsToCalculate.Add(num);
            }

            return (char)CalculateDigits(digitsToCalculate, _weightings, _modulus);
        }

        private static int CalculateDigits(List<int> digits, int[] weightings, int modulus)
        {
            int currentWeightingPosition = 0;
            int total = 0;
            foreach (int digit in digits)
            {
                total += digit * weightings[currentWeightingPosition];

                currentWeightingPosition++;
                //Reset the current weighting position if we're at the top of the array
                if (currentWeightingPosition >= weightings.Length)
                {
                    currentWeightingPosition = 0;
                }
            }

            return total % modulus;
        }

        private static int GetNonDigitNumber(char nonDigit)
        {
            string enumName = "";

            //If the character is the padding char then we need to map this to the name in the enum which is "lessThan"
            if (nonDigit == '<')
            {
                enumName = "lessThan";
            }
            else
            {
                enumName = nonDigit.ToString();
            }

            Enum.TryParse(enumName, out NonDigitMapping nonDigitEnum);

            //We need the value to calculate off of
            return (int)nonDigitEnum;
        }
    }
}
