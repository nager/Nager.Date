using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// New Zealand
    /// </summary>
    public class NewZealandProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// NewZealandProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NewZealandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.NZ;

            var queensBthday = DateSystem.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.First);
            var labourDay = DateSystem.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Fourth);
            var easterMon = this._catholicProvider.EasterMonday("Easter Monday", year, countryCode);

            var items = new List<PublicHoliday>();

            #region New Year's Day with fallback

            var newYearDay1 = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(newYearDay1, "New Year's Day", "New Year's Day", countryCode));

            var newYearDay2 = new DateTime(year, 1, 2).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            items.Add(new PublicHoliday(newYearDay2, "Day after New Year's Day", "Day after New Year's Day", countryCode));

            #endregion

            #region Anzac Day with fallback

            if (year >= 2015)
            {
                var anzacDay = new DateTime(year, 4, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
                items.Add(new PublicHoliday(anzacDay, "Anzac Day", "Anzac Day", countryCode));
            }
            else
            {
                items.Add(new PublicHoliday(year, 4, 25, "Anzac Day", "Anzac Day", countryCode));
            }

            #endregion

            #region Anzac Day with fallback

            if (year >= 2016)
            {
                var anzacDay = new DateTime(year, 2, 6).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
                items.Add(new PublicHoliday(anzacDay, "Waitangi Day", "Waitangi Day", countryCode));
            }
            else
            {
                items.Add(new PublicHoliday(year, 2, 6, "Waitangi Day", "Waitangi Day", countryCode));
            }

            #endregion

            #region Christmas Day with fallback

            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(christmasDay, "Christmas Day", "Christmas Day", countryCode));

            #endregion

            #region Boxing Day with fallback

            var boxingDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            items.Add(new PublicHoliday(boxingDay, "Boxing Day", "Boxing Day", countryCode));

        #endregion

            #region Regional Aniversary Days
            // https://www.employment.govt.nz/leave-and-holidays/public-holidays/public-holidays-and-anniversary-dates/
            var auckl = new DateTime(year, 1, 29).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new PublicHoliday(auckl, "Auckland/Northland Anniversary Day", "Auckland Anniversary Day", countryCode, counties: new[] { "NZ-AUK", "NZ-NTL", "NZ-MWT", "NZ-WKO", "NZ-GIS", "NZ-BOP", "NZ-HKB" }));

            var wellington = new DateTime(year, 1, 22).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new PublicHoliday(wellington, "Wellington Anniversary Day", "Wellington Anniversary Day", countryCode, counties: new[] { "NZ-WGN", "NZ-MWT" }));

            var canterburySth = DateSystem.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.Fourth);
            items.Add(new PublicHoliday(canterburySth, "Dominion Day", "Canterbury (South) Anniversary Day", countryCode, counties: new[] { "NZ-CAN" }));

            var chatham = new DateTime(year, 11, 30).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new PublicHoliday(chatham, "Chatham Islands Anniversary Day", "Chatham Islands Anniversary Day", countryCode, counties: new[] { "NZ-CIT" }));

            var nelson = new DateTime(year, 2, 1).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new PublicHoliday(nelson, "Nelson Anniversary Day", "Nelson Anniversary Day", countryCode, counties: new[] { "NZ-NSN" }));

            var otago = new DateTime(year, 3, 23).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new PublicHoliday(otago, "Otago Anniversary Day", "Otago Anniversary Day", countryCode, counties: new[] { "NZ-OTA" }));

            var taranaki = DateSystem.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second);
            items.Add(new PublicHoliday(taranaki, "Taranaki Anniversary Day", "Taranaki Anniversary Day", countryCode, counties: new[] { "NZ-TKI" }));

            // Fri before labour day, and labour day always a Mon
            var hawkesBay = labourDay.AddDays(-3);
            items.Add(new PublicHoliday(hawkesBay, "Hawke's Bay Anniversary Day", "Hawke's Bay Anniversary Day", countryCode, counties: new[] { "NZ-HKB" }));

            // Mon following labour day (which is always Mon itself)
            var marlborough = labourDay.AddDays(7);
            items.Add(new PublicHoliday(marlborough, "Marlborough Anniversary Day", "Marlborough Anniversary Day", countryCode, counties: new[] { "NZ-MBH" }));

            // Easter Tues
            var southland = easterMon.Date.AddDays(1);
            items.Add(new PublicHoliday(southland, "Southland Anniversary Day", "Southland Anniversary Day", countryCode, counties: new[] { "NZ-STL" }));

            var westland = new DateTime(year, 12, 1).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new PublicHoliday(westland, "Westland Anniversary Day", "Westland Anniversary Day", countryCode, counties: new[] { "NZ-WTC" }));

            // 2nd Fri following 1st Tues of Nov!
            var canterbury = DateSystem.FindDay(year, Month.November, DayOfWeek.Tuesday, Occurrence.First).AddDays(10);
            items.Add(new PublicHoliday(canterbury, "Canterbury (North & Central) Anniversary Day", "Canterbury Anniversary Day", countryCode, counties: new[] { "NZ-CAN" }));

            #endregion

            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(easterMon);
            items.Add(new PublicHoliday(queensBthday, "Queen's Birthday", "Queen's Birthday", countryCode));
            items.Add(new PublicHoliday(labourDay, "Labour Day", "Labour Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_New_Zealand"
            };
        }
    }
}
