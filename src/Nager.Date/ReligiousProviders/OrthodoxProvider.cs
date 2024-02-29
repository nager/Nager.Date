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
        public HolidaySpecification GoodFriday(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(-2),
                EnglishName = "Good Friday",
                LocalName = localName,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public HolidaySpecification HolySaturday(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(-1),
                EnglishName = "Holy Saturday",
                LocalName = localName,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public HolidaySpecification EasterSunday(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday,
                EnglishName = "Easter Sunday",
                LocalName = localName,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public HolidaySpecification EasterMonday(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(1),
                EnglishName = "Easter Monday",
                LocalName = localName,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public HolidaySpecification Pentecost(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(49),
                EnglishName = "Pentecost",
                LocalName = localName,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
        public HolidaySpecification WhitMonday(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null,
            string[] counties = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(50),
                EnglishName = "Whit Monday",
                LocalName = localName,
                ObservedRuleSet = observedRuleSet,
                SubdivisionCodes = counties
            };
        }
    }
}
