using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// United Kingdom HolidayProvider
    /// </summary>
    internal class UnitedKingdomHolidayProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// United Kingdom HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public UnitedKingdomHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "GB-NIR", "Northern Ireland" },
                { "GB-SCT", "Scotland" },
                { "GB-ENG", "England" },
                { "GB-WLS", "Wales" },
            };
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GB;

            var firstMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var lastMondayInAugust = DateSystem.FindLastDay(year, Month.August, DayOfWeek.Monday);

            var items = new List<Holiday>();

            #region New Year's Day with fallback

            var newYearDay = new DateTime(year, 1, 1);
            if (newYearDay.IsWeekend(countryCode))
            {
                var newYearDayMonday = DateSystem.FindDay(year, Month.January, 1, DayOfWeek.Monday);
                var newYearDayTuesday = DateSystem.FindDay(year, Month.January, 1, DayOfWeek.Tuesday);

                items.Add(new Holiday(newYearDay, "New Year's Day", "New Year's Day", countryCode, null, new string[] { "GB-NIR" }));
                items.Add(new Holiday(newYearDayMonday, "New Year's Day", "New Year's Day", countryCode, null, new string[] { "GB-ENG", "GB-WLS" }));
                items.Add(new Holiday(newYearDayTuesday, "New Year's Day", "New Year's Day", countryCode, null, new string[] { "GB-SCT" }));
            }
            else
            {
                items.Add(new Holiday(newYearDay, "New Year's Day", "New Year's Day", countryCode));
            }

            #endregion

            #region New Year's Day 2 with fallback

            var newYearDay2 = new DateTime(year, 1, 2).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new Holiday(newYearDay2, "New Year's Day", "New Year's Day", countryCode, null, new string[] { "GB-SCT" }));

            #endregion

            items.Add(new Holiday(year, 3, 17, "Saint Patrick's Day", "Saint Patrick's Day", countryCode, null, new string[] { "GB-NIR" }));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode).SetCounties("GB-ENG", "GB-WLS", "GB-NIR"));
            items.Add(new Holiday(year, 11, 30, "Saint Andrew's Day", "Saint Andrew's Day", countryCode, null, new string[] { "GB-SCT" }));
            items.Add(new Holiday(year, 7, 12, "Battle of the Boyne", "Battle of the Boyne", countryCode, null, new string[] { "GB-NIR" }));
            items.Add(new Holiday(firstMondayInAugust, "Summer Bank Holiday", "Summer Bank Holiday", countryCode, 1971, new string[] { "GB-SCT" }));
            items.Add(new Holiday(lastMondayInAugust, "Summer Bank Holiday", "Summer Bank Holiday", countryCode, 1971, new string[] { "GB-ENG", "GB-WLS", "GB-NIR" }));


            items.AddIfNotNull(this.EarlyMayBankHoliday(year, countryCode));
            items.AddIfNotNull(this.SpringBankHoliday(year, countryCode));
            items.AddIfNotNull(this.QueensPlatinumJubilee(year, countryCode));
            items.AddIfNotNull(this.QueensStateFuneral(year, countryCode));
            items.AddIfNotNull(this.CoronationBankHoliday(year, countryCode));

            #region Christmas Day with fallback

            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            items.Add(new Holiday(christmasDay, "Christmas Day", "Christmas Day", countryCode));

            #endregion

            #region St. Stephen's Day with fallback

            var sanktStehpenDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            items.Add(new Holiday(sanktStehpenDay, "Boxing Day", "St. Stephen's Day", countryCode));

            #endregion

            return items.OrderBy(o => o.Date);
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
            return new Holiday(lastMondayInMay, name, name, countryCode, 1971);
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

                return new Holiday(year, 5, 8, "Coronation Bank Holiday", "Coronation Bank Holiday", countryCode);
            }

            return null;
        }

        #endregion

        private Holiday EarlyMayBankHoliday(int year, CountryCode countryCode)
        {
            var holidayName = "Early May Bank Holiday";

            if (year == 2020)
            {
                //https://www.bbc.co.uk/news/uk-48565417
                var secondFridayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Friday, Occurrence.Second);
                return new Holiday(secondFridayInMay, holidayName, holidayName, countryCode, 1978);
            }

            var firstMondayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            return new Holiday(firstMondayInMay, holidayName, holidayName, countryCode, 1978);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_United_Kingdom",
                "https://de.wikipedia.org/wiki/Feiertage_im_Vereinigten_K%C3%B6nigreich"
            };
        }
    }
}
