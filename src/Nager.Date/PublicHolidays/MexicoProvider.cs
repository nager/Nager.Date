using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Mexico 
    /// </summary>
    internal class MexicoProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// MexicoProvider
        /// </summary>
        public MexicoProvider()
        {
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            //Only Statutory holidays
            var countryCode = CountryCode.MX;

            var firstMondayOfFebruary = DateSystem.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.First);
            var thirdMondayOfMarch = DateSystem.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayOfNovember = DateSystem.FindDay(year, Month.November, DayOfWeek.Monday, Occurrence.Third);

            var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            var laborDay = new DateTime(year, 5, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            var independenceDay = new DateTime(year, 9, 16).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(newYearDay, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(firstMondayOfFebruary, "Día de la Constitución", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayOfMarch, "Natalicio de Benito Juárez", "Benito Juárez's birthday", countryCode));
            items.Add(new PublicHoliday(laborDay, "Día del Trabajo", "Labor Day", countryCode));
            items.Add(new PublicHoliday(independenceDay, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayOfNovember, "Día de la Revolución", "Revolution Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            items.AddIfNotNull(this.InaugurationDay(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday InaugurationDay(int year, CountryCode countryCode)
        {
            // Every 6 years on 1. December
            if ((year - 2) % 6 == 0)
            {
                return new PublicHoliday(year, 12, 1, "Transmisión del Poder Ejecutivo Federal", "Inauguration Day", countryCode);
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
