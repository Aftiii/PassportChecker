using System;
using PassportChecker.Common.Enums;

namespace PassportChecker.Common.Models
{
    public class PassportBaseData
    {
        string _passportNumber = "";
        public string PassportNumber
        {
            get
            {
                return _passportNumber;
            }
            //Passport numbers should be 9 characters, however the user may not enter 9 characters as their passport doesn't include the filler character, pad the passport number with 0s
            //This way our composite check won't fail
            set
            {
                if (value.Length < 9)
                {
                    _passportNumber = value.PadRight(9, '0');
                }
                else
                {
                    _passportNumber = value;
                }
            }
        }
        public Nationality Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }
}
