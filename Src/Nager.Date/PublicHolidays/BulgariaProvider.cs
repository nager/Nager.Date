using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Bulgaria
    /// </summary>
    public class BulgariaProvider : IPublicHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// BulgariaProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public BulgariaProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.BG;
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Нова година", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 3, 3, "Ден на Освобождението на България от османско робство", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Великден", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Велики понеделник", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Ден на труда и на международната работническа солидарност", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 6, "Гергьовден, ден на храбростта и Българската армия", "Saint George's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 24, "Ден на българската просвета и култура и на славянската писменост", "Saints Cyril and Methodius Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 6, "Ден на Съединението", "Unification Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 22, "Ден на независимостта на България", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Ден на народните будители", "National Awakening Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Бъдни вечер", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Рождество Христово", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Рождество Христово", "St. Stephen's Day", countryCode));

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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bulgaria",
            };
        }
    }
}
