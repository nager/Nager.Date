using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Brazil
    /// </summary>
    public class BrazilProvider : IPublicHolidayProvider, ICountyProvider
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

        /// <summary>
        /// GetCounties
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "BR-AC", "Acre" },
                { "BR-AL", "Alagoas" },
                { "BR-AP", "Amapá" },
                { "BR-AM", "Amazonas" },
                { "BR-BA", "Bahia" },
                { "BR-CE", "Ceará" },
                { "BR-DF", "Distrito Federal" },
                { "BR-ES", "Espírito Santo" },
                { "BR-GO", "Goiás" },
                { "BR-MA", "Maranhão" },
                { "BR-MT", "Mato Grosso" },
                { "BR-MS", "Mato Grosso do Sul" },
                { "BR-MG", "Minas Gerais" },
                { "BR-PR", "Paraná" },
                { "BR-PB", "Paraíba" },
                { "BR-PA", "Pará" },
                { "BR-PE", "Pernambuco" },
                { "BR-PI", "Piauí" },
                { "BR-RN", "Rio Grande do Norte" },
                { "BR-RS", "Rio Grande do Sul" },
                { "BR-RJ", "Rio de Janeiro" },
                { "BR-RO", "Rondônia" },
                { "BR-RR", "Roraima" },
                { "BR-SC", "Santa Catarina" },
                { "BR-SE", "Sergipe" },
                { "BR-SP", "São Paulo" },
                { "BR-TO", "Tocantins" },
            };
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.BR;
            var items = new List<PublicHoliday>();

            // official holidays (fixed dates)
            items.Add(new PublicHoliday(year, 1, 1, "Confraternização Universal", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 21, "Dia de Tiradentes", "Tiradentes", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 7, "Dia da Independência", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Nossa Senhora Aparecida", "Children's Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Dia de Finados", "Day of the Dead", countryCode));
            items.Add(new PublicHoliday(year, 11, 15, "Proclamação da República", "Republic Proclamation Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode));

            // non fixed days (Easter, Carnival, Passion of Jesus and Corpus Christi)
            var easter = this._catholicProvider.EasterSunday(year);
            items.Add(new PublicHoliday(easter, "Domingo de Pascoa", "Easter Day", countryCode));
            items.Add(new PublicHoliday(easter.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easter.AddDays(-2), "Sexta feira Santa", "Passion of Jesus", countryCode));
            items.Add(new PublicHoliday(easter.AddDays(60), "Corpus Christi", "Corpus Christi", countryCode));

            // Unofficial holidays
            items.Add(new PublicHoliday(easter.AddDays(-46), "Quarta-feira de Cinzas", "Ash Wednesday", countryCode, null, null, null, PublicHolidayType.Observance));
            
            items.Add(new PublicHoliday(year, 6, 12, "Dia dos Namorados", "St. Valentine's Day", countryCode, null, null, null, PublicHolidayType.Observance));
            items.Add(new PublicHoliday(year, 10, 12, "Dia das Crianças", "Brazilian Children's Day", countryCode, null, null, null, PublicHolidayType.Observance));

            var firstSundayAugust = new DateTime(year, 8, 1).FirstDayOfWeekOnOrAfter(DayOfWeek.Sunday);
            items.Add(new PublicHoliday(firstSundayAugust.AddDays(7), "Dia dos Pais", "Father's Day", countryCode, null, null, null, PublicHolidayType.Observance));

            var firstSundayMay = new DateTime(year, 5, 1).FirstDayOfWeekOnOrAfter(DayOfWeek.Sunday);
            items.Add(new PublicHoliday(firstSundayMay.AddDays(7), "Dia das Mães", "Mother's Day", countryCode, null, null, null, PublicHolidayType.Observance));

            // Acre
            items.Add(new PublicHoliday(year, 1, 23, "Dia do evangélico", "Evangelical's Day", countryCode, 2005, new[] { "BR-AC" }));
            items.Add(new PublicHoliday(year, 3, 8, "Dia Internacional da Mulher", "International Women's Day", countryCode, 2002, new[] { "BR-AC" }));
            items.Add(new PublicHoliday(year, 6, 15, "Aniversário do Estado", "State Anniversary", countryCode, 1965, new[] { "BR-AC" }));
            items.Add(new PublicHoliday(year, 9, 5, "Dia da Amazônia", "Amazon's day", countryCode, 2004, new[] { "BR-AC" }));
            items.Add(new PublicHoliday(year, 11, 17, "Assinatura do Tratado de Petrópolis", "Signature of the Petrópolis Treaty", countryCode, 1966, new[] { "BR-AC" }, null, PublicHolidayType.Optional));

            // Alagoas
            items.Add(new PublicHoliday(year, 6, 24, "Dia de São João", "St. John's Day", countryCode, 1994, new[] { "BR-AL" }));
            items.Add(new PublicHoliday(year, 6, 29, "Dia de São Pedro", "St. Peter's Day", countryCode, 1994, new[] { "BR-AL" }));
            items.Add(new PublicHoliday(year, 9, 16, "Emancipação política", "Political emancipation", countryCode, 2020, new[] { "BR-AL" }));
            items.Add(new PublicHoliday(year, 11, 20, "Morte de Zumbi dos Palmares", "Death of Zumbi dos Palmares", countryCode, 1995, new[] { "BR-AL" }));

            // Amapá
            items.Add(new PublicHoliday(year, 3, 19, "Dia de São José", "St. Joseph's Day", countryCode, 2003, new[] { "BR-AP" }));
            items.Add(new PublicHoliday(year, 9, 13, "Criação do Território Federal", "aaaa", countryCode, 2012, new[] { "BR-AP" }));

            // Amazonas
            items.Add(new PublicHoliday(year, 9, 5, "Elevação do Amazonas à categoria de província", "Elevation of Amazonas to the category of province", countryCode, 978, new[] { "BR-AM" }));
            items.Add(new PublicHoliday(year, 11, 20, "Dia da Consciência Negra", "Black conscience day", countryCode, 2010, new[] { "BR-AM" }));
            items.Add(new PublicHoliday(year, 12, 8, "Nossa Senhora da Conceição", "Our Lady of Conception", countryCode, null, new[] { "BR-AM" }));

            // Bahia
            items.Add(new PublicHoliday(year, 6, 2, "Independência da Bahia", "Independence of Bahia", countryCode, 2012, new[] { "BR-BA" }));

            // Ceará
            items.Add(new PublicHoliday(year, 3, 19, "Dia de São José", "St. Joseph's Day", countryCode, 1996, new[] { "BR-CE" }));
            items.Add(new PublicHoliday(year, 3, 25, "Abolição da escravidão no Ceará", "Abolition of slavery in Ceará", countryCode, 2012, new[] { "BR-CE" }));
            items.Add(new PublicHoliday(year, 8, 15, "Dia de Nossa Senhora da Assunção", "Day of Our Lady of the Assumption", countryCode, 1996, new[] { "BR-CE" }));

            // Distrito Federal
            items.Add(new PublicHoliday(year, 4, 21, "Fundação de Brasília", "Brasília Foundation", countryCode, null, new[] { "BR-DF" }));
            items.Add(new PublicHoliday(year, 11, 30, "Dia do evangélico", "Evangelical's Day", countryCode, 1996, new[] { "BR-DF" }));

            // Espírito Santo
            items.Add(new PublicHoliday(easter.AddDays(8), "Dia de Nossa Senhora da Penha", "Day of Our Lady of Penha", countryCode, 2020, new[] { "BR-ES" }));

            // Goiás
            items.Add(new PublicHoliday(year, 7, 26, "Fundação da cidade de Goiás", "Foundation of the city of Goiás", countryCode, 2020, new[] { "BR-GO" }));
            items.Add(new PublicHoliday(year, 10, 4, "Pedra fundamental de Goiânia", "Goiania's cornerstone", countryCode, 2020, new[] { "BR-GO" }));

            // Maranhão
            items.Add(new PublicHoliday(year, 7, 28, "Adesão do Maranhão à independência do Brasil", "Maranhão's accession to Brazil's independence", countryCode, 1965, new[] { "BR-MA" }));

            // Mato Grosso
            items.Add(new PublicHoliday(year, 11, 20, "Dia da Consciência Negra", "Black conscience day", countryCode, 2003, new[] { "BR-MT" }));

            // Mato Grosso do Sul
            items.Add(new PublicHoliday(year, 10, 11, "Criação do estado", "State creation", countryCode, 1980, new[] { "BR-MS" }));

            // Minas Gerais
            items.Add(new PublicHoliday(year, 4, 21, "Execução de Tiradentes", "Execution of Tiradentes", countryCode, 1989, new[] { "BR-MG" }));

            // Pará
            items.Add(new PublicHoliday(year, 8, 15, " Adesão do Pará à independência do Brasil", "Pará's accession to Brazil's independence", countryCode, 1997, new[] { "BR-PA" }));

            // Paraíba
            items.Add(new PublicHoliday(year, 8, 5, "Fundação do Estado", "State Foundation", countryCode, 1968, new[] { "BR-PB" }));

            // Paraná
            items.Add(new PublicHoliday(year, 12, 19, "Emancipação política do estado do Paraná", "Political emancipation of the state of Paraná", countryCode, 1962, new[] { "BR-PR" }));

            // Pernambuco
            items.Add(new PublicHoliday(year, 3, 6, "Revolução Pernambucana de 1817", "1817 Pernambucan Revolution", countryCode, 2010, new[] { "BR-PE" }));
            items.Add(new PublicHoliday(year, 6, 24, "Dia de São João", "St. John's Day", countryCode, null, new[] { "BR-PE" }));

            // Piauí
            items.Add(new PublicHoliday(year, 10, 19, "Dia do Piauí", "Day of Piauí", countryCode, 1937, new[] { "BR-PI" }));

            // Rio de Janeiro
            items.Add(new PublicHoliday(easter.AddDays(2), "Terça de Carnaval", "Carnival Tuesday", countryCode, 2009, new[] { "BR-RJ" }));
            items.Add(new PublicHoliday(year, 4, 23, "Dia de São Jorge", "St. George's Day", countryCode, 2008, new[] { "BR-RJ" }));
            items.Add(new PublicHoliday(year, 11, 20, "Dia da Consciência Negra", "Black conscience day", countryCode, 2002, new[] { "BR-RJ" }));

            // Rio Grande do Norte
            items.Add(new PublicHoliday(year, 8, 7, "Dia do Rio Grande do Norte", "Rio Grande do Norte Day", countryCode, 2000, new[] { "BR-RN" }));
            items.Add(new PublicHoliday(year, 10, 3, "Mártires de Cunhaú e Uruaçu", "Martyrs of Cunhaú and Uruaçu", countryCode, 2007, new[] { "BR-RN" }));

            // Rio Grande do Sul
            items.Add(new PublicHoliday(year, 9, 20, "Dia do Gaúcho", "Gaucho's Day", countryCode, 1995, new[] { "BR-RS" }));

            // Rondônia
            items.Add(new PublicHoliday(year, 1, 4, "Criação do estado", "State creation", countryCode, 2011, new[] { "BR-RO" }));
            items.Add(new PublicHoliday(year, 6, 18, "Dia do evangélico", "Evangelical's Day", countryCode, 2002, new[] { "BR-RO" }));

            // Roraima
            items.Add(new PublicHoliday(year, 10, 5, "Criação do estado", "State creation", countryCode, 1988, new[] { "BR-RR" }));

            // Santa Catarina
            items.Add(new PublicHoliday(year, 8, 11, "Dia de Santa Catarina", "Santa Catarina's Day", countryCode, 2004, new[] { "BR-SC" }));
            items.Add(new PublicHoliday(year, 11, 25, "Dia de Santa Catarina de Alexandria", "Santa Catarina de Alexandria's day", countryCode, 1997, new[] { "BR-SC" }));

            // São Paulo
            items.Add(new PublicHoliday(year, 7, 9, "Revolução Constitucionalista de 1932", "Constitutionalist Revolution of 1932", countryCode, 1997, new[] { "BR-SP" }));

            // Sergipe
            items.Add(new PublicHoliday(year, 7, 8, "Emancipação política de Sergipe", "Political emancipation of Sergipe", countryCode, 1892, new[] { "BR-SE" }));

            // Tocantins
            items.Add(new PublicHoliday(year, 10, 5, "Criação do estado", "State creation", countryCode, 1990, new[] { "BR-TO" }));
            items.Add(new PublicHoliday(year, 3, 18, "Autonomia do Estado", "State Autonomy", countryCode, 1998, new[] { "BR-TO" }));
            items.Add(new PublicHoliday(year, 9, 8, "Nossa Senhora da Natividade", "Our Lady of the Nativity", countryCode, 1994, new[] { "BR-TO" }));

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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Brazil",
                "https://pt.wikipedia.org/wiki/Feriados_no_Brasil",
                "http://www.planalto.gov.br/ccivil_03/leis/L9093.htm"
            };
        }
    }
}