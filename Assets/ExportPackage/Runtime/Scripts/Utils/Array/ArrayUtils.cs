using System.Collections.Generic;

#pragma warning disable 0649

namespace CodeFramework.Runtime.Utils.Array
{
    public static class ArrayUtils
    {
        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            return array == null || array.Length == 0;
        }
        
        public static bool IsNullOrEmpty<T,V>(this IDictionary<T,V> dictionary)
        {
            return dictionary == null || dictionary.Count == 0;
        }
        
        public static bool IsNullOrEmpty<T>(this ICollection<T> list)
        {
            return list == null || list.Count == 0;
        }
        
        public static bool IsNullOrEmpty<Value, InternalValue, Id>(this DataList<Value, InternalValue, Id>  dataList) where Value : InternalData<Id, InternalValue>
        {
            return dataList == null || !dataList.IsValidList;
        }
    }
}
