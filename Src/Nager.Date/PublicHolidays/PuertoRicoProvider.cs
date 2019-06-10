using System;
using System.Collections.Generic;
using System.Linq;
using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Puerto Rico
    /// </summary>
    public class PuertoRicoProvider : IPublicHolidayProvider
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

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.PR;

            var easterSunday = this._catholicProvider.EasterSunday(year);
            var secondMondayInJanuary = DateSystem.FindDay(year, 1, DayOfWeek.Monday, 2);
            var thirdMondayInJanuary = DateSystem.FindDay(year, 1, DayOfWeek.Monday, 3);
            var thirdMondayInFebruary = DateSystem.FindDay(year, 2, DayOfWeek.Monday, 3);
            var thirdMondayInApril = DateSystem.FindDay(year, 4, DayOfWeek.Monday, 3);
            var lastMondayInMay = DateSystem.FindLastDay(year, 5, DayOfWeek.Monday);
            var thirdMondayInJuly = DateSystem.FindDay(year, 7, DayOfWeek.Monday, 3);
            var firstMondayInSeptember = DateSystem.FindDay(year, 9, DayOfWeek.Monday, 1);
            var secondMondayInOctober = DateSystem.FindDay(year, 10, DayOfWeek.Monday, 2);
            var fourthThursdayInNovember = DateSystem.FindDay(year, 11, DayOfWeek.Thursday, 4);

            var items = new List<PublicHoliday>();

            #region New Years Day with fallback

            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(newYearsDay, "Día de Año Nuevo", "New Year's Day", countryCode));

            #endregion

            items.Add(new PublicHoliday(year, 1, 6, "Día de Reyes", "Three Kings Day / Epiphany", countryCode));
            items.Add(new PublicHoliday(secondMondayInJanuary, "Natalicio de Eugenio María de Hostos", "Birthday of Eugenio María de Hostos", countryCode));
            items.Add(new PublicHoliday(thirdMondayInJanuary, "Natalicio de Martin Luther King, Jr.", "Martin Luther King, Jr. Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInFebruary, "Día de los Presidentes", "Presidents' Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 18, "Natalicio de Luis Muñoz Marín", "Birthday of Luis Muñoz Marín", countryCode));
            items.Add(new PublicHoliday(year, 3, 22, "Día de la Abolición de Esclavitud", "Emancipation Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(thirdMondayInApril, "Natalicio de José de Diego", "Birthday of José de Diego", countryCode));
            items.Add(new PublicHoliday(lastMondayInMay, "Recordación de los Muertos de la Guerra", "Memorial Day", countryCode));

            #region Independence Day with fallback

            var independenceDay = new DateTime(year, 7, 4).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(independenceDay, "Día de la Independencia de los Estados Unidos", "Independence Day", countryCode));

            #endregion
            
            items.Add(new PublicHoliday(thirdMondayInJuly, "Natalicio de Don Luis Muñoz Rivera", "Birthday of Don Luis Muñoz Rivera", countryCode));
            items.Add(new PublicHoliday(year, 7, 25, "Constitución de Puerto Rico", "Puerto Rico Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 27, "Natalicio de Dr. José Celso Barbosa", "Birthday of Dr. José Celso Barbosa", countryCode));
            items.Add(new PublicHoliday(firstMondayInSeptember, "Día del Trabajo", "Labour Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInOctober, "Día de la Raza Descubrimiento de América", "Columbus Day", countryCode));

            #region Veterans Day with fallback

            var veteransDay = new DateTime(year, 11, 11).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(veteransDay, "Día del Veterano Día del Armisticio", "Veterans Day", countryCode));

            #endregion
            
            items.Add(new PublicHoliday(year, 11, 19, "Día del Descubrimiento de Puerto Rico", "Discovery of Puerto Rico", countryCode));
            items.Add(new PublicHoliday(fourthThursdayInNovember, "Día de Acción de Gracias", "Thanksgiving Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Noche Buena", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            
            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
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
