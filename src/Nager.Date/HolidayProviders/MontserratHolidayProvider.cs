using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Montserrat HolidayProvider
    /// </summary>
    internal sealed class MontserratHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Montserrat HolidayProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public MontserratHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MS;

            var firstMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second);
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
                    Date = new DateTime(year, 3, 17),
                    EnglishName = "Saint Patrick's Day",
                    LocalName = "Saint Patrick's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstMondayInMay,
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = secondMondayInJune,
                    EnglishName = "Queen's Birthday",
                    LocalName = "Queen's Birthday",
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
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "St. Stephen's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "Festival Day",
                    LocalName = "Festival Day",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.WhitMonday("Whit Monday", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 3, 17, "Saint Patrick's Day", "Saint Patrick's Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            //items.Add(new Holiday(firstMondayInMay, "Labour Day", "Labour Day", countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode));
            //items.Add(new Holiday(secondMondayInJune, "Queen's Birthday", "Queen's Birthday", countryCode));
            //items.Add(new Holiday(firstMondayInAugust, "Emancipation Day", "Emancipation Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "Festival Day", "Festival Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Montserrat",
            ];
        }
    }
}
