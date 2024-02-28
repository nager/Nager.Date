using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Isle of Man
    /// </summary>
    internal class IsleOfManProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// IsleOfManProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IsleOfManProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.IM;

            var lastMondayInAugust = DateSystem.FindLastDay(year, Month.August, DayOfWeek.Monday);
            var tynwaldDay = new DateTime(year, 7, 5).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            var stStephensDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));

            var items = new List<Holiday>();

            #region New Year's Day with fallback

            var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new Holiday(newYearDay, "New Year's Day", "New Year's Day", countryCode));

            #endregion

            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));

            items.Add(new Holiday(tynwaldDay, "Tynwald Day", "Tynwald Day", countryCode));
            items.Add(new Holiday(lastMondayInAugust, "Late Summer Bank Holiday", "Late Summer Bank Holiday", countryCode));
            items.Add(new Holiday(christmasDay, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new Holiday(stStephensDay, "Boxing Day", "St. Stephen's Day", countryCode));

            items.AddIfNotNull(this.EarlyMayBankHoliday(year, countryCode));
            items.AddIfNotNull(this.SpringBankHoliday(year, countryCode));
            items.AddIfNotNull(this.QueensPlatinumJubilee(year, countryCode));
            items.AddIfNotNull(this.QueensStateFuneral(year, countryCode));
            items.AddIfNotNull(this.CoronationBankHoliday(year, countryCode));
            items.AddIfNotNull(this.SeniorRaceDay(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday SeniorRaceDay(int year, CountryCode countryCode)
        {
            var holidayName = "Senior Race Day";

            if (year == 2020)
            {
                var replacementTTDay = new DateTime(2020, 8, 28);
                return new Holiday(replacementTTDay, holidayName, holidayName, countryCode, 1978);
            }

            //The friday after the first saturday of June
            var ttRaceDay = DateSystem.FindDay(DateSystem.FindDay(year, Month.June, DayOfWeek.Saturday, Occurrence.First), DayOfWeek.Friday);
            return new Holiday(ttRaceDay, holidayName, holidayName, countryCode, 1978);
        }

        private Holiday EarlyMayBankHoliday(int year, CountryCode countryCode)
        {
            var holidayName = "Early May Bank Holiday";

            if (year == 2020)
            {
                //https://www.gov.uk/government/news/extra-bank-holiday-to-mark-the-queens-platinum-jubilee-in-2022
                var secondFridayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Friday, Occurrence.Second);
                return new Holiday(secondFridayInMay, holidayName, holidayName, countryCode, 1978);
            }

            var firstMondayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            return new Holiday(firstMondayInMay, holidayName, holidayName, countryCode, 1978);
        }

        private Holiday SpringBankHoliday(int year, CountryCode countryCode)
        {
            var name = "Spring Bank Holiday";

            if (year == 2022)
            {
                //https://www.gov.uk/government/news/extra-bank-holiday-to-mark-the-queens-platinum-jubilee-in-2022
                return new Holiday(year, 6, 2, name, name, countryCode);
            }

            var lastMondayInMay = DateSystem.FindLastDay(year, Month.May, DayOfWeek.Monday);
            return new Holiday(lastMondayInMay, name, name, countryCode);
        }


        #region Royal family

        private Holiday QueensPlatinumJubilee(int year, CountryCode countryCode)
        {
            if (year == 2022)
            {
                //Majesty Queen Elizabeth II’s
                return new Holiday(year, 6, 3, "Queen’s Platinum Jubilee", "Queen’s Platinum Jubilee", countryCode);
            }

            return null;
        }

        private Holiday QueensStateFuneral(int year, CountryCode countryCode)
        {
            if (year == 2022)
            {
                //Majesty Queen Elizabeth II’s (https://www.gov.uk/government/news/bank-holiday-announced-for-her-majesty-queen-elizabeth-iis-state-funeral-on-monday-19-september)
                return new Holiday(year, 9, 19, "Queen’s State Funeral", "Queen’s State Funeral", countryCode);
            }

            return null;
        }

        private Holiday CoronationBankHoliday(int year, CountryCode countryCode)
        {
            if (year == 2023)
            {
                //Bank holiday proclaimed in honour of the coronation of His Majesty King Charles III
                //https://www.gov.uk/government/news/bank-holiday-proclaimed-in-honour-of-the-coronation-of-his-majesty-king-charles-iii
                //https://www.iomtoday.co.im/news/extra-bank-holiday-to-mark-king-charles-iiis-coronation-571967

                return new Holiday(year, 5, 8, "Coronation Bank Holiday", "Coronation Bank Holiday", countryCode);
            }

            return null;
        }

        #endregion


        ///<inheritdoc/>
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
