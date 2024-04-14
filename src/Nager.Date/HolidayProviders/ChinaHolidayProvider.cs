using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// China HolidayProvider
    /// </summary>
    internal sealed class ChinaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// China HolidayProvider
        /// </summary>
        public ChinaHolidayProvider() : base(CountryCode.CN)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO: Provider incomplete
            //Tomb-Sweeping-Day is invalid (5th solar term)

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "元旦",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 5),
                    EnglishName = "Qingming Festival (Tomb-Sweeping Day)",
                    LocalName = "清明节",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "劳动节",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "National Day",
                    LocalName = "国庆节",
                    HolidayTypes = HolidayTypes.Public
                },
            };

            var chineseCalendar = new ChineseLunisolarCalendar();
            if (year > chineseCalendar.MinSupportedDateTime.Year && year < chineseCalendar.MaxSupportedDateTime.Year)
            {
                //LunisolarCalendar .net implementation only valid are between 1901 and 2100, inclusive.
                //https://github.com/dotnet/coreclr/blob/master/src/mscorlib/shared/System/Globalization/ChineseLunisolarCalendar.cs

                var leapMonth = chineseCalendar.GetLeapMonth(year);
                var springFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(1, leapMonth), 1, 0, 0, 0, 0);
                var dragonBoatFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(5, leapMonth), 5, 0, 0, 0, 0);
                var midAutumnFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(8, leapMonth), 15, 0, 0, 0, 0);

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = springFestival,
                    EnglishName = "Chinese New Year (Spring Festival)",
                    LocalName = "春节",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = dragonBoatFestival,
                    EnglishName = "Dragon Boat Festival",
                    LocalName = "端午节",
                    HolidayTypes = HolidayTypes.Public
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = midAutumnFestival,
                    EnglishName = "Mid-Autumn Festival",
                    LocalName = "中秋节",
                    HolidayTypes = HolidayTypes.Public
                });
            }

            return holidaySpecifications;
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_China",
            ];
        }
    }
}
