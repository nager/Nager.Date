using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Luxembourg
    /// </summary>
    public class LuxembourgProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// LuxembourgProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public LuxembourgProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.LU;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Neijoerschdag", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ouschterméindeg", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dag vun der Aarbecht", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 9, "Europadag", "Europe Day", countryCode, 2019));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreideg", "Good Friday", countryCode, type: PublicHolidayType.Bank));
            items.Add(this._catholicProvider.AscensionDay("Christi Himmelfaart", year, countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Péngschtméindeg", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 6, 23, "Groussherzogsgebuertsdag", "Sovereign's birthday", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Léiffrawëschdag", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Allerhellgen", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Chrëschtdag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Stiefesdag", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Luxembourg"
            };
        }
    }
}
