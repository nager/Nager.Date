using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Iraq HolidayProvider
    /// </summary>
    internal sealed class IraqHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Iraq HolidayProvider
        /// </summary>
        public IraqHolidayProvider() : base(CountryCode.IQ)
        {
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
                    Id = "ARMYDAY-01",
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Army Day",
                    LocalName = "Army Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NOWRUZ-01",
                    Date = new DateTime(year, 3, 21),
                    EnglishName = "Nowruz",
                    LocalName = "Nowruz",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY-01",
                    Date = new DateTime(year, 10, 3),
                    EnglishName = "National Day",
                    LocalName = "National Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "VICTORYDAY-01",
                    Date = new DateTime(year, 12, 10),
                    EnglishName = "Victory Day",
                    LocalName = "Victory Day",
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
            };

            // Islamic Holidays
            // CalendarType: Lunar
            // DeterminationType: MoonSighting (By the Sunni Endowment Diwan & Shia religious authorities / Najaf Hawza)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //Muharram 1	Islamic New Year
            //Muharram 10	Ashura
            //Rabi' al-Awwal 12	The Prophet's Birthday
            //Shawwal 1	End of Ramadan (3 days)
            //Dhu al-Hijjah 10	Feast of Sacrifice (4 days)
            //Dhu al-Hijjah 18	Eid al-Ghadir

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Iraq",
            ];
        }
    }
}
