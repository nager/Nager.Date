using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Estonia HolidayProvider
    /// </summary>
    internal class EstoniaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Estonia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public EstoniaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.EE;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "uusaasta",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 24),
                    EnglishName = "Independence Day",
                    LocalName = "iseseisvuspäev",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Spring Day",
                    LocalName = "kevadpüha",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 23),
                    EnglishName = "Victory Day",
                    LocalName = "võidupüha and jaanilaupäev",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 24),
                    EnglishName = "Midsummer Day",
                    LocalName = "jaanipäev",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 20),
                    EnglishName = "Day of Restoration of Independence",
                    LocalName = "taasiseseisvumispäev",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "jõululaupäev",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "esimene jõulupüha",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "teine jõulupüha",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("suur reede", year),
                this._catholicProvider.EasterSunday("ülestõusmispühade 1. püha", year),
                this._catholicProvider.Pentecost("nelipühade 1. püha", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "uusaasta", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 2, 24, "iseseisvuspäev", "Independence Day", countryCode, 1918));
            //items.Add(this._catholicProvider.GoodFriday("suur reede", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("ülestõusmispühade 1. püha", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "kevadpüha", "Spring Day", countryCode));
            //items.Add(this._catholicProvider.Pentecost("nelipühade 1. püha", year, countryCode));
            //items.Add(new Holiday(year, 6, 23, "võidupüha and jaanilaupäev", "Victory Day", countryCode));
            //items.Add(new Holiday(year, 6, 24, "jaanipäev", "Midsummer Day", countryCode));
            //items.Add(new Holiday(year, 8, 20, "taasiseseisvumispäev", "Day of Restoration of Independence", countryCode, 1991));
            //items.Add(new Holiday(year, 12, 24, "jõululaupäev", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "esimene jõulupüha", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "teine jõulupüha", "St. Stephen's Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Estonia",
            };
        }
    }
}
