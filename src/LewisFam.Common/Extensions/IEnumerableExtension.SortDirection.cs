using System.Collections.Generic;
using System.Linq;

namespace LewisFam.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
            int maxItems)
        {
            return items.Select((item, inx) => new { item, inx })
                .GroupBy(x => x.inx / maxItems)
                .Select(g => g.Select(x => x.item));
        }

        public enum SortDirection
        {
            Ascending,

            Descending
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