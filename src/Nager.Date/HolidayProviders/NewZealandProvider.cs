using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// New Zealand
    /// </summary>
    internal class NewZealandProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;
        private IDictionary<int, DateTime> _matariki;

        /// <summary>
        /// NewZealandProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NewZealandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
            this.InitMatariki();
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "NZ-AUK", "Auckland" },
                { "NZ-BOP", "Bay of Plenty" },
                { "NZ-CAN", "Canterbury" },
                { "NZ-CIT", "Chatham Islands Territory" },
                { "NZ-GIS", "Gisborne" },
                { "NZ-HKB", "Hawke's Bay" },
                { "NZ-MBH", "Marlborough" },
                { "NZ-MWT", "Manawatu-Wanganui" },
                { "NZ-NSN", "Nelson" },
                { "NZ-NTL", "Northland" },
                { "NZ-OTA", "Otago" },
                { "NZ-STL", "Southland" },
                { "NZ-TAS", "Tasman" },
                { "NZ-TKI", "Taranaki" },
                { "NZ-WGN", "Wellington" },
                { "NZ-WKO", "Waikato" },
                { "NZ-WTC", "West Coast" }
            };
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.NZ;


            var labourDay = DateSystem.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Fourth);
            var easterMonday = this._catholicProvider.EasterMonday("Easter Monday", year, countryCode);

            var items = new List<Holiday>();

            #region New Year's Day with fallback

            var newYearDay1 = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new Holiday(newYearDay1, "New Year's Day", "New Year's Day", countryCode));

            var newYearDay2 = new DateTime(year, 1, 2).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            items.Add(new Holiday(newYearDay2, "Day after New Year's Day", "Day after New Year's Day", countryCode));

            #endregion

            items.AddIfNotNull(this.AnzacDay(year, countryCode));
            items.AddIfNotNull(this.WaitangiDay(year, countryCode));

            #region Christmas Day with fallback

            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            items.Add(new Holiday(christmasDay, "Christmas Day", "Christmas Day", countryCode));

            #endregion

            #region Boxing Day with fallback

            var boxingDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            items.Add(new Holiday(boxingDay, "Boxing Day", "Boxing Day", countryCode));

            #endregion

            #region Regional Anniversary Days
            // https://www.employment.govt.nz/leave-and-holidays/public-holidays/public-holidays-and-anniversary-dates/
            var aucklandDay = new DateTime(year, 1, 29).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new Holiday(aucklandDay, "Auckland/Northland Anniversary Day", "Auckland Anniversary Day", countryCode, counties: new[] { "NZ-AUK", "NZ-NTL", "NZ-MWT", "NZ-WKO", "NZ-GIS", "NZ-BOP", "NZ-HKB" }));

            var wellingtonDay = new DateTime(year, 1, 22).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new Holiday(wellingtonDay, "Wellington Anniversary Day", "Wellington Anniversary Day", countryCode, counties: new[] { "NZ-WGN", "NZ-MWT" }));

            var canterburySouthDay = DateSystem.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.Fourth);
            items.Add(new Holiday(canterburySouthDay, "Dominion Day", "Canterbury (South) Anniversary Day", countryCode, counties: new[] { "NZ-CAN" }));

            var chathamDay = new DateTime(year, 11, 30).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new Holiday(chathamDay, "Chatham Islands Anniversary Day", "Chatham Islands Anniversary Day", countryCode, counties: new[] { "NZ-CIT" }));

            var nelsonDay = new DateTime(year, 2, 1).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new Holiday(nelsonDay, "Nelson Anniversary Day", "Nelson Anniversary Day", countryCode, counties: new[] { "NZ-NSN" }));

            var otagoDay = new DateTime(year, 3, 23).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new Holiday(otagoDay, "Otago Anniversary Day", "Otago Anniversary Day", countryCode, counties: new[] { "NZ-OTA" }));

            var taranakiDay = DateSystem.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second);
            items.Add(new Holiday(taranakiDay, "Taranaki Anniversary Day", "Taranaki Anniversary Day", countryCode, counties: new[] { "NZ-TKI" }));

            // Fri before labour day, and labour day always a Mon
            var hawkesBayDay = labourDay.AddDays(-3);
            items.Add(new Holiday(hawkesBayDay, "Hawke's Bay Anniversary Day", "Hawke's Bay Anniversary Day", countryCode, counties: new[] { "NZ-HKB" }));

            // Mon following labour day (which is always Mon itself)
            var marlboroughDay = labourDay.AddDays(7);
            items.Add(new Holiday(marlboroughDay, "Marlborough Anniversary Day", "Marlborough Anniversary Day", countryCode, counties: new[] { "NZ-MBH" }));

            // Easter Tues
            var southlandDay = easterMonday.Date.AddDays(1);
            items.Add(new Holiday(southlandDay, "Southland Anniversary Day", "Southland Anniversary Day", countryCode, counties: new[] { "NZ-STL" }));

            var westlandDay = new DateTime(year, 12, 1).ShiftToClosest(DayOfWeek.Monday);
            items.Add(new Holiday(westlandDay, "Westland Anniversary Day", "Westland Anniversary Day", countryCode, counties: new[] { "NZ-WTC" }));

            // 2nd Fri following 1st Tues of Nov!
            var canterburyDay = DateSystem.FindDay(year, Month.November, DayOfWeek.Tuesday, Occurrence.First).AddDays(10);
            items.Add(new Holiday(canterburyDay, "Canterbury (North & Central) Anniversary Day", "Canterbury Anniversary Day", countryCode, counties: new[] { "NZ-CAN" }));

            #endregion

            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(easterMonday);
            items.Add(new Holiday(labourDay, "Labour Day", "Labour Day", countryCode));

            items.AddIfNotNull(this.Matariki(year, countryCode));
            items.AddIfNotNull(this.MonarchBirthday(year, countryCode));
            items.AddIfNotNull(this.MemorialDayForQueenElizabeth(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday Matariki(int year, CountryCode countryCode)
        {
            if (this._matariki.TryGetValue(year, out var matariki))
            {
                return new Holiday(matariki, "Matariki", "Matariki", countryCode);
            }

            return null;
        }

        private Holiday WaitangiDay(int year, CountryCode countryCode)
        {
            if (year >= 2016)
            {
                var waitangiDay = new DateTime(year, 2, 6).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
                return new Holiday(waitangiDay, "Waitangi Day", "Waitangi Day", countryCode);
            }

            return new Holiday(year, 2, 6, "Waitangi Day", "Waitangi Day", countryCode);
        }

        private Holiday AnzacDay(int year, CountryCode countryCode)
        {
            if (year >= 2015)
            {
                var anzacDay = new DateTime(year, 4, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
                return new Holiday(anzacDay, "Anzac Day", "Anzac Day", countryCode);
            }

            return new Holiday(year, 4, 25, "Anzac Day", "Anzac Day", countryCode);
        }

        private Holiday MonarchBirthday(int year, CountryCode countryCode)
        {
            var name = "Queen's Birthday";
            if (year >= 2023)
            {
                name = "King's Birthday";
            }

            var monarchBirthday = DateSystem.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.First);
            return new Holiday(monarchBirthday, name, name, countryCode);
        }

        private Holiday MemorialDayForQueenElizabeth(int year, CountryCode countryCode)
        {
            if (year == 2022)
            {
                //Public Holiday on 26 September to mark passing of Queen Elizabeth II
                //https://www.beehive.govt.nz/release/public-holiday-26-september-mark-passing-queen-elizabeth-ii
                return new Holiday(year, 9, 26, "Queen Elizabeth II Memorial Day", "Queen Elizabeth II Memorial Day", countryCode);
            }

            return null;
        }

        /// <summary>
        /// Matariki (Maori New Year) is introduced as a national public holiday beginning in 2022.
        /// The first 30 years of dates have been agreed upon by the Matariki Advisory Committee.
        /// The dates have been chosen to account for adjustments between the Maori lunar calendar and
        /// the Gregorian calendar, while ensuring the public holiday falls on a Friday.
        /// </summary>
        private void InitMatariki()
        {
            this._matariki = new DateTime[]
            {
                new DateTime(2022, 6, 24),
                new DateTime(2023, 7, 14),
                new DateTime(2024, 6, 28),
                new DateTime(2025, 6, 20),
                new DateTime(2026, 7, 10),
                new DateTime(2027, 6, 25),
                new DateTime(2028, 7, 14),
                new DateTime(2029, 7, 6),
                new DateTime(2030, 6, 21),
                new DateTime(2031, 7, 11),
                new DateTime(2032, 7, 2),
                new DateTime(2033, 6, 24),
                new DateTime(2034, 7, 7),
                new DateTime(2035, 6, 29),
                new DateTime(2036, 7, 18),
                new DateTime(2037, 7, 10),
                new DateTime(2038, 6, 25),
                new DateTime(2039, 7, 15),
                new DateTime(2040, 7, 6),
                new DateTime(2041, 7, 19),
                new DateTime(2042, 7, 11),
                new DateTime(2043, 7, 3),
                new DateTime(2044, 6, 24),
                new DateTime(2045, 7, 7),
                new DateTime(2046, 6, 29),
                new DateTime(2047, 7, 19),
                new DateTime(2048, 7, 3),
                new DateTime(2049, 6, 25),
                new DateTime(2050, 7, 15),
                new DateTime(2051, 6, 30),
                new DateTime(2052, 6, 21),
            }
            .ToDictionary(data => data.Year);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_New_Zealand",
                "https://www.mbie.govt.nz/assets/matariki-dates-2022-to-2052-matariki-advisory-group.pdf"
            };
        }
    }
}
