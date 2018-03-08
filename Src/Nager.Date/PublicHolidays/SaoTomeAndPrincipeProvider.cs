using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.PublicHolidays
{
    public class SaoTomeAndPrincipeProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //São Tomé e Principe
            //Goverment Page
            //http://www.mnec.gov.st/index.php/o-pais?showall=1
            //Comunity Of Portguguese Speaking Countries
            //https://www.cplp.org/id-2993.aspx
            var countryCode = CountryCode.ST;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Dia de Ano Novo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 4, "Dia Rei Amador", "King's Amador Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 17, "Dia da Descoberta da Ilha do Príncipe", "Principe Island Discovery Day", countryCode, null, new string[] { "ST-P" }));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Worker's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 3, "Dia dos Mártires", "Martyr's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 29, "Dia da Autonomia", "Autonomy Day", countryCode, null, new string[] { "ST-P" }));
            items.Add(new PublicHoliday(year, 7, 12, "Dia da Independência", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Dia de São Lourenço", "Saint Lourence Day", countryCode, null, new string[] { "ST-P" }));
            items.Add(new PublicHoliday(year, 9, 6, "Dia das Forças Armadas", "Armed Forces Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 30, "Dia da Reforma Agrária", "Agriculture Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 21, "Dia de Descoberta da Ilha de São Tomé", "São Tomé Island Discovery Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode, null));

            return items.OrderBy(o => o.Date);
        }
    }
}
