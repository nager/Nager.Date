using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Ecuador HolidayProvider
    /// </summary>
    internal sealed class EcuadorHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Ecuador HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public EcuadorHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.EC)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);
            var observedRuleSet = this.GetObservedRuleSet(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWORKERSDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "Día del Trabajo",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "BATTLEPICHINCHA-01",
                    Date = new DateTime(year, 5, 24),
                    EnglishName = "The Battle of Pichincha",
                    LocalName = "Batalla de Pichincha",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEQUITO-01",
                    Date = new DateTime(year, 8, 10),
                    EnglishName = "Declaration of Independence of Quito",
                    LocalName = "Primer Grito de Independencia",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEGUAYAQUIL-01",
                    Date = new DateTime(year, 10, 9),
                    EnglishName = "Independence of Guayaquil",
                    LocalName = "Independencia de Guayaquil",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "ALLSOULSDAY-01",
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "All Souls' Day",
                    LocalName = "Día de los Difuntos, Día de Muertos",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCECUENCA-01",
                    Date = new DateTime(year, 11, 3),
                    EnglishName = "Independence of Cuenca",
                    LocalName = "Independencia de Cuenca",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Día de Navidad",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CARNIVAL-01",
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CARNIVAL-02",
                    Date = easterSunday.AddDays(-47),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Viernes Santo", year)
            };

            return holidaySpecifications;
        }

        private ObservedRuleSet? GetObservedRuleSet(int year)
        {
            //Ley Orgánica Reformatoria a la Ley Orgánica del Servicio Público y al Código del Trabajo
            //Registro Oficial Suplemento 906 of 20 December 2016
            if (year < 2017)
            {
                return null;
            }

            return new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(2),
                Thursday = date => date.AddDays(1),
                Saturday = date => date.AddDays(-1),
                Sunday = date => date.AddDays(1),
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://www.asambleanacional.gob.ec/es/blogs/herman-moya/47579-ley-de-feriados",
                "https://en.wikipedia.org/wiki/Public_holidays_in_Ecuador",
            ];
        }
    }
}
