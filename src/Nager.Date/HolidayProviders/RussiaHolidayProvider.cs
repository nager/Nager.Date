using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Russia HolidayProvider
    /// </summary>
    internal sealed class RussiaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Russia HolidayProvider
        /// </summary>
        public RussiaHolidayProvider() : base(CountryCode.RU)
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
                    LocalName = "Новый год",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-02",
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year holiday",
                    LocalName = "Новогодние каникулы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-03",
                    Date = new DateTime(year, 1, 3),
                    EnglishName = "New Year holiday",
                    LocalName = "Новогодние каникулы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-04",
                    Date = new DateTime(year, 1, 4),
                    EnglishName = "New Year holiday",
                    LocalName = "Новогодние каникулы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-05",
                    Date = new DateTime(year, 1, 5),
                    EnglishName = "New Year holiday",
                    LocalName = "Новогодние каникулы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-06",
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "New Year holiday",
                    LocalName = "Новогодние каникулы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Orthodox Christmas Day",
                    LocalName = "Рождество Христово",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 23),
                    EnglishName = "Defender of the Fatherland Day",
                    LocalName = "День защитника Отечества",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Международный женский день",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "День труда",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "VICTORYDAY-01",
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Victory Day",
                    LocalName = "День Победы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "RUSSIADAY-01",
                    Date = new DateTime(year, 6, 12),
                    EnglishName = "Russia Day",
                    LocalName = "День России",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "UNITYDAY-01",
                    Date = new DateTime(year, 11, 4),
                    EnglishName = "Unity Day",
                    LocalName = "День народного единства",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Russia"
            ];
        }
    }
}
