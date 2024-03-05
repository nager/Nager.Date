using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Malta HolidayProvider
    /// </summary>
    internal sealed class MaltaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Malta HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MaltaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MT;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "L-Ewwel tas-Sena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 10),
                    EnglishName = "Feast of St. Paul's Shipwreck",
                    LocalName = "In-Nawfraġju ta’ San Pawl",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 19),
                    EnglishName = "Feast of St. Joseph",
                    LocalName = "San Ġużepp",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 31),
                    EnglishName = "Freedom Day",
                    LocalName = "Jum il-Ħelsien",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Worker's Day",
                    LocalName = "Jum il-Ħaddiem",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 7),
                    EnglishName = "Sette Giugno",
                    LocalName = "Sette Giugno",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 29),
                    EnglishName = "Feast of St.Peter and St.Paul",
                    LocalName = "L-Imnarja",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Santa Marija",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 8),
                    EnglishName = "Feast of Our Lady of Victories",
                    LocalName = "Il-Vittorja",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 21),
                    EnglishName = "Independence Day",
                    LocalName = "L-Indipendenza",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Feast of the Immaculate Conception",
                    LocalName = "L-Immakulata Kunċizzjoni",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 13),
                    EnglishName = "Republic Day",
                    LocalName = "Jum ir-Repubblika",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "​Christmas Day",
                    LocalName = "Il-Milied​",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Il-Ġimgħa l-Kbira", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "L-Ewwel tas-Sena", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 2, 10, "In-Nawfraġju ta’ San Pawl", "Feast of St. Paul's Shipwreck", countryCode));
            //items.Add(new Holiday(year, 3, 19, "San Ġużepp", "Feast of St. Joseph", countryCode));
            //items.Add(new Holiday(year, 3, 31, "Jum il-Ħelsien", "Freedom Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Il-Ġimgħa l-Kbira", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Jum il-Ħaddiem", "Worker's Day", countryCode));
            //items.Add(new Holiday(year, 6, 7, "Sette Giugno", "​Sette Giugno", countryCode));
            //items.Add(new Holiday(year, 6, 29, "L-Imnarja", "​​Feast of St.Peter and St.Paul", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Santa Marija", "Assumption Day", countryCode));
            //items.Add(new Holiday(year, 9, 8, "Il-Vittorja", "Feast of Our Lady of Victories", countryCode));
            //items.Add(new Holiday(year, 9, 21, "L-Indipendenza", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 12, 8, "L-Immakulata Kunċizzjoni", "​Feast of the Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 13, "Jum ir-Repubblika", "Republic Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Il-Milied​", "​Christmas Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Malta"
            };
        }
    }
}
