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

        /// <inheritdoc/>
        public DateTime EasterSunday(int year)
        {
            var daysToAddForGregorianCalendar = year switch
            {
                int y when (y >= 1583 && y <= 1699) => 10,
                int y when (y >= 1700 && y <= 1799) => 11,
                int y when (y >= 1800 && y <= 1899) => 12,
                int y when (y >= 1900 && y <= 2099) => 13,
                int y when (y >= 2100 && y <= 2199) => 14,
                int y when (y >= 2200 && y <= 2299) => 15,
                int y when (y >= 2300 && y <= 2499) => 16,
                int y when (y >= 2500 && y <= 2599) => 17,
                int y when (y >= 2600 && y <= 2699) => 18,
                int y when (y >= 2700 && y <= 2899) => 19,
                int y when (y >= 2900 && y <= 2999) => 20,
                int y when (y >= 3000 && y <= 3099) => 21,
                int y when (y >= 3100 && y <= 3299) => 22,
                int y when (y >= 3300 && y <= 3399) => 23,
                _ => 0,
            };

            return _cache.GetOrAdd(year, y =>
            {
                var a = y % 19;
                var b = y % 7;
                var c = y % 4;

                var d = (19 * a + 15) % 30;
                var e = (2 * c + 4 * b - d + 34) % 7;

                var month = (int)Math.Floor((d + e + 114.0) / 31);
                var day = ((d + e + 114) % 31) + 1;

                return new DateTime(y, month, day).AddDays(daysToAddForGregorianCalendar);
            });
        }

        /// <inheritdoc />
        public HolidaySpecification GoodFriday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(-2),
                EnglishName = "Good Friday",
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public HolidaySpecification HolySaturday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(-1),
                EnglishName = "Holy Saturday",
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public HolidaySpecification EasterSunday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday,
                EnglishName = "Easter Sunday",
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public HolidaySpecification EasterMonday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(1),
                EnglishName = "Easter Monday",
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public HolidaySpecification Pentecost(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(49),
                EnglishName = "Pentecost",
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public HolidaySpecification WhitMonday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(50),
                EnglishName = "Whit Monday",
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }
    }
}
