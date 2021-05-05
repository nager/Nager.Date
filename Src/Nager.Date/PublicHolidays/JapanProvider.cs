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

            var secondMondayInJanuary = DateSystem.FindDay(year, 1, DayOfWeek.Monday, 2);
            var thirdMondayInJuly = DateSystem.FindDay(year, 7, DayOfWeek.Monday, 3);
            var thirdMondayInSeptember = DateSystem.FindDay(year, 9, DayOfWeek.Monday, 3);
            var secondMondayInOctober = DateSystem.FindDay(year, 10, DayOfWeek.Monday, 2);

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
            //items.Add(new PublicHoliday(this.GetVernalEquinox(year), "春分の日", "Vernal Equinox Day", countryCode));
            items.Add(new PublicHoliday(showaDay, "昭和の日", "Shōwa Day", countryCode));
            items.Add(new PublicHoliday(memorialDay, "憲法記念日", "Constitution Memorial Day", countryCode));
            items.Add(new PublicHoliday(greeneryDay, "みどりの日", "Greenery Day", countryCode));
            items.Add(new PublicHoliday(childrensDay, "こどもの日", "Children's Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInJuly, "海の日", "Marine Day", countryCode));
            items.Add(new PublicHoliday(mountainDay, "山の日", "Mountain Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInSeptember, "(敬老の日", "Respect for the Aged Day", countryCode));
            //items.Add(new PublicHoliday(this.GetAutumnalEquinox(year), "秋分の日", "Autumnal Equinox Day", countryCode));
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
        /// <see cref="https://en.wikipedia.org/wiki/The_Emperor%27s_Birthday#Emperor_birthday_list" />
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
