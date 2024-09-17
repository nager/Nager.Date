using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Croatia HolidayProvider
    /// </summary>
    internal sealed class CroatiaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Croatia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CroatiaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.HR)
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
                    LocalName = "Nova Godina",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Bogojavljenje, Sveta tri kralja",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "Međunarodni praznik rada",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 22),
                    EnglishName = "Anti-Fascist Struggle Day",
                    LocalName = "Dan antifašističke borbe",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 5),
                    EnglishName = "Victory and Homeland Thanksgiving Day and the Day of Croatian defenders",
                    LocalName = "Dan pobjede i domovinske zahvalnosti i Dan hrvatskih branitelja",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Velika Gospa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Dan svih svetih",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Božić",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Prvi dan po Božiću, Sveti Stjepan, Štefanje, Stipanje",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("Uskrs i uskrsni ponedjeljak", year),
                this._catholicProvider.EasterMonday("Uskrs i uskrsni ponedjeljak", year),
                this._catholicProvider.CorpusChristi("Tijelovo", year)
            };

            holidaySpecifications.AddIfNotNull(this.GetIndependenceDay(year));
            holidaySpecifications.AddIfNotNull(this.GetRemembranceDay(year));
            holidaySpecifications.AddIfNotNull(this.GetStatehoodDay(year));
            holidaySpecifications.AddIfNotNull(this.GetNationalDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? GetIndependenceDay(int year)
        {
            if (year >= 2002 && year < 2020)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 8),
                    EnglishName = "Independence Day",
                    LocalName = "Dan neovisnosti",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? GetRemembranceDay(int year)
        {
            if (year >= 2020)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 18),
                    EnglishName = "Remembrance Day",
                    LocalName = "Dan sjećanja na žrtve Domovinskog rata",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? GetStatehoodDay(int year)
        {
            if (year >= 2002 && year < 2020)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 25),
                    EnglishName = "Statehood Day",
                    LocalName = "Dan državnosti",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? GetNationalDay(int year)
        {
            if (year >= 2020)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 30),
                    EnglishName = "National Day",
                    LocalName = "Dan državnosti",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Croatia",
            ];
        }
    }
}
