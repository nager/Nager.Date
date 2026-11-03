using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Gibraltar HolidayProvider
    /// </summary>
    internal sealed class GibraltarHolidayProvider : AbstractHolidayProvider,
        IObservedRuleSetHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Gibraltar HolidayProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public GibraltarHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.GI)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var christmasDayObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var boxingDayObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(2),
                Monday = date => date.AddDays(1), // Christmas Day observed on Monday
            };

            var lastMondayInAugust = DateHelper.FindLastDay(year, Month.August, DayOfWeek.Monday);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "WORKERSMEMORIALDAY-01",
                    Date = new DateTime(year, 4, 28),
                    EnglishName = "Workers' Memorial Day",
                    LocalName = "Workers' Memorial Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "MAYDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "May Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "SUMMERBANKHOLIDAY-01",
                    Date = lastMondayInAugust,
                    EnglishName = "Late Summer Bank Holiday",
                    LocalName = "Late Summer Bank Holiday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "GIBRALTARNATIONALDAY-01",
                    Date = new DateTime(year, 9, 10),
                    EnglishName = "Gibraltar National Day",
                    LocalName = "Gibraltar National Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = christmasDayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "BOXINGDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = boxingDayObservedRuleSet
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this.GetWinterBankHoliday(year),
                this.GetSpringBankHoliday(year),
                this.GetSovereignsBirthday(year)
            };

            holidaySpecifications.AddIfNotNull(this.GetVEDay75thAnniversary(year));
            holidaySpecifications.AddIfNotNull(this.GetPlatinumJubilee(year));
            holidaySpecifications.AddIfNotNull(this.GetKingsCoronationBankHoliday(year));

            return holidaySpecifications;
        }

        private HolidaySpecification GetWinterBankHoliday(int year)
        {
            // until 2020: Commonwealth Day, second Monday in March
            if (year <= 2020)
            {
                return new HolidaySpecification
                {
                    Id = "COMMONWEALTHDAY-01",
                    Date = DateHelper.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second),
                    EnglishName = "Commonwealth Day",
                    LocalName = "Commonwealth Day",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            // 2021: Commonwealth Day, third Monday in February
            if (year == 2021)
            {
                return new HolidaySpecification
                {
                    Id = "COMMONWEALTHDAY-01",
                    Date = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third),
                    EnglishName = "Commonwealth Day",
                    LocalName = "Commonwealth Day",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            // 2024: Winter Midterm Bank Holiday, exception (second Monday in February)
            if (year == 2024)
            {
                return new HolidaySpecification
                {
                    Id = "WINTERMIDTERMBANKHOLIDAY-01",
                    Date = new DateTime(2024, 2, 12),
                    EnglishName = "Winter Midterm Bank Holiday",
                    LocalName = "Winter Midterm Bank Holiday",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            // from 2022: Winter Midterm Bank Holiday, third Monday in February
            return new HolidaySpecification
            {
                Id = "WINTERMIDTERMBANKHOLIDAY-01",
                Date = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third),
                EnglishName = "Winter Midterm Bank Holiday",
                LocalName = "Winter Midterm Bank Holiday",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification GetSpringBankHoliday(int year)
        {
            // 2022: moved to Thursday 2nd June for the Platinum Jubilee
            if (year == 2022)
            {
                return new HolidaySpecification
                {
                    Id = "SPRINGBANKHOLIDAY-01",
                    Date = new DateTime(2022, 6, 2),
                    EnglishName = "Spring Bank Holiday",
                    LocalName = "Spring Bank Holiday",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            // default: last Monday in May
            return new HolidaySpecification
            {
                Id = "SPRINGBANKHOLIDAY-01",
                Date = DateHelper.FindLastDay(year, Month.May, DayOfWeek.Monday),
                EnglishName = "Spring Bank Holiday",
                LocalName = "Spring Bank Holiday",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification GetSovereignsBirthday(int year)
        {
            // from 2023: King's Birthday, third Monday in June
            if (year >= 2023)
            {
                return new HolidaySpecification
                {
                    Id = "MONARCHBIRTHDAY-01",
                    Date = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Third),
                    EnglishName = "King's Birthday",
                    LocalName = "King's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            // 2021 - 2022: Queen's Birthday, second Monday in June
            if (year >= 2021)
            {
                return new HolidaySpecification
                {
                    Id = "MONARCHBIRTHDAY-01",
                    Date = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second),
                    EnglishName = "Queen's Birthday",
                    LocalName = "Queen's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            // until 2020: Queen's Birthday, third Monday in June
            return new HolidaySpecification
            {
                Id = "MONARCHBIRTHDAY-01",
                Date = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Third),
                EnglishName = "Queen's Birthday",
                LocalName = "Queen's Birthday",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? GetVEDay75thAnniversary(int year)
        {
            // 2020: 75th anniversary of VE Day (one-off holiday)
            if (year != 2020)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "VEDAY-01",
                Date = new DateTime(2020, 5, 8),
                EnglishName = "75th anniversary of VE Day",
                LocalName = "75th anniversary of VE Day",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? GetPlatinumJubilee(int year)
        {
            // 2022: Platinum Jubilee (one-off holiday)
            if (year != 2022)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "PLATINUMJUBILEE-01",
                Date = new DateTime(2022, 6, 3),
                EnglishName = "Platinum Jubilee",
                LocalName = "Platinum Jubilee",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? GetKingsCoronationBankHoliday(int year)
        {
            // 2023: Special King's Coronation Bank Holiday (one-off holiday)
            if (year != 2023)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "CORONATIONBANKHOLIDAY-01",
                Date = new DateTime(2023, 5, 8),
                EnglishName = "Special King's Coronation Bank Holiday",
                LocalName = "Special King's Coronation Bank Holiday",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Gibraltar",
                "https://www.gibraltar.gov.gi/press-releases/bank-holidays-2026-11299",
                "https://www.gibraltar.gov.gi/press-releases/bank-and-public-holidays-2025-10243",
                "https://www.gibraltar.gov.gi/press-releases/bank-and-public-holidays-2024-9356",
                "https://www.gibraltar.gov.gi/press-releases/bank-and-public-holidays-2023-8362",
                "https://www.gibraltar.gov.gi/press-releases/bank-and-public-holidays-2022-7603",
                "https://www.gibraltar.gov.gi/press-releases/bank-and-public-holidays-2021-6658",
                "https://www.gibraltar.gov.gi/press-releases/bank-and-public-holidays-2020-5363",
            ];
        }
    }
}
