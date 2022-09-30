using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Lithuania
    /// </summary>
    internal class LithuaniaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// LithuaniaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public LithuaniaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.LT;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Naujieji metai", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 16, "Lietuvos valstybės atkūrimo diena", "The Day of Restoration of the State of Lithuania", countryCode));
            items.Add(new PublicHoliday(year, 3, 11, "Lietuvos nepriklausomybės atkūrimo diena", "Day of Restoration of Independence of Lithuania", countryCode));
            items.Add(this._catholicProvider.EasterSunday("Velykos", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Antroji Velykų diena", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Tarptautinė darbo diena", "International Working Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 24, "Joninės, Rasos", "St. John's Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 6, "Valstybės diena", "Statehood Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Žolinė", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Visų šventųjų diena", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Vėlinės", "All Souls' Day", countryCode, 2020));
            items.Add(new PublicHoliday(year, 12, 24, "Šv. Kūčios", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Šv. Kalėdos", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Šv. Kalėdos", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Lithuania"
            };
        }
    }
}
