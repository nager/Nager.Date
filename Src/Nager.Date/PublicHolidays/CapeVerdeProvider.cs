using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.PublicHolidays
{
    public class CapeVerdeProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.CV;
            var easterSunday = base.EasterSunday(year);

            //Cape Verde Nacional Bank
            //http://www.bcv.cv/vPT/SistemadePagamentos/feriados_bancarios/Paginas/FeriadosBancarios.aspx
            //WikiTraveel
            //https://wikitravel.org/pt/Cabo_Verde
            //CPLP
            //https://www.cplp.org/id-2976.aspx

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Dia de Ano Novo", "New Year's Day", countryCode));

            items.Add(new PublicHoliday(year, 1, 13, "Dia da Democracia", "Democracy Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 20, "Dia do Héroi Nacional", "National Heroes Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-46), "Quarta-feira de Cinzas", "Ash Wednesday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Sexta-feira Santa", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Domingo de Páscoa", "Easter Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 19, "Dia do Município da Praia ", "Praia Municipal Holliday (Capital)", countryCode,null,new string[] { "Praia" }));
            items.Add(new PublicHoliday(year, 6, 1, "Dia da Criança", "Childrens Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 5, "Dia da Independência", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Assunção de Nossa Senhora", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Dia de Todos-os-Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode, null));

            return items.OrderBy(o => o.Date);
        }
    }
}
