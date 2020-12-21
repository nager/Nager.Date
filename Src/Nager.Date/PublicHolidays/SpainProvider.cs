using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Spain
    /// </summary>
    public class SpainProvider : IPublicHolidayProvider, ICountyProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// SpainProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SpainProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// GetCounties
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "ES-AN", "Andalusia" },
                { "ES-AR", "Aragon" },
                { "ES-AS", "Principality of Asturias" },
                { "ES-CN", "Canary Islands" },
                { "ES-CB", "Cantabria" },
                { "ES-CL", "Castile and León" },
                { "ES-CM", "Castile-La Mancha" },
                { "ES-CT", "Catalonia" },
                { "ES-CE", "Ceuta" },
                { "ES-EX", "Extremadura" },
                { "ES-GA", "Galicia" },
                { "ES-IB", "Balearic Islands" },
                { "ES-RI", "La Rioja" },
                { "ES-MD", "Community of Madrid" },
                { "ES-ML", "Melilla" },
                { "ES-MC", "Region of Murcia" },
                { "ES-NC", "Chartered Community of Navarre" },
                { "ES-PV", "Basque Country" },
                { "ES-VC", "Valencian Community" },

                //Provinces
                //TODO: Optimize code add provinces behind counties
                //https://en.wikipedia.org/wiki/ISO_3166-2:ES
                { "ES-O", "Asturias" },
                { "ES-NA", "Navarra" },
                { "ES-MU", "Murcia" },
                { "ES-M", "Madrid" },
                { "ES-LO", "La Rioja" },
            };
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.ES;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 6, "Día de Reyes / Epifanía del Señor", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 2, 28, "Día de Andalucía", "Regional Holiday", countryCode, null, new string[] { "ES-AN" }));
            items.Add(new PublicHoliday(year, 3, 1, "Dia de les Illes Balears", "Regional Holiday", countryCode, null, new string[] { "ES-IB" }));
            items.Add(new PublicHoliday(year, 3, 19, "San José", "St. Joseph's Day", countryCode, null, new string[] { "ES-EX", "ES-PV", "ES-GA", "ES-M", "ES-MU", "ES-NA", "ES-VC" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Jueves Santo", "Maundy Thursday", countryCode, null, new string[] { "ES-AN", "ES-AR", "ES-CE", "ES-ML", "ES-CL", "ES-CM", "ES-CN", "ES-EX", "ES-GA", "ES-IB", "ES-LO", "ES-M", "ES-MU", "ES-NA", "ES-O", "ES-PV", "ES-CB" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Lunes de Pascua", "Easter Monday", countryCode, 1642, new string[] { "ES-CT", "ES-IB", "ES-LO", "ES-NA", "ES-PV", "ES-VC" }));
            items.Add(new PublicHoliday(year, 4, 23, "San Jorge (Día de Aragón)", "Regional Holiday", countryCode, null, new string[] { "ES-AR" }));
            items.Add(new PublicHoliday(year, 4, 23, "Día de Castilla y León", "Regional Holiday", countryCode, null, new string[] { "ES-CL" }));
            items.Add(new PublicHoliday(year, 5, 17, "Día das Letras Galegas", "Regional Holiday", countryCode, null, new string[] { "ES-GA" }));
            items.Add(new PublicHoliday(year, 5, 31, "Día de la Región Castilla-La Mancha", "Regional Holiday", countryCode, null, new string[] { "ES-CM" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Corpus Christi", "Corpus Christi", countryCode, null, new string[] { "ES-CM" }));
            items.Add(new PublicHoliday(year, 6, 9, "Día de la Región de Murcia", "Regional Holiday", countryCode, null, new string[] { "ES-MU" }));
            items.Add(new PublicHoliday(year, 6, 9, "Día de La Rioja", "Regional Holiday", countryCode, null, new string[] { "ES-LO" }));
            items.Add(new PublicHoliday(year, 6, 24, "Sant Joan", "St. John's Day", countryCode, null, new string[] { "ES-CT", "ES-VC" }));
            items.Add(new PublicHoliday(year, 7, 20, "Fiesta del Sacrificio-Eidul Adha", "Eidul Adha", countryCode, null, new string[] { "ES-CE" }));
            items.Add(new PublicHoliday(year, 7, 21, "Fiesta del Sacrificio-Aid Al Adha", "Aid Al Adha", countryCode, null, new string[] { "ES-ML" }));
            items.Add(new PublicHoliday(year, 7, 28, "Día de las Instituciones de Cantabria", "Regional Holiday", countryCode, null, new string[] { "ES-CB" }));
            items.Add(new PublicHoliday(year, 9, 2, "Día de Ceuta", "Municipal Holiday", countryCode, null, new string[] { "ES-CE" }));
            items.Add(new PublicHoliday(year, 9, 8, "Día de Asturias", "Regional Holiday", countryCode, null, new string[] { "ES-O" }));
            items.Add(new PublicHoliday(year, 9, 8, "Día de Extremadura", "Regional Holiday", countryCode, null, new string[] { "ES-EX" }));
            items.Add(new PublicHoliday(year, 9, 11, "Diada Nacional de Catalunya", "National Day of Catalonia", countryCode, null, new string[] { "ES-CT" }));
            items.Add(new PublicHoliday(year, 9, 15, "La Bien Aparecida", "Regional Holiday", countryCode, null, new string[] { "ES-CB" }));
            items.Add(new PublicHoliday(year, 10, 9, "Dia de la Comunitat Valenciana", "Regional Holiday", countryCode, null, new string[] { "ES-VC" }));
            items.Add(new PublicHoliday(year, 10, 12, "Fiesta Nacional de España", "Fiesta Nacional de España", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Día de todos los Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 6, "Día de la Constitución", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

            var labourDay = this.LabourDay(year, countryCode);
            if (labourDay != null)
            {
                items.Add(labourDay);
            }

            var dayOfMadrid = this.DayOfMadrid(year, countryCode, labourDay);
            if (dayOfMadrid != null)
            {
                items.Add(dayOfMadrid);
            }

            var assumption = this.Assumption(year, countryCode);
            if (assumption != null)
            {
                items.Add(assumption);
            }

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday LabourDay(int year, CountryCode countryCode)
        {
            var date = new DateTime(year, 5, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            return new PublicHoliday(date, "Fiesta del trabajo", "Labour Day", countryCode);
        }

        private PublicHoliday DayOfMadrid(int year, CountryCode countryCode, PublicHoliday labourDay)
        {
            var date = new DateTime(year, 5, 2).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            if (labourDay.Date == date)
            {
                date = date.AddDays(1);
            }

            return new PublicHoliday(date, "Fiesta de la Comunidad de Madrid", "Day of Madrid", countryCode, null, new string[] { "ES-M" });
        }

        private PublicHoliday Assumption(int year, CountryCode countryCode)
        {
            var date = new DateTime(year, 8, 15).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            return new PublicHoliday(date, "Asunción", "Assumption", countryCode);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Spain",
                "https://www.boe.es/boe/dias/2020/11/02/pdfs/BOE-A-2020-13343.pdf"
            };
        }
    }
}
