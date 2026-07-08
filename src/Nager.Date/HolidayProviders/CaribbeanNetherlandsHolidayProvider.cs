using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Caribbean Netherlands HolidayProvider
    /// </summary>
    /// <remarks>These are the islands of Bonaire, Sint Eustatius, and Saba</remarks>
    internal sealed class CaribbeanNetherlandsHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Caribbean Netherlands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CaribbeanNetherlandsHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.BQ)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "BQ-BO", "Bonaire" },
                { "BQ-SE", "Sint Eustatius" },
                { "BQ-SA", "Saba" },
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nieuwjaarsdag",
                    HolidayTypes = HolidayTypes.Public,
                },
                //new HolidaySpecification
                //{
                //    Id = "CARNIVAL-01",
                //    Date = easterSunday.AddDays(-48),
                //    EnglishName = "Carnival Monday",
                //    LocalName = "Carnival Monday",
                //    HolidayTypes = HolidayTypes.Public,
                //},
                new HolidaySpecification
                {
                    Id = "KINGSBIRTHDAY-01",
                    Date = new DateTime(year, 4, 27),
                    EnglishName = "King's Birthday",
                    LocalName = "King's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "RINCONDAY-01",
                    Date = new DateTime(year, 4, 30),
                    EnglishName = "Rincon Day",
                    LocalName = "Rincon Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BQ-BO"],
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Dag van de Arbeid",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "BONAIREFLAGDAY-01",
                    Date = new DateTime(year, 9, 6),
                    EnglishName = "Bonaire Flag Day",
                    LocalName = "Vlagdag bonaire",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BQ-BO"],
                },
                new HolidaySpecification
                {
                    Id = "SABAFLAGDAY-01",
                    Date = new DateTime(year, 12, 6),
                    EnglishName = "Saba Flag Day",
                    LocalName = "Vlagdag saba",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BQ-SA"],
                },
                new HolidaySpecification
                {
                    Id = "EMANCIPATIONDAY-01",
                    Date = new DateTime(year, 7, 1),
                    EnglishName = "Emancipation Day",
                    LocalName = "Emancipation Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BQ-SE"],
                },
                new HolidaySpecification
                {
                    Id = "STATIADAY-01",
                    Date = new DateTime(year, 11, 16),
                    EnglishName = "Statia Day",
                    LocalName = "Statia Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BQ-SE"],
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Kerstmis",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Second Day of Christmas",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Goede Vrijdag", year),
                this._catholicProvider.EasterSunday("Pasen", year),
                this._catholicProvider.EasterMonday("Paasmaandag", year),
                this._catholicProvider.AscensionDay("Hemelvaartsdag", year),
                this._catholicProvider.Pentecost("Pinksteren", year),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bonaire",
                "https://www.statiagovernment.com/governance/official-public-holidays",
                "https://en.wikipedia.org/wiki/Public_holidays_in_Saba",
            ];
        }
    }
}
