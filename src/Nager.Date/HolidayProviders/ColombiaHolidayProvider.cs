using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Colombia HolidayProvider
    /// </summary>
    internal sealed class ColombiaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Colombia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ColombiaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.CO)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var epiphanyDate = DateHelper.FindDay(year, Month.January, 6, DayOfWeek.Monday);
            var saintJosephsDayDate = DateHelper.FindDay(year, Month.March, 19, DayOfWeek.Monday);
            var saintPeterAndSaintPaulDate = DateHelper.FindDay(year, Month.June, 29, DayOfWeek.Monday);
            var assumptionOfMaryDate = DateHelper.FindDay(year, Month.August, 15, DayOfWeek.Monday);
            var columbusDayDate = DateHelper.FindDay(year, Month.October, 12, DayOfWeek.Monday);
            var allSaintsDayDate = DateHelper.FindDay(year, Month.November, 1, DayOfWeek.Monday);
            var independenceOfCartagenaDate = DateHelper.FindDay(year, Month.November, 11, DayOfWeek.Monday);

            var mondayObservedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(6),
                Wednesday = date => date.AddDays(5),
                Thursday = date => date.AddDays(4),
                Friday = date => date.AddDays(3),
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1)
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
                    Date = epiphanyDate,
                    EnglishName = "Epiphany",
                    LocalName = "Día de los Reyes Magos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = saintJosephsDayDate,
                    EnglishName = "Saint Joseph's Day",
                    LocalName = "Día de San José",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Primero de Mayo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = saintPeterAndSaintPaulDate,
                    EnglishName = "Saint Peter and Saint Paul",
                    LocalName = "San Pedro y San Pablo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 20),
                    EnglishName = "Declaration of Independence",
                    LocalName = "Declaracion de la Independencia de Colombia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 7),
                    EnglishName = "Battle of Boyacá",
                    LocalName = "Batalla de Boyacá",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = assumptionOfMaryDate,
                    EnglishName = "Assumption of Mary",
                    LocalName = "La Asunción",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = columbusDayDate,
                    EnglishName = "Columbus Day",
                    LocalName = "Día de la Raza",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = allSaintsDayDate,
                    EnglishName = "All Saints’ Day",
                    LocalName = "Dia de los Santos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = independenceOfCartagenaDate,
                    EnglishName = "Independence of Cartagena",
                    LocalName = "Independencia de Cartagena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "La Inmaculada Concepción",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(68).AddDays(3),
                    EnglishName = "Sacred Heart",
                    LocalName = "Sagrado Corazón",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.AscensionDay("Ascensión del señor", year, mondayObservedRuleSet),
                this._catholicProvider.CorpusChristi("Corpus Christi", year, mondayObservedRuleSet),
                this._catholicProvider.MaundyThursday("Jueves Santo", year),
                this._catholicProvider.GoodFriday("Viernes Santo", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Colombia",
            ];
        }
    }
}
