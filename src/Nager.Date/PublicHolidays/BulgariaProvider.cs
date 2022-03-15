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

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.BG;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Нова година", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 3, 3, "Ден на oсвобождението на България от Oсманско робство", "Liberation Day", countryCode));
            items.Add(this._orthodoxProvider.GoodFriday("Разпети петък", year, countryCode));
            items.Add(this._orthodoxProvider.HolySaturday("Велика Cъбота", year, countryCode));
            items.Add(this._orthodoxProvider.EasterSunday("Великден", year, countryCode));
            items.Add(this._orthodoxProvider.EasterMonday("Велики понеделник", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Ден на труда и на международната работническа солидарност", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 6, "Гергьовден, ден на храбростта и Българската армия", "Saint George's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 24, "Ден на Българската просвета и култура и на славянската писменост", "Saints Cyril and Methodius Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 6, "Ден на cъединението", "Unification Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 22, "Ден на независимостта на България", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Бъдни вечер", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Рождество Христово", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Рождество Христово", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bulgaria",
            };
        }
    }
}
