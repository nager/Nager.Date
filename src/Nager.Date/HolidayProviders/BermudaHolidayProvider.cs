using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bermuda HolidayProvider
    /// </summary>
    internal sealed class BermudaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Bermuda HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BermudaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.BM)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var fourthFridayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Friday, Occurrence.Fourth);
            var thirdMondayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Third);
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var firstMondayInSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.First);

            var emancipationDayDate = firstMondayInAugust.AddDays(-4);
            var maryPrinceDayDate = firstMondayInAugust.AddDays(-3);

            var weekendObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
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
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "BERMUDADAY-01",
                    Date = fourthFridayInMay,
                    EnglishName = "Bermuda Day",
                    LocalName = "Bermuda Day",
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
                    Id = "NATIONALHEROESDAY-01",
                    Date = thirdMondayInJune,
                    EnglishName = "National Heroes Day",
                    LocalName = "National Heroes Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "EMANCIPATIONDAY-01",
                    Date = emancipationDayDate,
                    EnglishName = "Emancipation Day",
                    LocalName = "Emancipation Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MARYPRINCEDAY-01",
                    Date = maryPrinceDayDate,
                    EnglishName = "Mary Prince Day",
                    LocalName = "Mary Prince Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "REMEMBRANCEDAY-01",
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Remembrance Day",
                    LocalName = "Remembrance Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bermuda",
            ];
        }
    }
}
