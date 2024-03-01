using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Denmark HolidayProvider
    /// </summary>
    internal class DenmarkHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Denmark HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public DenmarkHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.DK;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nytårsdag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 5),
                    EnglishName = "Constitution Day",
                    LocalName = "Grundlovsdag",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Juleaftensdag",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Juledag / 1. juledag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "2. juledag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Nytårsaftensdag",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(40),
                    EnglishName = "Bank closing day",
                    LocalName = "Banklukkedag",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                this._catholicProvider.MaundyThursday("Skærtorsdag", year),
                this._catholicProvider.GoodFriday("Langfredag", year),
                this._catholicProvider.EasterSunday("Påskedag", year),
                this._catholicProvider.EasterMonday("2. Påskedag", year),
                this._catholicProvider.AscensionDay("Kristi Himmelfartsdag", year),
                this._catholicProvider.Pentecost("Pinsedag", year),
                this._catholicProvider.WhitMonday("2. Pinsedag", year)
            };

            holidaySpecifications.AddIfNotNull(this.GeneralPrayerDay(year));

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Nytårsdag", "New Year's Day", countryCode));
            //items.Add(this._catholicProvider.MaundyThursday("Skærtorsdag", year, countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Langfredag", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Påskedag", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("2. Påskedag", year, countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Kristi Himmelfartsdag", year, countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(40), "Banklukkedag", "Bank closing day", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));
            //items.Add(this._catholicProvider.Pentecost("Pinsedag", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("2. Pinsedag", year, countryCode));
            //items.Add(new Holiday(year, 6, 5, "Grundlovsdag", "Constitution Day", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));
            //items.Add(new Holiday(year, 12, 24, "Juleaftensdag", "Christmas Eve", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));
            //items.Add(new Holiday(year, 12, 25, "Juledag / 1. juledag", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "2. juledag", "St. Stephen's Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "Nytårsaftensdag", "New Year's Eve", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));

            //items.AddIfNotNull(this.GeneralPrayerDay(year, countryCode));

            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification GeneralPrayerDay(int year)
        {
            if (year < 2024)
            {
                var easterSunday = this._catholicProvider.EasterSunday(year);

                return new HolidaySpecification
                {
                    Date = easterSunday.AddDays(26),
                    EnglishName = "General Prayer Day",
                    LocalName = "Store bededag",
                    HolidayTypes = HolidayTypes.Public
                };

                //return new Holiday(easterSunday.AddDays(26), "Store bededag", "General Prayer Day", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Denmark",
            };
        }
    }
}
