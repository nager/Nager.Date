using Nager.Date.Model;
using Nager.Date.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Norway
    /// </summary>
    public class NorwayProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// NorwayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NorwayProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.NO;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Første nyttårsdag", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Skjærtorsdag", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Langfredag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Første påskedag", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Andre påskedag", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Første mai", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 17, "Syttende mai", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Kristi himmelfartsdag", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Første pinsedag", "Pentecost", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Andre pinsedag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Første juledag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Andre juledag", "St. Stephen's Day", countryCode));


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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Norway"
            };
        }
    }
}
