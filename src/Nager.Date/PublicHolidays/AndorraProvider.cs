using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Andorra
    /// </summary>
    internal class AndorraProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// AndorraProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AndorraProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AD;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Any nou", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Reis", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(year, 3, 14, "Dia de la Constitució", "Constitution Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Divendres Sant", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Dilluns de Pasqua", year, countryCode));        
            items.Add(new PublicHoliday(year, 5, 1, "Festa del Treball", "Labour Day", countryCode));
            items.Add(this._catholicProvider.WhitMonday("Dilluns de Pentecosta", year, countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Assumpció", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 8, "Mare de Déu de Meritxell", "National Holiday", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Tots Sants", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Immaculada Concepció", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Nadal", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Sant Esteve", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Andorra"
            };
        }
    }
}
