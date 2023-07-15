using UnityEngine;

namespace CodeFramework.Runtime.Controllers.Utils.Parse
{
    public static class DebugUtils
    {
        public static string Paint(Color color, string tag)
        {
            string result = string.Format("<color=#{0}>{1}</color>", GetColorHexString(color), tag);
            return result;
        }

        public static string Paint(this string message, Color color)
        {
            string result = string.Format("<color=#{0}>{1}</color>", GetColorHexString(color), message);
            return result;
        }

        public static string Paint(this object message, Color color)
        {
            string result = string.Format("<color=#{0}>{1}</color>", GetColorHexString(color), message);
            return result;
        }


        private static string GetColorHexString(Color color)
        {
            string colorString = string.Empty;
            colorString += ((int)(color.r * 255)).ToString("X02");
            colorString += ((int)(color.g * 255)).ToString("X02");
            colorString += ((int)(color.b * 255)).ToString("X02");
            return colorString;
        }
    }
}
