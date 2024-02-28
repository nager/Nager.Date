using Nager.Date.Models;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Russia HolidayProvider
    /// </summary>
    internal class RussiaHolidayProvider : IHolidayProvider
    {
        /// <summary>
        /// Russia HolidayProvider
        /// </summary>
        public RussiaHolidayProvider()
        {
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.RU;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Новый год", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 2, "Новогодние каникулы", "New Year holiday", countryCode));
            items.Add(new Holiday(year, 1, 3, "Новогодние каникулы", "New Year holiday", countryCode));
            items.Add(new Holiday(year, 1, 4, "Новогодние каникулы", "New Year holiday", countryCode));
            items.Add(new Holiday(year, 1, 5, "Новогодние каникулы", "New Year holiday", countryCode));
            items.Add(new Holiday(year, 1, 6, "Новогодние каникулы", "New Year holiday", countryCode));
            items.Add(new Holiday(year, 1, 7, "Рождество Христово", "Orthodox Christmas Day", countryCode));
            items.Add(new Holiday(year, 2, 23, "День защитника Отечества", "Defender of the Fatherland Day", countryCode, 1918));
            items.Add(new Holiday(year, 3, 8, "Международный женский день", "International Women's Day", countryCode, 1913));
            items.Add(new Holiday(year, 5, 1, "День труда", "Labour Day", countryCode));
            items.Add(new Holiday(year, 5, 9, "День Победы", "Victory Day", countryCode));
            items.Add(new Holiday(year, 6, 12, "День России", "Russia Day", countryCode, 2002));
            items.Add(new Holiday(year, 11, 4, "День народного единства", "Unity Day", countryCode, 2005));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Russia"
            };
        }
    }
}
