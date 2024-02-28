using Nager.Date.Models;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mozambique
    /// </summary>
    internal class MozambiqueProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        /// <summary>
        /// MozambiqueProvider
        /// </summary>
        public MozambiqueProvider()
        {
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
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
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MZ;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Dia de Ano Novo", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 2, 3, "Dia do Heroi Nacional", "Heroes's Day", countryCode));
            items.Add(new Holiday(year, 4, 7, "Dia da Mulher", "Women's Day", countryCode));
            items.Add(new Holiday(year, 5, 1, "Dia do Trabalhador", "worker's Day", countryCode));
            items.Add(new Holiday(year, 6, 25, "Dia da Independência", "Independence Day", countryCode));
            items.Add(new Holiday(year, 9, 7, "Dia da Victória", "Victory Day", countryCode));
            items.Add(new Holiday(year, 9, 25, "Dia da Revolução", "Revolution Day", countryCode));
            items.Add(new Holiday(year, 10, 4, "Dia da Paz e da Reconcialição", "Day of Peace and Reconciliation", countryCode));
            items.Add(new Holiday(year, 12, 25, "Natal", "Christmas Day", countryCode));

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
