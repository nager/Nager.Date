using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class ChileProvider : CatholicBaseProvider, ICountyProvider
    {
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

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Chile
            //https://en.wikipedia.org/wiki/Public_holidays_in_Chile

            var countryCode = CountryCode.CL;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();

            var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(newYearDay, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Sábado Santo", "Holy Saturday", countryCode));
            //Census
            items.Add(new PublicHoliday(year, 5, 1, "Día del Trabajo", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 21, "Día de las Glorias Navales", "Navy Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 7, "Asalto y Toma del Morro de Arica", "Battle of Arica", countryCode));
            items.Add(new PublicHoliday(year, 6, 26, "San Pedro y San Pablo", "Saint Peter and Saint Paul", countryCode));
            //Presidential and Congress Primary Elections
            items.Add(new PublicHoliday(year, 7, 16, "Virgen del Carmen", "Our Lady of Mount Carmel", countryCode));
            items.Add(new PublicHoliday(year, 8, 10, "San Lorenzo de Tarapacá", "Saint Lawrence", countryCode, null, new string[] { "CL-TA" }));
            items.Add(new PublicHoliday(year, 8, 10, "Día del Minero", "National Miner's Day", countryCode, null, new string[] { "CL-AT" }));
            items.Add(new PublicHoliday(year, 8, 15, "Asunción de la Virgen", "Assumption of Mary", countryCode));
            //items.Add(new PublicHoliday(year, 8, 20, "Nacimiento del Prócer de la Independencia", "Nativity of Liberator Bernardo O'Higgins", countryCode)); //Only Valid in a communes
            items.Add(new PublicHoliday(year, 9, 18, "Fiestas Patrias", "National holiday", countryCode));
            items.Add(new PublicHoliday(year, 9, 19, "Día de las Glorias del Ejército", "Army Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 20, "Feast of La Pampilla", "Fiesta de La Pampilla", countryCode, null, new string[] { "CL-CO" }));
            items.Add(new PublicHoliday(year, 9, 21, "Toma de posesión del estrecho de Magallanes", "National Possession of the Strait of Magellan", countryCode, null, new string[] { "CL-MA" }));
            items.Add(new PublicHoliday(year, 10, 2, "Aniversario de la Creación de la XIV Región de Los Ríos", "Los Ríos Region Anniversary", countryCode, null, new string[] { "CL-LR" }));
            items.Add(new PublicHoliday(year, 10, 9, "Día del Descubrimiento de Dos Mundos", "Columbus Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 27, "Día Nacional de las Iglesias Evangélicas y Protestantes", "Reformation Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Día de Todos los Santos", "All Saints", countryCode));
            items.Add(new PublicHoliday(year, 11, 19, "Elecciones presidencial, congresistas y regionales", "Presidential, parliamentary and regional elections", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            //Presidential election, runoff
            items.Add(new PublicHoliday(year, 12, 25, "Navidad / Natividad del Señor", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
