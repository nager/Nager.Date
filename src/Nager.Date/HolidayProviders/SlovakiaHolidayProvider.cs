using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Slovakia HolidayProvider
    /// </summary>
    internal sealed class SlovakiaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Slovakia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SlovakiaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.SK)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "Day of the Establishment of the Slovak Republic",
                    LocalName = "Deň vzniku Slovenskej republiky",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Zjavenie Pána",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "Sviatok práce",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 8),
                    EnglishName = "Day of victory over fascism",
                    LocalName = "Deň víťazstva nad fašizmom",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 5),
                    EnglishName = "St. Cyril and Methodius Day",
                    LocalName = "Sviatok svätého Cyrila a svätého Metoda",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 29),
                    EnglishName = "Slovak National Uprising anniversary",
                    LocalName = "Výročie Slovenského národného povstania",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 1),
                    EnglishName = "Day of the Constitution of the Slovak Republic",
                    LocalName = "Deň Ústavy Slovenskej republiky",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 15),
                    EnglishName = "Day of Our Lady of the Seven Sorrows",
                    LocalName = "Sedembolestná Panna Mária",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints’ Day",
                    LocalName = "Sviatok Všetkých svätých",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 17),
                    EnglishName = "Struggle for Freedom and Democracy Day",
                    LocalName = "Deň boja za slobodu a demokraciu",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Štedrý deň",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Prvý sviatok vianočný",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Druhý sviatok vianočný",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Veľkonočný piatok", year),
                this._catholicProvider.EasterMonday("Veľkonočný pondelok", year)
            };

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Deň vzniku Slovenskej republiky", "Day of the Establishment of the Slovak Republic", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Zjavenie Pána", "Epiphany", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Veľkonočný piatok", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Veľkonočný pondelok", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Sviatok práce", "International Workers' Day", countryCode));
            //items.Add(new Holiday(year, 5, 8, "Deň víťazstva nad fašizmom", "Day of victory over fascism", countryCode));
            //items.Add(new Holiday(year, 7, 5, "Sviatok svätého Cyrila a svätého Metoda", "St. Cyril and Methodius Day", countryCode));
            //items.Add(new Holiday(year, 8, 29, "Výročie Slovenského národného povstania", "Slovak National Uprising anniversary", countryCode));
            //items.Add(new Holiday(year, 9, 1, "Deň Ústavy Slovenskej republiky", "Day of the Constitution of the Slovak Republic", countryCode));
            //items.Add(new Holiday(year, 9, 15, "Sedembolestná Panna Mária", "Day of Our Lady of the Seven Sorrows", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Sviatok Všetkých svätých", "All Saints’ Day", countryCode));
            //items.Add(new Holiday(year, 11, 17, "Deň boja za slobodu a demokraciu", "Struggle for Freedom and Democracy Day", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Štedrý deň", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Prvý sviatok vianočný", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Druhý sviatok vianočný", "St. Stephen's Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Slovakia"
            ];
        }
    }
}
