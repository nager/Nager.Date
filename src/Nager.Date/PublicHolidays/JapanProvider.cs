using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
//using AASharp;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Japan
    /// </summary>
    public class JapanProvider : IPublicHolidayProvider
    {
        //private TimeZoneInfo _timeZone;

        /// <summary>
        /// JapanProvider
        /// </summary>
        public JapanProvider()
        {
            //TODO: TimeZoneInfo is not available on Android projects
            //https://github.com/tinohager/Nager.Date/issues/123
            //this._timeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.JP;

            var secondMondayInJanuary = DateSystem.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Second);
            var thirdMondayInJuly = DateSystem.FindDay(year, Month.July, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayInSeptember = DateSystem.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.Third);
            var secondMondayInOctober = DateSystem.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);

            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var foundationDay = new DateTime(year, 2, 11).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var showaDay = new DateTime(year, 4, 29).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var memorialDay = new DateTime(year, 5, 3).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var greeneryDay = new DateTime(year, 5, 4).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var childrensDay = new DateTime(year, 5, 5).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var mountainDay = new DateTime(year, 8, 11).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var cultureDay = new DateTime(year, 11, 3).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var thanksgivingDay = new DateTime(year, 11, 23).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(newYearsDay, "元日", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInJanuary, "成人の日", "Coming of Age Day", countryCode));
            items.Add(new PublicHoliday(foundationDay, "建国記念の日", "Foundation Day", countryCode));
            items.Add(new PublicHoliday(this.GetVernalEquinox(year), "春分の日", "Vernal Equinox Day", countryCode));
            items.Add(new PublicHoliday(showaDay, "昭和の日", "Shōwa Day", countryCode));
            items.Add(new PublicHoliday(memorialDay, "憲法記念日", "Constitution Memorial Day", countryCode));
            items.Add(new PublicHoliday(greeneryDay, "みどりの日", "Greenery Day", countryCode));
            items.Add(new PublicHoliday(childrensDay, "こどもの日", "Children's Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInJuly, "海の日", "Marine Day", countryCode));
            items.Add(new PublicHoliday(mountainDay, "山の日", "Mountain Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInSeptember, "敬老の日", "Respect for the Aged Day", countryCode));
            items.Add(new PublicHoliday(this.GetAutumnalEquinox(year), "秋分の日", "Autumnal Equinox Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInOctober, "体育の日", "Health and Sports Day", countryCode));
            items.Add(new PublicHoliday(cultureDay, "文化の日", "Culture Day", countryCode));
            items.Add(new PublicHoliday(thanksgivingDay, "勤労感謝の日", "Labour Thanksgiving Day", countryCode));
            //Will change to the date of the new emperor on the death of the current one
            var emperorsBirthday = this.GetEmperorsBirthday(year, countryCode);
            if (emperorsBirthday != null)
            {
                items.Add(emperorsBirthday);
            }

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Golden_Week_(Japan)
        /// Get the Golden Week for a given year
        /// </summary>
        /// <param name="year"></param>
        public DateTime GetGoldenWeekStartDate(int year)
        {
            var showaDay = new DateTime(year, 4, 29).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            return showaDay;
        }

        /// <summary>
        /// Adds the emperor's birthday based on the era/emperor of the current year.
        /// </summary>
        /// <see href="https://en.wikipedia.org/wiki/The_Emperor%27s_Birthday#Emperor_birthday_list" />
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Emperors Birthday object or null</returns>
        private PublicHoliday GetEmperorsBirthday(int year, CountryCode countryCode)
        {
            if (year < 1868)
            {
                return null;
            }

            DateTime result;

            if (year < 1873)
            {
                //TODO: Period 1868 - 1872 based on Lunisolar calendar
                return null;
            }
            else if (year < 1912)
            {
                result = new DateTime(year, 11, 3);
            }
            else if (year < 1913)
            {
                result = new DateTime(year, 8, 31);
            }
            else if (year < 1927)
            {
                result = new DateTime(year, 10, 31);
            }
            else if (year < 1989)
            {
                result = new DateTime(year, 4, 29);
            }
            else if (year < 2019)
            {
                result = new DateTime(year, 12, 23);
            }
            else if (year == 2019)
            {
                return null;
            }
            else
            {
                result = new DateTime(year, 2, 23);
            }

            return new PublicHoliday(
                result.Shift(saturday => saturday, sunday => sunday.AddDays(1)),
                year < 1948 ? "天長節" : "天皇誕生日",
                "The Emperor's Birthday",
                countryCode);
        }

        //private DateTime GetVernalEquinox(int year)
        //{
        //    long curYear = 0, month = 0, day = 0, hour = 0, minutes = 0;
        //    double seconds = 0;
        //    var date = new AASDate();
        //    var spring = AASEquinoxesAndSolstices.NorthwardEquinox(year, true);
        //    date.Set(spring, true);
        //    date.Get(ref curYear, ref month, ref day, ref hour, ref minutes, ref seconds);
        //    var dt = new DateTime((int)curYear, (int)month, (int)day, (int)hour, (int)minutes, (int)seconds);
        //    var converDt = TimeZoneInfo.ConvertTimeFromUtc(dt, timeZone);
        //    return converDt;
        //}

        private DateTime GetVernalEquinox(int year)
        {
            long curYear = year, month = 3, day = 21, hour = 0, minutes = 0;
            double seconds = 0;
            /*var date = new AASDate();
            var spring = AASEquinoxesAndSolstices.NorthwardEquinox(year, true);
            date.Set(spring, true);
            date.Get(ref curYear, ref month, ref day, ref hour, ref minutes, ref seconds);*/
            var mod = year % 4;
            var array = new int[4];
            if (1900 <= year && year <= 1923){array= new int[] {21,21,21,22};}
            else if (1924 <= year && year <= 1959){array= new int[] {21,21,21,21};}
            else if (1960 <= year && year <= 1991){array= new int[] {20,21,21,21};}
            else if (1992 <= year && year <= 2023){array= new int[] {20,20,21,21};}
            else if (2024 <= year && year <= 2055){array= new int[] {20,20,20,21};}
            else if (2056 <= year && year <= 2091){array= new int[] {20,20,20,20};}
            else if (2092 <= year && year <= 2099){array= new int[] {19,20,20,20};}
            else if (2100 <= year && year <= 2123){array= new int[] {20,21,21,21};}
            else if (2124 <= year && year <= 2155){array= new int[] {20,20,21,21};}
            else if (2156 <= year && year <= 2187){array= new int[] {20,20,20,21};}
            else if (2188 <= year && year <= 2199){array= new int[] {20,20,20,20};}
            else if (2200 <= year && year <= 2223){array= new int[] {21,21,21,21};}
            else if (2224 <= year && year <= 2255){array= new int[] {20,21,21,21};}
            else if (2256 <= year && year <= 2287){array= new int[] {20,20,21,21};}
            else if (2288 <= year && year <= 2299){array= new int[] {20,20,20,21};}
            var dt = new DateTime((int)curYear, (int)month, (int)array[mod], (int)hour, (int)minutes, (int)seconds);
            if(array.Length == 0){
                dt = new DateTime((int)curYear, (int)month, (int)day, (int)hour, (int)minutes, (int)seconds);
            }
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            var converDt = TimeZoneInfo.ConvertTimeFromUtc(dt, timeZone);
            return converDt;
        }

        //private DateTime GetAutumnalEquinox(int year)
        //{
        //    long curYear = 0, month = 0, day = 0, hour = 0, minutes = 0;
        //    double seconds = 0;
        //    var date = new AASDate();
        //    var spring = AASEquinoxesAndSolstices.SouthwardEquinox(year, true);
        //    date.Set(spring, true);
        //    date.Get(ref curYear, ref month, ref day, ref hour, ref minutes, ref seconds);
        //    var dt = new DateTime((int)curYear, (int)month, (int)day, (int)hour, (int)minutes, (int)seconds);
        //    var converDt = TimeZoneInfo.ConvertTimeFromUtc(dt, timeZone);
        //    return converDt;
        //}
    
        private DateTime GetAutumnalEquinox(int year){
            long curYear = year, month = 9, day = 23, hour = 0, minutes = 0;
            double seconds = 0;
            /*var date = new AASDate();
            var spring = AASEquinoxesAndSolstices.SouthwardEquinox(year, true);
            date.Set(spring, true);
            date.Get(ref curYear, ref month, ref day, ref hour, ref minutes, ref seconds);*/
            var mod = year % 4;
            var array = new int[4];
            if (1900 <= year && year <= 1919){array = new int[] {23,24,24,24};}
            else if (1920 <= year && year <= 1947){array = new int[] {23,23,24,24};}
            else if (1948 <= year && year <= 1979){array = new int[] {23,23,23,24};}
            else if (1980 <= year && year <= 2011){array = new int[] {23,23,23,23};}
            else if (2012 <= year && year <= 2043){array = new int[] {22,23,23,23};}
            else if (2044 <= year && year <= 2075){array = new int[] {22,22,23,23};}
            else if (2076 <= year && year <= 2099){array = new int[] {22,22,22,23};}
            else if (2100 <= year && year <= 2107){array = new int[] {23,23,23,24};}
            else if (2108 <= year && year <= 2139){array = new int[] {23,23,23,23};}
            else if (2140 <= year && year <= 2167){array = new int[] {22,23,23,23};}
            else if (2168 <= year && year <= 2199){array = new int[] {22,22,23,23};}
            else if (2200 <= year && year <= 2227){array = new int[] {23,23,23,24};}
            else if (2228 <= year && year <= 2263){array = new int[] {23,23,23,23};}
            else if (2264 <= year && year <= 2291){array = new int[] {22,23,23,23};}
            else if (2292 <= year && year <= 2299){array = new int[] {22,22,23,23};}
            var dt = new DateTime((int)curYear, (int)month, (int)array[mod], (int)hour, (int)minutes, (int)seconds);
            if(array.Length == 0){
                dt = new DateTime((int)curYear, (int)month, (int)day, (int)hour, (int)minutes, (int)seconds);
            }
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            var converDt = TimeZoneInfo.ConvertTimeFromUtc(dt, timeZone);
            return converDt;
        }
        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Japan",
                "https://en.wikipedia.org/wiki/Golden_Week_(Japan)",
                "https://www.boj.or.jp/en/about/outline/holi.htm/",
                "https://en.wikipedia.org/wiki/The_Emperor%27s_Birthday#Emperor_birthday_list"
            };
        }
    }
}
