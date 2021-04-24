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

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.NO;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Første nyttårsdag", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Skjærtorsdag", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Langfredag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Første påskedag", "Easter Sunday", countryCode));
            items.Add(this._catholicProvider.EasterMonday("Andre påskedag", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Første mai", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 17, "Syttende mai", "Constitution Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Kristi himmelfartsdag", year, countryCode));
            items.Add(this._catholicProvider.Pentecost("Første pinsedag", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Andre pinsedag", year, countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Første juledag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Andre juledag", "St. Stephen's Day", countryCode));


            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Norway"
            };
        }
    }
}
