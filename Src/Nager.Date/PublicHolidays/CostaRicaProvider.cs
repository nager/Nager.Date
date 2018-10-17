using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class CostaRicaProvider : CatholicBaseProvider
    {
        public CostaRicaProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Costa Rica
            //https://en.wikipedia.org/wiki/Public_holidays_in_Costa_Rica

            var countryCode = CountryCode.CR;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 11, "Juan Santa maria Day", "Juan Santa maria Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Good Thursday", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labor Day", "Labor Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 25, "Guanacaste Day", "Guanacaste Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 2, "Virgin of Los Angeles Day", "Virgin of Los Angeles Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Mother´s Day", "Mother´s Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 15, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Cultures National Day", "Cultures National Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
