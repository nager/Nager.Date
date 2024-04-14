using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Guernsey HolidayProvider
    /// </summary>
    internal sealed class GuernseyHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Guernsey HolidayProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public GuernseyHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.GG)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var lastMondayInMay = DateHelper.FindLastDay(year, Month.May, DayOfWeek.Monday);
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
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Early May Bank Holiday",
                    LocalName = "Early May Bank Holiday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Liberation Day",
                    LocalName = "Liberation Day",
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
                    Date = lastMondayInAugust,
                    EnglishName = "Summer Bank Holiday",
                    LocalName = "Summer Bank Holiday",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Guernsey"
            ];
        }
    }
}
