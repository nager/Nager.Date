using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Dominican Republic HolidayProvider
    /// </summary>
    internal sealed class DominicanRepublicHolidayProvider : AbstractHolidayProvider,
        IObservedRuleSetHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Dominican Republic HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public DominicanRepublicHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.DO)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            // Law 139-97: holidays on Tuesday/Wednesday move to the preceding Monday,
            // holidays on Thursday/Friday move to the following Monday
            var law13997RuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(-2),
                Thursday = date => date.AddDays(4),
                Friday = date => date.AddDays(3),
            };

            // Labour Day additionally moves to Monday if it falls on a Sunday
            var labourDayRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(-2),
                Thursday = date => date.AddDays(4),
                Friday = date => date.AddDays(3),
                Sunday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Día de Año Nuevo",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "DAYOFKINGS-01",
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Day of Kings",
                    LocalName = "Día de Reyes",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = law13997RuleSet,
                },
                new HolidaySpecification
                {
                    Id = "OURLADYOFALTAGRACIA-01",
                    Date = new DateTime(year, 1, 21),
                    EnglishName = "Our Lady of Altagracia",
                    LocalName = "Día de Nuestra Señora de la Altagracia",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "DUARTESBIRTHDAY-01",
                    Date = new DateTime(year, 1, 26),
                    EnglishName = "Duarte's Birthday",
                    LocalName = "Día del Natalicio de Juan Pablo Duarte",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = law13997RuleSet,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 2, 27),
                    EnglishName = "Independence Day",
                    LocalName = "Día de la Independencia de la República Dominicana",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Día del Trabajador",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = labourDayRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "RESTORATIONDAY-01",
                    Date = new DateTime(year, 8, 16),
                    EnglishName = "Restoration Day",
                    LocalName = "Día de la Restauración Dominicana",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "OURLADYOFMERCY-01",
                    Date = new DateTime(year, 9, 24),
                    EnglishName = "Our Lady of Mercy",
                    LocalName = "Nuestra Senora de las Mercedes",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 11, 6),
                    EnglishName = "Constitution Day",
                    LocalName = "Día de la Constitución",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = law13997RuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.CorpusChristi("Corpus Christi", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://www.mt.gob.do",
                "https://mt.gob.do/ministerio-de-trabajo-informa-dias-feriados-correspondientes-al-ano-2026/",
                "https://mt.gob.do/ministerio-de-trabajo-informa-dias-feriados-correspondientes-al-ano-2025/",
                "https://presidencia.gob.do/noticias/ministerio-de-trabajo-informa-dias-feriados-correspondientes-al-ano-2024",
                "https://presidencia.gob.do/noticias/ministerio-de-trabajo-informa-dias-feriados-correspondientes-al-ano-2023",
                "https://presidencia.gob.do/noticias/ministerio-de-trabajo-da-conocer-los-dias-feriados-correspondientes-al-ano-2022",
                "https://mt.gob.do/ministerio-de-trabajo-informa-dias-feriados-correspondientes-ano-2021/",
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Dominican_Republic",
            ];
        }
    }
}
