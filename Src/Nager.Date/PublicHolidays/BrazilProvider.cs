using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class BrazilProvider : CatholicBaseProvider
    {
        public BrazilProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Brazil
            //https://en.wikipedia.org/wiki/Public_holidays_in_Brazil
            //https://pt.wikipedia.org/wiki/Feriados_no_Brasil brazilian wikipedia is complete.
            //Contribution: github.com/mauricioribeiro

            var countryCode = CountryCode.BR;
            var items = new List<PublicHoliday>();

            // official holidays (fixed dates)
            items.Add(new PublicHoliday(year, 1, 1, "Confraternização Universal", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 21, "Dia de Tiradentes", "Tiradentes", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 7, "Dia da Independência", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Nossa Senhora Aparecida", "Children's Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Dia de Finados", "Day of the Dead", countryCode));
            items.Add(new PublicHoliday(year, 11, 15, "Proclamação da República", "Republic Proclamation Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode));

            // non fixed days (Easter, Carnival, Passion of Jesus and Corpus Christi)
            var easter = base.EasterSunday(year);
            items.Add(new PublicHoliday(easter, "Domingo de Pascoa", "Easter Day", countryCode));
            items.Add(new PublicHoliday(easter.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easter.AddDays(-2), "Sexta feira Santa", "Passion of Jesus", countryCode));
            items.Add(new PublicHoliday(easter.AddDays(60), "Corpus Christi", "Corpus Christi", countryCode));
            // TODO non-official holidays

            return items.OrderBy(o => o.Date);
        }
    }
}