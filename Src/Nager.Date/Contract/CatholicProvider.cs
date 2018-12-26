using System;

namespace Nager.Date.Contract
{
    public class CatholicProvider : ICatholicProvider
    {
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
    }
}
