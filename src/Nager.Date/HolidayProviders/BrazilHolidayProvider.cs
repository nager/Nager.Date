using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Brazil HolidayProvider
    /// </summary>
    internal sealed class BrazilHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Brazil HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BrazilHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.BR)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Confraternização Universal",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 21),
                    EnglishName = "Tiradentes",
                    LocalName = "Dia de Tiradentes",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Dia do Trabalhador",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 9),
                    EnglishName = "Constitutionalist Revolution of 1932",
                    LocalName = "Revolução Constitucionalista de 1932",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BR-SP"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 7),
                    EnglishName = "Independence Day",
                    LocalName = "Dia da Independência",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Our Lady of Aparecida",
                    LocalName = "Nossa Senhora Aparecida",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "All Souls' Day",
                    LocalName = "Dia de Finados",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 15),
                    EnglishName = "Republic Proclamation Day",
                    LocalName = "Proclamação da República",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Natal",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-47),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.Optional
                },
                this._catholicProvider.EasterSunday("Domingo de Páscoa", year),
                this._catholicProvider.GoodFriday("Sexta-feira Santa", year),
                this._catholicProvider.CorpusChristi("Corpus Christi", year),
            };

            holidaySpecifications.AddIfNotNull(this.BlackAwarenessDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? BlackAwarenessDay(int year)
        {
            if (year >= 2024)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 20),
                    EnglishName = "Black Awareness Day",
                    LocalName = "Dia da Consciência Negra",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Brazil",
                "https://pt.wikipedia.org/wiki/Feriados_no_Brasil"
            ];
        }
    }
}
