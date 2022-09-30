using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Austria
    /// </summary>
    internal class AustriaProvider : IPublicHolidayProvider, ICountyProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// AustriaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AustriaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "AT-1", "Burgenland" }, //Burgenland
                { "AT-2", "Kärnten" }, //Carinthia
                { "AT-3", "Niederösterreich" }, //Lower Austria
                { "AT-4", "Oberösterreich" }, //Upper Austria
                { "AT-5", "Salzburg" }, //Salzburg
                { "AT-6", "Steiermark" }, //Styria
                { "AT-7", "Tirol" }, //Tyrol
                { "AT-8", "Vorarlberg" }, //Vorarlberg
                { "AT-9", "Wien" }, //Vienna
            };
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AT;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 6, "Heilige Drei Könige", "Epiphany", countryCode));
            //items.Add(new PublicHoliday(year, 3, 19, "St. Josef", "Saint Joseph's Day", countryCode, type: PublicHolidayType.Authorities | PublicHolidayType.School, counties: new string[] { "AT-2", "AT-6", "AT-7", "AT-8" }));
            items.Add(this._catholicProvider.EasterMonday("Ostermontag", year, countryCode).SetLaunchYear(1642));
            items.Add(new PublicHoliday(year, 5, 1, "Staatsfeiertag", "National Holiday", countryCode, 1955));
            //items.Add(new PublicHoliday(year, 5, 1, "St. Florian", "Saint Florian", countryCode, type: PublicHolidayType.School, counties: new string[] { "AT-4" }));
            items.Add(this._catholicProvider.AscensionDay("Christi Himmelfahrt", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Pfingstmontag", year, countryCode));
            items.Add(this._catholicProvider.CorpusChristi("Fronleichnam", year, countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Maria Himmelfahrt", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 26, "Nationalfeiertag", "National Holiday", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Allerheiligen", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Mariä Empfängnis", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Stefanitag", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Austria"
            };
        }
    }
}
