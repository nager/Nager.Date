using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Ukraine HolidayProvider
    /// </summary>
    internal sealed class UkraineHolidayProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Ukraine HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public UkraineHolidayProvider(
            IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.UA;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Новий Рік",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "(Julian) Christmas",
                    LocalName = "Різдво",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Міжнародний жіночий день",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "День праці",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Victory day over Nazism in World War II",
                    LocalName = "День перемоги над нацизмом у Другій світовій війні",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 28),
                    EnglishName = "Constitution Day",
                    LocalName = "День Конституції",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 24),
                    EnglishName = "Independence Day",
                    LocalName = "День Незалежності",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 14),
                    EnglishName = "Defender of Ukraine Day",
                    LocalName = "День захисника України",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "(Gregorian and Revised Julian) Christmas",
                    LocalName = "Різдво",
                    HolidayTypes = HolidayTypes.Public
                },
                this._orthodoxProvider.EasterSunday("Великдень", year),
                this._orthodoxProvider.Pentecost("Трійця", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Новий Рік", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 7, "Різдво", "(Julian) Christmas", countryCode));
            //items.Add(new Holiday(year, 3, 8, "Міжнародний жіночий день", "International Women's Day", countryCode));
            //items.Add(this._orthodoxProvider.EasterSunday("Великдень", year, countryCode));
            //items.Add(this._orthodoxProvider.Pentecost("Трійця", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "День праці", "International Workers' Day", countryCode));
            //items.Add(new Holiday(year, 5, 9, "День перемоги над нацизмом у Другій світовій війні", "Victory day over Nazism in World War II", countryCode));
            //items.Add(new Holiday(year, 6, 28, "День Конституції", "Constitution Day", countryCode));
            //items.Add(new Holiday(year, 8, 24, "День Незалежності", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 10, 14, "День захисника України", "Defender of Ukraine Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Різдво", "(Gregorian and Revised Julian) Christmas", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Ukraine"
            };
        }
    }
}
