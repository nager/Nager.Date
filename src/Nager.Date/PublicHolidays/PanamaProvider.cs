using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Panama
    /// </summary>
    internal class PanamaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// PanamaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PanamaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PA;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 9, "Martyr's Day", "Martyr's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Carnival", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnival", "Carnival", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            //presidential inauguration (not enough informations)
            items.Add(new PublicHoliday(year, 11, 3, "Separation Day", "Separation Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 4, "Flag Day", "Flag Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 5, "Colón Day", "Colon Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 10, "Shout in Villa de los Santos", "Shout in Villa de los Santos", countryCode));
            items.Add(new PublicHoliday(year, 11, 28, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Mothers' Day", "Mothers' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Panama"
            };
        }
    }
}
