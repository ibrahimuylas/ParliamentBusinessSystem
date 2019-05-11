using System;
namespace PBS.Core.Helper
{
    public interface IDateTimeHelper
    {
        DateTime GetFirstDayOfWeek(in DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday);
        DateTime GetLastDayOfWeek(in DateTime date, DayOfWeek endOfWeek = DayOfWeek.Sunday);
        DateTime GetDateTime(in string value);
    }
}
