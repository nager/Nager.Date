using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Croatia HolidayProvider
    /// </summary>
    internal sealed class CroatiaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Croatia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CroatiaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.HR;

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

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Nova Godina", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Bogojavljenje, Sveta tri kralja", "Epiphany", countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Uskrs i uskrsni ponedjeljak", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Uskrs i uskrsni ponedjeljak", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Međunarodni praznik rada", "International Workers' Day", countryCode));
            //items.Add(this._catholicProvider.CorpusChristi("Tijelovo", year, countryCode));
            //items.Add(new Holiday(year, 6, 22, "Dan antifašističke borbe", "Anti-Fascist Struggle Day", countryCode));
            //items.Add(new Holiday(year, 8, 5, "Dan pobjede i domovinske zahvalnosti i Dan hrvatskih branitelja", "Victory and Homeland Thanksgiving Day and the Day of Croatian defenders", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Velika Gospa", "Assumption Day", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Dan svih svetih", "All Saints' Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Božić", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Prvi dan po Božiću, Sveti Stjepan, Štefanje, Stipanje", "St.Stephen's Day", countryCode));

            //items.AddIfNotNull(this.GetIndependenceDay(year, countryCode));
            //items.AddIfNotNull(this.GetRemembranceDay(year, countryCode));
            //items.AddIfNotNull(this.GetStatehoodDay(year, countryCode));
            //items.AddIfNotNull(this.GetNationalDay(year, countryCode));

            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification GetIndependenceDay(int year)
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

                //return new Holiday(year, 10, 8, "Dan neovisnosti", "Independence Day", countryCode);
            }

            return null;
        }

        private HolidaySpecification GetRemembranceDay(int year)
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

                //return new Holiday(year, 11, 18, "Dan sjećanja na žrtve Domovinskog rata", "Remembrance Day", countryCode);
            }

            return null;
        }

        private HolidaySpecification GetStatehoodDay(int year)
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

                //return new Holiday(year, 6, 25, "Dan državnosti", "Statehood Day", countryCode);
            }

            return null;
        }

        private HolidaySpecification GetNationalDay(int year)
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

                //return new Holiday(year, 5, 30, "Dan državnosti", "National Day", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Croatia",
            ];
        }
    }
}
