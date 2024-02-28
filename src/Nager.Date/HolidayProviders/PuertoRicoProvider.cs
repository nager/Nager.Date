using System;
using System.Collections.Generic;
using System.Linq;
using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Puerto Rico
    /// </summary>
    internal class PuertoRicoProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// PuertoRicoProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PuertoRicoProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PR;

            var secondMondayInJanuary = DateSystem.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Second);
            var thirdMondayInJanuary = DateSystem.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayInFebruary = DateSystem.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayInApril = DateSystem.FindDay(year, Month.April, DayOfWeek.Monday, Occurrence.Third);
            var lastMondayInMay = DateSystem.FindLastDay(year, Month.May, DayOfWeek.Monday);
            var thirdMondayInJuly = DateSystem.FindDay(year, Month.July, DayOfWeek.Monday, Occurrence.Third);
            var firstMondayInSeptember = DateSystem.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInOctober = DateSystem.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);
            var fourthThursdayInNovember = DateSystem.FindDay(year, Month.November, DayOfWeek.Thursday, Occurrence.Fourth);

            var items = new List<Holiday>();

            #region New Years Day with fallback

            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            items.Add(new Holiday(newYearsDay, "Día de Año Nuevo", "New Year's Day", countryCode));

            #endregion

            items.Add(new Holiday(year, 1, 6, "Día de Reyes", "Three Kings Day / Epiphany", countryCode));
            items.Add(new Holiday(secondMondayInJanuary, "Natalicio de Eugenio María de Hostos", "Birthday of Eugenio María de Hostos", countryCode));
            items.Add(new Holiday(thirdMondayInJanuary, "Natalicio de Martin Luther King, Jr.", "Martin Luther King, Jr. Day", countryCode));
            items.Add(new Holiday(thirdMondayInFebruary, "Día de los Presidentes", "Presidents' Day", countryCode));
            items.Add(new Holiday(year, 2, 18, "Natalicio de Luis Muñoz Marín", "Birthday of Luis Muñoz Marín", countryCode));
            items.Add(new Holiday(year, 3, 22, "Día de la Abolición de Esclavitud", "Emancipation Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(new Holiday(thirdMondayInApril, "Natalicio de José de Diego", "Birthday of José de Diego", countryCode));
            items.Add(new Holiday(lastMondayInMay, "Recordación de los Muertos de la Guerra", "Memorial Day", countryCode));

            #region Independence Day with fallback

            var independenceDay = new DateTime(year, 7, 4).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            items.Add(new Holiday(independenceDay, "Día de la Independencia de los Estados Unidos", "Independence Day", countryCode));

            #endregion
            
            items.Add(new Holiday(thirdMondayInJuly, "Natalicio de Don Luis Muñoz Rivera", "Birthday of Don Luis Muñoz Rivera", countryCode));
            items.Add(new Holiday(year, 7, 25, "Constitución de Puerto Rico", "Puerto Rico Constitution Day", countryCode));
            items.Add(new Holiday(year, 7, 27, "Natalicio de Dr. José Celso Barbosa", "Birthday of Dr. José Celso Barbosa", countryCode));
            items.Add(new Holiday(firstMondayInSeptember, "Día del Trabajo", "Labour Day", countryCode));
            items.Add(new Holiday(secondMondayInOctober, "Día de la Raza Descubrimiento de América", "Columbus Day", countryCode));

            #region Veterans Day with fallback

            var veteransDay = new DateTime(year, 11, 11).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            items.Add(new Holiday(veteransDay, "Día del Veterano Día del Armisticio", "Veterans Day", countryCode));

            #endregion
            
            items.Add(new Holiday(year, 11, 19, "Día del Descubrimiento de Puerto Rico", "Discovery of Puerto Rico", countryCode));
            items.Add(new Holiday(fourthThursdayInNovember, "Día de Acción de Gracias", "Thanksgiving Day", countryCode));
            items.Add(new Holiday(year, 12, 24, "Noche Buena", "Christmas Eve", countryCode));
            items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            
            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Puerto_Rico",
                "https://www.timeanddate.com/holidays/puerto-rico/2017#!hol=9",
                "http://www.puertorico.com/official-holidays/",
                "http://www.topuertorico.org/reference/holi.shtml"
            };
        }
    }
}
