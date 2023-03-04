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
    internal class JapanProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// JapanProvider
        /// </summary>
        public JapanProvider()
        { }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
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
            items.Add(new PublicHoliday(showaDay, "昭和の日", "Shōwa Day", countryCode));
            items.Add(new PublicHoliday(memorialDay, "憲法記念日", "Constitution Memorial Day", countryCode));
            items.Add(new PublicHoliday(greeneryDay, "みどりの日", "Greenery Day", countryCode));
            items.Add(new PublicHoliday(childrensDay, "こどもの日", "Children's Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInJuly, "海の日", "Marine Day", countryCode));
            items.Add(new PublicHoliday(mountainDay, "山の日", "Mountain Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInSeptember, "敬老の日", "Respect for the Aged Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInOctober, "体育の日", "Health and Sports Day", countryCode));
            items.Add(new PublicHoliday(cultureDay, "文化の日", "Culture Day", countryCode));
            items.Add(new PublicHoliday(thanksgivingDay, "勤労感謝の日", "Labour Thanksgiving Day", countryCode));

            //Will change to the date of the new emperor on the death of the current one
            items.AddIfNotNull(this.GetEmperorsBirthday(year, countryCode));
            items.AddIfNotNull(this.GetVernalEquinox(year, countryCode));
            items.AddIfNotNull(this.GetAutumnalEquinox(year, countryCode));

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

        private PublicHoliday GetVernalEquinox(int year, CountryCode countryCode)
        {
            if (year < 1850 || year > 2151)
            {
                return null;
            }

            var differencePerYear = 0.242194;
            var equinoxDay = 0.0;
            if (year >= 1851 && year <= 1899)
            {
                equinoxDay = Math.Truncate(19.8277 + differencePerYear * (year - 1980) - Math.Truncate((year - 1983) / 4.0));
            }
            else if (year >= 1900 && year <= 1979)
            {
                equinoxDay = Math.Truncate(20.8357 + differencePerYear * (year - 1980) - Math.Truncate((year - 1983) / 4.0));
            }
            else if (year >= 1980 && year <= 2099)
            {
                equinoxDay = Math.Truncate(20.8431 + differencePerYear * (year - 1980) - Math.Truncate((year - 1980) / 4.0));
            }
            else if (year >= 2100 && year <= 2150)
            {
                equinoxDay = Math.Truncate(21.8510 + differencePerYear * (year - 1980) - Math.Truncate((year - 1980) / 4.0));
            }

            return new PublicHoliday(new DateTime(year, 3, (int)equinoxDay), "春分の日", "Vernal Equinox Day", countryCode);
        }

        private PublicHoliday GetAutumnalEquinox(int year, CountryCode countryCode)
        {
            if (year < 1850 || year > 2151)
            {
                return null;
            }

            var differencePerYear = 0.242194;
            var equinoxDay = 0.0;
            if (year >= 1851 && year <= 1899)
            {
                equinoxDay = Math.Truncate(22.2588 + differencePerYear * (year - 1980) - Math.Truncate((year - 1983) / 4.0));
            }
            else if (year >= 1900 && year <= 1979)
            {
                equinoxDay = Math.Truncate(23.2588 + differencePerYear * (year - 1980) - Math.Truncate((year - 1983) / 4.0));
            }
            else if (year >= 1980 && year <= 2099)
            {
                equinoxDay = Math.Truncate(23.2488 + differencePerYear * (year - 1980) - Math.Truncate((year - 1980) / 4.0));
            }
            else if (year >= 2100 && year <= 2150)
            {
                equinoxDay = Math.Truncate(24.2488 + differencePerYear * (year - 1980) - Math.Truncate((year - 1980) / 4.0));
            }

            return new PublicHoliday(new DateTime(year, 9, (int)equinoxDay), "秋分の日", "Autumnal Equinox Day", countryCode);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Japan",
                "https://en.wikipedia.org/wiki/Golden_Week_(Japan)",
                "https://www.boj.or.jp/en/about/outline/holi.htm/",
                "https://en.wikipedia.org/wiki/The_Emperor%27s_Birthday#Emperor_birthday_list",
                "https://zariganitosh.hatenablog.jp/entry/20140929/japanese_holiday_memo",
                "https://rkapl123.github.io/QLAnnotatedSource/da/db4/japan_8cpp_source.html",
                "http://addinbox.sakura.ne.jp/holiday_logic_English.htm"
            };
        }
    }
}
