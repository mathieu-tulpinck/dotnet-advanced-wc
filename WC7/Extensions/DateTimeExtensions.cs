using System;

namespace WC7.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            while (dt.DayOfWeek != startOfWeek) {
                dt = dt.AddDays(-1);
            }

            return dt.Date;
        }
    }
}
