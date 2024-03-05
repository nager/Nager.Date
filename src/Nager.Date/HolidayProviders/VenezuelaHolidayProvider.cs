using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Venezuela HolidayProvider
    /// </summary>
    internal class VenezuelaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Venezuela HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public VenezuelaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            //TODO: Add countie support, Feria de la Chinita is only in Zulia...
            //TODO:Semana Santa

            var countryCode = CountryCode.VE;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var secondSundayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Sunday, Occurrence.Second);
            var thirdSundayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Sunday, Occurrence.Third);
            var thirdSundayInJuly = DateHelper.FindDay(year, Month.July, DayOfWeek.Sunday, Occurrence.Third);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Día de Año Nuevo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Día de Reyes",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 14),
                    EnglishName = "Feast of the Divina Pastora",
                    LocalName = "Día de la Divina Pastora",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 15),
                    EnglishName = "Teacher's Day",
                    LocalName = "Día del Maestro",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 12),
                    EnglishName = "Youth Day",
                    LocalName = "Día de la Juventud",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 20),
                    EnglishName = "Federation Day",
                    LocalName = "Dia de la Federacion",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-47),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Dia Internacional de la Mujer",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 19),
                    EnglishName = "St Joseph's Day",
                    LocalName = "Día de San José",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 21),
                    EnglishName = "Slavery Abolition Anniversary",
                    LocalName = "Día del abolición de la esclavitud",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 31),
                    EnglishName = "Foundation anniversary Day of San Cristóbal, Táchira",
                    LocalName = "Aniversario del fundacion del San Cristóbal",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 19),
                    EnglishName = "Beginning of the Independence Movement",
                    LocalName = "Diez y nueve de abril",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labor Day",
                    LocalName = "Día del Trabajador",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 3),
                    EnglishName = "Fiesta de las Cruces",
                    LocalName = "Día del Cruz del Mayo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = secondSundayInMay,
                    EnglishName = "Mother's Day",
                    LocalName = "Día de las Madres",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdSundayInJune,
                    EnglishName = "Father's Day",
                    LocalName = "Día de los Padres",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 24),
                    EnglishName = "Army Day",
                    LocalName = "Día de San Juan Bautista y aniversario de la Batalla de Carabobo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 27),
                    EnglishName = "Journalists' Day",
                    LocalName = "Día del Periodista y aniversario de la instauración del Decreto de Instrucción pública gratuita y obligatoria",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 5),
                    EnglishName = "Independence Day",
                    LocalName = "Cinco de julio",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdSundayInJuly,
                    EnglishName = "Children's Day",
                    LocalName = "Dia del niño",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 24),
                    EnglishName = "Navy Day",
                    LocalName = "Natalicio del Libertador, Dia de la Armada Nacional",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 25),
                    EnglishName = "Caracas City Foundation Day",
                    LocalName = "Aniversario del fundacion del Caracas",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 3),
                    EnglishName = "Flag Day",
                    LocalName = "Día de la Bandera",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 8),
                    EnglishName = "Birth of the Blessed Virgin Mary and feasts of the Virgen del Valle and Our Lady of Coromoto",
                    LocalName = "Día del Virgen del Valle, aparicion del Virgen del Coromoto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 24),
                    EnglishName = "Feast of the Our Lady of Mercy",
                    LocalName = "Día del Virgen de las Mercedes",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Day of Indigenous Resistance",
                    LocalName = "Día de la Resistencia Indígena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Día de Todos los Santos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "All Souls' Day",
                    LocalName = "Día de los fieles difuntos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 17),
                    EnglishName = "Feria of La Chinita",
                    LocalName = "Feria de la Chinita",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 18),
                    EnglishName = "Feria of La Chinita",
                    LocalName = "Feria de la Chinita",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 19),
                    EnglishName = "Feria of La Chinita",
                    LocalName = "Feria de la Chinita",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 21),
                    EnglishName = "University Students Day",
                    LocalName = "Día del estudiante universitario",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception, Loyalty Day",
                    LocalName = "Inmaculada Concepción, Dia de la Lealtad",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 17),
                    EnglishName = "Simon Bolivar Memorial Day",
                    LocalName = "Aniversario de la muerte de Libertador Simon Bolivar",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Nochebuena",
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
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Nochevieja",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Día de Año Nuevo", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Día de Reyes", "Epiphany", countryCode));
            //items.Add(new Holiday(year, 1, 14, "Día de la Divina Pastora", "Feast of the Divina Pastora", countryCode));
            //items.Add(new Holiday(year, 1, 15, "Día del Maestro", "Teacher's Day", countryCode));
            //items.Add(new Holiday(year, 2, 12, "Día de la Juventud", "Youth Day", countryCode));
            //items.Add(new Holiday(year, 2, 20, "Dia de la Federacion", "Federation Day", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            //items.Add(new Holiday(year, 3, 8, "Dia Internacional de la Mujer", "International Women's Day", countryCode));
            //items.Add(new Holiday(year, 3, 19, "Día de San José", "St Joseph's Day", countryCode));
            //items.Add(new Holiday(year, 3, 21, "Día del abolición de la esclavitud", "Slavery Abolition Anniversary", countryCode));
            //items.Add(new Holiday(year, 3, 31, "Aniversario del fundacion del San Cristóbal", "Foundation anniversary Day of San Cristóbal, Táchira", countryCode));
            //items.Add(new Holiday(year, 4, 19, "Diez y nueve de abril", "Beginning of the Independence Movement", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Día del Trabajador", "Labor Day", countryCode));
            //items.Add(new Holiday(year, 5, 3, "Día del Cruz del Mayo", "Fiesta de las Cruces", countryCode));
            //items.Add(new Holiday(secondSundayInMay, "Día de las Madres", "Mother's Day", countryCode));
            ////items.Add(new Holiday(thirdSundayInJune, "Día de los Padres", "Father's Day", countryCode));
            //items.Add(new Holiday(year, 6, 24, "Día de San Juan Bautista y aniversario de la Batalla de Carabobo", "Army Day", countryCode));
            //items.Add(new Holiday(year, 6, 27, "Día del Periodista y aniversario de la instauración del Decreto de Instrucción pública gratuita y obligatoria", "Journalists' Day", countryCode));
            //items.Add(new Holiday(year, 7, 5, "Cinco de julio", "Independence Day", countryCode));
            //items.Add(new Holiday(thirdSundayInJuly, "Dia del niño", "Children's Day", countryCode));
            //items.Add(new Holiday(year, 7, 24, "Natalicio del Libertador, Dia de la Armada Nacional", "Navy Day", countryCode));
            //items.Add(new Holiday(year, 7, 25, "Aniversario del fundacion del Caracas", "Caracas City Foundation Day", countryCode));
            //items.Add(new Holiday(year, 8, 3, "Día de la Bandera", "Flag Day", countryCode));
            //items.Add(new Holiday(year, 9, 8, "Día del Virgen del Valle, aparicion del Virgen del Coromoto", "Birth of the Blessed Virgin Mary and feasts of the Virgen del Valle and Our Lady of Coromoto", countryCode));
            //items.Add(new Holiday(year, 9, 24, "Día del Virgen de las Mercedes", "Feast of the Our Lady of Mercy", countryCode));
            //items.Add(new Holiday(year, 10, 12, "Día de la Resistencia Indígena", "Day of Indigenous Resistance", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Día de Todos los Santos", "All Saints' Day", countryCode));
            //items.Add(new Holiday(year, 11, 2, "Día de los fieles difuntos", "All Souls' Day", countryCode));
            //items.Add(new Holiday(year, 11, 17, "Feria de la Chinita", "Feria of La Chinita", countryCode));
            //items.Add(new Holiday(year, 11, 18, "Feria de la Chinita", "Feria of La Chinita", countryCode));
            //items.Add(new Holiday(year, 11, 19, "Feria de la Chinita", "Feria of La Chinita", countryCode));
            //items.Add(new Holiday(year, 11, 21, "Día del estudiante universitario", "University Students Day", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Inmaculada Concepción, Dia de la Lealtad", "Immaculate Conception, Loyalty Day", countryCode));
            //items.Add(new Holiday(year, 12, 17, "Aniversario de la muerte de Libertador Simon Bolivar", "Simon Bolivar Memorial Day", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Nochebuena", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "Nochevieja", "New Year's Eve", countryCode));
            //return items.OrderBy(o => o.Date);

            //items.Add(new PublicHoliday(year, 5, 25, "Día del Himno Nacional", "National Anthem Day", countryCode));//not a public holiday
            //items.Add(new PublicHoliday(year, 8, 4, "Día de la Guardia Nacional", "National Guard Day", countryCode));//not a public holiday
            //items.Add(new PublicHoliday(year, 12, 10, "Día de la Aviacion Militar", "Venezuelan Air Force Day", countryCode));//not a public holiday
            //items.Add(new PublicHoliday(year, 3, 28, "Día Nacional del Patrimonio Cultural", "National Cultural Patrimonies Day", countryCode)); //not a public holiday
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Venezuela"
            };
        }
    }
}
