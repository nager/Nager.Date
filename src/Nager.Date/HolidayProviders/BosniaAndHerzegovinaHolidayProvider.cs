using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bosnia and Herzegovina HolidayProvider
    /// </summary>
    internal sealed class BosniaAndHerzegovinaHolidayProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// BosniaAndHerzegovina HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public BosniaAndHerzegovinaHolidayProvider(
            IOrthodoxProvider orthodoxProvider)
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
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BA;

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

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);


            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Nova Godina", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 2, "Nova Godina", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Božić (za pravoslavce)", "Christmas Eve (Orthodox)", countryCode, null, new string[] { "BA-SRP" }));
            //items.Add(new Holiday(year, 1, 7, "Božić (za pravoslavce)", "Christmas Day (Orthodox)", countryCode, null, new string[] { "BA-SRP" }));
            //items.Add(new Holiday(year, 3, 1, "Dan nezavisnosti Bosne i Hercegovine", "Idependence day", countryCode, null, new string[] { "BA-BIH" }));
            //items.Add(new Holiday(year, 5, 1, "Praznik rada", "May Day / International Workers' Day", countryCode));
            //items.Add(new Holiday(year, 5, 2, "Praznik rada", "May Day / International Workers' Day", countryCode));
            //items.Add(new Holiday(year, 5, 9, "Dan pobjede nad fašizmom", "Victory Day over fascism", countryCode, null, new string[] { "BA-SRP" }));
            //items.Add(new Holiday(year, 11, 21, "Dan uspostavljanja Opšteg okvirnog sporazuma za mir u BiH", "Day of the establishment of the General Framework Agreement for Peace in BiH ", countryCode, null, new string[] { "BA-SRP" }));
            //items.Add(new Holiday(year, 11, 25, "Dan državnosti Bosne i Hercegovine", "Statehood Day", countryCode, null, new string[] { "BA-BIH" }));
            //items.Add(new Holiday(year, 12, 24, "Božić (za rimokatolike)", "Christmas Eve (Roman Catholic)", countryCode, null, new string[] { "BA-BIH" }));
            //items.Add(new Holiday(year, 12, 25, "Božić (za rimokatolike)", "Christmas Day (Roman Catholic)", countryCode, null, new string[] { "BA-BIH" }));

            //items.Add(this._orthodoxProvider.GoodFriday("Veliki petak", year, countryCode).SetCounties("BA-SRP"));
            //items.Add(this._orthodoxProvider.EasterSunday("Vaskrs (Uskrs)", year, countryCode).SetCounties("BA-SRP"));
            //items.Add(this._orthodoxProvider.EasterMonday("Vaskrsni (Uskrsni) ponedeljak", year, countryCode).SetCounties("BA-SRP"));
            

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bosnia_and_Herzegovina"
            ];
        }
    }
}
