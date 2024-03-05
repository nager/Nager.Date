using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Colombia HolidayProvider
    /// </summary>
    internal class ColombiaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Colombia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ColombiaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CO;
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

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //#region Ascension Day

            //var ascensionDayPublicHoliday = this._catholicProvider.AscensionDay("Ascensión del señor", year, countryCode);
            //var ascensionDay = DateHelper.FindDay(ascensionDayPublicHoliday.Date, DayOfWeek.Monday);
            //var shiftedAscensionDayPublicHoliday = new Holiday(ascensionDay, ascensionDayPublicHoliday.LocalName, ascensionDayPublicHoliday.Name, countryCode);

            //#endregion

            //#region Corpus Christi

            //var corpusChristiPublicHoliday = this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode);
            //var corpusChristiDay = DateHelper.FindDay(corpusChristiPublicHoliday.Date, DayOfWeek.Monday);
            //var shiftedCorpusChristiPublicHoliday = new Holiday(corpusChristiDay, corpusChristiPublicHoliday.LocalName, corpusChristiPublicHoliday.Name, countryCode);

            //#endregion

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            //items.Add(new Holiday(epiphanyDate, "Día de los Reyes Magos", "Epiphany", countryCode));
            //items.Add(new Holiday(saintJosephsDayDate, "Día de San José", "Saint Joseph's Day", countryCode));
            //items.Add(this._catholicProvider.MaundyThursday("Jueves Santo", year, countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Primero de Mayo", "Labour Day", countryCode));
            //items.Add(shiftedAscensionDayPublicHoliday);
            //items.Add(shiftedCorpusChristiPublicHoliday);
            //items.Add(new Holiday(easterSunday.AddDays(68).AddDays(3), "Sagrado Corazón", "Sacred Heart", countryCode));
            //items.Add(new Holiday(saintPeterAndSaintPaulDate, "San Pedro y San Pablo", "Saint Peter and Saint Paul", countryCode));
            //items.Add(new Holiday(year, 7, 20, "Declaracion de la Independencia de Colombia", "Declaration of Independence", countryCode));
            //items.Add(new Holiday(year, 8, 7, "Batalla de Boyacá", "Battle of Boyacá", countryCode));
            //items.Add(new Holiday(assumptionOfMaryDate, "La Asunción", "Assumption of Mary", countryCode));
            //items.Add(new Holiday(columbusDayDate, "Día de la Raza", "Columbus Day", countryCode));
            //items.Add(new Holiday(allSaintsDayDate, "Dia de los Santos", "All Saints’ Day", countryCode));
            //items.Add(new Holiday(independenceOfCartagenaDate, "Independencia de Cartagena", "Independence of Cartagena", countryCode));
            //items.Add(new Holiday(year, 12, 8, "La Inmaculada Concepción", "Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Colombia",
            };
        }
    }
}
