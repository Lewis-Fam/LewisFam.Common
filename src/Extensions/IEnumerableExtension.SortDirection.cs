/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Author: LewisFam
***/

using System.Collections.Generic;
using System.Linq;

namespace LewisFam.Extensions
{
    public static class IEnumerableExtension
    {
        public enum SortDirection
        {
            Ascending,

            Descending
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
                    int maxItems)
        {
            return items.Select((item, inx) => new { item, inx })
                .GroupBy(x => x.inx / maxItems)
                .Select(g => g.Select(x => x.item));
        }

        /// <summary>Orders the by.</summary>
        /// <param name="enumerable">   The enumerable.</param>
        /// <param name="property">     The property.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <returns>A list of TS.</returns>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> enumerable, string property, SortDirection sortDirection = SortDirection.Ascending)
        {
            return sortDirection == SortDirection.Ascending ? enumerable.OrderBy(x => GetProperty(x, property)) : enumerable.OrderByDescending(x => GetProperty(x, property));
        }

        private static object GetProperty(object o, string propertyName)
        {
            return o.GetType().GetProperty(propertyName)?.GetValue(o, null);
        }
    }

    //public class SortOrder
    //{
    //    public SortOrder(string propName, IEnumerableExtension.SortDirection sortDirection = IEnumerableExtension.SortDirection.Ascending)
    //    {
    //        propName = propName;
    //    }
    //}
}