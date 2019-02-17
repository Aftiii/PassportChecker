using System;
using System.ComponentModel.DataAnnotations;
using PassportChecker.Common.Enums;

namespace PassportChecker.Common.ViewModels
{
    public class PassportInput
    {
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Passport number must be 9 characters long.")]
        [RegularExpression("^([a-zA-Z0-9<]+)$", ErrorMessage = "Passport Number is not a valid Passport Number, must be alpha numeric and could contain <")]
        public string PassportNumber { get; set; }
        [EnumDataType(typeof(Nationality),ErrorMessage = "Nationality must be a type found in this table: http://www.highprogrammer.com/alan/numbers/mrp.html#countrycodes")]
        public Nationality Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        [EnumDataType(typeof(Gender), ErrorMessage = "Gender must be Male, Female or non-specified")]
        public Gender Gender { get; set; }
        public DateTime DateOfExpiry { get; set; }
        [StringLength(44, MinimumLength = 44, ErrorMessage = "MzrLine2 must be 44 characters long.")]
        [RegularExpression("^([a-zA-Z0-9<]+)$", ErrorMessage ="MzrLine2 is not a valid MzrLine2, must be alpha numeric and could contain <")]
        public string mzrLine2 { get; set; }
    }
}
