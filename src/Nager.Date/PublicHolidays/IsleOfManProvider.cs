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
    public class IsleOfManProvider : IPublicHolidayProvider
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
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.IM;

            var items = new List<PublicHoliday>();

            #region New Year's Day with fallback

            var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(newYearDay, "New Year's Day", "New Year's Day", countryCode));

            #endregion

            var earlyMayBankHoliday = this.GetEarlyMayBankHoliday(year, countryCode);
            if (earlyMayBankHoliday != null)
            {
                items.Add(earlyMayBankHoliday);
            }

            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));

            var springBankHoliday = this.GetSpringBankHoliday(year, countryCode);
            if (springBankHoliday != null)
            {
                items.Add(springBankHoliday);
            }

            var queensPlatinumJubilee = this.GetQueensPlatinumJubilee(year, countryCode);
            if (queensPlatinumJubilee != null)
            {
                items.Add(queensPlatinumJubilee);
            }

            var ttRaceDay = this.GetTTRaceDay(year, countryCode);
            if (ttRaceDay != null)
            {
                items.Add(ttRaceDay);
            }

            var tynwaldDay = new DateTime(year, 7, 5).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(tynwaldDay, "Tynwald Day", "Tynwald Day", countryCode));

            var lastMondayInAugust = DateSystem.FindLastDay(year, Month.August, DayOfWeek.Monday);
            items.Add(new PublicHoliday(lastMondayInAugust, "Late Summer Bank Holiday", "Late Summer Bank Holiday", countryCode));

            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            items.Add(new PublicHoliday(christmasDay, "Christmas Day", "Christmas Day", countryCode));

            var stStephensDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            items.Add(new PublicHoliday(stStephensDay, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday GetTTRaceDay(int year, CountryCode countryCode)
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

        private PublicHoliday GetEarlyMayBankHoliday(int year, CountryCode countryCode)
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

        private PublicHoliday GetSpringBankHoliday(int year, CountryCode countryCode)
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

        private PublicHoliday GetQueensPlatinumJubilee(int year, CountryCode countryCode)
        {
            if (year == 2022)
            {
                //https://www.bbc.co.uk/news/uk-59929077
                return new PublicHoliday(year, 6, 3, "Queen’s Platinum Jubilee", "Queen’s Platinum Jubilee", countryCode);
            }

            return null;
        }

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
