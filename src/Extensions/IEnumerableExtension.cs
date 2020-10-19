using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LewisFam.Common.Extensions
{
    public static partial class IEnumerableExtension
    {
        public static List<T> GetRandomElements<T>(this IEnumerable<T> list, int elementsCount)
        {
            return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
        }

        public static IEnumerable<T> Sort_List<T>(this IEnumerable<T> data, string propName, SortDirection sortDirection = SortDirection.Ascending)
        {
            var sortedList = new List<T>();

            if (sortDirection == SortDirection.Ascending)
            {
                sortedList = (from n in data
                              orderby GetDynamicPropertyName(n, propName) ascending
                              select n).ToList();
            }

            else if (sortDirection == SortDirection.Descending)
            {
                sortedList = (from n in data
                              orderby GetDynamicPropertyName(n, propName) descending
                              select n).ToList();

            }

            return sortedList;

        }

        /// <summary>
        /// Gets the dynamic property name.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propName">The prop name.</param>
        /// <returns>An object.</returns>
        /// <exception cref="System.Reflection.AmbiguousMatchException">Ignore.</exception>
        /// <exception cref="System.Reflection.TargetException">Ignore.</exception>
        /// <exception cref="System.Reflection.TargetParameterCountException">Ignore.</exception>
        /// <exception cref="MethodAccessException">Ignore.</exception>
        /// <exception cref="System.Reflection.TargetInvocationException">Ignore.</exception>
        private static object GetDynamicPropertyName(object item, string propName)
        {
            //Use reflection to get order type
            return item.GetType().GetProperty(propName).GetValue(item, null);
        }
    }
}
