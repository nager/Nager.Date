using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Romania
    /// </summary>
    internal class RomaniaProvider : IPublicHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// RomaniaProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public RomaniaProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.RO;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Anul Nou", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Anul Nou", "Day after New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 24, "Unirea Principatelor Române/Mica Unire", "Union Day/Small Union", countryCode));
            items.Add(this._orthodoxProvider.GoodFriday("Vinerea mare", year, countryCode).SetLaunchYear(2018));
            items.Add(this._orthodoxProvider.EasterSunday("Paștele", year, countryCode));
            items.Add(this._orthodoxProvider.EasterMonday("Paștele", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Ziua Muncii", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 1, "Ziua Copilului", "Children's Day", countryCode, 2017));
            items.Add(this._orthodoxProvider.Pentecost("Rusaliile", year, countryCode));
            items.Add(this._orthodoxProvider.WhitMonday("Rusaliile", year, countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Adormirea Maicii Domnului/Sfânta Maria Mare", "Dormition of the Theotokos", countryCode));
            items.Add(new PublicHoliday(year, 11, 30, "Sfântul Andrei", "St. Andrew's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 1, "Ziua Națională/Marea Unire", "National Day/Great Union", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Crăciunul", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Crăciunul", "St. Stephen's Day", countryCode));

            items.AddIfNotNull(this.Epiphany(year, countryCode));
            items.AddIfNotNull(this.SaintJohnTheBaptist(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday Epiphany(int year, CountryCode countryCode)
        {
            if (year >= 2024)
            {
                return new PublicHoliday(year, 1, 6, "Bobotează", "Epiphany", countryCode);
            }

            return null;
        }

        private PublicHoliday SaintJohnTheBaptist(int year, CountryCode countryCode)
        {
            if (year >= 2024)
            {
                return new PublicHoliday(year, 1, 7, "Sfântul Ion", "Saint John the Baptist", countryCode);
            }

            return null;
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Romania"
            };
        }
    }
}
