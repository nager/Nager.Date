using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Andorra HolidayProvider
    /// </summary>
    internal class AndorraHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Andorra HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AndorraHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AD;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Any nou", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 6, "Reis", "Epiphany", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            items.Add(new Holiday(year, 3, 14, "Dia de la Constitució", "Constitution Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Divendres Sant", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Dilluns de Pasqua", year, countryCode));        
            items.Add(new Holiday(year, 5, 1, "Festa del Treball", "Labour Day", countryCode));
            items.Add(this._catholicProvider.WhitMonday("Dilluns de Pentecosta", year, countryCode));
            items.Add(new Holiday(year, 8, 15, "Assumpció", "Assumption Day", countryCode));
            items.Add(new Holiday(year, 9, 8, "Mare de Déu de Meritxell", "National Holiday", countryCode));
            items.Add(new Holiday(year, 11, 1, "Tots Sants", "All Saints' Day", countryCode));
            items.Add(new Holiday(year, 12, 8, "Immaculada Concepció", "Immaculate Conception", countryCode));
            items.Add(new Holiday(year, 12, 25, "Nadal", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Sant Esteve", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Andorra"
            };
        }
    }
}
