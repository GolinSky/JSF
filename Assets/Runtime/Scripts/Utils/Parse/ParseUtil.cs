using System;
using System.Collections.Generic;
using Runtime.Scripts.Utils.String;

namespace Runtime.Scripts.Utils.Parse
{
    public static class ParseUtil 
    {
       public static bool TryParse<T>(string value, out T parseValue) where T : struct => Enum.TryParse(value.RemoveWhitespace(), true, out parseValue);
       
       public static T ToFlagEnum<T>(this List<string> enumFlagsAsList) where T : struct
       {
           if (!typeof(T).IsEnum)
               throw new NotSupportedException(typeof(T).Name + " is not an Enum");
           T flags;
           enumFlagsAsList.RemoveAll(c => !Enum.TryParse(c, true, out flags));
           var commaSeparatedFlags = string.Join(",", enumFlagsAsList);
           Enum.TryParse(commaSeparatedFlags, true, out flags);
           return flags;
       }
    }
}
