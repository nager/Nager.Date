using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// South Korea
    /// </summary>
    internal class SouthKoreaProvider : IPublicHolidayProvider
    {
        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.KR;
            var items = new List<PublicHoliday>();

            var koreanCalendar = new KoreanLunisolarCalendar();
            if (year >= koreanCalendar.MinSupportedDateTime.Year && year < koreanCalendar.MaxSupportedDateTime.Year)
            {
                var leapMonth = koreanCalendar.GetLeapMonth(year);

                var lunarNewYear1 = koreanCalendar.ToDateTime(year, this.MoveMonth(1, leapMonth), 1, 0, 0, 0, 0); //Has substitute holiday
                lunarNewYear1 = lunarNewYear1.Shift(saturday => saturday, sunday => sunday.AddDays(1));

                var lunarNewYear2 = lunarNewYear1.AddDays(+1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                var lunarNewYear3 = lunarNewYear1.AddDays(-1).Shift(saturday => saturday, sunday => sunday.AddDays(-1));

                var buddhaBday = koreanCalendar.ToDateTime(year, this.MoveMonth(4, leapMonth), 8, 0, 0, 0, 0);

                var chuseok1 = koreanCalendar.ToDateTime(year, this.MoveMonth(8, leapMonth), 14, 0, 0, 0, 0); //Has substitute holiday
                chuseok1 = chuseok1.Shift(saturday => saturday, sunday => sunday.AddDays(1));
                var chuseok2 = chuseok1.AddDays(+1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                var chuseok3 = chuseok2.AddDays(+1).Shift(saturday => saturday, sunday => sunday.AddDays(1));

                items.Add(new PublicHoliday(lunarNewYear1, "설날", "Lunar New Year", countryCode));
                items.Add(new PublicHoliday(lunarNewYear2, "설날", "Lunar New Year", countryCode));
                items.Add(new PublicHoliday(lunarNewYear3, "설날", "Lunar New Year", countryCode));
                items.Add(new PublicHoliday(buddhaBday, "부처님 오신 날", "Buddha's Birthday", countryCode));
                items.Add(new PublicHoliday(chuseok1, "추석", "Chuseok", countryCode));
                items.Add(new PublicHoliday(chuseok2, "추석", "Chuseok", countryCode));
                items.Add(new PublicHoliday(chuseok3, "추석", "Chuseok", countryCode));
            }

            items.Add(new PublicHoliday(year, 1, 1, "새해", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 1, "3·1절", "Independence Movement Day", countryCode));

            var childrenDay = new DateTime(year, 5, 5).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1)); //Substitute holiday
            items.Add(new PublicHoliday(childrenDay, "어린이날", "Children's Day", countryCode)); //Has substitute holiday

            items.Add(new PublicHoliday(year, 6, 6, "현충일", "Memorial Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "광복절", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 3, "개천절", "National Foundation Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 9, "한글날", "Hangul Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "크리스마스", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        private int MoveMonth(int month, int leapMonth)
        {
            if (leapMonth == 0)
            {
                return month;
            }

            if (leapMonth < month)
            {
                return ++month;
            }

            return month;
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_South_Korea", //South Korea's public holidays
                "https://www.koreanlaborlaw.com/substitute-holiday-system-of-korea/" //Substitute holiday system of Korea
            };
        }
    }
}
