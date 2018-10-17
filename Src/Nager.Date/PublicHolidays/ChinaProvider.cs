using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class ChinaProvider : IOffDaysProvider
    {
        private readonly IWeekendProvider _weekendProvider;

        public ChinaProvider(IWeekendProvider weekendProvider)
        {
            _weekendProvider = weekendProvider ?? throw new ArgumentNullException(nameof(weekendProvider));
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            //TODO: Provider incomplete
            //Tomb-Sweeping-Day is invalid (5th solar term)

            //China
            //https://en.wikipedia.org/wiki/Public_holidays_in_China

            var countryCode = CountryCode.CN;
            var items = new List<PublicHoliday>();

            if (year > 1901 && year < 2100)
            {
                //LunisolarCalendar .net implementation only valid are between 1901 and 2100, inclusive.
                //https://github.com/dotnet/coreclr/blob/master/src/mscorlib/shared/System/Globalization/ChineseLunisolarCalendar.cs
                var chineseCalendar = new ChineseLunisolarCalendar();
                var leapMonth = chineseCalendar.GetLeapMonth(year);
                var springFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(1, leapMonth), 1, 0, 0, 0, 0);
                var dragonBoatFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(5, leapMonth), 5, 0, 0, 0, 0);
                var midAutumnFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(8, leapMonth), 15, 0, 0, 0, 0);

                items.Add(new PublicHoliday(springFestival, "春节", "Chinese New Year (Spring Festival)", countryCode));
                items.Add(new PublicHoliday(dragonBoatFestival, "端午节", "Dragon Boat Festival", countryCode));
                items.Add(new PublicHoliday(midAutumnFestival, "中秋节", "Mid-Autumn Festival", countryCode));
            }

            items.Add(new PublicHoliday(year, 1, 1, "元旦", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 5, "清明节", "Qingming Festival (Tomb-Sweeping Day)", countryCode)); //TODO: Date is not fixed, calculate from 5th solar term
            items.Add(new PublicHoliday(year, 5, 1, "劳动节", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 1, "国庆节", "National Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        public bool IsWeekend(DateTime date) =>
            _weekendProvider.IsWeekend(date);

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
    }
}
