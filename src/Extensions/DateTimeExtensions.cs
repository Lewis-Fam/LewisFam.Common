using System;
using System.Collections.Generic;
using System.Text;

namespace LewisFam.Common.Extensions
{
    public static class DateTimeExtensions
    {

        public static bool IsMarketHours(this DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Sunday || dateTime.DayOfWeek == DayOfWeek.Saturday) return false;

            var open = new TimeSpan(7, 30, 0);
            var close = new TimeSpan(14, 00, 0);

            var a = dateTime.TimeOfDay < close;
            var b = dateTime.TimeOfDay > open;

            return a && b;
        }
    }
    
}
