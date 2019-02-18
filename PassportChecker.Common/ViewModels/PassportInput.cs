using System;
using System.ComponentModel.DataAnnotations;
using PassportChecker.Common.Enums;

namespace PassportChecker.Common.ViewModels
{
    public class PassportInput
    {
        string _mrzLine2 = "";
        [RegularExpression("^([a-zA-Z0-9<]+)$", ErrorMessage = "Passport Number is not a valid Passport Number, must be alpha numeric and could contain <")]
        [StringLength(9,ErrorMessage = "Passport numbers cannot be more than 9 characters long")]
        [MinLength(1,ErrorMessage = "Passport numbers must be at least 1 character long")]
        public string PassportNumber { get; set; }
        [EnumDataType(typeof(Nationality), ErrorMessage = "Nationality must be a type found in this table: http://www.highprogrammer.com/alan/numbers/mrp.html#countrycodes")]
        public Nationality? Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        [EnumDataType(typeof(Gender), ErrorMessage = "Gender must be Male, Female or non-specified")]
        public Gender? Gender { get; set; }
        public DateTime DateOfExpiry { get; set; }
        [StringLength(44, MinimumLength = 44, ErrorMessage = "MrzLine2 must be 44 characters long.")]
        [RegularExpression("^([a-zA-Z0-9<]+)$", ErrorMessage = "MrzLine2 is not a valid mrzLine2, must be alpha numeric and could contain <")]
        //Free text MrzLine2 means users can input lowercase, this won't map properly to an enum
        public string MrzLine2
        {
            get
            {
                return _mrzLine2;
            }
            set
            {
                _mrzLine2 = value.ToUpper();
            }
        }
    }
}
