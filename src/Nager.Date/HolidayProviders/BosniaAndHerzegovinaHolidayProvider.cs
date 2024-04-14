using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bosnia and Herzegovina HolidayProvider
    /// </summary>
    internal sealed class BosniaAndHerzegovinaHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// BosniaAndHerzegovina HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public BosniaAndHerzegovinaHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.BA)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "BA-BIH", "Federation of Bosnia and Herzegovina" },
                { "BA-SRP", "Republic of Serbia" }
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
                    LocalName = "Nova Godina",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "Nova Godina",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Christmas Eve (Orthodox)",
                    LocalName = "Božić (za pravoslavce)",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BA-SRP"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Christmas Day (Orthodox)",
                    LocalName = "Božić (za pravoslavce)",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BA-SRP"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 1),
                    EnglishName = "Idependence day",
                    LocalName = "Dan nezavisnosti Bosne i Hercegovine",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BA-BIH"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day / International Workers' Day",
                    LocalName = "Praznik rada",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 2),
                    EnglishName = "May Day / International Workers' Day",
                    LocalName = "Praznik rada",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Victory Day over fascism",
                    LocalName = "Dan pobjede nad fašizmom",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BA-SRP"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 21),
                    EnglishName = "Day of the establishment of the General Framework Agreement for Peace in BiH",
                    LocalName = "Dan uspostavljanja Opšteg okvirnog sporazuma za mir u BiH",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BA-SRP"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 25),
                    EnglishName = "Statehood Day",
                    LocalName = "Dan državnosti Bosne i Hercegovine",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BA-BIH"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve (Roman Catholic)",
                    LocalName = "Božić (za rimokatolike)",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BA-BIH"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day (Roman Catholic)",
                    LocalName = "Božić (za rimokatolike)",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["BA-BIH"]
                },
                this._orthodoxProvider.GoodFriday("Veliki petak", year).SetSubdivisionCodes("BA-SRP"),
                this._orthodoxProvider.EasterSunday("Vaskrs (Uskrs)", year).SetSubdivisionCodes("BA-SRP"),
                this._orthodoxProvider.EasterMonday("Vaskrsni (Uskrsni) ponedeljak", year).SetSubdivisionCodes("BA-SRP")
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bosnia_and_Herzegovina"
            ];
        }
    }
}
