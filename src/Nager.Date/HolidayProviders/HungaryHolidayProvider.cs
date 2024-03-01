using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Hungary HolidayProvider
    /// </summary>
    internal class HungaryHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Hungary HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public HungaryHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.HU;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Újév",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 15),
                    EnglishName = "1848 Revolution Memorial Day",
                    LocalName = "Nemzeti ünnep",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour day",
                    LocalName = "A munka ünnepe",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 20),
                    EnglishName = "State Foundation Day",
                    LocalName = "Az államalapítás ünnepe",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 23),
                    EnglishName = "1956 Revolution Memorial Day",
                    LocalName = "Nemzeti ünnep",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "Mindenszentek",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Karácsony",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Karácsony másnapja",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("Húsvétvasárnap", year),
                this._catholicProvider.EasterMonday("Húsvéthétfő", year),
                this._catholicProvider.Pentecost("Pünkösdvasárnap", year),
                this._catholicProvider.WhitMonday("Pünkösdhétfő", year)
            };

            if (year >= 2017)
            {
                holidaySpecifications.AddIfNotNull(this._catholicProvider.GoodFriday("Nagypéntek", year));
            }

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Újév", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 3, 15, "Nemzeti ünnep", "1848 Revolution Memorial Day", countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Húsvétvasárnap", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Húsvéthétfő", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "A munka ünnepe", "Labour day", countryCode));
            //items.Add(this._catholicProvider.Pentecost("Pünkösdvasárnap", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Pünkösdhétfő", year, countryCode));
            //items.Add(new Holiday(year, 8, 20, "Az államalapítás ünnepe", "State Foundation Day", countryCode));
            //items.Add(new Holiday(year, 10, 23, "Nemzeti ünnep", "1956 Revolution Memorial Day", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Mindenszentek", "All Saints Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Karácsony", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Karácsony másnapja", "St. Stephen's Day", countryCode));

            //if (year >= 2017)
            //{
            //    items.Add(this._catholicProvider.GoodFriday("Nagypéntek", year, countryCode));
            //}

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Hungary",
            };
        }
    }
}
