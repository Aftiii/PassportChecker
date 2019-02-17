using System;
using PassportChecker.Common.Enums;

namespace PassportChecker.Common.Models
{
    public class PassportBaseData
    {
        public string PassportNumber { get; set; }
        public Nationality Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }
}
