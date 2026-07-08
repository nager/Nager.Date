using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Djibouti HolidayProvider
    /// </summary>
    internal sealed class DjiboutiHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Djibouti HolidayProvider
        /// </summary>
        public DjiboutiHolidayProvider() : base(CountryCode.DJ)
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
                    Date = new DateTime(year, 6, 27),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            //TODO: Islamic Holidays - Djibouti
            // CalendarType: Lunar (Hijri)
            // DeterminationType: MoonSighting (By the Ministry of Islamic Affairs, Culture and Charitable Assets / Supreme Islamic Council)
            // Astronomical calculation: No (Used strictly as a guide; the official decree is announced after local/regional crescent observation)
            //27 Rajab	The Prophet's Ascension	Ascension of Muhammad
            //12 Rabi' al-awwal	The Prophet's Birthday	Birthday of Muhammad
            //1-2 Shawwal	Eid al-Fitr	End of Ramadan
            //9 Dhu al-Hijjah	Arafat Day	Arafat of Muhammad
            //10-11 Dhu al-Hijjah	Eid al-Adha	Feast of Sacrifice
            //1 Muharram	Islamic New Year	Islamic New Year

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Djibouti",
            ];
        }
    }
}
