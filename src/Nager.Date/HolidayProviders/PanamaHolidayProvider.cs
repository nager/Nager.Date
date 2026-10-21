using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Panama HolidayProvider
    /// </summary>
    internal sealed class PanamaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Panama HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PanamaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.PA)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            //When a holiday falls on a Sunday, the following Monday is a day off
            var sundayObservedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "MARTYRSDAY-01",
                    Date = new DateTime(year, 1, 9),
                    EnglishName = "Martyrs' Day",
                    LocalName = "Día de los Mártires",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Día del Trabajo",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "SEPARATIONDAY-01",
                    Date = new DateTime(year, 11, 3),
                    EnglishName = "Separation Day",
                    LocalName = "Separación de Panamá de Colombia",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "FLAGDAY-01",
                    Date = new DateTime(year, 11, 4),
                    EnglishName = "Flag Day",
                    LocalName = "Día de los Símbolos Patrios",
                    HolidayTypes = HolidayTypes.Authorities | HolidayTypes.School,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "COLONDAY-01",
                    Date = new DateTime(year, 11, 5),
                    EnglishName = "Consolidation of the Separation Day",
                    LocalName = "Consolidación de la Separación de Panamá de Colombia",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "SHOUTVILLADELOSSANTOS-01",
                    Date = new DateTime(year, 11, 10),
                    EnglishName = "Shout in Villa de los Santos",
                    LocalName = "Primer Grito de Independencia de la Villa de Los Santos",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 11, 28),
                    EnglishName = "Independence Day",
                    LocalName = "Independencia de Panamá de España",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "MOTHERSDAY-01",
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Mother's Day",
                    LocalName = "Día de las Madres",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CARNIVAL-01",
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Carnival Monday",
                    LocalName = "Lunes de Carnaval",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CARNIVAL-02",
                    Date = easterSunday.AddDays(-47),
                    EnglishName = "Carnival Tuesday",
                    LocalName = "Martes de Carnaval",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Viernes Santo", year)
            };

            holidaySpecifications.AddIfNotNull(this.NationalDayOfMourning(year, sundayObservedRuleSet));

            return holidaySpecifications;
        }

        private HolidaySpecification? NationalDayOfMourning(int year, ObservedRuleSet observedRuleSet)
        {
            //Day of the fallen of the United States invasion of Panama (20 December 1989), national holiday since 2022
            if (year < 2022)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "NATIONALDAYOFMOURNING-01",
                Date = new DateTime(year, 12, 20),
                EnglishName = "National Day of Mourning",
                LocalName = "Día de Duelo Nacional",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Panama",
                "https://files.latinexbolsa.com/pabvprblob02/media/documents/MEMORANDUM_D%C3%ADas_festivos_2026_final.pdf",
                "https://docs.panama.justia.com/federales/codigos/codigo-de-trabajo.pdf",
            ];
        }
    }
}
