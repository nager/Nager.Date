using System;

namespace Nager.Date.Contract
{
    public class OrthodoxProvider : IOrthodoxProvider
    {
        /// <summary>
        /// Get Orthodox easter for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime EasterSunday(int year)
        {
            var a = year % 19;
            var b = year % 7;
            var c = year % 4;

            var d = (19 * a + 16) % 30;
            var e = (2 * c + 4 * b + 6 * d) % 7;
            var f = (19 * a + 16) % 30;
            var key = f + e + 3;

            var month = (key > 30) ? 5 : 4;
            var day = (key > 30) ? key - 30 : key;

            return new DateTime(year, month, day);
        }
    }
}
