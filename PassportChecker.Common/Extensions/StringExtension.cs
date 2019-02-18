namespace PassportChecker.Common.Extensions
{
    public static class StringExtension
    {
        private static readonly string fillerStr = "<";
        //Use extension methods instead of helpers as it'll make it easier to use
        public static string ZeroFillerChars(this string str)
        {
            return str.Replace(fillerStr, "0");
        }
        public static string TrimFillerChars(this string str)
        {
            return str.Replace(fillerStr, "");
        }
    }
}
