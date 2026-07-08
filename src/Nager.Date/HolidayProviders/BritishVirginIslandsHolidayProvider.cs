using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// British Virgin Islands HolidayProvider
    /// </summary>
    internal sealed class BritishVirginIslandsHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// British Virgin Islands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BritishVirginIslandsHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.VG)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var sovereigntyDayDate = DateHelper.FindDay(year, Month.June, DayOfWeek.Friday, Occurrence.Second);
            var thirdMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Third);

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
                    Id = "LAVITYSTOUTTSBIRTHDAY-01",
                    Date = new DateTime(year, 3, 7),
                    EnglishName = "Lavity Stoutt's Birthday",
                    LocalName = "Lavity Stoutt's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "SOVEREIGNSBIRTHDAY-01",
                    Date = sovereigntyDayDate,
                    EnglishName = "Sovereign's Birthday",
                    LocalName = "Sovereign's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "VIRGINISLANDSDAY-01",
                    Date = new DateTime(year, 7, 1),
                    EnglishName = "Virgin Islands Day",
                    LocalName = "Virgin Islands Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "HEROESANDFOREPARENTSDAY-01",
                    Date = thirdMondayInOctober,
                    EnglishName = "Heroes and Foreparents Day",
                    LocalName = "Heroes and Foreparents Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.WhitMonday("Whit Monday", year),
            };

            holidaySpecifications.AddRangeIfNotNull(this.EmancipationDays(year));
            holidaySpecifications.AddIfNotNull(this.The1949GreatMarchAndRestorationDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? The1949GreatMarchAndRestorationDay(int year)
        {
            if (year >= 2021)
            {
                var fourthMondayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Monday, Occurrence.Fourth);

                return new HolidaySpecification
                {
                    Id = "1949GREATMARCHANDRESTORATIONDAY-01",
                    Date = fourthMondayInNovember,
                    EnglishName = "The 1949 Great March and Restoration Day",
                    LocalName = "The 1949 Great March and Restoration Day",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        private HolidaySpecification[] EmancipationDays(
            int year)
        {
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var id = "EMANCIPATION";

            if (year >= 2020)
            {
                return
                [
                    new HolidaySpecification
                    {
                        Id = $"{id}-01",
                        Date = firstMondayInAugust,
                        EnglishName = "Emancipation Monday",
                        LocalName = "Emancipation Monday",
                        HolidayTypes = HolidayTypes.Public,
                    },
                    new HolidaySpecification
                    {
                        Id = $"{id}-02",
                        Date = firstMondayInAugust.AddDays(1),
                        EnglishName = "Emancipation Tuesday",
                        LocalName = "Emancipation Tuesday",
                        HolidayTypes = HolidayTypes.Public,
                    },
                    new HolidaySpecification
                    {
                        Id = $"{id}-03",
                        Date = firstMondayInAugust.AddDays(2),
                        EnglishName = "Emancipation Wednesday",
                        LocalName = "Emancipation Wednesday",
                        HolidayTypes = HolidayTypes.Public,
                    },
                ];
            }

            return
            [
                new HolidaySpecification
                {
                    Id = $"{id}-01",
                    Date = firstMondayInAugust,
                    EnglishName = "Festival Monday",
                    LocalName = "Festival Monday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = $"{id}-02",
                    Date = firstMondayInAugust.AddDays(1),
                    EnglishName = "Festival Tuesday",
                    LocalName = "Festival Tuesday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = $"{id}-03",
                    Date = firstMondayInAugust.AddDays(2),
                    EnglishName = "Festival Wednesday",
                    LocalName = "Festival Wednesday",
                    HolidayTypes = HolidayTypes.Public,
                },
            ];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_British_Virgin_Islands",
            ];
        }
    }
}
