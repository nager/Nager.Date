using System;
using System.Collections.Generic;

namespace Nager.Date.Extensions
{
    public static class DateTimeExtension
    {
        public static bool IsWeekend(this DateTime dateTime, CountryCode countryCode)
        {
            //For feature weekend is different need countryCode
            //https://en.wikipedia.org/wiki/Workweek_and_weekend

            if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            return false;
        }

        public static DateTime Shift(this DateTime value, Func<DateTime, DateTime> saturday, Func<DateTime, DateTime> sunday, Func<DateTime, DateTime> monday = null)
        {
            var daysOff = new List<DateTime>();
            switch (value.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return saturday.Invoke(value);
                case DayOfWeek.Sunday:
                    return sunday.Invoke(value);
                case DayOfWeek.Monday:
                    if (monday != null)
                    {
                        return monday.Invoke(value);
                    }
                    break;
                default:
                    break;
            }

            return value;
        }
    }
}