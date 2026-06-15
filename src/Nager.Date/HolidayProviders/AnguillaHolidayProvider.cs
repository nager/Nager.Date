using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Anguilla HolidayProvider
    /// </summary>
    internal sealed class AnguillaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Anguilla HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AnguillaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.AI)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var sovereigntyDayDate = DateHelper.FindDay(year, Month.June, DayOfWeek.Saturday, Occurrence.Second).AddDays(2);
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var augustThursdayDate = firstMondayInAugust.AddDays(3);
            var constitutionDayDate = firstMondayInAugust.AddDays(4);

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
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "ANGUILLADAY-01",
                    Date = new DateTime(year, 5, 30),
                    EnglishName = "Anguilla Day",
                    LocalName = "Anguilla Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "SOVEREIGNTYDAY-01",
                    Date = sovereigntyDayDate,
                    EnglishName = "Sovereignty Day",
                    LocalName = "Sovereignty Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "AUGUSTMONDAY-01",
                    Date = firstMondayInAugust,
                    EnglishName = "August Monday",
                    LocalName = "August Monday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "AUGUSTTHURSDAY-01",
                    Date = augustThursdayDate,
                    EnglishName = "August Thursday",
                    LocalName = "August Thursday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = constitutionDayDate,
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NATIONALHEROESDAY-01",
                    Date = new DateTime(year, 12, 19),
                    EnglishName = "National Heroes' Day",
                    LocalName = "National Heroes' Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet
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
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.WhitMonday("Whit Monday", year),
            };

            holidaySpecifications.AddIfNotNull(this.JamesRonaldWebsterDay(year, weekendObservedRuleSet));

            return holidaySpecifications;
        }

        private HolidaySpecification? JamesRonaldWebsterDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            if (year >= 2010)
            {
                return new HolidaySpecification
                {
                    Id = "JAMESRONALDWEBSTERDAY-01",
                    Date = new DateTime(year, 3, 2),
                    EnglishName = "James Ronald Webster Day",
                    LocalName = "James Ronald Webster Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Anguilla",
            ];
        }
    }
}
