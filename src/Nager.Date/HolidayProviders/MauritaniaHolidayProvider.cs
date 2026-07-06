using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mauritania HolidayProvider
    /// </summary>
    internal sealed class MauritaniaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Mauritania HolidayProvider
        /// </summary>
        public MauritaniaHolidayProvider() : base(CountryCode.MR)
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
                    Id = "AFRICADAY-01",
                    Date = new DateTime(year, 5, 25),
                    EnglishName = "Africa Day",
                    LocalName = "Africa Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 11, 28),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            //TODO: Islamic Holidays
            //CalendarType: Lunar
            //DeterminationType: MoonSighting
            //Astronomical calculation: No
            //1 Muharram	Islamic New Year
            //12 Rabi' al-awwal	Mouloud	Muhammad's Birthday
            //1 Shawwal	Korité	Festival of Breaking the Fast
            //10 Dhu al-Hijjah	Tabaski	Feast of the Sacrifice

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mauritania",
            ];
        }
    }
}
