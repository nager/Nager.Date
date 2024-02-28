using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Colombia
    /// </summary>
    internal class ColombiaProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// ColombiaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ColombiaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CO;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var epiphanyDate = DateSystem.FindDay(year, Month.January, 6, DayOfWeek.Monday);
            var saintJosephsDayDate = DateSystem.FindDay(year, Month.March, 19, DayOfWeek.Monday);
            var saintPeterAndSaintPaulDate = DateSystem.FindDay(year, Month.June, 29, DayOfWeek.Monday);
            var assumptionOfMaryDate = DateSystem.FindDay(year, Month.August, 15, DayOfWeek.Monday);
            var columbusDayDate = DateSystem.FindDay(year, Month.October, 12, DayOfWeek.Monday);
            var allSaintsDayDate = DateSystem.FindDay(year, Month.November, 1, DayOfWeek.Monday);
            var independenceOfCartagenaDate = DateSystem.FindDay(year, Month.November, 11, DayOfWeek.Monday);

            #region Ascension Day

            var ascensionDayPublicHoliday = this._catholicProvider.AscensionDay("Ascensión del señor", year, countryCode);
            var ascensionDay = DateSystem.FindDay(ascensionDayPublicHoliday.Date, DayOfWeek.Monday);
            var shiftedAscensionDayPublicHoliday = new Holiday(ascensionDay, ascensionDayPublicHoliday.LocalName, ascensionDayPublicHoliday.Name, countryCode);

            #endregion

            #region Corpus Christi

            var corpusChristiPublicHoliday = this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode);
            var corpusChristiDay = DateSystem.FindDay(corpusChristiPublicHoliday.Date, DayOfWeek.Monday);
            var shiftedCorpusChristiPublicHoliday = new Holiday(corpusChristiDay, corpusChristiPublicHoliday.LocalName, corpusChristiPublicHoliday.Name, countryCode);

            #endregion

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new Holiday(epiphanyDate, "Día de los Reyes Magos", "Epiphany", countryCode));
            items.Add(new Holiday(saintJosephsDayDate, "Día de San José", "Saint Joseph's Day", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Jueves Santo", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Primero de Mayo", "Labour Day", countryCode));
            items.Add(shiftedAscensionDayPublicHoliday);
            items.Add(shiftedCorpusChristiPublicHoliday);
            items.Add(new Holiday(easterSunday.AddDays(68).AddDays(3), "Sagrado Corazón", "Sacred Heart", countryCode));
            items.Add(new Holiday(saintPeterAndSaintPaulDate, "San Pedro y San Pablo", "Saint Peter and Saint Paul", countryCode));
            items.Add(new Holiday(year, 7, 20, "Declaracion de la Independencia de Colombia", "Declaration of Independence", countryCode));
            items.Add(new Holiday(year, 8, 7, "Batalla de Boyacá", "Battle of Boyacá", countryCode));
            items.Add(new Holiday(assumptionOfMaryDate, "La Asunción", "Assumption of Mary", countryCode));
            items.Add(new Holiday(columbusDayDate, "Día de la Raza", "Columbus Day", countryCode));
            items.Add(new Holiday(allSaintsDayDate, "Dia de los Santos", "All Saints’ Day", countryCode));
            items.Add(new Holiday(independenceOfCartagenaDate, "Independencia de Cartagena", "Independence of Cartagena", countryCode));
            items.Add(new Holiday(year, 12, 8, "La Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Colombia",
            };
        }
    }
}
