using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Argentina HolidayProvider
    /// </summary>
    internal sealed class ArgentinaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Argentina HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ArgentinaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.AR)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var mondayObservedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(-2),
                Thursday = date => date.AddDays(4),
                Friday = date => date.AddDays(3)
            };

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
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet
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
                    Date = new DateTime(year, 8, 17),
                    EnglishName = "General José de San Martín Memorial Day",
                    LocalName = "Paso a la Inmortalidad del General José de San Martín",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Day of Respect for Cultural Diversity",
                    LocalName = "Día del Respeto a la Diversidad Cultural",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 20),
                    EnglishName = "National Sovereignty Day",
                    LocalName = "Día de la Soberanía Nacional",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet
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
                this._catholicProvider.GoodFriday("Viernes Santo", year, mondayObservedRuleSet)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Argentina",
                "https://www.argentina.gob.ar/normativa/nacional/ley-27399-281835/texto",
                "https://www.argentina.gob.ar/normativa/nacional/decreto-52-2017-271094/texto",
                "https://www.argentina.gob.ar/normativa/nacional/decreto-1584-2010-174389/actualizacion"
            ];
        }
    }
}
