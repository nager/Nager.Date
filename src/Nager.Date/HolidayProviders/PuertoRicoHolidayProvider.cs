using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Puerto Rico HolidayProvider
    /// </summary>
    internal sealed class PuertoRicoHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Puerto Rico HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PuertoRicoHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PR;

            var secondMondayInJanuary = DateHelper.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Second);
            var thirdMondayInJanuary = DateHelper.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayInFebruary = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayInApril = DateHelper.FindDay(year, Month.April, DayOfWeek.Monday, Occurrence.Third);
            var lastMondayInMay = DateHelper.FindLastDay(year, Month.May, DayOfWeek.Monday);
            var thirdMondayInJuly = DateHelper.FindDay(year, Month.July, DayOfWeek.Monday, Occurrence.Third);
            var firstMondayInSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);
            var fourthThursdayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Thursday, Occurrence.Fourth);

            //var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            //var independenceDay = new DateTime(year, 7, 4).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            //var veteransDay = new DateTime(year, 11, 11).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));

            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(-1),
                Sunday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Día de Año Nuevo",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Three Kings Day / Epiphany",
                    LocalName = "Día de Reyes",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = secondMondayInJanuary,
                    EnglishName = "Birthday of Eugenio María de Hostos",
                    LocalName = "Natalicio de Eugenio María de Hostos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInJanuary,
                    EnglishName = "Martin Luther King, Jr. Day",
                    LocalName = "Natalicio de Martin Luther King, Jr.",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInFebruary,
                    EnglishName = "Presidents' Day",
                    LocalName = "Día de los Presidentes",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 18),
                    EnglishName = "Birthday of Luis Muñoz Marín",
                    LocalName = "Natalicio de Luis Muñoz Marín",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 22),
                    EnglishName = "Emancipation Day",
                    LocalName = "Día de la Abolición de Esclavitud",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 4),
                    EnglishName = "Independence Day",
                    LocalName = "Día de la Independencia de los Estados Unidos",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInApril,
                    EnglishName = "Birthday of José de Diego",
                    LocalName = "Natalicio de José de Diego",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = lastMondayInMay,
                    EnglishName = "Memorial Day",
                    LocalName = "Recordación de los Muertos de la Guerra",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInJuly,
                    EnglishName = "Birthday of Don Luis Muñoz Rivera",
                    LocalName = "Natalicio de Don Luis Muñoz Rivera",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 25),
                    EnglishName = "Puerto Rico Constitution Day",
                    LocalName = "Constitución de Puerto Rico",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 27),
                    EnglishName = "Birthday of Dr. José Celso Barbosa",
                    LocalName = "Natalicio de Dr. José Celso Barbosa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstMondayInSeptember,
                    EnglishName = "Labour Day",
                    LocalName = "Día del Trabajo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = secondMondayInOctober,
                    EnglishName = "Columbus Day",
                    LocalName = "Día de la Raza Descubrimiento de América",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Veterans Day",
                    LocalName = "Día del Veterano Día del Armisticio",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 19),
                    EnglishName = "Discovery of Puerto Rico",
                    LocalName = "Día del Descubrimiento de Puerto Rico",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = fourthThursdayInNovember,
                    EnglishName = "Thanksgiving Day",
                    LocalName = "Día de Acción de Gracias",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Noche Buena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Viernes Santo", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(newYearsDay, "Día de Año Nuevo", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Día de Reyes", "Three Kings Day / Epiphany", countryCode));
            //items.Add(new Holiday(secondMondayInJanuary, "Natalicio de Eugenio María de Hostos", "Birthday of Eugenio María de Hostos", countryCode));
            //items.Add(new Holiday(thirdMondayInJanuary, "Natalicio de Martin Luther King, Jr.", "Martin Luther King, Jr. Day", countryCode));
            //items.Add(new Holiday(thirdMondayInFebruary, "Día de los Presidentes", "Presidents' Day", countryCode));
            //items.Add(new Holiday(year, 2, 18, "Natalicio de Luis Muñoz Marín", "Birthday of Luis Muñoz Marín", countryCode));
            //items.Add(new Holiday(year, 3, 22, "Día de la Abolición de Esclavitud", "Emancipation Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            //items.Add(new Holiday(independenceDay, "Día de la Independencia de los Estados Unidos", "Independence Day", countryCode));
            //items.Add(new Holiday(thirdMondayInApril, "Natalicio de José de Diego", "Birthday of José de Diego", countryCode));
            //items.Add(new Holiday(lastMondayInMay, "Recordación de los Muertos de la Guerra", "Memorial Day", countryCode));           
            //items.Add(new Holiday(thirdMondayInJuly, "Natalicio de Don Luis Muñoz Rivera", "Birthday of Don Luis Muñoz Rivera", countryCode));
            //items.Add(new Holiday(year, 7, 25, "Constitución de Puerto Rico", "Puerto Rico Constitution Day", countryCode));
            //items.Add(new Holiday(year, 7, 27, "Natalicio de Dr. José Celso Barbosa", "Birthday of Dr. José Celso Barbosa", countryCode));
            //items.Add(new Holiday(firstMondayInSeptember, "Día del Trabajo", "Labour Day", countryCode));
            //items.Add(new Holiday(secondMondayInOctober, "Día de la Raza Descubrimiento de América", "Columbus Day", countryCode));
            //items.Add(new Holiday(veteransDay, "Día del Veterano Día del Armisticio", "Veterans Day", countryCode));
            //items.Add(new Holiday(year, 11, 19, "Día del Descubrimiento de Puerto Rico", "Discovery of Puerto Rico", countryCode));
            //items.Add(new Holiday(fourthThursdayInNovember, "Día de Acción de Gracias", "Thanksgiving Day", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Noche Buena", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Puerto_Rico",
                "https://www.timeanddate.com/holidays/puerto-rico/2017#!hol=9",
                "http://www.puertorico.com/official-holidays/",
                "http://www.topuertorico.org/reference/holi.shtml"
            ];
        }
    }
}
