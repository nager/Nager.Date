using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Brazil
    /// </summary>
    public class BrazilProvider : IPublicHolidayProvider
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
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.BR;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            // official holidays (fixed dates)
            items.Add(new PublicHoliday(year, 1, 1, "Confraternização Universal", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 21, "Dia de Tiradentes", "Tiradentes", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 7, "Dia da Independência", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Nossa Senhora Aparecida", "Our Lady of Aparecida", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Dia de Finados", "All Souls' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 15, "Proclamação da República", "Republic Proclamation Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode));

            // non fixed days (Easter, Carnival, Good Friday and Corpus Christi)
            items.Add(this._catholicProvider.EasterSunday("Domingo de Páscoa", year, countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Sexta-feira Santa", year, countryCode));
            items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode));
            // TODO non-official holidays

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
