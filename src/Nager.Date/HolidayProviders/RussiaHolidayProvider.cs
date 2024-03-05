using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Russia HolidayProvider
    /// </summary>
    internal sealed class RussiaHolidayProvider : IHolidayProvider
    {
        /// <summary>
        /// Russia HolidayProvider
        /// </summary>
        public RussiaHolidayProvider()
        {
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.RU;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Новый год",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year holiday",
                    LocalName = "Новогодние каникулы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 3),
                    EnglishName = "New Year holiday",
                    LocalName = "Новогодние каникулы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 4),
                    EnglishName = "New Year holiday",
                    LocalName = "Новогодние каникулы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 5),
                    EnglishName = "New Year holiday",
                    LocalName = "Новогодние каникулы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "New Year holiday",
                    LocalName = "Новогодние каникулы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Orthodox Christmas Day",
                    LocalName = "Рождество Христово",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 23),
                    EnglishName = "Defender of the Fatherland Day",
                    LocalName = "День защитника Отечества",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Международный женский день",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "День труда",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Victory Day",
                    LocalName = "День Победы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 12),
                    EnglishName = "Russia Day",
                    LocalName = "День России",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 4),
                    EnglishName = "Unity Day",
                    LocalName = "День народного единства",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Новый год", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 2, "Новогодние каникулы", "New Year holiday", countryCode));
            //items.Add(new Holiday(year, 1, 3, "Новогодние каникулы", "New Year holiday", countryCode));
            //items.Add(new Holiday(year, 1, 4, "Новогодние каникулы", "New Year holiday", countryCode));
            //items.Add(new Holiday(year, 1, 5, "Новогодние каникулы", "New Year holiday", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Новогодние каникулы", "New Year holiday", countryCode));
            //items.Add(new Holiday(year, 1, 7, "Рождество Христово", "Orthodox Christmas Day", countryCode));
            //items.Add(new Holiday(year, 2, 23, "День защитника Отечества", "Defender of the Fatherland Day", countryCode, 1918));
            //items.Add(new Holiday(year, 3, 8, "Международный женский день", "International Women's Day", countryCode, 1913));
            //items.Add(new Holiday(year, 5, 1, "День труда", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 9, "День Победы", "Victory Day", countryCode));
            //items.Add(new Holiday(year, 6, 12, "День России", "Russia Day", countryCode, 2002));
            //items.Add(new Holiday(year, 11, 4, "День народного единства", "Unity Day", countryCode, 2005));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Russia"
            };
        }
    }
}
