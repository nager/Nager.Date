using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Argentina HolidayProvider
    /// </summary>
    internal class ArgentinaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Argentina HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ArgentinaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AR;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var thirdMondayInAugust = DateSystem.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.Third);
            var secondMondayInOctober = DateSystem.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-47),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 24),
                    EnglishName = "Day of Remembrance for Truth and Justice",
                    LocalName = "Día Nacional de la Memoria por la Verdad y la Justicia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 2),
                    EnglishName = "Day of the Veterans and Fallen of the Malvinas War",
                    LocalName = "Día del Veterano y de los Caídos en la Guerra de Malvinas",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Día del Trabajador",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 25),
                    EnglishName = "May Revolution",
                    LocalName = "Día de la Revolución de Mayo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 17),
                    EnglishName = "Anniversary of the Passing of General Martín Miguel de Güemes",
                    LocalName = "Paso a la Inmortalidad del General Martín Miguel de Güemes",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 20),
                    EnglishName = "General Manuel Belgrano Memorial Day",
                    LocalName = "Paso a la Inmortalidad del General Manuel Belgrano",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 9),
                    EnglishName = "Independence Day",
                    LocalName = "Día de la Independencia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInAugust,
                    EnglishName = "General José de San Martín Memorial Day",
                    LocalName = "Paso a la Inmortalidad del General José de San Martín",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = secondMondayInOctober,
                    EnglishName = "Day of Respect for Cultural Diversity",
                    LocalName = "Día del Respeto a la Diversidad Cultural",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 20),
                    EnglishName = "National Sovereignty Day",
                    LocalName = "Día de la Soberanía Nacional",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception Day",
                    LocalName = "Día de la Inmaculada Concepción de María",
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
            //items.Add(new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            //items.Add(new Holiday(year, 3, 24, "Día Nacional de la Memoria por la Verdad y la Justicia", "Day of Remembrance for Truth and Justice", countryCode));
            //items.Add(new Holiday(year, 4, 2, "Día del Veterano y de los Caídos en la Guerra de Malvinas", "Day of the Veterans and Fallen of the Malvinas War", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Día del Trabajador", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 25, "Día de la Revolución de Mayo", "May Revolution", countryCode));
            //items.Add(new Holiday(year, 6, 17, "Paso a la Inmortalidad del General Martín Miguel de Güemes", "Anniversary of the Passing of General Martín Miguel de Güemes", countryCode, 2016));
            //items.Add(new Holiday(year, 6, 20, "Paso a la Inmortalidad del General Manuel Belgrano", "General Manuel Belgrano Memorial Day", countryCode));
            //items.Add(new Holiday(year, 7, 9, "Día de la Independencia", "Independence Day", countryCode));
            //items.Add(new Holiday(thirdMondayInAugust, "Paso a la Inmortalidad del General José de San Martín", "General José de San Martín Memorial Day", countryCode));
            //items.Add(new Holiday(secondMondayInOctober, "Día del Respeto a la Diversidad Cultural", "Day of Respect for Cultural Diversity", countryCode));
            //items.Add(new Holiday(year, 11, 20, "Día de la Soberanía Nacional", "National Sovereignty Day", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Día de la Inmaculada Concepción de María", "Immaculate Conception Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Argentina"
            };
        }
    }
}
