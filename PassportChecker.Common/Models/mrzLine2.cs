using System;
using PassportChecker.Common.Enums;

namespace PassportChecker.Common.Models
{
    public class mrzLine2
    {
        /*We're not doing any Math on the passport number, it's not needed for any numeric operations, let's leave it as a string to avoid
        any overflow issues in the future if the passport number grows in size*/
        public string PassportNumber { get; set; }
        //Leave this as a char for the same reason as the passport number, no math being done on the checkdigit.
        public char CheckDigitPassportNumber { get; set; }
        public Nationality Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char CheckDigitDateOfBirth { get; set; }
        public Gender Sex { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public char CheckDigitDateOfExpiry { get; set;}
        public string PersonalNumber { get; set; }
        public char CheckDigitPersonalNumber { get; set; }
        //Passport number, first check digit, DoB, expiry date, second check digit and personal number
        public char CheckDigitOverall { get; set; }
    }
}
