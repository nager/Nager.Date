using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Northern Mariana Islands HolidayProvider
    /// </summary>
    internal sealed class NorthernMarianaIslandsHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Northern Mariana Islands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NorthernMarianaIslandsHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.MP)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var thirdMondayInJanuary = DateHelper.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayInFebruary = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third);
            var lastMondayInMay = DateHelper.FindLastDay(year, Month.May, DayOfWeek.Monday);
            var firstMondayInSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);
            var fourthThursdayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Thursday, Occurrence.Fourth);

            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(-1),
                Sunday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "MARTINLUTHERKINGJRDAY-01",
                    Date = thirdMondayInJanuary,
                    EnglishName = "Martin Luther King Jr. Day",
                    LocalName = "Martin Luther King Jr. Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PRESIDENTSDAY-01",
                    Date = thirdMondayInFebruary,
                    EnglishName = "Presidents' Day",
                    LocalName = "Presidents' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "COMMONWEALTHCOVENANTDAY-01",
                    Date = new DateTime(year, 3, 24),
                    EnglishName = "Commonwealth Covenant Day",
                    LocalName = "Commonwealth Covenant Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "MEMORIALDAY-01",
                    Date = lastMondayInMay,
                    EnglishName = "Memorial Day",
                    LocalName = "Memorial Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "JUNETEENTH-01",
                    Date = new DateTime(year, 6, 19),
                    EnglishName = "Juneteenth",
                    LocalName = "Juneteenth",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 7, 4),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = firstMondayInSeptember,
                    EnglishName = "Labour Day",
                    LocalName = "Labor Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "COMMONWEALTHCULTURALDAY-01",
                    Date = secondMondayInOctober,
                    EnglishName = "Commonwealth Cultural Day",
                    LocalName = "Commonwealth Cultural Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CITIZENSHIPDAY-01",
                    Date = new DateTime(year, 11, 4),
                    EnglishName = "Citizenship Day",
                    LocalName = "Citizenship Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "VETERANSDAY-01",
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Veterans Day",
                    LocalName = "Veterans Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "THANKSGIVING-01",
                    Date = fourthThursdayInNovember,
                    EnglishName = "Thanksgiving",
                    LocalName = "Thanksgiving",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://www.nmid.uscourts.gov/holiday-schedule",
                "https://en.wikipedia.org/wiki/2025_in_the_Northern_Mariana_Islands",
            ];
        }
    }
}
