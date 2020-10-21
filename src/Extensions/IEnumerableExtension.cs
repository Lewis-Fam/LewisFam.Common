using System;
using System.Collections.Generic;
using System.Linq;

namespace LewisFam.Common.Extensions
{
    /// <summary>
    /// IEnumerable extension.
    /// </summary>
    public static partial class IEnumerableExtension
    {
        /// <summary>
        /// Get batches.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="maxItems">The max items.</param>
        /// <returns>A list of IEnumerable.</returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
                                                           int maxItems)
        {
            return items.Select((item, inx) => new { item, inx })
                        .GroupBy(x => x?.inx / maxItems)
                        .Select(g => g?.Select(x => x.item));
        }

        /// <summary>
        /// Get random elements.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="elementsCount">The elements count.</param>
        /// <returns>A list of TS.</returns>
        public static List<T> GetRandomElements<T>(this IEnumerable<T> list, int elementsCount)
        {
            return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
        }

        /// <summary>
        /// Sorts the list.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="propName">The prop name.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <returns>A list of TS.</returns>
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

        /// <summary>Gets the dynamic property name.</summary>
        /// <param name="item">    The item.</param>
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