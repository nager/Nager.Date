using Nager.Date.Extensions;
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

            holidaySpecifications.AddIfNotNull(this.DayOfTheConstitution(year));

            return holidaySpecifications;
        }

        private HolidaySpecification DayOfTheConstitution(int year)
        {
            var englishName = "Day of the Constitution of the Slovak Republic";
            var localName = "Deň Ústavy Slovenskej republiky";
            var holidayDate = new DateTime(year, 9, 1);

            if (year > 2024)
            {
                return new HolidaySpecification
                {
                    Date = holidayDate,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Observance
                };
            }

            return new HolidaySpecification
            {
                Date = holidayDate,
                EnglishName = englishName,
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Slovakia",
                "https://mzv.sk/en/web/en/slovakia/public-holidays"
            ];
        }
    }
}
