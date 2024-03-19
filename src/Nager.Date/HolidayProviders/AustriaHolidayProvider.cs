using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Austria HolidayProvider
    /// </summary>
    internal sealed class AustriaHolidayProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Austria HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AustriaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
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

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AT;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Neujahr",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Heilige Drei Könige",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "National Holiday",
                    LocalName = "Staatsfeiertag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Maria Himmelfahrt",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 26),
                    EnglishName = "National Holiday",
                    LocalName = "Nationalfeiertag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Allerheiligen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Mariä Empfängnis",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Weihnachten",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Stefanitag",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterMonday("Ostermontag", year),
                this._catholicProvider.AscensionDay("Christi Himmelfahrt", year),
                this._catholicProvider.WhitMonday("Pfingstmontag", year),
                this._catholicProvider.CorpusChristi("Fronleichnam", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Neujahr", "New Year's Day", countryCode, 1967));
            //items.Add(new Holiday(year, 1, 6, "Heilige Drei Könige", "Epiphany", countryCode));
            //items.Add(new PublicHoliday(year, 3, 19, "St. Josef", "Saint Joseph's Day", countryCode, type: PublicHolidayType.Authorities | PublicHolidayType.School, counties: new string[] { "AT-2", "AT-6", "AT-7", "AT-8" }));
            //items.Add(this._catholicProvider.EasterMonday("Ostermontag", year, countryCode).SetLaunchYear(1642));
            //items.Add(new Holiday(year, 5, 1, "Staatsfeiertag", "National Holiday", countryCode, 1955));
            //items.Add(new PublicHoliday(year, 5, 1, "St. Florian", "Saint Florian", countryCode, type: PublicHolidayType.School, counties: new string[] { "AT-4" }));
            //items.Add(this._catholicProvider.AscensionDay("Christi Himmelfahrt", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Pfingstmontag", year, countryCode));
            //items.Add(this._catholicProvider.CorpusChristi("Fronleichnam", year, countryCode));
            //items.Add(new Holiday(year, 8, 15, "Maria Himmelfahrt", "Assumption Day", countryCode));
            //items.Add(new Holiday(year, 10, 26, "Nationalfeiertag", "National Holiday", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Allerheiligen", "All Saints' Day", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Mariä Empfängnis", "Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Weihnachten", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Stefanitag", "St. Stephen's Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Austria"
            ];
        }
    }
}
