using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
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
            // Public holidays (all regions)
            items.Add(new PublicHoliday(year, 1, 1, "Ano Novo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode, null, null, null, PublicHolidayType.Optional));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Sexta-feira Santa", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Domingo de Páscoa", "Easter Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 25, "Dia da Liberdade", "Freedom Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Corpo de Deus", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(year, 6, 10, "Dia de Portugal, de Camões e das Comunidades Portuguesas", "National Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Assunção de Nossa Senhora", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 5, "Implantação da República", "Republic Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Dia de Todos-os-Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 1, "Restauração da Independência", "Restoration of Independence", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Imaculada Conceição", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode, null));

            // Public holidays (only Azores)
            items.Add(new PublicHoliday(year, 6, 1, "Dia dos Açores", "Azores Day", countryCode, null, new string[] { "PT-20" }));

            // Public holidays (only Madeira)
            items.Add(new PublicHoliday(year, 7, 1, "Dia da Madeira", "Madeira Day", countryCode, null, new string[] { "PT-30" }));
            items.Add(new PublicHoliday(year, 12, 26, "Primeira Oitava", "St. Stephen's Day", countryCode, null, new string[] { "PT-30" }));

            // Public holidays (Local holidays)
            items.Add(new PublicHoliday(year, 1, 15, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Santa Cruz" }));
            items.Add(new PublicHoliday(year, 1, 20, "Dia do São Sebastião", "San Sebastian's Day", countryCode, 1910, null, new string[] { "Santa Maria da Feira", "Aveiro" }));
            items.Add(new PublicHoliday(year, 1, 22, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "São Vicente" }));
            items.Add(new PublicHoliday(year, 2, 18, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Valença" }));
            items.Add(new PublicHoliday(year, 3, 19, "Dia de São José", "St. Joseph's Day", countryCode, 1910, null, new string[] { "Santarém" }));
            items.Add(new PublicHoliday(year, 4, 11, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Lagoa" }));
            items.Add(new PublicHoliday(year, 4, 23, "Dia de São Jorge", "Saint George's Day", countryCode, 1910, null, new string[] { "Velas" }));
            items.Add(new PublicHoliday(year, 5, 23, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Santana" }));
            items.Add(new PublicHoliday(year, 6, 13, "Dia de Santo António", "St. Anthony's Day", countryCode, 1910, null, new string[] { "Lisbon" }));
            items.Add(new PublicHoliday(year, 6, 16, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Olhão" }));
            items.Add(new PublicHoliday(year, 6, 20, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Corvo" }));
            items.Add(new PublicHoliday(year, 6, 24, "Dia de São João", "St. John's Day", countryCode, 1910, null, new string[] { "Porto", "Braga", "Figueira da Foz", "Almada", "Calheta", "Porto Santo", "Angra do Heroísmo", "Horta", "Santa Cruz da Graciosa", "Santa Cruz das Flores", "Vila do Porto", "Vila Franca do Campo" }));
            items.Add(new PublicHoliday(year, 6, 29, "Dia de São Pedro", "St. Peter's Day", countryCode, 1910, null, new string[] { "Alfândega da Fé", "Bombarral", "Castro Daire", "Castro Verde", "Évora", "Felgueiras", "Macedo de Cavaleiros", "Montijo", "Penedono", "Porto de Mós", "Póvoa de Varzim", "Ribeira Brava", "Ribeira Grande", "São Pedro do Sul", "Seixal", "Sintra" }));
            items.Add(new PublicHoliday(year, 7, 4, "Dia de Santa Isabel", "St. Elizabeth's Day", countryCode, 1910, null, new string[] { "Coimbra" }));
            items.Add(new PublicHoliday(year, 7, 18, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Nordeste" }));
            items.Add(new PublicHoliday(year, 7, 22, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Porto Moniz", "Madalena" }));
            items.Add(new PublicHoliday(year, 8, 11, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Praia da Vitória" }));
            items.Add(new PublicHoliday(year, 8, 16, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "São Roque do Pico" }));
            items.Add(new PublicHoliday(year, 8, 20, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Viana do Castelo" }));
            items.Add(new PublicHoliday(year, 8, 21, "Dia da Cidade do Funchal", "Funchal City Day", countryCode, 1910, null, new string[] { "Funchal" }));
            items.Add(new PublicHoliday(year, 9, 8, "Natividade de Nossa Senhora", "Nativity of Mary", countryCode, 1910, null, new string[] { "Lagoa", "Alcoutim", "Ponta do Sol", "Lamego", "Mangualde", "Marco de Canaveses", "Marvão", "Montemor-o-Velho", "Murtosa", "Nazaré", "Odemira", "Ourique", "Sabrosa" }));
            items.Add(new PublicHoliday(year, 9, 21, "Dia de São Mateus", "St. Matthew's Day", countryCode, 1910, null, new string[] { "Viseu", "Elvas" }));
            items.Add(new PublicHoliday(year, 10, 4, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Câmara de Lobos" }));
            items.Add(new PublicHoliday(year, 10, 9, "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Machico" }));
            items.Add(new PublicHoliday(year, 11, 25, "Dia de Santa Catarina", "Saint Catherine's Day", countryCode, 1910, null, new string[] { "Calheta" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Segunda-feira de Páscoa", "Easter Monday", countryCode, 1910, null, new string[] { "Avis", "Borba", "Caminha", "Campo Maior", "Cuba", "Freixo de Espada à Cinta", "Ílhavo", "Mação", "Mora", "Penamacor", "Ponte de Sor", "Portel", "Redondo", "Castelo de Vide", "Constância", "Crato", "Nisa", "Sousel" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(4), "Quinta-feira da Ascensão", "Ascension of Jesus", countryCode, 1910, null, new string[] { "Alcanena", "Alenquer", "Almeirim", "Alter do Chão", "Alvito", "Anadia", "Ansião", "Arraiolos", "Arruda dos Vinhos", "Azambuja", "Beja", "Benavente", "Cartaxo", "Chamusca", "Estremoz", "Golegã", "Loulé", "Mafra", "Marinha Grande", "Mealhada", "Melgaço", "Monchique", "Mortágua", "Oliveira do Bairro", "Quarteira", "Salvaterra de Magos", "Santa Comba Dão", "Sobral de Monte Agraço", "Torres Novas", "Vidigueira", "Vila Franca de Xira" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(35), "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Ponta Delgada" }));

            var firstSundayOfSeptember = new DateTime(year, 9, 1).FirstDayOfWeekOnOrAfter(DayOfWeek.Sunday);
            items.Add(new PublicHoliday(firstSundayOfSeptember.AddDays(1), "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Povoação" }));

            var firstMondayOfJuly = new DateTime(year, 7, 1).FirstDayOfWeekOnOrAfter(DayOfWeek.Monday);
            items.Add(new PublicHoliday(firstMondayOfJuly.AddDays(21), "Dia do Concelho", "Municipal Holiday", countryCode, 1910, null, new string[] { "Lajes das Flores" }));

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
