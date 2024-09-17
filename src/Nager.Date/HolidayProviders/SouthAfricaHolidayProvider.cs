using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// South Africa HolidayProvider
    /// </summary>
    internal sealed class SouthAfricaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// South Africa HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SouthAfricaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.ZA)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var observedRuleSet1 = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            var observedRuleSet2 = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(2)
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 21),
                    EnglishName = "Human Rights Day",
                    LocalName = "Human Rights Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(1),
                    EnglishName = "Family Day",
                    LocalName = "Family Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 27),
                    EnglishName = "Freedom Day",
                    LocalName = "Freedom Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Workers' Day",
                    LocalName = "Workers' Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 16),
                    EnglishName = "Youth Day",
                    LocalName = "Youth Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 9),
                    EnglishName = "National Women's Day",
                    LocalName = "National Women's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 24),
                    EnglishName = "Heritage Day",
                    LocalName = "Heritage Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 16),
                    EnglishName = "Day of Reconciliation",
                    LocalName = "Day of Reconciliation",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet2
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Day of Goodwill",
                    LocalName = "St. Stephen's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                this._catholicProvider.GoodFriday("Good Friday", year)
            };

            holidaySpecifications.AddIfNotNull(this.SpringboksVictory(year));
            holidaySpecifications.AddIfNotNull(this.ElectionDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? SpringboksVictory(int year)
        {
            if (year == 2023)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 15),
                    EnglishName = "Springboks Victory",
                    LocalName = "Springboks Victory",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? ElectionDay(int year)
        {
            if (year == 2024)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 29),
                    EnglishName = "Election Day",
                    LocalName = "Election Day",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_South_Africa"
            ];
        }
    }
}
