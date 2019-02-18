
namespace PassportChecker.Common
{
    public class MrzLocation
    {
        public MrzLocation(int index, int length)
        {
            Index = index;
            Length = length;
        }
        public int Index { get; set; }
        public int Length { get; set; }
    }
}
