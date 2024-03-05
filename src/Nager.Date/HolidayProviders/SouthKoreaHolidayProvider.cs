using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// South Korea HolidayProvider
    /// </summary>
    internal class SouthKoreaHolidayProvider : IHolidayProvider
    {
        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.KR;

            var childrenDay = new DateTime(year, 5, 5).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1)); //Substitute holiday

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "새해",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 1),
                    EnglishName = "Independence Movement Day",
                    LocalName = "3·1절",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = childrenDay,
                    EnglishName = "Children's Day",
                    LocalName = "어린이날",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 6),
                    EnglishName = "Memorial Day",
                    LocalName = "현충일",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Liberation Day",
                    LocalName = "광복절",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 3),
                    EnglishName = "National Foundation Day",
                    LocalName = "개천절",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 9),
                    EnglishName = "Hangul Day",
                    LocalName = "한글날",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "크리스마스",
                    HolidayTypes = HolidayTypes.Public
                }
            };

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

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = lunarNewYear1,
                    EnglishName = "Lunar New Year",
                    LocalName = "설날",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = lunarNewYear2,
                    EnglishName = "Lunar New Year",
                    LocalName = "설날",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = lunarNewYear3,
                    EnglishName = "Lunar New Year",
                    LocalName = "설날",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = buddhaBday,
                    EnglishName = "Buddha's Birthday",
                    LocalName = "부처님 오신 날",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = chuseok1,
                    EnglishName = "Chuseok",
                    LocalName = "추석",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = chuseok2,
                    EnglishName = "Chuseok",
                    LocalName = "추석",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = chuseok3,
                    EnglishName = "Chuseok",
                    LocalName = "추석",
                    HolidayTypes = HolidayTypes.Public
                });
            }

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);


            //var items = new List<Holiday>();

            //var koreanCalendar = new KoreanLunisolarCalendar();
            //if (year >= koreanCalendar.MinSupportedDateTime.Year && year < koreanCalendar.MaxSupportedDateTime.Year)
            //{
            //    var leapMonth = koreanCalendar.GetLeapMonth(year);

            //    var lunarNewYear1 = koreanCalendar.ToDateTime(year, this.MoveMonth(1, leapMonth), 1, 0, 0, 0, 0); //Has substitute holiday
            //    lunarNewYear1 = lunarNewYear1.Shift(saturday => saturday, sunday => sunday.AddDays(1));

            //    var lunarNewYear2 = lunarNewYear1.AddDays(+1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            //    var lunarNewYear3 = lunarNewYear1.AddDays(-1).Shift(saturday => saturday, sunday => sunday.AddDays(-1));

            //    var buddhaBday = koreanCalendar.ToDateTime(year, this.MoveMonth(4, leapMonth), 8, 0, 0, 0, 0);

            //    var chuseok1 = koreanCalendar.ToDateTime(year, this.MoveMonth(8, leapMonth), 14, 0, 0, 0, 0); //Has substitute holiday
            //    chuseok1 = chuseok1.Shift(saturday => saturday, sunday => sunday.AddDays(1));
            //    var chuseok2 = chuseok1.AddDays(+1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            //    var chuseok3 = chuseok2.AddDays(+1).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            //    items.Add(new Holiday(lunarNewYear1, "설날", "Lunar New Year", countryCode));
            //    items.Add(new Holiday(lunarNewYear2, "설날", "Lunar New Year", countryCode));
            //    items.Add(new Holiday(lunarNewYear3, "설날", "Lunar New Year", countryCode));
            //    items.Add(new Holiday(buddhaBday, "부처님 오신 날", "Buddha's Birthday", countryCode));
            //    items.Add(new Holiday(chuseok1, "추석", "Chuseok", countryCode));
            //    items.Add(new Holiday(chuseok2, "추석", "Chuseok", countryCode));
            //    items.Add(new Holiday(chuseok3, "추석", "Chuseok", countryCode));
            //}

            //items.Add(new Holiday(year, 1, 1, "새해", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 3, 1, "3·1절", "Independence Movement Day", countryCode));
            //items.Add(new Holiday(childrenDay, "어린이날", "Children's Day", countryCode)); //Has substitute holiday
            //items.Add(new Holiday(year, 6, 6, "현충일", "Memorial Day", countryCode));
            //items.Add(new Holiday(year, 8, 15, "광복절", "Liberation Day", countryCode));
            //items.Add(new Holiday(year, 10, 3, "개천절", "National Foundation Day", countryCode));
            //items.Add(new Holiday(year, 10, 9, "한글날", "Hangul Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "크리스마스", "Christmas Day", countryCode));

            //return items.OrderBy(o => o.Date);
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

        /// <inheritdoc/>
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
