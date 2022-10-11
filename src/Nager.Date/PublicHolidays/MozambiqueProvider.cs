using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Mozambique
    /// </summary>
    internal class MozambiqueProvider : IPublicHolidayProvider, ICountyProvider
    {
        /// <summary>
        /// MozambiqueProvider
        /// </summary>
        public MozambiqueProvider()
        {
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetCounties()
        {
            //List of Provinces https://en.wikipedia.org/wiki/Provinces_of_Mozambique

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

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
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

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mozambique"
            };
        }
    }
}
