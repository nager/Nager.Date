using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Portugal
    /// </summary>
    public class PortugalProvider : IPublicHolidayProvider, ICountyProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// PortugalProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PortugalProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// GetCounties
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "PT-01", "Aveiro" },
                { "PT-20", "Azoren" },
                { "PT-02", "Beja" },
                { "PT-03", "Braga" },
                { "PT-04", "Bragança" },
                { "PT-05", "Castelo Branco" },
                { "PT-06", "Coimbra" },
                { "PT-07", "Évora" },
                { "PT-08", "Faro" },
                { "PT-09", "Guarda" },
                { "PT-10", "Leiria" },
                { "PT-11", "Lissabon" },
                { "PT-30", "Madeira" },
                { "PT-12", "Portalegre" },
                { "PT-13", "Porto" },
                { "PT-14", "Santarém" },
                { "PT-15", "Setúbal" },
                { "PT-16", "Viana do Castelo" },
                { "PT-17", "Vila Real" },
                { "PT-18", "Viseu" },
            };
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.PT;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Ano Novo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Sexta-feira Santa", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Domingo de Páscoa", "Easter Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 25, "Dia da Liberdade", "Freedom Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Corpo de Deus", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(year, 6, 1, "Dia dos Açores", "Azores Day", countryCode, null, new string[] { "PT-20" }));
            items.Add(new PublicHoliday(year, 6, 10, "Dia de Portugal, de Camões e das Comunidades Portuguesas", "National Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 1, "Dia da Madeira", "Madeira Day", countryCode, null, new string[] { "PT-30" }));
            items.Add(new PublicHoliday(year, 8, 15, "Assunção de Nossa Senhora", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 5, "Implantação da República", "Republic Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Dia de Todos-os-Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 1, "Restauração da Independência", "Restoration of Independence", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Imaculada Conceição", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode, null));
            items.Add(new PublicHoliday(year, 12, 26, "Primeira Oitava", "St. Stephen's Day", countryCode, null, new string[] { "PT-30" }));

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Portugal",
                "https://de.wikipedia.org/wiki/ISO_3166-2:PT"
            };
        }
    }
}
