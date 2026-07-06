using Nager.Date.Helpers;
using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Liberia HolidayProvider
    /// </summary>
    internal sealed class LiberiaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Liberia HolidayProvider
        /// </summary>
        public LiberiaHolidayProvider() : base(CountryCode.LR)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var secondWednesdayInMarch = DateHelper.FindDay(year, Month.March, DayOfWeek.Wednesday, Occurrence.Second);
            var secondFridayInApril = DateHelper.FindDay(year, Month.April, DayOfWeek.Friday, Occurrence.Second);
            var firstThursdayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Thursday, Occurrence.First);

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
                    Id = "ARMEDFORCESDAY-01",
                    Date = new DateTime(year, 2, 11),
                    EnglishName = "Armed Forces Day",
                    LocalName = "Armed Forces Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDECORATIONDAY-01",
                    Date = secondWednesdayInMarch,
                    EnglishName = "National Decoration Day",
                    LocalName = "National Decoration Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PRESIDENTROBERTSBIRTHDAY-01",
                    Date = new DateTime(year, 3, 15),
                    EnglishName = "Joseph Jenkins Roberts Birthday",
                    LocalName = "Joseph Jenkins Roberts Birthday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "FASTANDPRAYERDAY-01",
                    Date = secondFridayInApril,
                    EnglishName = "Fast and Prayer Day",
                    LocalName = "Fast and Prayer Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALUNIFICATIONDAY-01",
                    Date = new DateTime(year, 5, 14),
                    EnglishName = "National Unification Day",
                    LocalName = "National Unification Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 7, 26),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALFLAGDAY-01",
                    Date = new DateTime(year, 8, 24),
                    EnglishName = "National Flag Day",
                    LocalName = "National Flag Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "THANKSGIVINGDAY-01",
                    Date = firstThursdayInNovember,
                    EnglishName = "Thanksgiving Day",
                    LocalName = "Thanksgiving Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PRESIDENTTUBMANSBIRTHDAY-01",
                    Date = new DateTime(year, 11, 29),
                    EnglishName = "William V. S. Tubman's Birthday",
                    LocalName = "William V. S. Tubman's Birthday",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Liberia",
            ];
        }
    }
}
