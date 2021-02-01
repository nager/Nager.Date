using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Korea
    /// </summary>
    public class KoreaProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// KoreaProvider
        /// </summary>
        public KoreaProvider()
        {
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            //TODO: Provider incomplete
            //Tomb-Sweeping-Day is invalid (5th solar term)

            var countryCode = CountryCode.KR;
            var items = new List<PublicHoliday>();

            if (year > 1901 && year < 2100)
            {
                //LunisolarCalendar .net implementation only valid are between 1901 and 2100, inclusive.
                //https://docs.microsoft.com/en-us/dotnet/api/system.globalization.koreanlunisolarcalendar?view=net-5.0
                var koreanCalendar = new KoreanLunisolarCalendar();
                var leapMonth = koreanCalendar.GetLeapMonth(year);

                var lunarNewYear2 = koreanCalendar.ToDateTime(year, this.MoveMonth(1, leapMonth), 1, 0, 0, 0, 0);   //Has alternative holidays
                var lunarNewYear1 = lunarNewYear2.AddDays(-1);
                var lunarNewYear3 = koreanCalendar.ToDateTime(year, this.MoveMonth(1, leapMonth), 2, 0, 0, 0, 0);
                var buddhaBday = koreanCalendar.ToDateTime(year, this.MoveMonth(4, leapMonth), 8, 0, 0, 0, 0);
                var Chuseok1 = koreanCalendar.ToDateTime(year, this.MoveMonth(8, leapMonth), 14, 0, 0, 0, 0);   //Has alternative holidays
                var Chuseok2 = koreanCalendar.ToDateTime(year, this.MoveMonth(8, leapMonth), 15, 0, 0, 0, 0);
                var Chuseok3 = koreanCalendar.ToDateTime(year, this.MoveMonth(8, leapMonth), 16, 0, 0, 0, 0);

                items.Add(new PublicHoliday(lunarNewYear1, "설날", "Lunar New Year", countryCode));
                items.Add(new PublicHoliday(lunarNewYear2, "설날", "Lunar New Year", countryCode));
                items.Add(new PublicHoliday(lunarNewYear3, "설날", "Lunar New Year", countryCode));
                items.Add(new PublicHoliday(buddhaBday, "부처님 오신 날", "Buddha's Birthday", countryCode));
                items.Add(new PublicHoliday(Chuseok1, "추석", "Chuseok", countryCode));
                items.Add(new PublicHoliday(Chuseok2, "추석", "Chuseok", countryCode));
                items.Add(new PublicHoliday(Chuseok3, "추석", "Chuseok", countryCode));
            }
            items.Add(new PublicHoliday(year, 1, 1, "새해", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 1, "3·1절", "Independence Movement Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 5, "어린이날", "Children's Day", countryCode));    //Has alternative holidays
            items.Add(new PublicHoliday(year, 6, 6, "현충일", "Memorial Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "광복절", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 3, "개천절", "National Foundation Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 9, "한글날", "Hangul Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "크리스마스", "Christmas", countryCode));


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
                "https://en.wikipedia.org/wiki/Public_holidays_in_South_Korea",
            };
        }
    }
}
