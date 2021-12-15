using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Bosnia and Herzegovina
    /// </summary>
    public class BosniaAndHerzegovinaProvider : IPublicHolidayProvider, ICountyProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// BosniaAndHerzegovinaProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public BosniaAndHerzegovinaProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "BA-FBIH", "Federation of Bosnia and Herzegovina" },
                { "BA-RS", "Republic of Serbia" }
            };
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.BA;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nova Godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Nova Godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Božić (za pravoslavce)", "Christmas Eve (Orthodox)", countryCode, null, new string[] { "BA-RS" }));
            items.Add(new PublicHoliday(year, 1, 7, "Božić (za pravoslavce)", "Christmas Day (Orthodox)", countryCode, null, new string[] { "BA-RS" }));
            items.Add(new PublicHoliday(year, 3, 1, "Dan nezavisnosti Bosne i Hercegovine", "Idependence day", countryCode, null, new string[] { "BA-FBIH" }));
            items.Add(new PublicHoliday(year, 5, 1, "Praznik rada", "May Day / International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 2, "Praznik rada", "May Day / International Workers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 9, "Dan pobjede nad fašizmom", "Victory Day over fascism", countryCode, null, new string[] { "BA-RS" }));
            items.Add(new PublicHoliday(year, 11, 21, "Dan uspostavljanja Opšteg okvirnog sporazuma za mir u BiH", "Day of the establishment of the General Framework Agreement for Peace in BiH ", countryCode, null, new string[] { "BA-RS" }));
            items.Add(new PublicHoliday(year, 11, 25, "Dan državnosti Bosne i Hercegovine", "Statehood Day", countryCode, null, new string[] { "BA-FBIH" }));
            items.Add(new PublicHoliday(year, 12, 24, "Božić (za rimokatolike)", "Christmas Eve (Roman Catholic)", countryCode, null, new string[] { "BA-FBIH" }));
            items.Add(new PublicHoliday(year, 12, 25, "Božić (za rimokatolike)", "Christmas Day (Roman Catholic)", countryCode, null, new string[] { "BA-FBIH" }));

            items.Add(this._orthodoxProvider.GoodFriday("Veliki petak", year, countryCode).SetCounties("BA-RS"));
            items.Add(this._orthodoxProvider.EasterSunday("Vaskrs (Uskrs)", year, countryCode).SetCounties("BA-RS"));
            items.Add(this._orthodoxProvider.EasterMonday("Vaskrsni (Uskrsni) ponedeljak", year, countryCode).SetCounties("BA-RS"));


            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bosnia_and_Herzegovina"
            };
        }
    }
}
