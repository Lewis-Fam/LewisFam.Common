using System;
using System.Collections.Generic;
using System.Linq;

namespace LewisFam.Common.Util
{
    public class EnumUtil
    {
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