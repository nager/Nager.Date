using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Tunisia HolidayProvider
    /// </summary>
    internal sealed class TunisiaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Tunisia HolidayProvider
        /// </summary>
        public TunisiaHolidayProvider() : base(CountryCode.TN)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO:Add moon calendar logic

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
                    Date = new DateTime(year, 1, 14),
                    EnglishName = "Revolution and Youth Day",
                    LocalName = "Revolution and Youth Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 20),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 9),
                    EnglishName = "Martyrs' Day",
                    LocalName = "Martyrs' Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "Victory Day",
                    LocalName = "Victory Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 25),
                    EnglishName = "Republic Day",
                    LocalName = "Republic Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 13),
                    EnglishName = "Women's Day",
                    LocalName = "Women's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 15),
                    EnglishName = "Eid El Jala'",
                    LocalName = "Eid El Jala'",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Tunisia"
            ];
        }
    }
}
