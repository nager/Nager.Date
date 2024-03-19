using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Portugal HolidayProvider
    /// </summary>
    internal sealed class PortugalHolidayProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Portugal HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PortugalHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
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

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PT;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Ano Novo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-47),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 25),
                    EnglishName = "Freedom Day",
                    LocalName = "Dia da Liberdade",
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
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "Azores Day",
                    LocalName = "Dia dos Açores",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["PT-20"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 10),
                    EnglishName = "National Day",
                    LocalName = "Dia de Portugal, de Camões e das Comunidades Portuguesas",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 1),
                    EnglishName = "Madeira Day",
                    LocalName = "Dia da Madeira",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["PT-30"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Assunção de Nossa Senhora",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 5),
                    EnglishName = "Republic Day",
                    LocalName = "Implantação da República",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "Dia de Todos-os-Santos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 1),
                    EnglishName = "Restoration of Independence",
                    LocalName = "Restauração da Independência",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Imaculada Conceição",
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
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Primeira Oitava",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["PT-30"]
                },
                this._catholicProvider.GoodFriday("Sexta-feira Santa", year),
                this._catholicProvider.EasterSunday("Domingo de Páscoa", year),
                this._catholicProvider.CorpusChristi("Corpo de Deus", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Ano Novo", "New Year's Day", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode, null, null, HolidayTypes.Optional));
            //items.Add(this._catholicProvider.GoodFriday("Sexta-feira Santa", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Domingo de Páscoa", year, countryCode));
            //items.Add(new Holiday(year, 4, 25, "Dia da Liberdade", "Freedom Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            //items.Add(this._catholicProvider.CorpusChristi("Corpo de Deus", year, countryCode));
            //items.Add(new Holiday(year, 6, 1, "Dia dos Açores", "Azores Day", countryCode, null, new string[] { "PT-20" }));
            //items.Add(new Holiday(year, 6, 10, "Dia de Portugal, de Camões e das Comunidades Portuguesas", "National Day", countryCode));
            //items.Add(new Holiday(year, 7, 1, "Dia da Madeira", "Madeira Day", countryCode, null, new string[] { "PT-30" }));
            //items.Add(new Holiday(year, 8, 15, "Assunção de Nossa Senhora", "Assumption Day", countryCode));
            //items.Add(new Holiday(year, 10, 5, "Implantação da República", "Republic Day", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Dia de Todos-os-Santos", "All Saints Day", countryCode));
            //items.Add(new Holiday(year, 12, 1, "Restauração da Independência", "Restoration of Independence", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Imaculada Conceição", "Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Natal", "Christmas Day", countryCode, null));
            //items.Add(new Holiday(year, 12, 26, "Primeira Oitava", "St. Stephen's Day", countryCode, null, new string[] { "PT-30" }));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Portugal",
                "https://de.wikipedia.org/wiki/ISO_3166-2:PT"
            ];
        }
    }
}
