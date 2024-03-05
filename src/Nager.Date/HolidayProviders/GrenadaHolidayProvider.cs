using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Grenada HolidayProvider
    /// </summary>
    internal class GrenadaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Grenada HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GrenadaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GD;

            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 7),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Indian Arrival Day",
                    LocalName = "Indian Arrival Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "Emancipation Day",
                    LocalName = "Emancipation Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 11),
                    EnglishName = "Carnival",
                    LocalName = "Carnival",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 25),
                    EnglishName = "Thanksgiving Day",
                    LocalName = "Thanksgiving Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.WhitMonday("Whit Monday", year),
                this._catholicProvider.CorpusChristi("Corpus Christi", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 2, 7, "Independence Day", "Independence Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Indian Arrival Day", "Indian Arrival Day", countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode));
            //items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode));
            //items.Add(new Holiday(firstMondayInAugust, "Emancipation Day", "Emancipation Day", countryCode));
            //items.Add(new Holiday(year, 8, 11, "Carnival", "Carnival", countryCode));
            //items.Add(new Holiday(year, 10, 25, "Thanksgiving Day", "Thanksgiving Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Grenada",
            };
        }
    }
}
