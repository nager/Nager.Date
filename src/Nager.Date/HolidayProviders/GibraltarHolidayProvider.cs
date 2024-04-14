using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Gibraltar HolidayProvider
    /// </summary>
    internal sealed class GibraltarHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Gibraltar HolidayProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public GibraltarHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.GI)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var secondMondayInMarch = DateHelper.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second);
            var lastMondayInMay = DateHelper.FindLastDay(year, Month.May, DayOfWeek.Monday);
            var thirdMondayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second);
            var lastMondayInAugust = DateHelper.FindLastDay(year, Month.August, DayOfWeek.Monday);

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
                    Date = secondMondayInMarch,
                    EnglishName = "Commonwealth Day",
                    LocalName = "Commonwealth Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 28),
                    EnglishName = "Workers' Memorial Day",
                    LocalName = "Workers' Memorial Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day Bank Holiday",
                    LocalName = "May Day Bank Holiday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = lastMondayInMay,
                    EnglishName = "Spring Bank Holiday",
                    LocalName = "Spring Bank Holiday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInJune,
                    EnglishName = "Queen's Birthday",
                    LocalName = "Queen's Birthday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = lastMondayInAugust,
                    EnglishName = "Summer Bank Holiday",
                    LocalName = "Summer Bank Holiday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 10),
                    EnglishName = "Gibraltar National Day",
                    LocalName = "Gibraltar National Day",
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
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Gibraltar"
            ];
        }
    }
}
