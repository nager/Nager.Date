using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// El Salvador
    /// </summary>
    internal class ElSalvadorProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// ElSalvadorProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ElSalvadorProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SV;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();

            //TODO: Add Holy Week / Easter bad documentation on wikipedia

            items.Add(new PublicHoliday(year, 5, 1, "Día del trabajo", "Labor Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 3, "Día de la Cru", "The Day of the Cross", countryCode));
            items.Add(new PublicHoliday(year, 5, 7, "Día del Soldado", "Soldiers' Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 10, "Día de las Madres", "Mother's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 10, "Día del Padre", "Father's Day", countryCode));

            #region Fiestas de agosto

            items.Add(new PublicHoliday(year, 8, 1, "Fiestas de agosto", "August Festivals", countryCode));
            items.Add(new PublicHoliday(year, 8, 2, "Fiestas de agosto", "August Festivals", countryCode));
            items.Add(new PublicHoliday(year, 8, 3, "Fiestas de agosto", "August Festivals", countryCode));
            items.Add(new PublicHoliday(year, 8, 4, "Fiestas de agosto", "August Festivals", countryCode));
            items.Add(new PublicHoliday(year, 8, 5, "Fiestas de agosto", "August Festivals", countryCode));
            items.Add(new PublicHoliday(year, 8, 6, "Fiestas de agosto", "August Festivals", countryCode));
            items.Add(new PublicHoliday(year, 8, 7, "Fiestas de agosto", "August Festivals", countryCode));
            items.Add(new PublicHoliday(year, 9, 15, "Día de la Independencia", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 1, "Día del niño", "Children's Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Día de la raza", "Ethnic Pride Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "El día de los difuntos", "Day of the Dead", countryCode));

            #endregion

            #region Festival Nacional De La Pupusa

            items.Add(new PublicHoliday(year, 11, 7, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            items.Add(new PublicHoliday(year, 11, 8, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            items.Add(new PublicHoliday(year, 11, 9, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            items.Add(new PublicHoliday(year, 11, 10, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            items.Add(new PublicHoliday(year, 11, 11, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            items.Add(new PublicHoliday(year, 11, 12, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));
            items.Add(new PublicHoliday(year, 11, 13, "Festival Nacional De La Pupusa", "National Pupusa Festival", countryCode));

            #endregion

            items.Add(new PublicHoliday(year, 11, 21, "Dia de la Reina de la Paz", "Day of the Queen of Peace", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Noche Buena", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Fin de año", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/El_Salvador#Public_holidays",
            };
        }
    }
}
