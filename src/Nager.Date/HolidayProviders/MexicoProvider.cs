using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mexico 
    /// </summary>
    internal class MexicoProvider : IHolidayProvider
    {
        /// <summary>
        /// MexicoProvider
        /// </summary>
        public MexicoProvider()
        {
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            //Only Statutory holidays
            var countryCode = CountryCode.MX;

            var firstMondayOfFebruary = DateSystem.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.First);
            var thirdMondayOfMarch = DateSystem.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayOfNovember = DateSystem.FindDay(year, Month.November, DayOfWeek.Monday, Occurrence.Third);

            var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            var laborDay = new DateTime(year, 5, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            var independenceDay = new DateTime(year, 9, 16).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));

            var items = new List<Holiday>();
            items.Add(new Holiday(newYearDay, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new Holiday(firstMondayOfFebruary, "Día de la Constitución", "Constitution Day", countryCode));
            items.Add(new Holiday(thirdMondayOfMarch, "Natalicio de Benito Juárez", "Benito Juárez's birthday", countryCode));
            items.Add(new Holiday(laborDay, "Día del Trabajo", "Labor Day", countryCode));
            items.Add(new Holiday(independenceDay, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new Holiday(thirdMondayOfNovember, "Día de la Revolución", "Revolution Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            items.AddIfNotNull(this.InaugurationDay(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday InaugurationDay(int year, CountryCode countryCode)
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
                    return new Holiday(year, 12, 1, "Transmisión del Poder Ejecutivo Federal", "Inauguration Day", countryCode);
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
                    return new Holiday(year, 10, 1, "Transmisión del Poder Ejecutivo Federal", "Inauguration Day", countryCode);
            }

            return null;
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mexico"
            };
        }
    }
}
