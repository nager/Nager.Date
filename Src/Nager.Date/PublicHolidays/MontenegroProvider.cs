using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Montenegro
    /// </summary>
    public class MontenegroProvider : IPublicHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// MontenegroProvider
        /// </summary>
        public MontenegroProvider(
            IOrthodoxProvider orthodoxProvider,
            ICatholicProvider catholicProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.ME;

            var orthodoxEasterSunday = this._orthodoxProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nova godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Nova godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Praznik rada", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 2, "Praznik rada", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 21, "Dan nezavisnosti", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 22, "Dan nezavisnosti", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 13, "Dan državnosti", "Statehood Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 14, "Dan državnosti", "Statehood Day", countryCode));

            #region Orthodox holidays

            var easterMondayOrthodox = this._orthodoxProvider.EasterMonday("Vaskrs", year, countryCode);
            easterMondayOrthodox.SetType(PublicHolidayType.Optional);

            items.Add(new PublicHoliday(year, 1, 6, "Badnji dan", "Orthodox Christmas Eve", countryCode, null, null, PublicHolidayType.Optional));
            items.Add(new PublicHoliday(year, 1, 7, "Božić", "Orthodox Christmas Day", countryCode, null, null, PublicHolidayType.Optional));
            items.Add(new PublicHoliday(year, 1, 8, "Božić", "Orthodox Christmas Day", countryCode, null, null, PublicHolidayType.Optional));
            items.Add(new PublicHoliday(orthodoxEasterSunday.AddDays(-2), "Vaskrs", "Orthodox Good Friday", countryCode, null, null, PublicHolidayType.Optional));
            items.Add(easterMondayOrthodox);

            #endregion

            #region Catholic holidays

            var easterSunday = this._catholicProvider.EasterSunday("Uskrs", year, countryCode);
            easterSunday.SetType(PublicHolidayType.Optional);

            var easterMonday = this._catholicProvider.EasterMonday("Uskrs", year, countryCode);
            easterMonday.SetType(PublicHolidayType.Optional);

            var goodFriday = this._catholicProvider.GoodFriday("Veliki petak", year, countryCode);
            goodFriday.SetType(PublicHolidayType.Optional);

            items.Add(goodFriday);
            items.Add(easterSunday);
            items.Add(easterMonday);
            items.Add(new PublicHoliday(year, 11, 1, "Svi Sveti", "Catholic All Saints' Day", countryCode, null, null, PublicHolidayType.Optional));
            items.Add(new PublicHoliday(year, 12, 24, "Badnji dan", "Catholic Christmas Eve", countryCode, null, null, PublicHolidayType.Optional));
            items.Add(new PublicHoliday(year, 12, 25, "Božić", "Catholic Christmas Day", countryCode, null, null, PublicHolidayType.Optional));
            items.Add(new PublicHoliday(year, 12, 26, "Božić", "Catholic St. Stephen's Day", countryCode, null, null, PublicHolidayType.Optional));

            #endregion

            //TODO
            //Muslim holidays
            //Jewish holidays

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Montenegro"
            };
        }
    }
}
