using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;

namespace Nager.Date.PublicHolidays
{
    class AngolaProvider : CatholicBaseProvider, ICountyProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.AO;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            //According to Angola Laws hollidays at sunday must be passed to the following monday
            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var uprisingDay = new DateTime(year, 2, 4).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var womensDay = new DateTime(year, 3, 8).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var peaceDay = new DateTime(year, 4, 4).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var workersDay = new DateTime(year, 5, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var foundersDay = new DateTime(year, 9, 17).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var dayOfTheDeaths = new DateTime(year, 11, 2).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var independenceDay = new DateTime(year, 11, 11).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var christmasDay = new DateTime(year, 12, 256).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            items.Add(new PublicHoliday(newYearsDay, "Dia de Ano Novo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(uprisingDay, "Dia do Ínicio da Luta Armando", "Day of the Uprising", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnaval", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Sexta-feira Santa", "Good Friday", countryCode));
            items.Add(new PublicHoliday(womensDay, "Dia Internacional da Mulher", "Women's Day", countryCode));
            items.Add(new PublicHoliday(peaceDay, "Dia da Paz", "Peace Day", countryCode));
            items.Add(new PublicHoliday(workersDay, "Dia do Trabalhador", "Worker's Day", countryCode));
            items.Add(new PublicHoliday(foundersDay, "Dia do Fundador da Nação e do Herói Nacional", "Agostinho Neto Day", countryCode));
            items.Add(new PublicHoliday(dayOfTheDeaths, "Dia dos Finados", "Day of the Deaths", countryCode));
            items.Add(new PublicHoliday(independenceDay, "Dia da Independência Nacional ", "Independence Day", countryCode));
            items.Add(new PublicHoliday(christmasDay, "Natal", "Christmas Day", countryCode, null));

            return items.OrderBy(o => o.Date);
        }

        public IDictionary<string, string> GetCounties()
        {
            //List of provinces
            //https://pt.wikipedia.org/wiki/Prov%C3%ADncias_de_Angola
            return new Dictionary<string, string>
            {
                { "AO-BO","Bengo" },
                { "AO-BG", "Benguela" },
                { "AO-BI", "Bié" },
                { "AO-CA", "Cabinda" },
                { "AO-CU", "Cuando Cubango" },
                { "AO-KN", "Kwanza Norte" },
                { "AO-KS", "Kwanza Sul" },
                { "AO-CN", "Cunene" },
                { "AO-HU", "Huambo" },
                { "AO-HA", "Huíla" },
                { "AO-LD", "Luanda" },
                { "AO-LN", "Lunda Norte" },
                { "AO-LS", "Lunda Sul" },
                { "AO-MJ", "Malanje" },
                { "AO-MO", "Moxico" },
                { "AO-NA", "Namibe" },
                { "AO-UI", "Uíge" },
                { "AO-ZA", "Zaire" }
            };
        }
    }
}
