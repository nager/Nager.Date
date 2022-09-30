using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Venezuela
    /// </summary>
    internal class VenezuelaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// VenezuelaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public VenezuelaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            //TODO: Add countie support, Feria de la Chinita is only in Zulia...

            var countryCode = CountryCode.VE;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var secondSundayInMay = DateSystem.FindDay(year, Month.May, DayOfWeek.Sunday, Occurrence.Second);
            var thirdSundayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Sunday, Occurrence.Third);
            var thirdSundayInJuly = DateSystem.FindDay(year, Month.July, DayOfWeek.Sunday, Occurrence.Third);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Día de Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Día de Reyes", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 1, 14, "Día de la Divina Pastora", "Feast of the Divina Pastora", countryCode));
            items.Add(new PublicHoliday(year, 1, 15, "Día del Maestro", "Teacher's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 12, "Día de la Juventud", "Youth Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 20, "Dia de la Federacion", "Federation Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(year, 3, 8, "Dia Internacional de la Mujer", "International Women's Day", countryCode));
            //TODO:Semana Santa
            items.Add(new PublicHoliday(year, 3, 19, "Día de San José", "St Joseph's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 21, "Día del abolición de la esclavitud", "Slavery Abolition Anniversary", countryCode));
            //items.Add(new PublicHoliday(year, 3, 28, "Día Nacional del Patrimonio Cultural", "National Cultural Patrimonies Day", countryCode)); //not a public holiday
            items.Add(new PublicHoliday(year, 3, 31, "Aniversario del fundacion del San Cristóbal", "Foundation anniversary Day of San Cristóbal, Táchira", countryCode));
            items.Add(new PublicHoliday(year, 4, 19, "Diez y nueve de abril", "Beginning of the Independence Movement", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Día del Trabajador", "Labor Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 3, "Día del Cruz del Mayo", "Fiesta de las Cruces", countryCode));
            items.Add(new PublicHoliday(secondSundayInMay, "Día de las Madres", "Mother's Day", countryCode));
            //items.Add(new PublicHoliday(year, 5, 25, "Día del Himno Nacional", "National Anthem Day", countryCode));//not a public holiday
            items.Add(new PublicHoliday(thirdSundayInJune, "Día de los Padres", "Father's Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 24, "Día de San Juan Bautista y aniversario de la Batalla de Carabobo", "Army Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 27, "Día del Periodista y aniversario de la instauración del Decreto de Instrucción pública gratuita y obligatoria", "Journalists' Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 5, "Cinco de julio", "Independence Day", countryCode));
            items.Add(new PublicHoliday(thirdSundayInJuly, "Dia del niño", "Children's Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 24, "Natalicio del Libertador, Dia de la Armada Nacional", "Navy Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 25, "Aniversario del fundacion del Caracas", "Caracas City Foundation Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 3, "Día de la Bandera", "Flag Day", countryCode));
            //items.Add(new PublicHoliday(year, 8, 4, "Día de la Guardia Nacional", "National Guard Day", countryCode));//not a public holiday
            items.Add(new PublicHoliday(year, 9, 8, "Día del Virgen del Valle, aparicion del Virgen del Coromoto", "Birth of the Blessed Virgin Mary and feasts of the Virgen del Valle and Our Lady of Coromoto", countryCode));
            items.Add(new PublicHoliday(year, 9, 24, "Día del Virgen de las Mercedes", "Feast of the Our Lady of Mercy", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Día de la Resistencia Indígena", "Day of Indigenous Resistance", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Día de Todos los Santos", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Día de los fieles difuntos", "All Souls' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 17, "Feria de la Chinita", "Feria of La Chinita", countryCode));
            items.Add(new PublicHoliday(year, 11, 18, "Feria de la Chinita", "Feria of La Chinita", countryCode));
            items.Add(new PublicHoliday(year, 11, 19, "Feria de la Chinita", "Feria of La Chinita", countryCode));
            items.Add(new PublicHoliday(year, 11, 21, "Día del estudiante universitario", "University Students Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Inmaculada Concepción, Dia de la Lealtad", "Immaculate Conception, Loyalty Day", countryCode));
            //items.Add(new PublicHoliday(year, 12, 10, "Día de la Aviacion Militar", "Venezuelan Air Force Day", countryCode));//not a public holiday
            items.Add(new PublicHoliday(year, 12, 17, "Aniversario de la muerte de Libertador Simon Bolivar", "Simon Bolivar Memorial Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Nochebuena", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Nochevieja", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Venezuela"
            };
        }
    }
}
