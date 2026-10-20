using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Belize HolidayProvider
    /// </summary>
    internal sealed class BelizeHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Belize HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BelizeHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.BZ)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            // Holidays Act, Chapter 289 (Revised Edition 2011, in force since 2021):
            // Saturdays are never moved.

            // Only Sunday is moved to the following Monday
            var sundayOnlyRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1),
            };

            // Tuesday/Wednesday are moved to the preceding Monday, Sunday to the following Monday
            var precedingMondayRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(-2),
                Sunday = date => date.AddDays(1),
            };

            // Always observed on a Monday
            // (Friday rule not yet confirmed by official data, next occurrence: 9th March 2029)
            var alwaysMondayRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(-2),
                Thursday = date => date.AddDays(-3),
                Friday = date => date.AddDays(3),
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            // Holidays Act (Revised Edition 2000-2003, until 2020):
            // Saturday and Sunday are moved to the following Monday
            var weekendRuleSet = new ObservedRuleSet
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
                    ObservedRuleSet = sundayOnlyRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALHEROESDAY-01",
                    Date = new DateTime(year, 3, 9),
                    EnglishName = "National Heroes and Benefactors Day",
                    LocalName = "National Heroes and Benefactors Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = alwaysMondayRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = precedingMondayRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "SAINTGEORGESCAYEDAY-01",
                    Date = new DateTime(year, 9, 10),
                    EnglishName = "Saint George's Caye Day",
                    LocalName = "Saint George's Caye Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayOnlyRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 9, 21),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayOnlyRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "GARIFUNASETTLEMENTDAY-01",
                    Date = new DateTime(year, 11, 19),
                    EnglishName = "Garifuna Settlement Day",
                    LocalName = "Garifuna Settlement Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayOnlyRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterSaturday("Holy Saturday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            holidaySpecifications.AddIfNotNull(this.BoxingDay(year, sundayOnlyRuleSet, weekendRuleSet));
            holidaySpecifications.AddIfNotNull(this.PanAmericanDay(year, weekendRuleSet));
            holidaySpecifications.AddIfNotNull(this.IndigenousPeoplesResistanceDay(year, alwaysMondayRuleSet));
            holidaySpecifications.AddIfNotNull(this.GeorgePriceDay(year, sundayOnlyRuleSet));
            holidaySpecifications.AddIfNotNull(this.EmancipationDay(year, precedingMondayRuleSet));
            holidaySpecifications.AddIfNotNull(this.CommonwealthDay(year, weekendRuleSet));

            return holidaySpecifications;
        }

        private HolidaySpecification BoxingDay(
            int year,
            ObservedRuleSet observedRuleSet,
            ObservedRuleSet legacyObservedRuleSet)
        {
            // Holidays Act, Revised Edition 2000-2003 (until 2020):
            // Saturday and Sunday moved to the following Monday
            // e.g. Saturday 26th December 2020 -> Monday 28th December 2020
            //
            // Holidays Act, Revised Edition 2011 (since 2021):
            // only Sunday moved to the following Monday
            // e.g. Saturday 26th December 2026 remains a Saturday
            var ruleSet = year < 2021
                ? legacyObservedRuleSet
                : observedRuleSet;

            return new HolidaySpecification
            {
                Id = "BOXINGDAY-01",
                Date = new DateTime(year, 12, 26),
                EnglishName = "Boxing Day",
                LocalName = "Boxing Day",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = ruleSet
            };
        }

        private HolidaySpecification? PanAmericanDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            // Replaced by Indigenous Peoples' Resistance Day,
            // not listed in the official 2021 public and bank holidays
            if (year <= 2020)
            {
                return new HolidaySpecification
                {
                    Id = "DAYOFTHEAMERICAS-01",
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Pan American Day",
                    LocalName = "Pan American Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification? IndigenousPeoplesResistanceDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            if (year >= 2022)
            {
                return new HolidaySpecification
                {
                    Id = "INDIGENOUSPEOPLESRESISTANCEDAY-01",
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Indigenous Peoples' Resistance Day",
                    LocalName = "Indigenous Peoples' Resistance Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification? CommonwealthDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            if (year < 2021)
            {
                return new HolidaySpecification
                {
                    Id = "COMMONWEALTHDAY-01",
                    Date = new DateTime(year, 5, 24),
                    EnglishName = "Commonwealth Day",
                    LocalName = "Commonwealth Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification? GeorgePriceDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            if (year >= 2021)
            {
                return new HolidaySpecification
                {
                    Id = "GEORGEPRICEDAY-01",
                    Date = new DateTime(year, 1, 15),
                    EnglishName = "George Price Day",
                    LocalName = "George Price Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification? EmancipationDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            if (year >= 2021)
            {
                return new HolidaySpecification
                {
                    Id = "EMANCIPATIONDAY-01",
                    Date = new DateTime(year, 8, 1),
                    EnglishName = "Emancipation Day",
                    LocalName = "Emancipation Day",
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
                "https://www.pressoffice.gov.bz/public-and-bank-holidays-2026/",
                "https://www.pressoffice.gov.bz/public-and-bank-holidays-2025/",
                "https://www.pressoffice.gov.bz/public-and-bank-holidays-2024/",
                "https://www.pressoffice.gov.bz/public-and-bank-holidays-2023/",
                "https://www.pressoffice.gov.bz/public-and-bank-holidays-2022-updated/",
                "https://www.pressoffice.gov.bz/public-and-bank-holidays-2021-3/",
                "https://en.wikipedia.org/wiki/Public_holidays_in_Belize",
                "https://www.pressoffice.gov.bz/wp-content/uploads/2019/12/Jan-11-Government-of-Belize-Establishes-New-Public-and-Bank-Holidays.pdf",
                "https://www.pressoffice.gov.bz/wp-content/uploads/2024/10/Oct-21-PR163-24-Public-and-Bank-Holidays-2025.pdf"
            ];
        }
    }
}
