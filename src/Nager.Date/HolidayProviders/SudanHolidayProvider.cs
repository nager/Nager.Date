using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Sudan HolidayProvider
    /// </summary>
    internal sealed class SudanHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Sudan HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public SudanHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.SD)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ORTHODOXCHRISTMASDAY-01",
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Coptic Christmas",
                    LocalName = "Coptic Christmas",
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
                this._orthodoxProvider.EasterSunday("Coptic Easter Sunday", year),
            };

            // TODO: Islamic Holidays
            // CalendarType: Lunar
            // DeterminationType: MoonSighting (By the Islamic Fiqh Academy of Sudan / Majma' al-Fiqh al-Islami)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //The Prophet's Birthday
            //Eid al-Fitr
            //Islamic New Year
            //Eid al-Adha

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Sudan",
            ];
        }
    }
}
