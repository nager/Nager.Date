using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Cayman Islands HolidayProvider
    /// </summary>
    internal sealed class CaymanIslandsHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Cayman Islands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CaymanIslandsHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.KY)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var sundayObservedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1),
            };

            var weekendObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var weekendObservedRuleSet2 = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(2),
                Monday = date => date.AddDays(1),
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
                    ObservedRuleSet = sundayObservedRuleSet,
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
                    ObservedRuleSet = weekendObservedRuleSet2,
                },
                new HolidaySpecification
                {
                    Id = "ASHWEDNESDAY-01",
                    Date = easterSunday.AddDays(-46),
                    EnglishName = "Ash Wednesday",
                    LocalName = "Ash Wednesday",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
            };

            holidaySpecifications.AddIfNotNull(this.NationalHeroesDay(year));
            holidaySpecifications.AddIfNotNull(this.EmancipationDay(year));
            holidaySpecifications.AddIfNotNull(this.DiscoveryDay(year));
            holidaySpecifications.AddIfNotNull(this.ConstitutionDay(year));
            holidaySpecifications.AddIfNotNull(this.RemembranceDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification NationalHeroesDay(int year)
        {
            var fourthMondayInJanuary = DateHelper.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Fourth);

            return new HolidaySpecification
            {
                Id = "NATIONALHEROESDAY-01",
                Date = fourthMondayInJanuary,
                EnglishName = "National Heroes Day",
                LocalName = "National Heroes Day",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification EmancipationDay(int year)
        {
            var id = "EMANCIPATIONDAY-01";
            var englishName = "Emancipation Day";
            var localName = "Emancipation Day";

            if (year >= 2024)
            {
                var firstMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);

                return new HolidaySpecification
                {
                    Id = id,
                    Date = firstMondayInMay,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                };
            }
            else
            {
                var thirdMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.Third);

                return new HolidaySpecification
                {
                    Id = id,
                    Date = thirdMondayInMay,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                };
            }
        }

        private HolidaySpecification DiscoveryDay(int year)
        {
            var id = "DISCOVERYDAY-01";
            var englishName = "Discovery Day";
            var localName = "Discovery Day";

            if (year >= 2024)
            {
                var thirdMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.Third);

                return new HolidaySpecification
                {
                    Id = id,
                    Date = thirdMondayInMay,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                };
            }
            else
            {
                var firstMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);

                return new HolidaySpecification
                {
                    Id = id,
                    Date = firstMondayInMay,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                };
            }
        }

        private HolidaySpecification ConstitutionDay(int year)
        {
            var firstMondayInJuly = DateHelper.FindDay(year, Month.July, DayOfWeek.Monday, Occurrence.First);

            return new HolidaySpecification
            {
                Id = "CONSTITUTIONDAY-01",
                Date = firstMondayInJuly,
                EnglishName = "Constitution Day",
                LocalName = "Constitution Day",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification RemembranceDay(int year)
        {
            var secondMondayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Monday, Occurrence.Second);

            return new HolidaySpecification
            {
                Id = "REMEMBRANCEDAY-01",
                Date = secondMondayInNovember,
                EnglishName = "Remembrance Day",
                LocalName = "Remembrance Day",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Cayman_Islands",
            ];
        }
    }
}
