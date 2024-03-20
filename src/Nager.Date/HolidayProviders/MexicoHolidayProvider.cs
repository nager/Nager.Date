using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mexico HolidayProvider
    /// </summary>
    internal sealed class MexicoHolidayProvider : IHolidayProvider
    {
        /// <summary>
        /// Mexico HolidayProvider
        /// </summary>
        public MexicoHolidayProvider()
        {
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            //Only Statutory holidays
            var countryCode = CountryCode.MX;

            var firstMondayOfFebruary = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.First);
            var thirdMondayOfMarch = DateHelper.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayOfNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Monday, Occurrence.Third);

            //var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            //var laborDay = new DateTime(year, 5, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            //var independenceDay = new DateTime(year, 9, 16).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));

            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(-1),
                Sunday = date => date.AddDays(1)
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = firstMondayOfFebruary,
                    EnglishName = "Constitution Day",
                    LocalName = "Día de la Constitución",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdMondayOfMarch,
                    EnglishName = "Benito Juárez's birthday",
                    LocalName = "Natalicio de Benito Juárez",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labor Day",
                    LocalName = "Día del Trabajo",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 16),
                    EnglishName = "Independence Day",
                    LocalName = "Día de la Independencia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdMondayOfNovember,
                    EnglishName = "Revolution Day",
                    LocalName = "Día de la Revolución",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            holidaySpecifications.AddIfNotNull(this.InaugurationDay(year));

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(newYearDay, "Año Nuevo", "New Year's Day", countryCode));
            //items.Add(new Holiday(firstMondayOfFebruary, "Día de la Constitución", "Constitution Day", countryCode));
            //items.Add(new Holiday(thirdMondayOfMarch, "Natalicio de Benito Juárez", "Benito Juárez's birthday", countryCode));
            //items.Add(new Holiday(laborDay, "Día del Trabajo", "Labor Day", countryCode));
            //items.Add(new Holiday(independenceDay, "Día de la Independencia", "Independence Day", countryCode));
            //items.Add(new Holiday(thirdMondayOfNovember, "Día de la Revolución", "Revolution Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            //items.AddIfNotNull(this.InaugurationDay(year, countryCode));
            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification InaugurationDay(int year)
        {
            // The president in Mexico is usually elected every 6 years
            // A reform was introduced in 2014 that changes the date from 2024

            switch (year)
            {
                case 1934:
                case 1940:
                case 1946:
                case 1952:
                case 1958:
                case 1964:
                case 1970:
                case 1976:
                case 1982:
                case 1988:
                case 1994:
                case 2000:
                case 2006:
                case 2012:
                case 2018:
                    return new HolidaySpecification
                    {
                        Date = new DateTime(year, 12, 1),
                        EnglishName = "Inauguration Day",
                        LocalName = "Transmisión del Poder Ejecutivo Federal",
                        HolidayTypes = HolidayTypes.Public
                    };

                    //return new Holiday(year, 12, 1, "Transmisión del Poder Ejecutivo Federal", "Inauguration Day", countryCode);
                case 2024:
                case 2030:
                case 2036:
                case 2042:
                case 2048:
                case 2054:
                case 2060:
                case 2066:
                case 2072:
                case 2078:
                    return new HolidaySpecification
                    {
                        Date = new DateTime(year, 10, 1),
                        EnglishName = "Inauguration Day",
                        LocalName = "Transmisión del Poder Ejecutivo Federal",
                        HolidayTypes = HolidayTypes.Public
                    };

                    //return new Holiday(year, 10, 1, "Transmisión del Poder Ejecutivo Federal", "Inauguration Day", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mexico"
            ];
        }
    }
}
