using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Andorra
    /// </summary>
    public class AndorraProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.AD;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Any nou", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 14, "Dia de la Constitució", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 14, "Mare de Déu de Meritxell", "National Holiday", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Nadal", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Andorra"
            };
        }
    }
}
