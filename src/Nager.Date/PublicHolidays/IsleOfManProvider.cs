using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Isle of Man
    /// </summary>
    internal class IsleOfManProvider : IPublicHolidayProvider
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
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.IM;

            var lastMondayInAugust = DateSystem.FindLastDay(year, Month.August, DayOfWeek.Monday);
            var tynwaldDay = new DateTime(year, 7, 5).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            var stStephensDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));

            var items = new List<PublicHoliday>();

            #region New Year's Day with fallback

            var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(newYearDay, "New Year's Day", "New Year's Day", countryCode));

            #endregion

            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));

            items.Add(new PublicHoliday(tynwaldDay, "Tynwald Day", "Tynwald Day", countryCode));
            items.Add(new PublicHoliday(lastMondayInAugust, "Late Summer Bank Holiday", "Late Summer Bank Holiday", countryCode));
            items.Add(new PublicHoliday(christmasDay, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(stStephensDay, "Boxing Day", "St. Stephen's Day", countryCode));

            items.AddIfNotNull(this.EarlyMayBankHoliday(year, countryCode));
            items.AddIfNotNull(this.SpringBankHoliday(year, countryCode));
            items.AddIfNotNull(this.QueensPlatinumJubilee(year, countryCode));
            items.AddIfNotNull(this.QueensStateFuneral(year, countryCode));
            items.AddIfNotNull(this.CoronationBankHoliday(year, countryCode));
            items.AddIfNotNull(this.SeniorRaceDay(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday SeniorRaceDay(int year, CountryCode countryCode)
        {
            var holidayName = "Senior Race Day";

            if (year == 2020)
            {
                var replacementTTDay = new DateTime(2020, 8, 28);
                return new PublicHoliday(replacementTTDay, holidayName, holidayName, countryCode, 1978);
            }

            //The friday after the first saturday of June
            var ttRaceDay = DateSystem.FindDay(DateSystem.FindDay(year, Month.June, DayOfWeek.Saturday, Occurrence.First), DayOfWeek.Friday);
            return new PublicHoliday(ttRaceDay, holidayName, holidayName, countryCode, 1978);
        }

        private PublicHoliday EarlyMayBankHoliday(int year, CountryCode countryCode)
        {
            var holidayName = "Early May Bank Holiday";

            if (year == 2020)
            {
                //https://www.gov.uk/government/news/extra-bank-holiday-to-mark-the-queens-platinum-jubilee-in-2022
                var secondFridayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Friday, Occurrence.Second);
                return new PublicHoliday(secondFridayInMay, holidayName, holidayName, countryCode, 1978);
            }

            var firstMondayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            return new PublicHoliday(firstMondayInMay, holidayName, holidayName, countryCode, 1978);
        }

        private PublicHoliday SpringBankHoliday(int year, CountryCode countryCode)
        {
            var name = "Spring Bank Holiday";

            if (year == 2022)
            {
                //https://www.gov.uk/government/news/extra-bank-holiday-to-mark-the-queens-platinum-jubilee-in-2022
                return new PublicHoliday(year, 6, 2, name, name, countryCode);
            }

            var lastMondayInMay = DateSystem.FindLastDay(year, Month.May, DayOfWeek.Monday);
            return new PublicHoliday(lastMondayInMay, name, name, countryCode);
        }


        #region Royal family

        private PublicHoliday QueensPlatinumJubilee(int year, CountryCode countryCode)
        {
            if (year == 2022)
            {
                //Majesty Queen Elizabeth II’s
                return new PublicHoliday(year, 6, 3, "Queen’s Platinum Jubilee", "Queen’s Platinum Jubilee", countryCode);
            }

            return null;
        }

        private PublicHoliday QueensStateFuneral(int year, CountryCode countryCode)
        {
            if (year == 2022)
            {
                //Majesty Queen Elizabeth II’s (https://www.gov.uk/government/news/bank-holiday-announced-for-her-majesty-queen-elizabeth-iis-state-funeral-on-monday-19-september)
                return new PublicHoliday(year, 9, 19, "Queen’s State Funeral", "Queen’s State Funeral", countryCode);
            }

            return null;
        }

        private PublicHoliday CoronationBankHoliday(int year, CountryCode countryCode)
        {
            if (year == 2023)
            {
                //Bank holiday proclaimed in honour of the coronation of His Majesty King Charles III
                //https://www.gov.uk/government/news/bank-holiday-proclaimed-in-honour-of-the-coronation-of-his-majesty-king-charles-iii
                //https://www.iomtoday.co.im/news/extra-bank-holiday-to-mark-king-charles-iiis-coronation-571967

                return new PublicHoliday(year, 5, 8, "Coronation Bank Holiday", "Coronation Bank Holiday", countryCode);
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
