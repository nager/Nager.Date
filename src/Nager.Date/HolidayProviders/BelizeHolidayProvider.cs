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
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var chapter289observedRuleSet1 = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1),
            };

            var chapter289observedRuleSet2 = new ObservedRuleSet
            {
                Friday = date => date.AddDays(3),
                Sunday = date => date.AddDays(1),
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(-2),
                Thursday = date => date.AddDays(-3),
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
                    ObservedRuleSet = chapter289observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "NATIONALHEROESDAY-01",
                    Date = new DateTime(year, 3, 9),
                    EnglishName = "National Heroes and Benefactors Day",
                    LocalName = "National Heroes and Benefactors Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = chapter289observedRuleSet2
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = chapter289observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "SAINTGEORGESCAYEDAY-01",
                    Date = new DateTime(year, 9, 10),
                    EnglishName = "Saint George's Caye Day",
                    LocalName = "Saint George's Caye Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = chapter289observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 9, 21),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = chapter289observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "GARIFUNASETTLEMENTDAY-01",
                    Date = new DateTime(year, 11, 19),
                    EnglishName = "Garifuna Settlement Day",
                    LocalName = "Garifuna Settlement Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = chapter289observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = chapter289observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "BOXINGDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = chapter289observedRuleSet1
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterSaturday("Holy Saturday", year),
                this._catholicProvider.EasterSunday("Easter Sunday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            holidaySpecifications.AddIfNotNull(this.PanAmericaDay(year, chapter289observedRuleSet2));
            holidaySpecifications.AddIfNotNull(this.GeorgePriceDay(year, chapter289observedRuleSet1));
            holidaySpecifications.AddIfNotNull(this.EmancipationDay(year, chapter289observedRuleSet1));
            holidaySpecifications.AddIfNotNull(this.CommonwealthDay(year, chapter289observedRuleSet2));

            return holidaySpecifications;
        }

        private HolidaySpecification? PanAmericaDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            var id = "DAYOFTHEAMERICAS-01";

            if (year > 2021)
            {
                return new HolidaySpecification
                {
                    Id = id,
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Pan America Day",
                    LocalName = "Pan America Day",
                    HolidayTypes = HolidayTypes.Optional,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return new HolidaySpecification
            {
                Id = id,
                Date = new DateTime(year, 10, 12),
                EnglishName = "Columbus Day",
                LocalName = "Columbus Day",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Belize",
                "https://www.pressoffice.gov.bz/wp-content/uploads/2019/12/Jan-11-Government-of-Belize-Establishes-New-Public-and-Bank-Holidays.pdf",
                "https://www.pressoffice.gov.bz/wp-content/uploads/2024/10/Oct-21-PR163-24-Public-and-Bank-Holidays-2025.pdf"
            ];
        }
    }
}
