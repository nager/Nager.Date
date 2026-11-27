using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Taiwan HolidayProvider
    /// </summary>
    internal sealed class TaiwanHolidayProvider : AbstractHolidayProvider,
        IObservedRuleSetHolidayProvider
    {
        /// <summary>
        /// Taiwan HolidayProvider
        /// </summary>
        public TaiwanHolidayProvider() : base(CountryCode.TW)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var observedRuleSet = this.GetObservedRuleSet(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "中華民國開國紀念日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "PEACEMEMORIALDAY-01",
                    Date = new DateTime(year, 2, 28),
                    EnglishName = "Peace Memorial Day",
                    LocalName = "和平紀念日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY-01",
                    Date = new DateTime(year, 10, 10),
                    EnglishName = "National Day",
                    LocalName = "國慶日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
            };

            holidaySpecifications.AddIfNotNull(this.LabourDay(year, observedRuleSet));
            holidaySpecifications.AddRangeIfNotNull(this.ChildrensDayAndTombSweepingDay(year));
            holidaySpecifications.AddRangeIfNotNull(this.LunisolarHolidays(year, observedRuleSet));
            holidaySpecifications.AddRangeIfNotNull(this.HolidaysSince2025(year, observedRuleSet));

            return holidaySpecifications;
        }

        /// <summary>
        /// A holiday on a Saturday is observed on the previous working day,
        /// a holiday on a Sunday on the next working day (since 2015)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private ObservedRuleSet? GetObservedRuleSet(int year)
        {
            if (year < 2015)
            {
                return null;
            }

            return new ObservedRuleSet
            {
                Saturday = date => date.AddDays(-1),
                Sunday = date => date.AddDays(1),
            };
        }

        private HolidaySpecification LabourDay(int year, ObservedRuleSet? observedRuleSet)
        {
            if (year < 2026)
            {
                // Until the 2025 act, a day off for workers only, not for government offices
                return new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "勞動節",
                    HolidayTypes = HolidayTypes.Optional,
                };
            }

            return new HolidaySpecification
            {
                Id = "LABOURDAY-01",
                Date = new DateTime(year, 5, 1),
                EnglishName = "Labour Day",
                LocalName = "勞動節",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet,
            };
        }

        /// <summary>
        /// Children's Day (since 2011) and Tomb-Sweeping Day
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private HolidaySpecification[] ChildrensDayAndTombSweepingDay(int year)
        {
            var tombSweepingDay = this.GetTombSweepingDay(year);
            if (tombSweepingDay is null)
            {
                return [];
            }

            var holidaySpecifications = new List<HolidaySpecification>();

            var tombSweepingDayObserved = tombSweepingDay.Value;

            if (year >= 2011)
            {
                var childrensDay = new DateTime(year, 4, 4);

                // If Children's Day and Tomb-Sweeping Day fall on the same day, the day off
                // for Children's Day is the day before, or the day after if it is a Thursday
                var childrensDayObserved = childrensDay;
                if (childrensDay == tombSweepingDay.Value)
                {
                    childrensDayObserved = childrensDay.DayOfWeek == DayOfWeek.Thursday
                        ? childrensDay.AddDays(1)
                        : childrensDay.AddDays(-1);
                }

                if (year >= 2015)
                {
                    if (childrensDayObserved.DayOfWeek == DayOfWeek.Saturday)
                    {
                        childrensDayObserved = childrensDayObserved.AddDays(-1);
                    }
                    else if (childrensDayObserved.DayOfWeek == DayOfWeek.Sunday)
                    {
                        childrensDayObserved = childrensDayObserved.AddDays(1);
                        if (childrensDayObserved == tombSweepingDay.Value)
                        {
                            childrensDayObserved = childrensDayObserved.AddDays(1);
                        }
                    }

                    if (tombSweepingDay.Value.DayOfWeek == DayOfWeek.Saturday)
                    {
                        tombSweepingDayObserved = tombSweepingDay.Value.AddDays(-1);
                        if (tombSweepingDayObserved == childrensDayObserved)
                        {
                            tombSweepingDayObserved = tombSweepingDayObserved.AddDays(-1);
                        }
                    }
                    else if (tombSweepingDay.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        tombSweepingDayObserved = tombSweepingDay.Value.AddDays(1);
                    }
                }

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "CHILDRENSDAY-01",
                    Date = childrensDay,
                    EnglishName = "Children's Day",
                    LocalName = "兒童節",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = this.ObservedOn(childrensDay, childrensDayObserved),
                });
            }

            holidaySpecifications.Add(new HolidaySpecification
            {
                Id = "TOMBSWEEPINGDAY-01",
                Date = tombSweepingDay.Value,
                EnglishName = "Tomb-Sweeping Day",
                LocalName = "清明節",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = this.ObservedOn(tombSweepingDay.Value, tombSweepingDayObserved),
            });

            return [.. holidaySpecifications];
        }

        /// <summary>
        /// Lunar New Year, Dragon Boat Festival and Mid-Autumn Festival
        /// </summary>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns></returns>
        private HolidaySpecification[] LunisolarHolidays(int year, ObservedRuleSet? observedRuleSet)
        {
            var chineseCalendar = new ChineseLunisolarCalendar();
            if (year <= chineseCalendar.MinSupportedDateTime.Year || year >= chineseCalendar.MaxSupportedDateTime.Year)
            {
                return [];
            }

            var leapMonth = chineseCalendar.GetLeapMonth(year);
            var lunarNewYearDay = chineseCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);
            var dragonBoatFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(5, leapMonth), 5, 0, 0, 0, 0);
            var midAutumnFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(8, leapMonth), 15, 0, 0, 0, 0);

            var lunarNewYearHoliday = new List<(string Id, DateTime Date, string EnglishName, string LocalName)>();

            // Since the 2025 act, the holiday starts on the day before Lunar New Year's Eve
            if (year >= 2026)
            {
                lunarNewYearHoliday.Add(("LUNARNEWYEAR-01", lunarNewYearDay.AddDays(-2), "Day before Lunar New Year's Eve", "小年夜"));
            }

            lunarNewYearHoliday.Add(("LUNARNEWYEAR-02", lunarNewYearDay.AddDays(-1), "Lunar New Year's Eve", "除夕"));
            lunarNewYearHoliday.Add(("LUNARNEWYEAR-03", lunarNewYearDay, "Lunar New Year", "春節"));
            lunarNewYearHoliday.Add(("LUNARNEWYEAR-04", lunarNewYearDay.AddDays(1), "Lunar New Year", "春節"));
            lunarNewYearHoliday.Add(("LUNARNEWYEAR-05", lunarNewYearDay.AddDays(2), "Lunar New Year", "春節"));

            // Days of the Lunar New Year holiday on a Saturday or Sunday are observed on
            // the working days after the holiday (since 2015)
            var nextWorkingDay = lunarNewYearHoliday.Last().Date.AddDays(1);

            var holidaySpecifications = new List<HolidaySpecification>();
            foreach (var day in lunarNewYearHoliday)
            {
                var observedDate = day.Date;
                if (year >= 2015 && this.IsWeekend(day.Date))
                {
                    while (this.IsWeekend(nextWorkingDay))
                    {
                        nextWorkingDay = nextWorkingDay.AddDays(1);
                    }

                    observedDate = nextWorkingDay;
                    nextWorkingDay = nextWorkingDay.AddDays(1);
                }

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = day.Id,
                    Date = day.Date,
                    EnglishName = day.EnglishName,
                    LocalName = day.LocalName,
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = this.ObservedOn(day.Date, observedDate),
                });
            }

            holidaySpecifications.Add(new HolidaySpecification
            {
                Id = "DRAGONBOATFESTIVAL-01",
                Date = dragonBoatFestival,
                EnglishName = "Dragon Boat Festival",
                LocalName = "端午節",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet,
            });
            holidaySpecifications.Add(new HolidaySpecification
            {
                Id = "MIDAUTUMNFESTIVAL-01",
                Date = midAutumnFestival,
                EnglishName = "Mid-Autumn Festival",
                LocalName = "中秋節",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet,
            });

            return [.. holidaySpecifications];
        }

        /// <summary>
        /// Days off added by the Commemoration Days and Holidays Implementation Act (2025-05-28)
        /// </summary>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns></returns>
        private HolidaySpecification[] HolidaysSince2025(int year, ObservedRuleSet? observedRuleSet)
        {
            if (year < 2025)
            {
                return [];
            }

            return
            [
                new HolidaySpecification
                {
                    Id = "TEACHERSDAY-01",
                    Date = new DateTime(year, 9, 28),
                    EnglishName = "Teachers' Day",
                    LocalName = "孔子誕辰紀念日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "RETROCESSIONDAY-01",
                    Date = new DateTime(year, 10, 25),
                    EnglishName = "Taiwan Retrocession Day",
                    LocalName = "臺灣光復暨金門古寧頭大捷紀念日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Constitution Day",
                    LocalName = "行憲紀念日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
            ];
        }

        /// <summary>
        /// Tomb-Sweeping Day is the day of the solar term Qingming (April 4 or 5).
        /// The day is calculated with the common solar term formula,
        /// which matches the astronomical dates from 1901 to 2100
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private DateTime? GetTombSweepingDay(int year)
        {
            if (year < 1901 || year > 2100)
            {
                return null;
            }

            var centuryStart = year <= 2000 ? 1900 : 2000;
            var constant = year <= 2000 ? 5.59 : 4.81;
            var yearInCentury = year - centuryStart;

            var leapYears = 0;
            for (var i = centuryStart + 1; i <= year; i++)
            {
                if (DateTime.IsLeapYear(i))
                {
                    leapYears++;
                }
            }

            var day = (int)Math.Floor(yearInCentury * 0.2422 + constant) - leapYears;
            return new DateTime(year, 4, day);
        }

        private ObservedRuleSet? ObservedOn(DateTime date, DateTime observedDate)
        {
            if (date == observedDate)
            {
                return null;
            }

            Func<DateTime, DateTime> observed = _ => observedDate;

            return date.DayOfWeek switch
            {
                DayOfWeek.Monday => new ObservedRuleSet { Monday = observed },
                DayOfWeek.Tuesday => new ObservedRuleSet { Tuesday = observed },
                DayOfWeek.Wednesday => new ObservedRuleSet { Wednesday = observed },
                DayOfWeek.Thursday => new ObservedRuleSet { Thursday = observed },
                DayOfWeek.Friday => new ObservedRuleSet { Friday = observed },
                DayOfWeek.Saturday => new ObservedRuleSet { Saturday = observed },
                _ => new ObservedRuleSet { Sunday = observed },
            };
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        private int MoveMonth(int month, int leapMonth)
        {
            if (leapMonth == 0)
            {
                return month;
            }

            if (leapMonth <= month)
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
                "https://law.moj.gov.tw/LawClass/LawAll.aspx?pcode=D0020095", // Commemoration Days and Holidays Implementation Act (since 2025-05-28)
                "https://law.moj.gov.tw/LawClass/LawAll.aspx?pcode=D0020033", // Regulations on the Implementation of Memorial Days and Holidays (repealed 2025-06-06)
                "https://data.gov.tw/dataset/14718", // Government office calendars of the DGPA
                "https://en.wikipedia.org/wiki/Public_holidays_in_Taiwan"
            ];
        }
    }
}
