using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Monaco
    /// </summary>
    internal class MonacoProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// MonacoProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MonacoProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MC;

            var items = new List<Holiday>();
            
            items.Add(new Holiday(year, 1, 27, "La Sainte Dévote", "Saint Devota's Day", countryCode));
            items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Le 1er mai", "May Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("L’Ascension", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Le lundi de Pentecôte", year, countryCode));
            items.Add(this._catholicProvider.CorpusChristi("La Fête Dieu", year, countryCode));
            items.Add(new Holiday(year, 8, 15, "L'Assomption de Marie", "Assumption Day", countryCode));
            items.Add(new Holiday(year, 12, 8, "L’Immaculée Conception", "The Immaculate Conception", countryCode));

            #region New Year's Day

            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            items.Add(new Holiday(newYearsDay, "Le jour de l’An", "New Year's Day", countryCode));

            #endregion

            #region All Saints Day

            var allSaintsDay = new DateTime(year, 11, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            items.Add(new Holiday(allSaintsDay, "La Toussaint", "All Saints Day", countryCode));

            #endregion

            #region National Day / La Fête du Prince

            var nationalDay = new DateTime(year, 11, 19).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            items.Add(new Holiday(nationalDay, "La Fête du Prince", "National Day", countryCode));

            #endregion

            #region Christmas Day

            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            items.Add(new Holiday(christmasDay, "Noël​", "​Christmas Day", countryCode));

            #endregion

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Monaco"
            };
        }
    }
}
