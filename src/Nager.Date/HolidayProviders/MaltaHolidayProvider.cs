using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Malta HolidayProvider
    /// </summary>
    internal class MaltaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Malta HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MaltaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MT;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "L-Ewwel tas-Sena", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 2, 10, "In-Nawfraġju ta’ San Pawl", "Feast of St. Paul's Shipwreck", countryCode));
            items.Add(new Holiday(year, 3, 19, "San Ġużepp", "Feast of St. Joseph", countryCode));
            items.Add(new Holiday(year, 3, 31, "Jum il-Ħelsien", "Freedom Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Il-Ġimgħa l-Kbira", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Jum il-Ħaddiem", "Worker's Day", countryCode));
            items.Add(new Holiday(year, 6, 7, "Sette Giugno", "​Sette Giugno", countryCode));
            items.Add(new Holiday(year, 6, 29, "L-Imnarja", "​​Feast of St.Peter and St.Paul", countryCode));
            items.Add(new Holiday(year, 8, 15, "Santa Marija", "Assumption Day", countryCode));
            items.Add(new Holiday(year, 9, 8, "Il-Vittorja", "Feast of Our Lady of Victories", countryCode));
            items.Add(new Holiday(year, 9, 21, "L-Indipendenza", "Independence Day", countryCode));
            items.Add(new Holiday(year, 12, 8, "L-Immakulata Kunċizzjoni", "​Feast of the Immaculate Conception", countryCode));
            items.Add(new Holiday(year, 12, 13, "Jum ir-Repubblika", "Republic Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Il-Milied​", "​Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Malta"
            };
        }
    }
}