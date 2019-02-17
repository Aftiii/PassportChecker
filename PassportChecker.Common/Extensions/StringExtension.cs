namespace PassportChecker.Common.Extensions
{
    public static class StringExtension
    {
        private static readonly string fillerStr = "<";
        public static string TrimFillerChars(this string str)
        {
            return str.Replace(fillerStr, "");
        }
    }
}
