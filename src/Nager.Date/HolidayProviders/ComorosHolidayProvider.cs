using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Comoros HolidayProvider
    /// </summary>
    internal sealed class ComorosHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Comoros HolidayProvider
        /// </summary>
        public ComorosHolidayProvider() : base(CountryCode.KM)
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
                    Id = "CHEIKHALMAAROUFDAY-01",
                    Date = new DateTime(year, 3, 18),
                    EnglishName = "Cheikh Al Maarouf Day",
                    LocalName = "Cheikh Al Maarouf Day",
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
                    Date = new DateTime(year, 7, 6),
                    EnglishName = "National Day",
                    LocalName = "National Day",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            holidaySpecifications.AddIfNotNull(this.MaoreDay(year));

            //TODO: Islamic Holidays
            //CalendarType: Lunar
            //DeterminationType: MoonSighting (By the Grand Mufti of the Comoros / Dar al-Ifta)
            //Astronomical calculation: No
            //Eid al-Fitr
            //Eid al-Adha

            return holidaySpecifications;
        }

        private HolidaySpecification? MaoreDay(
            int year)
        {
            if (year >= 2006)
            {
                return new HolidaySpecification
                {
                    Id = "MAOREDAY-01",
                    Date = new DateTime(year, 11, 12),
                    EnglishName = "Maore Day",
                    LocalName = "Maore Day",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Comoros",
            ];
        }
    }
}
