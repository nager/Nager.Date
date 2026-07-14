using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Cocos (Keeling) Islands HolidayProvider
    /// </summary>
    internal sealed class CocosIslandsHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Cocos (Keeling) Islands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CocosIslandsHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.CC)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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
                    Id = "SELFDETERMINATIONDAY-01",
                    Date = new DateTime(year, 4, 6),
                    EnglishName = "Self Determination Day",
                    LocalName = "Self Determination Day",
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
                    Id = "KINGSBIRTHDAY-01",
                    Date = new DateTime(year, 6, 6),
                    EnglishName = "King's Birthday",
                    LocalName = "King's Birthday",
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

            // TODO: Islamic Holidays
            // CalendarType: Lunar
            // DeterminationType: MoonSighting (By the Islamic Council of Cocos Keeling Islands)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //Hari Raya Puasa
            //Hari Raya Haji
            //Islamic New Year
            //Hari Maulaud Nabi

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Cocos_(Keeling)_Islands",
            ];
        }
    }
}
