
namespace PassportChecker.Common.ViewModels
{
    public class ValidationResults
    {
        public bool PassportNumberCheckDigit { get; set; }
        public bool DateOfBirthCheckDigit { get; set; }
        public bool PassportExpierationDateCheckDigit { get; set;}
        public bool PersonalNumberCheckDigit { get; set; }
        public bool FinalCheckDigit { get; set; }
        public bool GenderCrossCheck { get; set; }
        public bool DateOfBirthCrossCheck { get; set; }
        public bool ExpirationDateCrossCheck { get; set; }
        public bool NationalityCrossCheck { get; set; }
        public bool PassportNumberCrossCheck { get; set; }
    }
}
