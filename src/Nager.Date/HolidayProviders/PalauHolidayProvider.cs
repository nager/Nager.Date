using Nager.Date.Helpers;
using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Palau HolidayProvider
    /// </summary>
    internal sealed class PalauHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Palau HolidayProvider
        /// </summary>
        public PalauHolidayProvider() : base(CountryCode.PW)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstMondayInSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.First);
            var fourthThursdayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Thursday, Occurrence.Fourth);
            var fourthFridayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Friday, Occurrence.Fourth);

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
                    Id = "YOUTHDAY-01",
                    Date = new DateTime(year, 3, 15),
                    EnglishName = "Youth Day",
                    LocalName = "Youth Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "SENIORCITIZENSDAY-01",
                    Date = new DateTime(year, 5, 5),
                    EnglishName = "Senior Citizens Day",
                    LocalName = "Senior Citizens Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PRESIDENTSDAY-01",
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "President's Day",
                    LocalName = "President's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 7, 9),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = firstMondayInSeptember,
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "UNITEDNATIONSDAY-01",
                    Date = new DateTime(year, 10, 24),
                    EnglishName = "United Nations Day",
                    LocalName = "United Nations Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "THANKSGIVINGDAY-01",
                    Date = fourthThursdayInNovember,
                    EnglishName = "Thanksgiving Day",
                    LocalName = "Thanksgiving Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "FAMILYDAY-01",
                    Date = fourthFridayInNovember,
                    EnglishName = "Family Day",
                    LocalName = "Family Day",
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

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Palau",
            ];
        }
    }
}
