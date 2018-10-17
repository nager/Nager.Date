using System;
using System.Collections.Generic;

namespace Nager.Date.Extensions
{
    public static class DateTimeExtension
    {
        public static bool IsWeekend(this DateTime dateTime, CountryCode countryCode)
        {
            var provider = DateSystem.GetWeekendProvider(countryCode);
            return provider.IsWeekend(dateTime);
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

        public static DateTime ShiftWeekdays(this DateTime value, Func<DateTime, DateTime> monday = null, Func<DateTime, DateTime> tuesday = null, Func<DateTime, DateTime> wednesday = null, Func<DateTime, DateTime> thursday = null, Func<DateTime, DateTime> friday = null)
        {
            switch (value.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    if (monday != null)
                    {
                        return monday.Invoke(value);
                    }
                    break;

                case DayOfWeek.Tuesday:
                    if (tuesday != null)
                    {
                        return tuesday.Invoke(value);
                    }
                    break;

                case DayOfWeek.Wednesday:
                    if (wednesday != null)
                    {
                        return wednesday.Invoke(value);
                    }
                    break;

                case DayOfWeek.Thursday:
                    if (thursday != null)
                    {
                        return thursday.Invoke(value);
                    }
                    break;

                case DayOfWeek.Friday:
                    if (friday != null)
                    {
                        return friday.Invoke(value);
                    }
                    break;

                default:
                    break;
            }

            return value;
        }

        public static DateTime Shift(this DateTime value, DayOfWeek dayOfWeek, Func<DateTime, DateTime> shift) =>
            (shift != null && value.DayOfWeek == dayOfWeek) ? shift.Invoke(value) : value;
    }
}