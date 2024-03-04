using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Isle of Man HolidayProvider
    /// </summary>
    internal class IsleOfManHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Isle of Man HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IsleOfManHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.IM;

            var observedRuleSet1 = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var observedRuleSet2 = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(2),
            };

            var lastMondayInAugust = DateSystem.FindLastDay(year, Month.August, DayOfWeek.Monday);
            //var tynwaldDay = new DateTime(year, 7, 5).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            //var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            //var stStephensDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            //var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));

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
                    Date = new DateTime(year, 7, 5),
                    EnglishName = "Tynwald Day",
                    LocalName = "Tynwald Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = lastMondayInAugust,
                    EnglishName = "Late Summer Bank Holiday",
                    LocalName = "Late Summer Bank Holiday",
                    HolidayTypes = HolidayTypes.Public
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
                    EnglishName = "Boxing Day",
                    LocalName = "St. Stephen's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet2
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            holidaySpecifications.AddIfNotNull(this.EarlyMayBankHoliday(year));
            holidaySpecifications.AddIfNotNull(this.SpringBankHoliday(year));
            holidaySpecifications.AddIfNotNull(this.QueensPlatinumJubilee(year));
            holidaySpecifications.AddIfNotNull(this.QueensStateFuneral(year));
            holidaySpecifications.AddIfNotNull(this.CoronationBankHoliday(year));
            holidaySpecifications.AddIfNotNull(this.SeniorRaceDay(year));

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

//            //var items = new List<Holiday>();
            //items.Add(new Holiday(newYearDay, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(tynwaldDay, "Tynwald Day", "Tynwald Day", countryCode));
            //items.Add(new Holiday(lastMondayInAugust, "Late Summer Bank Holiday", "Late Summer Bank Holiday", countryCode));
            //items.Add(new Holiday(christmasDay, "Christmas Day", "Christmas Day", countryCode));
            //items.Add(new Holiday(stStephensDay, "Boxing Day", "St. Stephen's Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            //items.AddIfNotNull(this.EarlyMayBankHoliday(year, countryCode));
            //items.AddIfNotNull(this.SpringBankHoliday(year, countryCode));
            //items.AddIfNotNull(this.QueensPlatinumJubilee(year, countryCode));
            //items.AddIfNotNull(this.QueensStateFuneral(year, countryCode));
            //items.AddIfNotNull(this.CoronationBankHoliday(year, countryCode));
            //items.AddIfNotNull(this.SeniorRaceDay(year, countryCode));
            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification SeniorRaceDay(int year)
        {
            var holidayName = "Senior Race Day";

            if (year == 2020)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 28),
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public
                };

                //var replacementTTDay = new DateTime(year, 8, 28);
                //return new Holiday(replacementTTDay, holidayName, holidayName, countryCode, 1978);
            }

            //The friday after the first saturday of June
            var ttRaceDay = DateSystem.FindDay(DateSystem.FindDay(year, Month.June, DayOfWeek.Saturday, Occurrence.First), DayOfWeek.Friday);
            return new HolidaySpecification
            {
                Date = ttRaceDay,
                EnglishName = holidayName,
                LocalName = holidayName,
                HolidayTypes = HolidayTypes.Public
            };
            //return new Holiday(ttRaceDay, holidayName, holidayName, countryCode, 1978);
        }

        private HolidaySpecification EarlyMayBankHoliday(int year)
        {
            var holidayName = "Early May Bank Holiday";

            if (year == 2020)
            {
                //https://www.gov.uk/government/news/extra-bank-holiday-to-mark-the-queens-platinum-jubilee-in-2022
                var secondFridayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Friday, Occurrence.Second);
                return new HolidaySpecification
                {
                    Date = secondFridayInMay,
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public
                };
                //return new Holiday(secondFridayInMay, holidayName, holidayName, countryCode, 1978);
            }

            var firstMondayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            return new HolidaySpecification
            {
                Date = firstMondayInMay,
                EnglishName = holidayName,
                LocalName = holidayName,
                HolidayTypes = HolidayTypes.Public
            };
            //return new Holiday(firstMondayInMay, holidayName, holidayName, countryCode, 1978);
        }

        private HolidaySpecification SpringBankHoliday(int year)
        {
            var holidayName = "Spring Bank Holiday";

            if (year == 2022)
            {
                //https://www.gov.uk/government/news/extra-bank-holiday-to-mark-the-queens-platinum-jubilee-in-2022
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 2),
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public
                };
                //return new Holiday(year, 6, 2, holidayName, holidayName, countryCode);
            }

            var lastMondayInMay = DateSystem.FindLastDay(year, Month.May, DayOfWeek.Monday);
            return new HolidaySpecification
            {
                Date = lastMondayInMay,
                EnglishName = holidayName,
                LocalName = holidayName,
                HolidayTypes = HolidayTypes.Public
            };
            //return new Holiday(lastMondayInMay, holidayName, holidayName, countryCode);
        }


        #region Royal family

        private HolidaySpecification QueensPlatinumJubilee(int year)
        {
            if (year == 2022)
            {
                var holidayName = "Queen’s Platinum Jubilee";

                //Majesty Queen Elizabeth II’s
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 3),
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public
                };
                //return new Holiday(year, 6, 3, "Queen’s Platinum Jubilee", "Queen’s Platinum Jubilee", countryCode);
            }

            return null;
        }

        private HolidaySpecification QueensStateFuneral(int year)
        {
            if (year == 2022)
            {
                var holidayName = "Queen’s State Funeral";

                //Majesty Queen Elizabeth II’s (https://www.gov.uk/government/news/bank-holiday-announced-for-her-majesty-queen-elizabeth-iis-state-funeral-on-monday-19-september)
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 19),
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public
                };
                //return new Holiday(year, 9, 19, "Queen’s State Funeral", "Queen’s State Funeral", countryCode);
            }

            return null;
        }

        private HolidaySpecification CoronationBankHoliday(int year)
        {
            if (year == 2023)
            {
                var holidayName = "Coronation Bank Holiday";

                //Bank holiday proclaimed in honour of the coronation of His Majesty King Charles III
                //https://www.gov.uk/government/news/bank-holiday-proclaimed-in-honour-of-the-coronation-of-his-majesty-king-charles-iii
                //https://www.iomtoday.co.im/news/extra-bank-holiday-to-mark-king-charles-iiis-coronation-571967

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 8),
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public
                };
                //return new Holiday(year, 5, 8, "Coronation Bank Holiday", "Coronation Bank Holiday", countryCode);
            }

            return null;
        }

        #endregion


        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Isle_of_Man",
                "https://www.gov.im/categories/home-and-neighbourhood/bank-holidays/"
            };
        }
    }
}
