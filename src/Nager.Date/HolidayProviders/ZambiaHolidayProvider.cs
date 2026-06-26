using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Zambia HolidayProvider
    /// </summary>
    internal sealed class ZambiaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Zambia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ZambiaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.ZM)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var fisrstMondayInJuly = DateHelper.FindDay(year, Month.July, DayOfWeek.Monday, Occurrence.First);
            var tuesdayAfterFirstMondayInJuly = fisrstMondayInJuly.AddDays(1);
            var fisrstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);

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
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "International Women's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "YOUTHDAY-01",
                    Date = new DateTime(year, 3, 12),
                    EnglishName = "Youth Day",
                    LocalName = "Youth Day",
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
                    Id = "AFRICADAY-01",
                    Date = new DateTime(year, 5, 25),
                    EnglishName = "African Freedom Day",
                    LocalName = "Africa Freedom Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "HEROESDAY-01",
                    Date = fisrstMondayInJuly,
                    EnglishName = "Heroes' Day",
                    LocalName = "Heroes' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "UNITYDAY-01",
                    Date = tuesdayAfterFirstMondayInJuly,
                    EnglishName = "Unity Day",
                    LocalName = "Unity Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "FARMERSDAY-01",
                    Date = fisrstMondayInAugust,
                    EnglishName = "Farmers' Day",
                    LocalName = "Farmers' Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAYOFPRAYER-01",
                    Date = new DateTime(year, 10, 18),
                    EnglishName = "National Day of Prayer",
                    LocalName = "National Day of Prayer",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 10, 24),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
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
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterSaturday("Easter Saturday", year),
                this._catholicProvider.EasterSunday("Easter Sunday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
            };

            holidaySpecifications.AddIfNotNull(this.KennethKaundasBirthday(year, weekendObservedRuleSet));

            return holidaySpecifications;
        }

        private HolidaySpecification? KennethKaundasBirthday(
            int year,
            ObservedRuleSet weekendObservedRuleSet)
        {
            if (year >= 2021)
            {
                return new HolidaySpecification
                {
                    Id = "KENNETHKAUNDASBIRTHDAY-01",
                    Date = new DateTime(year, 4, 28),
                    EnglishName = "Kenneth Kaunda's Birthday",
                    LocalName = "Kenneth Kaunda's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Zambia"
            ];
        }
    }
}
