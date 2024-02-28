using Nager.Date.Models;
using System;
using System.Collections.Concurrent;

namespace Nager.Date.ReligiousProviders
{
    /// <summary>
    /// Orthodox Provider
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

                var month = key > 30 ? 5 : 4;
                var day = key > 30 ? key - 30 : key;

                return new DateTime(y, month, day);
            });
        }

        /// <inheritdoc />
        public Holiday GoodFriday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new Holiday(easterSunday.AddDays(-2), localName, "Good Friday", countryCode);
        }

        ///<inheritdoc/>
        public Holiday HolySaturday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new Holiday(easterSunday.AddDays(-1), localName, "Holy Saturday", countryCode);
        }

        ///<inheritdoc/>
        public Holiday EasterSunday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new Holiday(easterSunday, localName, "Easter Sunday", countryCode);
        }

        ///<inheritdoc/>
        public Holiday EasterMonday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new Holiday(easterSunday.AddDays(1), localName, "Easter Monday", countryCode);
        }

        ///<inheritdoc/>
        public Holiday Pentecost(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new Holiday(easterSunday.AddDays(49), localName, "Pentecost", countryCode);
        }

        ///<inheritdoc/>
        public Holiday WhitMonday(string localName, int year, CountryCode countryCode, string[] counties = null)
        {
            var easterSunday = this.EasterSunday(year);
            return new Holiday(easterSunday.AddDays(50), localName, "Whit Monday", countryCode, null, counties);
        }
    }
}
