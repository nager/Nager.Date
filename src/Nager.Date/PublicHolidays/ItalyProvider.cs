using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Italy
    /// </summary>
    internal class ItalyProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// ItalyProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ItalyProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.IT;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Capodanno", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 6, "Epifania", "Epiphany", countryCode));
            items.Add(this._catholicProvider.EasterSunday("Pasqua", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Lunedì dell'Angelo", year, countryCode).SetLaunchYear(1642));
            items.Add(new PublicHoliday(year, 4, 25, "Festa della Liberazione", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Festa del Lavoro", "International Workers Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 2, "Festa della Repubblica", "Republic Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Ferragosto o Assunzione", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Tutti i santi", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Immacolata Concezione", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natale", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Santo Stefano", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Italy",
            };
        }
    }
}
