using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Austria HolidayProvider
    /// </summary>
    internal sealed class AustriaHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Austria HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AustriaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.AT)
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
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Austria"
            ];
        }
    }
}
