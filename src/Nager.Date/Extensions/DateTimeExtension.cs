using System;

namespace Nager.Date.Extensions
{
    /// <summary>
    /// DateTime Extension
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Checks if the specified date is a weekend
        /// </summary>
        /// <param name="dateTime">The date</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>True if given date is in the weekend in given country, false otherwise</returns>
        public static bool IsWeekend(
            this DateTime dateTime,
            CountryCode countryCode)
        {
            var provider = WeekendSystem.GetWeekendProvider(countryCode);
            return provider.IsWeekend(dateTime);
        }

        /// <summary>
        /// If the given date on this Weekday it can be shifted
        /// </summary>
        /// <param name="value">The date</param>
        /// <param name="saturday">shift for Saturday</param>
        /// <param name="sunday">shift for Sunday</param>
        /// <param name="monday">shift for Monday</param>
        /// <returns>Shifted date</returns>
        internal static DateTime Shift(
            this DateTime value,
            Func<DateTime, DateTime> saturday,
            Func<DateTime, DateTime> sunday,
            Func<DateTime, DateTime>? monday = null)
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
    }
}
