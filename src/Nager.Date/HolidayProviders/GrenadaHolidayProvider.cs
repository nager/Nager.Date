using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Grenada HolidayProvider
    /// </summary>
    internal sealed class GrenadaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Grenada HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GrenadaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.GD)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            // Bank Holidays Act (Chapter 25): When a bank holiday falls on a Sunday,
            // the Monday immediately following shall be observed.
            var observedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1),
            };

            // Christmas on Sunday -> Boxing Day stays on Monday, Christmas moves to Tuesday
            var christmasObservedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(2),
            };

            var secondMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.Second);

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
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 2, 7),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CARNIVALMONDAY-01",
                    Date = secondMondayInAugust,
                    EnglishName = "Carnival Monday",
                    LocalName = "Carnival Monday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CARNIVALTUESDAY-01",
                    Date = secondMondayInAugust.AddDays(1),
                    EnglishName = "Carnival Tuesday",
                    LocalName = "Carnival Tuesday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "THANKSGIVINGDAY-01",
                    Date = new DateTime(year, 10, 25),
                    EnglishName = "Thanksgiving Day",
                    LocalName = "Thanksgiving Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = christmasObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "BOXINGDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.WhitMonday("Whit Monday", year),
                this._catholicProvider.CorpusChristi("Corpus Christi", year),
                this.GetEmancipationDay(year, observedRuleSet),
            };

            holidaySpecifications.AddIfNotNull(this.GetNationalHeroesDay(year, observedRuleSet));

            return holidaySpecifications;
        }

        private HolidaySpecification GetEmancipationDay(int year, ObservedRuleSet observedRuleSet)
        {
            // Up to 2023 observed on the first Monday in August,
            // since 2025 (official lists) fixed on 1 August
            if (year >= 2025)
            {
                return new HolidaySpecification
                {
                    Id = "EMANCIPATIONDAY-01",
                    Date = new DateTime(year, 8, 1),
                    EnglishName = "Emancipation Day",
                    LocalName = "Emancipation Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                };
            }

            return new HolidaySpecification
            {
                Id = "EMANCIPATIONDAY-01",
                Date = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First),
                EnglishName = "Emancipation Day",
                LocalName = "Emancipation Day",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? GetNationalHeroesDay(int year, ObservedRuleSet observedRuleSet)
        {
            // Not part of the official 2023 list, included since 2025 (official lists)
            if (year < 2025)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "NATIONALHEROESDAY-01",
                Date = new DateTime(year, 10, 19),
                EnglishName = "National Heroes' Day",
                LocalName = "National Heroes' Day",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Grenada",
                "https://www.gov.gd",
                "https://web.archive.org/web/20231209233625/https://www.gov.gd/pdf/Public%20Holidays%202023.pdf", //2023
                "https://www.gov.gd/documents/public-holidays-2026/viewdocument/2024", //2026
                "https://www.gov.gd/component/edocman/grenadas-public-holidays-2025/viewdocument/1386?p=1", //2025
                "https://nowgrenada.com/wp-content/uploads/2024/10/S.R.O.-29-of-2024-Bank-Holiday-Proclamation-2024.pdf",
                "https://nowgrenada.com/2025/06/legislation-to-make-1-august-a-holiday-down-for-approval-in-upcoming-lower-house-session/",
            ];
        }
    }
}
