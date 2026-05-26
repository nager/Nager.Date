using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Hong Kong HolidayProvider
    /// </summary>
    internal sealed class HongKongHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Hong Kong HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public HongKongHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.HK)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "元旦新年",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "勞動節",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "SPECIALADMINISTRATIVEREGION-01",
                    Date = new DateTime(year, 7, 1),
                    EnglishName = "Hong Kong Special Administrative Region Establishment Day",
                    LocalName = "香港特別行政區成立紀念日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY-01",
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "National Day",
                    LocalName = "中華人民共和國國慶日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "聖誕節",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "BOXINGDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "聖誕節翌日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                }
            };

            holidaySpecifications.AddRange(this.GetChineseLunisolarHolidaysAndCatholic(year));

            return holidaySpecifications;
        }

        private HolidaySpecification[] GetChineseLunisolarHolidaysAndCatholic(int year)
        {
            var goodFriday = this._catholicProvider.GoodFriday("耶穌受難節", year);
            var easterSaturday = this._catholicProvider.EasterSaturday("耶穌受難節翌日", year); //The day following Good Friday

            var holidaySpecifications = new List<HolidaySpecification>
            {
                goodFriday,
                easterSaturday
            };

            DateTime? chingMingFestivalDate = null;
            var chineseCalendar = new ChineseLunisolarCalendar();
            if (year > chineseCalendar.MinSupportedDateTime.Year && year < chineseCalendar.MaxSupportedDateTime.Year)
            {
                var observedRuleSet1 = new ObservedRuleSet
                {
                    Sunday = date => date.AddDays(1)
                };

                var observedRuleSet2 = new ObservedRuleSet
                {
                    Sunday = date => date.AddDays(1),
                    Monday = date => date.AddDays(1)
                };

                var observedRuleSet3 = new ObservedRuleSet
                {
                    Sunday = date => date.AddDays(1),
                    Monday = date => date.AddDays(1),
                    Tuesday = date => date.AddDays(1)
                };

                //LunisolarCalendar .net implementation only valid are between 1901 and 2100, inclusive.
                //https://github.com/dotnet/coreclr/blob/master/src/mscorlib/shared/System/Globalization/ChineseLunisolarCalendar.cs

                var leapMonth = chineseCalendar.GetLeapMonth(year);
                var lunarNewYearDay = chineseCalendar.ToDateTime(year, this.MoveMonth(1, leapMonth), 1, 0, 0, 0, 0);
                var secondLunarNewYearDay = chineseCalendar.ToDateTime(year, this.MoveMonth(1, leapMonth), 2, 0, 0, 0, 0);
                var thirdLunarNewYearDay = chineseCalendar.ToDateTime(year, this.MoveMonth(1, leapMonth), 3, 0, 0, 0, 0);
                var buddhasBirthdayDay = chineseCalendar.ToDateTime(year, this.MoveMonth(4, leapMonth), 8, 0, 0, 0, 0);
                var dragonBoatFestivalDay = chineseCalendar.ToDateTime(year, this.MoveMonth(5, leapMonth), 5, 0, 0, 0, 0);
                var followingTheMidAutumnFestivalDay = chineseCalendar.ToDateTime(year, this.MoveMonth(8, leapMonth), 16, 0, 0, 0, 0);
                var chungYeungFestivalDay = chineseCalendar.ToDateTime(year, this.MoveMonth(9, leapMonth), 9, 0, 0, 0, 0);

                chingMingFestivalDate = new DateTime(year, 4, 5);
                if (leapMonth != 4)
                {
                    chingMingFestivalDate = chingMingFestivalDate.Value.AddDays(-1);
                }

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "LUNARNEWYEAR-01",
                    Date = lunarNewYearDay,
                    EnglishName = "Lunar New Year",
                    LocalName = "農曆年初一",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "LUNARNEWYEAR-02",
                    Date = secondLunarNewYearDay,
                    EnglishName = "Second day of Lunar New Year",
                    LocalName = "農曆年初二",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet2
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "LUNARNEWYEAR-03",
                    Date = thirdLunarNewYearDay,
                    EnglishName = "Third day of Lunar New Year",
                    LocalName = "農曆年初三",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet3
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "BUDDHASBIRTHDAY-01",
                    Date = buddhasBirthdayDay,
                    EnglishName = "Buddha's Birthday",
                    LocalName = "佛誕",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "DRAGONBOATFESTIVAL-01",
                    Date = dragonBoatFestivalDay,
                    EnglishName = "Dragon Boat Festival",
                    LocalName = "端午節",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "DAYAFTERMIDAUTUMNFESTIVAL-01",
                    Date = followingTheMidAutumnFestivalDay,
                    EnglishName = "Day following the Mid-Autumn Festival",
                    LocalName = "中秋節翌日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "CHUNGYEUNGFESTIVAL-01",
                    Date = chungYeungFestivalDay,
                    EnglishName = "Chung Yeung Festival",
                    LocalName = "重陽節",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                });

                var observedRuleSetChingMingFestival = new ObservedRuleSet
                {
                    Sunday = date => date.AddDays(1),
                };

                if (easterSaturday.Date == chingMingFestivalDate)
                {
                    observedRuleSetChingMingFestival.Saturday = date => date.AddDays(2);
                }

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "CHINGMINGFESTIVAL-01",
                    Date = chingMingFestivalDate.Value,
                    EnglishName = "Ching Ming Festival",
                    LocalName = "清明節",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSetChingMingFestival
                });
            }

            var easterMonday = this._catholicProvider.EasterMonday("復活節星期一", year);

            // The Qingming Festival falls on a fairly fixed date,
            // but Easter Sunday shifts from year to year;
            // if the Qingming Festival takes place on the same weekend,
            // the holidays must be adjusted.
            if (chingMingFestivalDate.HasValue &&
                (
                    easterSaturday.Date == chingMingFestivalDate ||
                    chingMingFestivalDate.Value.DayOfWeek == DayOfWeek.Sunday && chingMingFestivalDate.Value.Date.AddDays(1) == easterMonday.Date)
                )
            {
                //The day following Easter Monday / 復活節星期一翌日
                easterMonday.ObservedRuleSet = new ObservedRuleSet { Monday = date => date.AddDays(1) };
            }

            holidaySpecifications.Add(easterMonday);

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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Hong_Kong",
                "https://www.gov.hk/en/about/abouthk/holiday/2026.htm",
            ];
        }
    }
}
