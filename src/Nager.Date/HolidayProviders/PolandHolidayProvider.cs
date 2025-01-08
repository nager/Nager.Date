using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Poland HolidayProvider
    /// </summary>
    internal sealed class PolandHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Poland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PolandHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.PL)
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
                    EnglishName = "New Year's Day",
                    LocalName = "Nowy Rok",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Święto Trzech Króli",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "Święto Pracy",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 3),
                    EnglishName = "Constitution Day",
                    LocalName = "Święto Narodowe Trzeciego Maja",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Wniebowzięcie Najświętszej Maryi Panny",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Wszystkich Świętych",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Independence Day",
                    LocalName = "Narodowe Święto Niepodległości",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Boże Narodzenie",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Drugi Dzień Bożego Narodzenia",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("Wielkanoc", year),
                this._catholicProvider.EasterMonday("Drugi Dzień Wielkanocy", year),
                this._catholicProvider.Pentecost("Zielone Świątki", year),
                this._catholicProvider.CorpusChristi("Boże Ciało", year)
            };

            holidaySpecifications.AddIfNotNull(this.IndependenceDay(year));
            holidaySpecifications.AddIfNotNull(this.ChristmasEve(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? ChristmasEve(int year)
        {
            if (year >= 2025)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Wolna Wigilia",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? IndependenceDay(int year)
        {
            if (year == 2018)
            {
                //100th anniversary
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 12),
                    EnglishName = "Independence Day",
                    LocalName = "Narodowe Święto Niepodległości",
                    HolidayTypes = HolidayTypes.Public
                };

                //items.Add(new Holiday(year, 11, 12, "Narodowe Święto Niepodległości", "Independence Day", countryCode));
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Poland"
            ];
        }
    }
}
