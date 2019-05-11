using System;
using PBS.Core.Helper;

namespace PBS.Toolkit
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTime GetDateTime(in string value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public DateTime GetFirstDayOfWeek(in DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (date.DayOfWeek - startOfWeek)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        public DateTime GetLastDayOfWeek(in DateTime date, DayOfWeek endOfWeek = DayOfWeek.Sunday)
        {
            int diff = (7 + (endOfWeek - date.DayOfWeek)) % 7;
            return date.AddDays(diff).Date;
        }
    }
}
