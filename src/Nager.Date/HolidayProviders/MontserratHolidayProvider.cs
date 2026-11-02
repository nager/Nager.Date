using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Montserrat HolidayProvider
    /// </summary>
    internal sealed class MontserratHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Montserrat HolidayProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public MontserratHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.MS)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);

            // Public Holidays Act (Cap. 6.09), Schedule:
            // If a public holiday falls on a Saturday or Sunday, the succeeding Monday is a public holiday.
            var weekendObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            // Two consecutive public holidays (Christmas Day / Boxing Day, Festival Day / New Year's Day)
            // If the first falls on a Saturday and the second on the Sunday, Monday and Tuesday are public holidays.
            // If one falls on a Sunday and the other on the Monday, the Tuesday is a public holiday.
            var consecutiveHolidaysObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(2),
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
                    ObservedRuleSet = consecutiveHolidaysObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "SAINTPATRICKSDAY-01",
                    Date = new DateTime(year, 3, 17),
                    EnglishName = "Saint Patrick's Day",
                    LocalName = "Saint Patrick's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = firstMondayInMay,
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "EMANCIPATIONDAY-01",
                    Date = firstMondayInAugust,
                    EnglishName = "Emancipation Day",
                    LocalName = "Emancipation Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = consecutiveHolidaysObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "BOXINGDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "St. Stephen's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = consecutiveHolidaysObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "FESTIVALDAY-01",
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "Festival Day",
                    LocalName = "Festival Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = consecutiveHolidaysObservedRuleSet,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.WhitMonday("Whit Monday", year)
            };

            holidaySpecifications.AddIfNotNull(this.SovereignsBirthday(year));
            holidaySpecifications.AddIfNotNull(this.DayOfPrayerAndThanksgiving(year));

            return holidaySpecifications;
        }

        private HolidaySpecification SovereignsBirthday(int year)
        {
            var name = year >= 2023 ? "King's Birthday" : "Queen's Birthday";

            // The date is appointed every year by proclamation of the Governor (Public Holidays Act, section 4)
            // S.R.O. 22 of 2026 appointed Saturday 13 June 2026 (second Saturday in June)
            var secondSaturdayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Saturday, Occurrence.Second);
            var whitMonday = this._catholicProvider.EasterSunday(year).AddDays(50);

            var observedRuleSet = new ObservedRuleSet
            {
                // If the succeeding Monday is already a public holiday (Whit Monday), the Tuesday is a public holiday
                Saturday = date => date.AddDays(2) == whitMonday ? date.AddDays(3) : date.AddDays(2),
            };

            return new HolidaySpecification
            {
                Id = "QUEENSBIRTHDAY-01",
                Date = secondSaturdayInJune,
                EnglishName = name,
                LocalName = name,
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet,
            };
        }

        private HolidaySpecification? DayOfPrayerAndThanksgiving(int year)
        {
            if (year < 2024)
            {
                return null;
            }

            var secondWednesdayInJuly = DateHelper.FindDay(year, Month.July, DayOfWeek.Wednesday, Occurrence.Second);

            return new HolidaySpecification
            {
                Id = "DAYOFPRAYERANDTHANKSGIVING-01",
                Date = secondWednesdayInJuly,
                EnglishName = "Day of Prayer and Thanksgiving",
                LocalName = "Day of Prayer and Thanksgiving",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Montserrat",
                "https://www.gov.ms/wp-content/uploads/2026/02/6.09-Public-Holidays-Act.pdf",
                "https://www.gov.ms/wp-content/uploads/2026/06/SRO-No.-22-of-2026-Proclamation-Appointing-Saturday-13-June-2026-a-Public-Holiday.pdf",
                "https://www.gov.ms/wp-content/uploads/2025/01/2025-Public-Holidays-on-Montserrat.pdf",
                "https://www.gov.ms/wp-content/uploads/2023/12/Public-Holidays-Montserrat-2024.docx.pdf",
            ];
        }
    }
}
