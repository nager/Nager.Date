using Nager.Date.Contract;
using Nager.Date.Model;
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
            items.Add(new PublicHoliday(year, 3, 19, "San José", "St. Joseph's Day", countryCode, null, new string[] { "ES-ML", "ES-CM", "ES-GA", "ES-IB", "ES-M", "ES-MU", "ES-NA", "ES-O", "ES-VC" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Jueves Santo", "Maundy Thursday", countryCode, null, new string[] { "ES-AN", "ES-AR", "ES-CE", "ES-ML", "ES-CL", "ES-CM", "ES-CN", "ES-EX", "ES-GA", "ES-IB", "ES-LO", "ES-M", "ES-MU", "ES-NA", "ES-O", "ES-PV", "ES-CB" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Pascua de Resurrección", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Lunes de Pascua", "Easter Monday", countryCode, 1642, new string[] { "ES-CT", "ES-IB", "ES-NA", "ES-PV", "ES-VC" }));
            items.Add(new PublicHoliday(year, 4, 23, "San Jorge (Día de Aragón)", "Regional Holiday", countryCode, null, new string[] { "ES-AR" }));
            items.Add(new PublicHoliday(year, 4, 23, "Día de Castilla y León", "Regional Holiday", countryCode, null, new string[] { "ES-CL" }));
            items.Add(new PublicHoliday(year, 5, 1, "Día del Trabajador", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 2, "Fiesta de la Comunidad de Madrid", "Regional Holiday", countryCode, null, new string[] { "ES-M" }));
            items.Add(new PublicHoliday(year, 5, 17, "Día das Letras Galegas", "Regional Holiday", countryCode, null, new string[] { "ES-GA" }));
            items.Add(new PublicHoliday(year, 5, 30, "Día de Canarias", "Regional Holiday", countryCode, null, new string[] { "ES-CN" }));
            items.Add(new PublicHoliday(year, 5, 31, "Día de la Región Castilla-La Mancha", "Regional Holiday", countryCode, null, new string[] { "ES-CM" }));
            items.Add(new PublicHoliday(year, 6, 9, "Día de la Región de Murcia", "Regional Holiday", countryCode, null, new string[] { "ES-MU" }));
            items.Add(new PublicHoliday(year, 6, 9, "Día de La Rioja", "Regional Holiday", countryCode, null, new string[] { "ES-LO" }));
            items.Add(new PublicHoliday(year, 6, 24, "Sant Joan", "St. John's Day", countryCode, null, new string[] { "ES-CT" }));
            items.Add(new PublicHoliday(year, 7, 25, "Santiago Apóstol", "Saint James", countryCode, null, new string[] { "ES-GA" }));
            items.Add(new PublicHoliday(year, 8, 15, "Asunción", "Assumption", countryCode));
            items.Add(new PublicHoliday(year, 9, 2, "Día de Ceuta", "Municipal Holiday", countryCode, null, new string[] { "ES-CE" }));
            items.Add(new PublicHoliday(year, 9, 8, "Día de Asturias", "Regional Holiday", countryCode, null, new string[] { "ES-O" }));
            items.Add(new PublicHoliday(year, 9, 8, "Día de Extremadura", "Regional Holiday", countryCode, null, new string[] { "ES-EX" }));
            items.Add(new PublicHoliday(year, 9, 11, "Diada Nacional de Catalunya", "National Day of Catalonia", countryCode, null, new string[] { "ES-CT" }));
            items.Add(new PublicHoliday(year, 9, 15, "Día de Cantabria", "Regional Holiday", countryCode, null, new string[] { "ES-CB" }));
            items.Add(new PublicHoliday(year, 10, 9, "Dia de la Comunitat Valenciana", "Regional Holiday", countryCode, null, new string[] { "ES-VC" }));
            items.Add(new PublicHoliday(year, 10, 12, "Fiesta Nacional de España", "Fiesta Nacional de España", countryCode));
            items.Add(new PublicHoliday(year, 10, 25, "Euskadi Eguna", "Regional Holiday", countryCode, null, new string[] { "ES-PV" }));
            items.Add(new PublicHoliday(year, 11, 1, "Día de todos los Santos", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 6, "Día de la Constitución", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Sant Esteve", "St. Stephen's Day", countryCode, null, new string[] { "ES-CT", "ES-IB" }));

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Spain"
            };
        }
    }
}
