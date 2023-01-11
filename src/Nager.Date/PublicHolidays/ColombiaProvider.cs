using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Colombia
    /// </summary>
    internal class ColombiaProvider : IPublicHolidayProvider
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
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            //TODO: Check, movable holiday: when they do not fall on a Monday, these holidays are observed the following Monday.
            //TODO: Check weekends in Colombia as they can be Universal or only sundays (in which case? how to handle that?)
            //https://en.wikipedia.org/wiki/Workweek_and_weekend#Colombia

            var countryCode = CountryCode.CO;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var saintJosephsDay = DateSystem.FindDay(year, Month.March, 19, DayOfWeek.Monday);
            var assumptionOfMaryDay = DateSystem.FindDay(year, Month.August, 15, DayOfWeek.Monday);
            var independenceOfCartagenaDay = DateSystem.FindDay(year, Month.November, 11, DayOfWeek.Monday);

            var ascensionDayPublicHoliday = this._catholicProvider.AscensionDay("Ascensión del señor", year, countryCode);
            var ascensionDay = DateSystem.FindDay(ascensionDayPublicHoliday.Date, DayOfWeek.Monday);
            var shiftedAscensionDayPublicHoliday = new PublicHoliday(ascensionDay, ascensionDayPublicHoliday.LocalName, ascensionDayPublicHoliday.Name, countryCode);

            //Corpus Christi
            //Sacred Heart
            //Saint Peter and Saint Paul
            //Columbus Day
            //All Saints’ Day
            //Epiphany

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Día de los Reyes Magos", "Epiphany", countryCode));
            //TODO: Valid only for the city of Barranquilla
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Carnival", "Carnival", countryCode));
            //TODO: Valid only for the city of Barranquilla
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnival", "Carnival", countryCode));
            items.Add(new PublicHoliday(saintJosephsDay, "Día de San José", "Saint Joseph's Day", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Jueves Santo", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Primero de Mayo", "Labour Day", countryCode));
            items.Add(shiftedAscensionDayPublicHoliday);
            items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(68), "Sagrado Corazón", "Sacred Heart", countryCode));
            items.Add(new PublicHoliday(year, 6, 29, "San Pedro y San Pablo", "Saint Peter and Saint Paul", countryCode));
            items.Add(new PublicHoliday(year, 7, 20, "Declaracion de la Independencia de Colombia", "Declaration of Independence", countryCode));
            items.Add(new PublicHoliday(year, 8, 7, "Battle of Boyacá", "Battle of Boyacá", countryCode));
            items.Add(new PublicHoliday(assumptionOfMaryDay, "La Asunción", "Assumption of Mary", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Día de la Raza", "Columbus Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Dia de los Santos", "All Saints’ Day", countryCode));
            items.Add(new PublicHoliday(independenceOfCartagenaDay, "Independencia de Cartagena", "Independence of Cartagena", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "La Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

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
