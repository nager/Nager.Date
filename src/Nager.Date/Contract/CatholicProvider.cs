using Nager.Date.Model;
using System;
using System.Collections.Concurrent;

namespace Nager.Date.Contract
{

    /// <summary>
    /// Catholic
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
                var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));

                var day = i - ((y + (int)(y / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
                var month = 3;

                if (day > 31)
                {
                    month++;
                    day -= 31;
                }

                return new DateTime(y, month, day);
            });
        }

        ///<inheritdoc/>
        public DateTime AdventSunday(int year)
        {
            var christmasDate = new DateTime(year, 12, 24);
            var daysToAdvent = 21 + (int)christmasDate.DayOfWeek;

            return christmasDate.AddDays(-daysToAdvent);
        }

        ///<inheritdoc/>
        public PublicHoliday MaundyThursday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(-3), localName, "Maundy Thursday", countryCode);
        }

        ///<inheritdoc/>
        public PublicHoliday GoodFriday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(-2), localName, "Good Friday", countryCode);
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
        public PublicHoliday AscensionDay(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(39), localName, "Ascension Day", countryCode);
        }

        ///<inheritdoc/>
        public PublicHoliday Pentecost(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(49), localName, "Pentecost", countryCode);
        }

        ///<inheritdoc/>
        public PublicHoliday WhitMonday(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(50), localName, "Whit Monday", countryCode);
        }

        ///<inheritdoc/>
        public PublicHoliday CorpusChristi(string localName, int year, CountryCode countryCode)
        {
            var easterSunday = this.EasterSunday(year);
            return new PublicHoliday(easterSunday.AddDays(60), localName, "Corpus Christi", countryCode);
        }
    }
}
