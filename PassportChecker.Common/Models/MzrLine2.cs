using System;
using PassportChecker.Common.Enums;

namespace PassportChecker.Common.Models
{
    public class MzrLine2
    {
        public string PassportNumber { get; set; }
        //Leave this as a string for the same reason as the passport number, no math being done on the checkdigit.
        public string CheckDigitPassportNumber { get; set; }
        public Nationality Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CheckDigitDateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string CheckDigitDateOfExpiry { get; set;}
        public string PersonalNumber { get; set; }
        public string CheckDigitPersonalNumber { get; set; }
        //Passport number, first check digit, DoB, expiry date, second check digit and personal number
        public string CheckDigitOverall { get; set; }
    }
}
