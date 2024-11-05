using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Puerto Rico HolidayProvider
    /// </summary>
    internal sealed class PuertoRicoHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Puerto Rico HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PuertoRicoHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.PR)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var secondMondayInJanuary = DateHelper.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Second);
            var thirdMondayInJanuary = DateHelper.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayInFebruary = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayInApril = DateHelper.FindDay(year, Month.April, DayOfWeek.Monday, Occurrence.Third);
            var lastMondayInMay = DateHelper.FindLastDay(year, Month.May, DayOfWeek.Monday);
            var thirdMondayInJuly = DateHelper.FindDay(year, Month.July, DayOfWeek.Monday, Occurrence.Third);
            var firstMondayInSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);
            var fourthThursdayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Thursday, Occurrence.Fourth);

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
                    LocalName = "Día de la Raza / Descubrimiento de América",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Veterans Day",
                    LocalName = "Día del Veterano / Día del Armisticio",
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

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
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
