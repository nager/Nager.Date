using Nager.Date.Model;
using System;
using System.Collections.Concurrent;

namespace Nager.Date.Contract
{

    /// <summary>
    /// Orthodox
    /// </summary>
    public class OrthodoxProvider : IOrthodoxProvider
    {
        private static readonly ConcurrentDictionary<int, DateTime> _cache = new ConcurrentDictionary<int, DateTime>();

        ///<inheritdoc/>
        public DateTime EasterSunday(int year)
        {
            return _cache.GetOrAdd(year, y =>
            {
                var a = y % 19;
                var b = y % 7;
                var c = y % 4;

                var d = (19 * a + 16) % 30;
                var e = (2 * c + 4 * b + 6 * d) % 7;
                var f = (19 * a + 16) % 30;
                var key = f + e + 3;

                var month = (key > 30) ? 5 : 4;
                var day = (key > 30) ? key - 30 : key;

                return new DateTime(y, month, day);
            });
        }

        /// <inheritdoc />
        public PublicHoliday GoodFriday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(-2), localName, "Good Friday", countryCode);
        }

        ///<inheritdoc/>
        public PublicHoliday HolySaturday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(-1), localName, "Holy Saturday", countryCode);
        }

        ///<inheritdoc/>
        public PublicHoliday EasterSunday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday, localName, "Easter Sunday", countryCode);
        }

        ///<inheritdoc/>
        public PublicHoliday EasterMonday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(1), localName, "Easter Monday", countryCode);
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
