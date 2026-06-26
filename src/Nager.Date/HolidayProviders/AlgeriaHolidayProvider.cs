using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Algeria HolidayProvider
    /// </summary>
    internal sealed class AlgeriaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Algeria HolidayProvider
        /// </summary>
        public AlgeriaHolidayProvider() : base(CountryCode.DZ)
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
                    Id = "AMAZIGHNEWYEAR-01",
                    Date = new DateTime(year, 1, 12),
                    EnglishName = "Amazigh New Year",
                    LocalName = "Amazigh New Year",
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
                    Date = new DateTime(year, 7, 5),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "REVOLUTIONDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "Revolution Day",
                    LocalName = "Revolution Day",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            // TODO:
            // - Islamic New Year - The 1st day of the month of Muharram
            // - Ashura - The 10th day of the month of Muharram
            // - Mawlid - The Birth of Muhammad
            // - Eid al-Fitr - The end of Ramadan
            // - Eid al-Adha - Sacrifice Feast

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Algeria",
            ];
        }
    }
}
