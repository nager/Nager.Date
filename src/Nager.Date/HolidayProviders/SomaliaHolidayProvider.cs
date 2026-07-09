using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Somalia HolidayProvider
    /// </summary>
    internal sealed class SomaliaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Somalia HolidayProvider
        /// </summary>
        public SomaliaHolidayProvider() : base(CountryCode.SO)
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
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 6, 26),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "REPUBLICDAY-01",
                    Date = new DateTime(year, 7, 1),
                    EnglishName = "Republic Day",
                    LocalName = "Republic Day",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            // Islamic Holidays
            // CalendarType: Lunar
            // DeterminationType: MoonSighting (By the Ministry of Religious Affairs and Endowments / National Moon-Sighting Committee)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //12 Rabi' al-Awwal	Mawlid Nabi	Birthday of Muhammad
            //1 Shawwal	Eid al-Fitr	End of Ramadan
            //10 Dhu'l-Hijja	Eid al-Adha	Feast of Sacrifice
            //1 Muharram	Islamic New Year	Islamic New Year
            //10 Muharram	Ashura	Ashura

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Somalia",
            ];
        }
    }
}
