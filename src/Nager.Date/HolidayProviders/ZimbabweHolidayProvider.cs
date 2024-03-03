using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Zimbabwe HolidayProvider
    /// </summary>
    internal class ZimbabweHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Zimbabwe HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ZimbabweHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.ZW;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var secondMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.Second);
            var tuesdayAfterSecondMondayInAugust = secondMondayInAugust.AddDays(1);

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
                    Date = new DateTime(year, 2, 21),
                    EnglishName = "Robert Mugabe National Youth Day",
                    LocalName = "Robert Mugabe National Youth Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-1),
                    EnglishName = "Easter Saturday",
                    LocalName = "Easter Saturday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 18),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Worker's Day",
                    LocalName = "Worker's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 25),
                    EnglishName = "Africa Day",
                    LocalName = "Africa Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = secondMondayInAugust,
                    EnglishName = "Heroes' Day",
                    LocalName = "Heroes' Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = tuesdayAfterSecondMondayInAugust,
                    EnglishName = "Defence Forces Day",
                    LocalName = "Defence Forces Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 22),
                    EnglishName = "Unity Day",
                    LocalName = "Unity Day",
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
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterSaturday("Easter Saturday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 2, 21, "Robert Mugabe National Youth Day", "Robert Mugabe National Youth Day", countryCode, 2018));
            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-1), "Easter Saturday", "Easter Saturday", countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            //items.Add(new Holiday(year, 4, 18, "Independence Day", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Worker's Day", "Worker's Day", countryCode));
            //items.Add(new Holiday(year, 5, 25, "Africa Day", "Africa Day", countryCode));
            //items.Add(new Holiday(secondMondayInAugust, "Heroes' Day", "Heroes' Day", countryCode));
            //items.Add(new Holiday(tuesdayAfterSecondMondayInAugust, "Defence Forces Day", "Defence Forces Day", countryCode));
            //items.Add(new Holiday(year, 12, 22, "Unity Day", "Unity Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.m.wikipedia.org/wiki/Public_holidays_in_Zimbabwe"
            };
        }
    }
}
