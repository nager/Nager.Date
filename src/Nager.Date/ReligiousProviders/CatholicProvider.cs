using Nager.Date.Models;
using System;
using System.Collections.Concurrent;

namespace Nager.Date.ReligiousProviders
{
    /// <summary>
    /// Catholic Provider
    /// </summary>
    public class CatholicProvider : ICatholicProvider
    {
        private static readonly ConcurrentDictionary<int, DateTime> _cache = new ConcurrentDictionary<int, DateTime>();

        /// <inheritdoc/>
        public DateTime EasterSunday(int year)
        {
            return _cache.GetOrAdd(year, y =>
            {
                //http://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year

                var g = y % 19;
                var c = y / 100;
                var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
                var i = h - h / 28 * (1 - h / 28 * (29 / (h + 1)) * ((21 - g) / 11));

                var day = i - (y + y / 4 + i + 2 - c + c / 4) % 7 + 28;
                var month = 3;

                if (day > 31)
                {
                    month++;
                    day -= 31;
                }

                return new DateTime(y, month, day);
            });
        }

        /// <inheritdoc/>
        public DateTime AdventSunday(int year)
        {
            var christmasDate = new DateTime(year, 12, 24);
            var daysToAdvent = 21 + (int)christmasDate.DayOfWeek;

            return christmasDate.AddDays(-daysToAdvent);
        }

        /// <inheritdoc/>
        public HolidaySpecification MaundyThursday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(-3),
                EnglishName = "Maundy Thursday",
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }

        /// <inheritdoc/>
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
        public HolidaySpecification EasterSaturday(
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
        public HolidaySpecification AscensionDay(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(39),
                EnglishName = "Ascension Day",
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

        /// <inheritdoc/>
        public HolidaySpecification CorpusChristi(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null)
        {
            var easterSunday = this.EasterSunday(year);

            return new HolidaySpecification
            {
                Date = easterSunday.AddDays(60),
                EnglishName = "Corpus Christi",
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }
    }
}
