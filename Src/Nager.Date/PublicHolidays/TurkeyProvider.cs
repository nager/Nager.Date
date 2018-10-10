using Nager.Date.Contract;
using Nager.Date.Model;
using Nager.Date.Weekends;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class TurkeyProvider : IOffDaysProvider
    {
        //https://en.wikipedia.org/wiki/Workweek_and_weekend#Around_the_world
        private readonly IWeekendProvider weekendProvider = new UniversalWeekendProvider();

        public IEnumerable<PublicHoliday> Get(int year)
        {
            //Turkey
            //https://en.wikipedia.org/wiki/Public_holidays_in_Turkey

            var countryCode = CountryCode.TR;

            var items = new List<PublicHoliday>();

            items.Add(new PublicHoliday(year, 1, 1, "Yılbaşı", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 23, "Ulusal Egemenlik ve Çocuk Bayramı", "National Independence & Children's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "İşçi Bayramı", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 19, "Atatürk'ü Anma, Gençlik ve Spor Bayramı", "Atatürk Commemoration & Youth Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 15, "Demokrasi Bayramı", "Democracy Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 30, "Zafer Bayramı", "Victory Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 29, "Cumhuriyet Bayramı", "Republic Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        public bool IsWeekend(DateTime date) =>
            weekendProvider.IsWeekend(date);
    }
}
