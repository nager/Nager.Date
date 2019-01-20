using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Slovakia
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Slovakia
    /// </summary>
    public class SlovakiaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// SlovakiaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SlovakiaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.SK;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Deň vzniku Slovenskej republiky", "Day of the Establishment of the Slovak Republic", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Zjavenie Pána", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Veľkonočný piatok", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Veľkonočný pondelok", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Sviatok práce", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 8, "Deň víťazstva nad fašizmom", "Day of victory over fascism", countryCode));
            items.Add(new PublicHoliday(year, 7, 5, "Sviatok svätého Cyrila a Metoda", "St. Cyril and Methodius Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 29, "Výročie Slovenského národného povstania", "Slovak National Uprising anniversary", countryCode));
            items.Add(new PublicHoliday(year, 9, 1, "Deň Ústavy Slovenskej republiky", "Day of the Constitution of the Slovak Republic", countryCode));
            items.Add(new PublicHoliday(year, 9, 15, "Sviatok Panny Márie Sedembolestnej", "Day of Our Lady of the Seven Sorrows", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Sviatok všetkých svätých", "All Saints’ Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 17, "Deň boja za slobodu a demokraciu", "Struggle for Freedom and Democracy Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Štedrý deň", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Prvý sviatok vianočný", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Druhý sviatok vianočný", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
