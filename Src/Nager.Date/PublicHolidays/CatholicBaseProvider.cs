using Nager.Date.Contract;
using Nager.Date.Model;
using NodaTime;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public abstract class CatholicBaseProvider : IPublicHolidayProvider
    {
        public abstract IEnumerable<PublicHoliday> Get(int year);

        /// <summary>
        /// Get Catholic easter for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime EasterSunday(int year)
        {
            //http://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year

            var g = year % 19;
            var c = year / 100;
            var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));

            var day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            var month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Get advent sunday for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime AdventSunday(int year)
        {
            var christmasDate = new DateTime(year, 12, 24);
            var daysToAdvent = 21 + (int)christmasDate.DayOfWeek;

            return christmasDate.AddDays(-daysToAdvent);
        }

        /// <summary>
        /// Get Catholic Pentecost for requested year
        /// https://en.wikipedia.org/wiki/Pentecost
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime Pentecost(int year)
        {
            return EasterSunday(year).AddDays(49);
        }

        /// <summary>
        /// Get Catholic Trinity Sunday for requested year
        /// https://en.wikipedia.org/wiki/Trinity_Sunday
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime TrinitySunday(int year)
        {
            var pentecostDate = Pentecost(year);
            return LocalDate.FromDateTime(pentecostDate,CalendarSystem.Gregorian).With(DateAdjusters.Next(IsoDayOfWeek.Sunday)).ToDateTimeUnspecified();
        }

        /// <summary>
        /// Get Catholic Corpus Christi for request year
        /// https://en.wikipedia.org/wiki/Corpus_Christi_(feast)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime CorpusChristi(int year)
        {
            var trinitySunday = TrinitySunday(year);
            return LocalDate.FromDateTime(trinitySunday, CalendarSystem.Gregorian).With(DateAdjusters.Next(IsoDayOfWeek.Thursday)).ToDateTimeUnspecified();
        }
    }
}
