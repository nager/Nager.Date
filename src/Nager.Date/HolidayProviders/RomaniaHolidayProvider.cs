using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Romania HolidayProvider
    /// </summary>
    internal class RomaniaHolidayProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Romania HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public RomaniaHolidayProvider(
            IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.RO;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Anul Nou", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 2, "Anul Nou", "Day after New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 24, "Unirea Principatelor Române/Mica Unire", "Union Day/Small Union", countryCode));
            items.Add(this._orthodoxProvider.GoodFriday("Vinerea mare", year, countryCode).SetLaunchYear(2018));
            items.Add(this._orthodoxProvider.EasterSunday("Paștele", year, countryCode));
            items.Add(this._orthodoxProvider.EasterMonday("Paștele", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Ziua Muncii", "Labour Day", countryCode));
            items.Add(new Holiday(year, 6, 1, "Ziua Copilului", "Children's Day", countryCode, 2017));
            items.Add(this._orthodoxProvider.Pentecost("Rusaliile", year, countryCode));
            items.Add(this._orthodoxProvider.WhitMonday("Rusaliile", year, countryCode));
            items.Add(new Holiday(year, 8, 15, "Adormirea Maicii Domnului/Sfânta Maria Mare", "Dormition of the Theotokos", countryCode));
            items.Add(new Holiday(year, 11, 30, "Sfântul Andrei", "St. Andrew's Day", countryCode));
            items.Add(new Holiday(year, 12, 1, "Ziua Națională/Marea Unire", "National Day/Great Union", countryCode));
            items.Add(new Holiday(year, 12, 25, "Crăciunul", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Crăciunul", "St. Stephen's Day", countryCode));

            items.AddIfNotNull(this.Epiphany(year, countryCode));
            items.AddIfNotNull(this.SaintJohnTheBaptist(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday Epiphany(int year, CountryCode countryCode)
        {
            if (year >= 2024)
            {
                return new Holiday(year, 1, 6, "Bobotează", "Epiphany", countryCode);
            }

            return null;
        }

        private Holiday SaintJohnTheBaptist(int year, CountryCode countryCode)
        {
            if (year >= 2024)
            {
                return new Holiday(year, 1, 7, "Sfântul Ion", "Saint John the Baptist", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Romania"
            };
        }
    }
}
