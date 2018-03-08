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

        public static DateTime ShiftWeekdays(this DateTime value, Func<DateTime, DateTime> monday = null, Func<DateTime, DateTime> tuesday = null, Func<DateTime, DateTime> wednesday = null, Func<DateTime, DateTime> thursday = null, Func<DateTime, DateTime> friday = null)
        {
            var daysOff = new List<DateTime>();
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

        ///
        /// Get the current season return the day
        ///
        ///
        ///
        public static Seasons Season(this DateTime date, bool northernEmisphere)
        {
            /* Astronomically Spring begins on March 21st, the 80th day of the year.
             * Summer begins on the 172nd day, Autumn, the 266th and Winter the 355th.
             * Of course, on a leap year add one day to each, 81, 173, 267 and 356.*/

            int doy = date.DayOfYear - Convert.ToInt32((DateTime.IsLeapYear(date.Year)) && date.DayOfYear > 59);

            if (doy < 80 || doy >= 355) return northernEmisphere ? Seasons.Winter : Seasons.Summer;

            if (doy >= 80 && doy < 172) return northernEmisphere ? Seasons.Spring : Seasons.Autumn;

            if (doy >= 172 && doy < 266) return northernEmisphere ? Seasons.Summer : Seasons.Winter;

            return northernEmisphere ? Seasons.Autumn : Seasons.Spring;
        }

        public static DateTime FirstDayOfTheYear(this DateTime dt, int year)
        {
            return new DateTime(year, 1, 1);
        }
    }
}