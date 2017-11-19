using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class SurinameProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Suriname
            //https://en.wikipedia.org/wiki/Suriname#National_holidays

            var countryCode = CountryCode.SR;
            var easterSunday = base.EasterSunday(year);

            var thirdSundayInJanuary = DateSystem.FindDay(year, 1, DayOfWeek.Sunday, 1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Three Kings Day", "Three Kings Day", countryCode));
            items.Add(new PublicHoliday(thirdSundayInJanuary, "World Religion Day", "World Religion Day", countryCode));
            //TODO:Chinese New Year
            items.Add(new PublicHoliday(year, 2, 25, "Day of the Revolution", "Day of the Revolution", countryCode));
            //TODO:Holi
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Easter", "Easter", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Ascension Day", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 5, "Indian Arrival Day", "Indian Arrival Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 1, "Keti Koti", "Keti Koti", countryCode));
            items.Add(new PublicHoliday(year, 8, 8, "Javanese Arrival Day", "Javanese Arrival Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 9, "Indigenous People's Day", "Indigenous People's Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 10, "Day of the Maroons", "Day of the Maroons", countryCode));
            items.Add(new PublicHoliday(year, 10, 20, "Chinese Arrival day", "Chinese Arrival day", countryCode));
            //TODO:Largest festival of Hindus
            items.Add(new PublicHoliday(year, 11, 25, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode));
            return items.OrderBy(o => o.Date);
        }
    }
}
