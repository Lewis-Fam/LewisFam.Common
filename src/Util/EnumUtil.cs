using System;
using System.Collections.Generic;
using System.Linq;

namespace LewisFam.Common.Util
{
    public static class EnumUtil
    {
        //Move to Extensions namespace...?
        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static IReadOnlyList<T> GetValuesList<T>()
        {
            return (T[])Enum.GetValues(typeof(T));
        }

         public static List<T> ToList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList<T>();
        }
    }
}