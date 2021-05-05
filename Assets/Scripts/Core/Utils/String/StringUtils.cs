using System;
using System.Linq;

namespace Core.Utils.String
{
    public static class StringUtils
    {
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static string ReplaceChars(this string input, char oldChar, char newChar)
        {
            var array = input.ToCharArray();
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(oldChar)) array[i] = newChar;
            }

            return new string(array);
        }

        public static string AddNull(this string input)
        {
            if (input.Length == 1)
            {
                return  input = "0" + input;
            }
            return input;
        }
    }
}

