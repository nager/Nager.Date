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

            var weekendObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var weekendObservedRuleSet2 = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
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
            holidaySpecifications.AddIfNotNull(this.MonarchBirthday(year));
            holidaySpecifications.AddIfNotNull(this.CoronationDay(year));
            holidaySpecifications.AddIfNotNull(this.PlatinumJubilee(year));
            holidaySpecifications.AddIfNotNull(this.GeneralElectionDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? GeneralElectionDay(int year)
        {
            //General elections are a public holiday, the date is set by the government for each election
            DateTime? date = year switch
            {
                2021 => new DateTime(2021, 4, 14),
                2025 => new DateTime(2025, 4, 30),
                _ => null
            };

            if (date is null)
            {
                return null;
            }

            var name = year == 2025 ? "General Election and Referendum Day" : "General Election Day";

            return new HolidaySpecification
            {
                Id = "GENERALELECTIONDAY-01",
                Date = date.Value,
                EnglishName = name,
                LocalName = name,
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? PlatinumJubilee(int year)
        {
            //One-off public holiday for the Platinum Jubilee of Her Majesty Queen Elizabeth II
            if (year != 2022)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "PLATINUMJUBILEE-01",
                Date = new DateTime(2022, 6, 3),
                EnglishName = "Queen's Platinum Jubilee",
                LocalName = "Queen's Platinum Jubilee",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? CoronationDay(int year)
        {
            //One-off public holiday for the Coronation of His Majesty King Charles III,
            //gazetted as Public Holidays (No.2) Order, 2022
            if (year != 2023)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "CORONATIONDAY-01",
                Date = new DateTime(2023, 5, 8),
                EnglishName = "Coronation of King Charles III",
                LocalName = "Coronation of King Charles III",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? MonarchBirthday(int year)
        {
            //Public Holidays Act, the Monday following the official birthday of the Sovereign in the United Kingdom.
            //The official birthday is celebrated with the Birthday Parade (Trooping the Colour) in London.
            //Its date does not follow a fixed rule: it is always a Saturday in June, usually the second,
            //sometimes the first or third. It is set by the Royal Household together with the Household Division
            //and the government, preceded by two reviews on the two Saturdays before (Major General's Review,
            //Colonel's Review) and scheduled to avoid clashes with other major state, church or sporting events.
            //Because the date can't be calculated, the observed Monday in the Cayman Islands is fixed per year.
            //Example 2026: Trooping the Colour on Saturday, 13 June -> public holiday on Monday, 15 June.

            DateTime? date = year switch
            {
                2021 => new DateTime(2021, 6, 14),
                2022 => new DateTime(2022, 6, 6),
                2023 => new DateTime(2023, 6, 19),
                2024 => new DateTime(2024, 6, 17),
                2025 => new DateTime(2025, 6, 23),
                2026 => new DateTime(2026, 6, 15),
                _ => null
            };

            if (date is null)
            {
                return null;
            }

            var name = year >= 2023 ? "King's Birthday" : "Queen's Birthday";

            return new HolidaySpecification
            {
                Id = "MONARCHBIRTHDAY-01",
                Date = date.Value,
                EnglishName = name,
                LocalName = name,
                HolidayTypes = HolidayTypes.Public,
            };
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

        private HolidaySpecification? EmancipationDay(int year)
        {
            //Introduced in 2024, first Monday in May
            if (year < 2024)
            {
                return null;
            }

            var firstMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);

            return new HolidaySpecification
            {
                Id = "EMANCIPATIONDAY-01",
                Date = firstMondayInMay,
                EnglishName = "Emancipation Day",
                LocalName = "Emancipation Day",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification DiscoveryDay(int year)
        {
            var thirdMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.Third);

            return new HolidaySpecification
            {
                Id = "DISCOVERYDAY-01",
                Date = thirdMondayInMay,
                EnglishName = "Discovery Day",
                LocalName = "Discovery Day",
                HolidayTypes = HolidayTypes.Public,
            };
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
            var secondSundayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Sunday, Occurrence.Second);

            return new HolidaySpecification
            {
                Id = "REMEMBRANCEDAY-01",
                Date = secondSundayInNovember.AddDays(1),
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
                "https://gov.ky/public-holidays", //2026
                "https://web.archive.org/web/20251207164825/https://gov.ky/public-holidays", //2025
                "https://caymannewsservice.com/2023/12/officials-release-dates-for-2024-public-holidays/", //2024
                "https://www.caymaniantimes.ky/news/for-immediate-release-2024-public-holidays-named", //2024
                "https://archive.ph/2025.07.09-033515/https://www.gov.ky/news/press-release-details/public-holidays-2022#selection-2099.0-2171.43", //2022
                "https://archive.ph/2025.07.09-033240/https://www.gov.ky/news/press-release-details/public-holidays-for-2021#selection-2085.0-2159.44", //2021
            ];
        }
    }
}
