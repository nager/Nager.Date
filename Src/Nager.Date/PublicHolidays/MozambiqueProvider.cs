using Nager.Date.Contract;
using Nager.Date.Model;
using Nager.Date.Weekends;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class MozambiqueProvider : IOffDaysProvider, ICountyProvider
    {
        //https://en.wikipedia.org/wiki/Workweek_and_weekend#Around_the_world
        private readonly IWeekendProvider weekendProvider = new UniversalWeekendProvider();

        public IEnumerable<PublicHoliday> Get(int year)
        {
            //Mozambique
            //https://en.wikipedia.org/wiki/Public_holidays_in_Mozambique

            var countryCode = CountryCode.MZ;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Dia de Ano Novo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 3, "Dia do Heroi Nacional", "Heroes's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 7, "Dia da Mulher", "Women's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "worker's Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 25, "Dia da Independência", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 7, "Dia da Victória", "Victory Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 25, "Dia da Revolução", "Revolution Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 4, "Dia da Paz e da Reconcialição", "Day of Peace and Reconciliation", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        public IDictionary<string, string> GetCounties()
        {
            //List of Provinces
            //https://en.wikipedia.org/wiki/Provinces_of_Mozambique
            return new Dictionary<string, string>
            {
                { "MZ-CD","Cabo Delgado" },
                { "MZ-GZ", "Gaza" },
                { "MZ-IH", "Inhambane" },
                { "MZ-MA", "Manica" },
                { "MZ-MP", "Maputo Cidade" },
                { "MZ-MT", "Maputo" },
                { "MZ-NA", "Nampula" },
                { "MZ-NI", "Niassa" },
                { "MZ-SO", "Sofala" },
                { "MZ-TE", "Tete" },
                { "MZ-ZA", "Zambezia" }
            };
        }

        public bool IsWeekend(DateTime date) =>
            weekendProvider.IsWeekend(date);
    }
}
