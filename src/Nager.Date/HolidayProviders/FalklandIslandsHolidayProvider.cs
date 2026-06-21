using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Falkland Islands HolidayProvider
    /// </summary>
    internal sealed class FalklandIslandsHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Falkland Islands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public FalklandIslandsHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.FK)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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
                    Id = "LIBERATIONDAY-01",
                    Date = new DateTime(year, 6, 14),
                    EnglishName = "Liberation Day",
                    LocalName = "Liberation Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "KINGSBIRTHDAY-01",
                    Date = new DateTime(year, 11, 14),
                    EnglishName = "King's Birthday",
                    LocalName = "King's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "BATTLEDAY-01",
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Battle Day",
                    LocalName = "Battle Day",
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
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASHOLIDAY-01",
                    Date = new DateTime(year, 12, 27),
                    EnglishName = "Christmas Holiday",
                    LocalName = "Christmas Holiday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "GOVERNMENTHOLIDAY-01",
                    Date = new DateTime(year, 12, 30),
                    EnglishName = "Government Holiday",
                    LocalName = "Government Holiday",
                    HolidayTypes = HolidayTypes.Authorities,
                },
                new HolidaySpecification
                {
                    Id = "GOVERNMENTHOLIDAY-02",
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "Government Holiday",
                    LocalName = "Government Holiday",
                    HolidayTypes = HolidayTypes.Authorities,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
            };

            holidaySpecifications.AddIfNotNull(this.PeatCuttingDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? PeatCuttingDay(
            int year)
        {
            if (year >= 2002)
            {
                var firstMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.First);

                return new HolidaySpecification
                {
                    Id = "PEATCUTTINGDAY-01",
                    Date = firstMondayInOctober,
                    EnglishName = "Peat Cutting Day",
                    LocalName = "Peat Cutting Day",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Falkland_Islands",
            ];
        }
    }
}
