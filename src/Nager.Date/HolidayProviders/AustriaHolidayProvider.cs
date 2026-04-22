using Nager.Date.Extensions;
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
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Neujahr",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "EPIPHANY-01",
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Heilige Drei Könige",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NATIONALHOLIDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "National Holiday",
                    LocalName = "Staatsfeiertag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ASSUMPTIONDAY-01",
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Maria Himmelfahrt",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NATIONALHOLIDAY-02",
                    Date = new DateTime(year, 10, 26),
                    EnglishName = "National Holiday",
                    LocalName = "Nationalfeiertag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Allerheiligen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "IMMACULATECONCEPTION-01",
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Mariä Empfängnis",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Weihnachten",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Stefanitag",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("Ostersonntag", year),
                this._catholicProvider.EasterMonday("Ostermontag", year),
                this._catholicProvider.AscensionDay("Christi Himmelfahrt", year),
                this._catholicProvider.Pentecost("Pfingstsonntag", year),
                this._catholicProvider.WhitMonday("Pfingstmontag", year),
                this._catholicProvider.CorpusChristi("Fronleichnam", year)
            };

            holidaySpecifications.AddIfNotNull(this.SaintJosephsDay(year));
            holidaySpecifications.AddIfNotNull(this.SaintFloriansDay(year));
            holidaySpecifications.AddIfNotNull(this.SaintRupertsDay(year));
            holidaySpecifications.AddIfNotNull(this.SaintMartinsDay(year));
            holidaySpecifications.AddIfNotNull(this.SaintLeopoldsDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification SaintJosephsDay(int year)
        {
            return new HolidaySpecification
            {
                Id = "SAINTJOSEPHSDAY-01",
                Date = new DateTime(year, 3, 19),
                EnglishName = "Saint Joseph's Day",
                LocalName = "Josefstag",
                HolidayTypes = HolidayTypes.School,
                SubdivisionCodes = ["AT-2", "AT-6", "AT-7", "AT-8"]
            };
        }

        private HolidaySpecification SaintFloriansDay(int year)
        {
            return new HolidaySpecification
            {
                Id = "SAINTFLORIANSDAY-01",
                Date = new DateTime(year, 5, 4),
                EnglishName = "Saint Florian's Day",
                LocalName = "Florianitag",
                HolidayTypes = HolidayTypes.School,
                SubdivisionCodes = ["AT-4"]
            };
        }

        private HolidaySpecification SaintRupertsDay(int year)
        {
            return new HolidaySpecification
            {
                Id = "SAINTRUPERTSDAY-01",
                Date = new DateTime(year, 9, 24),
                EnglishName = "Saint Rupert's Day",
                LocalName = "Rupertitag",
                HolidayTypes = HolidayTypes.School,
                SubdivisionCodes = ["AT-6"]
            };
        }

        private HolidaySpecification SaintMartinsDay(int year)
        {
            return new HolidaySpecification
            {
                Id = "SAINTMARTINSDAY-01",
                Date = new DateTime(year, 11, 11),
                EnglishName = "Saint Martin's Day",
                LocalName = "Martinstag",
                HolidayTypes = HolidayTypes.School,
                SubdivisionCodes = ["AT-1"]
            };
        }

        private HolidaySpecification SaintLeopoldsDay(int year)
        {
            return new HolidaySpecification
            {
                Id = "SAINTLEOPOLDSDAY-01",
                Date = new DateTime(year, 11, 15),
                EnglishName = "Saint Leopold's Day",
                LocalName = "Leopolditag",
                HolidayTypes = HolidayTypes.School,
                SubdivisionCodes = ["AT-3", "AT-9"]
            };
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
