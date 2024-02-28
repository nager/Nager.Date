using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Brazil
    /// </summary>
    internal class BrazilProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// BrazilProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BrazilProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "BR-AC", "Acre" },
                { "BR-AL", "Alagoas" },
                { "BR-AP", "Amapá" },
                { "BR-AM", "Amazonas" },
                { "BR-BA", "Bahia" },
                { "BR-CE", "Ceará" },
                { "BR-ES", "Espírito Santo" },
                { "BR-GO", "Goiás" },
                { "BR-MA", "Maranhão" },
                { "BR-MT", "Mato Grosso" },
                { "BR-MS", "Mato Grosso do Sul" },
                { "BR-MG", "Minas Gerais" },
                { "BR-PA", "Pará" },
                { "BR-PB", "Paraíba" },
                { "BR-PR", "Paraná" },
                { "BR-PE", "Pernambuco" },
                { "BR-PI", "Piauí" },
                { "BR-RJ", "Rio de Janeiro" },
                { "BR-RN", "Rio Grande do Norte" },
                { "BR-RS", "Rio Grande do Sul" },
                { "BR-RO", "Rondônia" },
                { "BR-RR", "Roraima" },
                { "BR-SC", "Santa Catarina" },
                { "BR-SP", "São Paulo" },
                { "BR-SE", "Sergipe" },
                { "BR-TO", "Tocantins" },
            };
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BR;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<Holiday>();

            items.Add(new Holiday(year, 1, 1, "Confraternização Universal", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 4, 21, "Dia de Tiradentes", "Tiradentes", countryCode));
            items.Add(new Holiday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new Holiday(year, 9, 7, "Dia da Independência", "Independence Day", countryCode));
            items.Add(new Holiday(year, 10, 12, "Nossa Senhora Aparecida", "Our Lady of Aparecida", countryCode));
            items.Add(new Holiday(year, 11, 2, "Dia de Finados", "All Souls' Day", countryCode));
            items.Add(new Holiday(year, 11, 15, "Proclamação da República", "Republic Proclamation Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Natal", "Christmas Day", countryCode));

            items.Add(this._catholicProvider.EasterSunday("Domingo de Páscoa", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Sexta-feira Santa", year, countryCode));
            items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode));

            items.Add(new Holiday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode, null, null, HolidayTypes.Bank | HolidayTypes.Optional));
            items.Add(new Holiday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode, null, null, HolidayTypes.Bank | HolidayTypes.Optional));

            items.Add(new Holiday(year, 7, 9, "Revolução Constitucionalista de 1932", "Constitutionalist Revolution of 1932", countryCode).SetCounties("BR-SP"));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Brazil",
                "https://pt.wikipedia.org/wiki/Feriados_no_Brasil"
            };
        }
    }
}
