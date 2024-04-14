using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Zimbabwe HolidayProvider
    /// </summary>
    internal sealed class ZimbabweHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Zimbabwe HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ZimbabweHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.ZW)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var secondMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.Second);
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

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.m.wikipedia.org/wiki/Public_holidays_in_Zimbabwe"
            ];
        }
    }
}
