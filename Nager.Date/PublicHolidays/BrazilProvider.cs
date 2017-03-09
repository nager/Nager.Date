using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class BrazilProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(int year)
        {
            //Brazil
            //https://en.wikipedia.org/wiki/Public_holidays_in_Brazil
            //Contribution: github.com/mauricioribeiro

            var countryCode = CountryCode.BR;
            var items = new List<PublicHoliday>();
            
            // official holidays
            items.Add(new PublicHoliday(year, 1, 1, "Confraternização Universal", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 21, "Dia de Tiradentes", "Tiradentes", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 7, "Dia da Independência", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Nossa Senhora Aparecida", "Children's Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Dia de Finados", "Day of the Dead", countryCode));
            items.Add(new PublicHoliday(year, 11, 15, "Proclamação da República", "Republic Proclamation Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode, null));
            
            // TODO non-official holidays
            
            return items.OrderBy(o => o.Date);
        }
    }
}
