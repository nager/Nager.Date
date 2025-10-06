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
                    Id = "ESTABLISHMENTSLOVAKREPUBLIC-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "Day of the Establishment of the Slovak Republic",
                    LocalName = "Deň vzniku Slovenskej republiky",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "EPIPHANY-01",
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Zjavenie Pána",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWORKERSDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "Sviatok práce",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "STCYRILANDMETHODIUSDAY-01",
                    Date = new DateTime(year, 7, 5),
                    EnglishName = "St. Cyril and Methodius Day",
                    LocalName = "Sviatok svätého Cyrila a svätého Metoda",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "SLOVAKNATIONALUPRISING-01",
                    Date = new DateTime(year, 8, 29),
                    EnglishName = "Slovak National Uprising anniversary",
                    LocalName = "Výročie Slovenského národného povstania",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints’ Day",
                    LocalName = "Sviatok Všetkých svätých",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASEVE-01",
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Štedrý deň",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Prvý sviatok vianočný",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Druhý sviatok vianočný",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Veľkonočný piatok", year),
                this._catholicProvider.EasterMonday("Veľkonočný pondelok", year)
            };

            holidaySpecifications.AddIfNotNull(this.DayOfTheConstitution(year));
            holidaySpecifications.AddIfNotNull(this.DayOfOurLadyOfTheSevenSorrows(year));
            holidaySpecifications.AddIfNotNull(this.DayOfVictoryOverFascism(year));
            holidaySpecifications.AddIfNotNull(this.StruggleForFreedonAndDemocracyDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification DayOfTheConstitution(int year)
        {
            var id = "CONSTITUTIONDAY-01";
            var englishName = "Day of the Constitution of the Slovak Republic";
            var localName = "Deň Ústavy Slovenskej republiky";
            var holidayDate = new DateTime(year, 9, 1);

            return new HolidaySpecification
            {
                Id = id,
                Date = holidayDate,
                EnglishName = englishName,
                LocalName = localName,
                HolidayTypes = year > 2024 ? HolidayTypes.Observance : HolidayTypes.Public
            };
        }

        private HolidaySpecification DayOfOurLadyOfTheSevenSorrows(int year)
        {
            var id = "DAYOURLADYSEVENSORROWS-01";
            var englishName = "Day of Our Lady of the Seven Sorrows";
            var localName = "Sedembolestná Panna Mária";
            var holidayDate = new DateTime(year, 9, 15);

            return new HolidaySpecification
            {
                Id = id,
                Date = holidayDate,
                EnglishName = englishName,
                LocalName = localName,
                HolidayTypes = year == 2026 ? HolidayTypes.Observance : HolidayTypes.Public
            };
        }

        private HolidaySpecification DayOfVictoryOverFascism(int year)
        {
            var id = "DAYOFVICTORYOVERFASCISM-01";
            var englishName = "Day of victory over fascism";
            var localName = "Deň víťazstva nad fašizmom";
            var holidayDate = new DateTime(year, 5, 8);

            return new HolidaySpecification
            {
                Id = id,
                Date = holidayDate,
                EnglishName = englishName,
                LocalName = localName,
                HolidayTypes = year == 2026 ? HolidayTypes.Observance : HolidayTypes.Public
            };
        }

        private HolidaySpecification StruggleForFreedonAndDemocracyDay(int year)
        {
            var id = "STRUGGLEFREEDOMDEMOCRACYDAY-01";
            var englishName = "Struggle for Freedom and Democracy Day";
            var localName = "Deň boja za slobodu a demokraciu";
            var holidayDate = new DateTime(year, 11, 17);

            return new HolidaySpecification
            {
                Id = id,
                Date = holidayDate,
                EnglishName = englishName,
                LocalName = localName,
                HolidayTypes = year >= 2026 ? HolidayTypes.Observance : HolidayTypes.Public
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
