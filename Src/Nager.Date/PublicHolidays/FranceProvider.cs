using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// France
    /// </summary>
    public class FranceProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// FranceProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public FranceProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.FR;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Jour de l'an", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Vendredi saint", "Good Friday", countryCode, null, new string[] { "FR-A", "FR-57" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Lundi de Pâques", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(year, 5, 1, "Fête du premier mai", "Labour Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Jour de l'Ascension", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 8, "Fête de la Victoire", "Victory in Europe Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 22, "Abolition de l'esclavage", "Abolition of Slavery", countryCode, null, new string[] { "FR-MQ" }));
            items.Add(new PublicHoliday(year, 5, 27, "Abolition of Slavery", "Abolition de l'esclavage", countryCode, null, new string[] { "FR-GP", "FR-MF", "FR-BL" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Lundi de Pentecôte", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 7, 14, "Fête nationale", "Bastille Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "L'Assomption de Marie", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "La Toussaint", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 11, "Armistice de 1918", "Armistice Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Noël", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Saint-Étienne", "St. Stephen's Day", countryCode, null, new string[] { "FR-A", "FR-57" }));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_France",
                "https://en.wikipedia.org/wiki/ISO_3166-2:FR",
            };
        }
    }
}
