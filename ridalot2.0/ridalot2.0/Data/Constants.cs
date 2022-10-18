using System.Text.RegularExpressions;

namespace ridalot2._0.Data
{
    public static class Constants
    {
        public static string button = "background-color: Black; " +
                                "border-radius: 8px; " +
                                "color: white; " +
                                "padding: 10px 24px; " +
                                "text-align: center; " +
                                "display: inline-block; " +
                                "font-size: 16px;";

        public static string addressRegexString = @"^([\w\s\W]+[\w\W]?)\s([\d\-\\\/\w]*)?";

        public static Regex addressRegex = new Regex(addressRegexString);

        public static bool addressMatch(string str)
        {
            return addressRegex.IsMatch(str);
        }


    }
}
