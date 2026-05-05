using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// South Korea HolidayProvider
    /// </summary>
    internal sealed class SouthKoreaHolidayProvider : AbstractHolidayProvider
    {
        public SouthKoreaHolidayProvider() : base(CountryCode.KR)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var weekendObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "새해",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHILDRENSDAY-01",
                    Date = new DateTime(year, 5, 5),
                    EnglishName = "Children's Day",
                    LocalName = "어린이날",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "MEMORIALDAY-01",
                    Date = new DateTime(year, 6, 6),
                    EnglishName = "Memorial Day",
                    LocalName = "현충일",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "크리스마스",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            holidaySpecifications.AddIfNotNull(this.LabourDay(year, weekendObservedRuleSet));
            holidaySpecifications.AddIfNotNull(this.ConstitutionDay(year, weekendObservedRuleSet));
            holidaySpecifications.AddIfNotNull(this.IndependenceMovementDay(year, weekendObservedRuleSet));
            holidaySpecifications.AddIfNotNull(this.LiberationDay(year, weekendObservedRuleSet));
            holidaySpecifications.AddIfNotNull(this.NationalFoundationDay(year, weekendObservedRuleSet));
            holidaySpecifications.AddIfNotNull(this.HangulDay(year, weekendObservedRuleSet));
            holidaySpecifications.AddRangeIfNotNull(this.GetKoreanLunisolarHolidays(year));

            return holidaySpecifications;
        }

        private HolidaySpecification IndependenceMovementDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            var holidayObservedRuleSet = observedRuleSet;

            if (year < 2022)
            {
                holidayObservedRuleSet = null;
            }

            return new HolidaySpecification
            {
                Id = "INDEPENDENCEMOVEMENTDAY-01",
                Date = new DateTime(year, 3, 1),
                EnglishName = "Independence Movement Day",
                LocalName = "3·1절",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = holidayObservedRuleSet
            };
        }

        private HolidaySpecification LiberationDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            var holidayObservedRuleSet = observedRuleSet;

            if (year < 2022)
            {
                holidayObservedRuleSet = null;
            }

            return new HolidaySpecification
            {
                Id = "LIBERATIONDAY-01",
                Date = new DateTime(year, 8, 15),
                EnglishName = "Liberation Day",
                LocalName = "광복절",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = holidayObservedRuleSet
            };
        }

        private HolidaySpecification NationalFoundationDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            var holidayObservedRuleSet = observedRuleSet;

            if (year < 2022)
            {
                holidayObservedRuleSet = null;
            }

            return new HolidaySpecification
            {
                Id = "NATIONALFOUNDATIONDAY-01",
                Date = new DateTime(year, 10, 3),
                EnglishName = "National Foundation Day",
                LocalName = "개천절",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = holidayObservedRuleSet
            };
        }

        private HolidaySpecification HangulDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            var holidayObservedRuleSet = observedRuleSet;

            if (year < 2022)
            {
                holidayObservedRuleSet = null;
            }

            return new HolidaySpecification
            {
                Id = "HANGULDAY-01",
                Date = new DateTime(year, 10, 9),
                EnglishName = "Hangul Day",
                LocalName = "한글날",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = holidayObservedRuleSet
            };
        }

        private HolidaySpecification? LabourDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            if (year < 2026)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "LABOURDAY-01",
                Date = new DateTime(year, 5, 1),
                EnglishName = "Labour Day",
                LocalName = "노동절",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }

        private HolidaySpecification ConstitutionDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            var holidayTypes = HolidayTypes.Public;

            if (year >= 2008 && year < 2026)
            {
                holidayTypes = HolidayTypes.Observance;
            }

            return new HolidaySpecification
            {
                Id = "CONSTITUTIONDAY-01",
                Date = new DateTime(year, 7, 17),
                EnglishName = "Constitution Day",
                LocalName = "제헌절",
                HolidayTypes = holidayTypes,
                ObservedRuleSet = observedRuleSet
            };
        }

        private HolidaySpecification[] GetKoreanLunisolarHolidays(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>();

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
                    Id = "LUNARNEWYEAR-01",
                    Date = lunarNewYear1,
                    EnglishName = "Lunar New Year",
                    LocalName = "설날",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "LUNARNEWYEAR-02",
                    Date = lunarNewYear2,
                    EnglishName = "Lunar New Year",
                    LocalName = "설날",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "LUNARNEWYEAR-03",
                    Date = lunarNewYear3,
                    EnglishName = "Lunar New Year",
                    LocalName = "설날",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "BUDDHASBIRTHDAY-01",
                    Date = buddhaBday,
                    EnglishName = "Buddha's Birthday",
                    LocalName = "부처님 오신 날",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "CHUSEOK-01",
                    Date = chuseok1,
                    EnglishName = "Chuseok",
                    LocalName = "추석",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "CHUSEOK-02",
                    Date = chuseok2,
                    EnglishName = "Chuseok",
                    LocalName = "추석",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "CHUSEOK-03",
                    Date = chuseok3,
                    EnglishName = "Chuseok",
                    LocalName = "추석",
                    HolidayTypes = HolidayTypes.Public
                });
            }

            return [.. holidaySpecifications];
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
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_South_Korea", //South Korea's public holidays
                "https://www.koreanlaborlaw.com/substitute-holiday-system-of-korea/", //Substitute holiday system of Korea
                "https://www.law.go.kr/lsInfoP.do?lsiSeq=233829#0000"
            ];
        }
    }
}
