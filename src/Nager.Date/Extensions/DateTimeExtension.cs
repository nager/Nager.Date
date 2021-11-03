using System;

namespace Nager.Date.Extensions
{
    /// <summary>
    /// DateTimeExtension
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Checks if the specified date is a weekend
        /// </summary>
        /// <param name="dateTime">The date</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime dateTime, CountryCode countryCode)
        {
            var provider = DateSystem.GetWeekendProvider(countryCode);
            return provider.IsWeekend(dateTime);
        }

        /// <summary>
        /// If the given date on this Weekday it can be shifted
        /// </summary>
        /// <param name="value">The date</param>
        /// <param name="saturday">shift for Saturday</param>
        /// <param name="sunday">shift for Sunday</param>
        /// <param name="monday">shift for Monday</param>
        /// <returns></returns>
        public static DateTime Shift(this DateTime value, Func<DateTime, DateTime> saturday, Func<DateTime, DateTime> sunday, Func<DateTime, DateTime> monday = null)
        {
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

        /// <summary>
        /// If the given date on this Weekday it can be shifted
        /// </summary>
        /// <param name="value">The date</param>
        /// <param name="dayOfWeek">Weekday</param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public static DateTime Shift(this DateTime value, DayOfWeek dayOfWeek, Func<DateTime, DateTime> shift)
        {
            if (shift != null && value.DayOfWeek == dayOfWeek)
            {
                return shift.Invoke(value);
            }

            return value;
        }

        /// <summary>
        /// ShiftWeekdays
        /// </summary>
        /// <param name="value"></param>
        /// <param name="monday"></param>
        /// <param name="tuesday"></param>
        /// <param name="wednesday"></param>
        /// <param name="thursday"></param>
        /// <param name="friday"></param>
        /// <returns></returns>
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
        public static DateTime ShiftToClosest(this DateTime value, DayOfWeek targetDayOfWeek)
        {
            var daysDif = targetDayOfWeek - value.DayOfWeek;
            if (daysDif < -3) { daysDif += 7; }
            return value.AddDays(daysDif);
        }
    }
}
