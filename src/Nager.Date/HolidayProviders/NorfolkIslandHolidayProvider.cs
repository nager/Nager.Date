using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Norfolk Island HolidayProvider
    /// </summary>
    internal sealed class NorfolkIslandHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Norfolk Island HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NorfolkIslandHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.NF)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var secondMondayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second);
            var secondMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);
            var fourthWednesdayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Wednesday, Occurrence.Fourth);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "AUSTRALIADAY-01",
                    Date = new DateTime(year, 1, 26),
                    EnglishName = "Australia Day",
                    LocalName = "Australia Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "FOUNDATIONDAY-01",
                    Date = new DateTime(year, 3, 6),
                    EnglishName = "Norfolk Island Foundation Day",
                    LocalName = "Norfolk Island Foundation Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ANZACDAY-01",
                    Date = new DateTime(year, 4, 25),
                    EnglishName = "Anzac Day",
                    LocalName = "Anzac Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "BOUNTYDAY-01",
                    Date = new DateTime(year, 6, 8),
                    EnglishName = "Bounty Day",
                    LocalName = "Bounty Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "KINGSBIRTHDAY-01",
                    Date = secondMondayInJune,
                    EnglishName = "King's Birthday",
                    LocalName = "King's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "AGRICULTURALSHOW-01",
                    Date = secondMondayInOctober,
                    EnglishName = "Norfolk Island Agricultural Show",
                    LocalName = "KNorfolk Island Agricultural Show",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "THANKSGIVINGDAY-01",
                    Date = fourthWednesdayInNovember,
                    EnglishName = "Thanksgiving Day",
                    LocalName = "Thanksgiving Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Norfolk_Island",
            ];
        }
    }
}
