using Nager.Date.Model;
using System;

namespace Nager.Date.Contract
{
    /// <summary>
    /// Orthodox
    /// </summary>
    public class OrthodoxProvider : IOrthodoxProvider
    {
        ///<inheritdoc/>
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

        ///<inheritdoc/>
        public PublicHoliday Pentecost(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(49), localName, "Pentecost", countryCode);
        }

        ///<inheritdoc/>
        public PublicHoliday WhitMonday(string localName, int year, CountryCode countryCode, string[] counties = null)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(50), localName, "Whit Monday", countryCode, null, counties);
        }
    }
}
