using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Ukraine
    /// </summary>
    internal class UkraineProvider : IPublicHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// UkraineProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public UkraineProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.UA;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Новий Рік", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 7, "Різдво", "(Julian) Christmas", countryCode));
            items.Add(new PublicHoliday(year, 3, 8, "Міжнародний жіночий день", "International Women's Day", countryCode));
            items.Add(this._orthodoxProvider.EasterSunday("Великдень", year, countryCode));
            items.Add(this._orthodoxProvider.Pentecost("Трійця", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "День праці", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 9, "День перемоги над нацизмом у Другій світовій війні", "Victory day over Nazism in World War II", countryCode));
            items.Add(new PublicHoliday(year, 6, 28, "День Конституції", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 24, "День Незалежності", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 14, "День захисника України", "Defender of Ukraine Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Різдво", "(Gregorian and Revised Julian) Christmas", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Ukraine"
            };
        }
    }
}
