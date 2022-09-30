using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Chile
    /// </summary>
    internal class ChileProvider : IPublicHolidayProvider, ICountyProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// ChileProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ChileProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "CL-AI", "Región de Aisén" },
                { "CL-AN", "Región de Antofagasta" },
                { "CL-AP", "Región de Arica y Parinacota" },
                { "CL-AR", "Región de la Araucanía" },
                { "CL-AT", "Región de Atacama" },
                { "CL-BI", "Región del Bío-Bío" },
                { "CL-CO", "Región de Coquimbo" },
                { "CL-LI", "Región del Libertador General Bernardo O’Higgins" },
                { "CL-LL", "Región de los Lagos" },
                { "CL-LR", "Región de Los Ríos" },
                { "CL-MA", "Región de Magallanes y de la Antártica Chilena" },
                { "CL-ML", "Región del Maule" },
                { "CL-RM", "Región Metropolitana" },
                { "CL-TA", "Región de Tarapacá" },
                { "CL-VS", "Región de Valparaíso" }
            };
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CL;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();

            var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            items.Add(new PublicHoliday(newYearDay, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Sábado Santo", "Holy Saturday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Día del Trabajo", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 21, "Día de las Glorias Navales", "Navy Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 7, "Asalto y Toma del Morro de Arica", "Battle of Arica", countryCode, null, new string[] { "CL-AP" }));

            //TODO:National Day of Aboriginal Peoples (This holiday is to be observed on each Winter Solstice.)
            //The winter solstice, also called the hibernal solstice, occurs when either of Earth's poles reaches its maximum tilt away from the Sun

            items.Add(new PublicHoliday(year, 7, 16, "Virgen del Carmen", "Our Lady of Mount Carmel", countryCode, launchYear: 2007));
            items.Add(new PublicHoliday(year, 8, 15, "Asunción de la Virgen", "Assumption of Mary", countryCode));
            items.Add(new PublicHoliday(year, 9, 4, "Plebiscito nacional", "National plebiscite", countryCode));
            items.Add(new PublicHoliday(year, 9, 18, "Fiestas Patrias", "National holiday", countryCode));
            items.Add(new PublicHoliday(year, 9, 19, "Día de las Glorias del Ejército", "Army Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Día de Todos los Santos", "All Saints", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad / Natividad del Señor", "Christmas Day", countryCode));

            var saintPeterAndSaintPaul = this.SaintPeterAndSaintPaul(year, countryCode);
            if (saintPeterAndSaintPaul != null)
            {
                items.Add(saintPeterAndSaintPaul);
            }

            var columbusDay = this.ColumbusDay(year, countryCode);
            if (columbusDay != null)
            {
                items.Add(columbusDay);
            }

            var reformationDay = this.ReformationDay(year, countryCode);
            if (reformationDay != null)
            {
                items.Add(reformationDay);
            }

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday SaintPeterAndSaintPaul(int year, CountryCode countryCode)
        {
            var date = new DateTime(year, 6, 27);

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    date = date.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    date = date.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    date = date.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    date = date.AddDays(1);
                    break;
            }

            return new PublicHoliday(date, "San Pedro y San Pablo", "Saint Peter and Saint Paul", countryCode);
        }

        private PublicHoliday ColumbusDay(int year, CountryCode countryCode)
        {
            var date = new DateTime(year, 10, 12);

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    date = date.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    date = date.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    date = date.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    date = date.AddDays(1);
                    break;
            }

            return new PublicHoliday(date, "Día del Descubrimiento de Dos Mundos", "Columbus Day", countryCode);
        }

        private PublicHoliday ReformationDay(int year, CountryCode countryCode)
        {
            var date = new DateTime(year, 10, 31);

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Wednesday:
                    date = date.AddDays(2);
                    break;
                case DayOfWeek.Tuesday:
                    date = date.AddDays(-4);
                    break;
                default:
                    break;
            }

            return new PublicHoliday(date, "Día Nacional de las Iglesias Evangélicas y Protestantes", "Reformation Day", countryCode);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Chile",
            };
        }
    }
}
