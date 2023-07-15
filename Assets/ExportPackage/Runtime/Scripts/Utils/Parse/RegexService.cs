using System.Text.RegularExpressions;

namespace CodeFramework.Runtime.Controllers.Utils.Parse
{
    public static class RegexService
    {
        // \{(.|\s)*\}
        private const string JsonRegex = "({.*?})";
        public static string MatchJson(string input)
        {
           return Match(input, JsonRegex);

        }
        
        private static string Match(string input, string pattern) => Regex.Match(input, pattern).Value;
    }
}
