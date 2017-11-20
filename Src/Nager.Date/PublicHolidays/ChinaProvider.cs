using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class ChinaProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(int year)
        {
            //TODO: Provider incomplete
            //Tomb-Sweeping-Day is invalid (5th solar term)
            //Mid-Autumn Festival is invalid for 2017

            //China
            //https://en.wikipedia.org/wiki/Public_holidays_in_China

            var countryCode = CountryCode.CN;
            var items = new List<PublicHoliday>();

            var chineseCalendar = new ChineseLunisolarCalendar();
            var springFestival = chineseCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);
            var tombSweepimgDay = chineseCalendar.ToDateTime(year, 5, 1, 0, 0, 0, 0);
            var dragonBoatFestival = chineseCalendar.ToDateTime(year, 5, 5, 0, 0, 0, 0);
            var midAutumnFestival = chineseCalendar.ToDateTime(year, 8, 15, 0, 0, 0, 0);

            items.Add(new PublicHoliday(year, 1, 1, "元旦", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(springFestival, "春节", "Spring Festival", countryCode));
            //items.Add(new PublicHoliday(tombSweepimgDay, "清明节", "Tomb-Sweeping Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "劳动节", "Labour Day", countryCode));
            items.Add(new PublicHoliday(dragonBoatFestival, "端午节", "Dragon Boat Festival", countryCode));
            //items.Add(new PublicHoliday(midAutumnFestival, "中秋节", "Mid-Autumn Festival", countryCode));
            items.Add(new PublicHoliday(year, 10, 1, "国庆节", "National Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
