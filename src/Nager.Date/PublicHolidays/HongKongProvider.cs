using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Hong Kong
    /// </summary>
    public class HongKongProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// HongKongProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public HongKongProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.HK;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "元旦新年", "New Year's Day", countryCode));

            var chineseCalendar = new ChineseLunisolarCalendar();
            if (year > chineseCalendar.MinSupportedDateTime.Year && year < chineseCalendar.MaxSupportedDateTime.Year)
            {
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

                items.Add(new PublicHoliday(lunarNewYearDay, "農曆年初一", "Lunar New Year", countryCode));
                items.Add(new PublicHoliday(secondLunarNewYearDay, "農曆年初二", "Second day of Lunar New Year", countryCode));
                items.Add(new PublicHoliday(thirdLunarNewYearDay, "農曆年初三", "Third day of Lunar New Year", countryCode));

                items.Add(new PublicHoliday(buddhasBirthdayDay, "佛誕", "Buddha's Birthday", countryCode));
                items.Add(new PublicHoliday(dragonBoatFestivalDay, "端午節", "Dragon Boat Festival", countryCode));
                items.Add(new PublicHoliday(followingTheMidAutumnFestivalDay, "中秋節翌日", "Day following the Mid-Autumn Festival", countryCode));
                items.Add(new PublicHoliday(chungYeungFestivalDay, "重陽節", "Chung Yeung Festival", countryCode));

                var chingMingFestivalDate = new DateTime(year, 4, 5);
                if (leapMonth != 4)
                {
                    chingMingFestivalDate = chingMingFestivalDate.AddDays(-1);
                }
                items.Add(new PublicHoliday(chingMingFestivalDate, "清明節", "Ching Ming Festival", countryCode));
            }

            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "耶穌受難節", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "耶穌受難節翌日", "Holy Saturday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "復活節星期一", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "勞動節", "Labour Day", countryCode));

            items.Add(new PublicHoliday(year, 7, 1, "香港特別行政區成立紀念日", "Hong Kong Special Administrative Region Establishment Day", countryCode));

            items.Add(new PublicHoliday(year, 10, 1, "中華人民共和國國慶日", "National Day", countryCode));

            items.Add(new PublicHoliday(year, 12, 25, "聖誕節", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "聖誕節翌日", "Boxing Day", countryCode));

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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Hong_Kong",
            };
        }
    }
}
