using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Chile HolidayProvider
    /// </summary>
    internal sealed class ChileHolidayProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Chile HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ChileHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
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

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CL;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var observedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Día del Trabajo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 21),
                    EnglishName = "Navy Day",
                    LocalName = "Día de las Glorias Navales",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 7),
                    EnglishName = "Battle of Arica",
                    LocalName = "Asalto y Toma del Morro de Arica",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CL-AP"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 16),
                    EnglishName = "Our Lady of Mount Carmel",
                    LocalName = "Virgen del Carmen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption of Mary",
                    LocalName = "Asunción de la Virgen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 18),
                    EnglishName = "National holiday",
                    LocalName = "Fiestas Patrias",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 19),
                    EnglishName = "Army Day",
                    LocalName = "Día de las Glorias del Ejército",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints",
                    LocalName = "Día de Todos los Santos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Inmaculada Concepción",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad / Natividad del Señor",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Viernes Santo", year),
                this._catholicProvider.EasterSaturday("Sábado Santo", year)
            };

            holidaySpecifications.AddIfNotNull(this.SaintPeterAndSaintPaul(year));
            holidaySpecifications.AddIfNotNull(this.ColumbusDay(year));
            holidaySpecifications.AddIfNotNull(this.ReformationDay(year));
            holidaySpecifications.AddIfNotNull(this.NationalPlebiscite(year));
            holidaySpecifications.AddIfNotNull(this.NationalDayOfIndigenousPeoples(year));

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();

            //var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            //items.Add(new Holiday(newYearDay, "Año Nuevo", "New Year's Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-1), "Sábado Santo", "Holy Saturday", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Día del Trabajo", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 21, "Día de las Glorias Navales", "Navy Day", countryCode));
            //items.Add(new Holiday(year, 6, 7, "Asalto y Toma del Morro de Arica", "Battle of Arica", countryCode, null, new string[] { "CL-AP" }));

            //TODO:National Day of Aboriginal Peoples (This holiday is to be observed on each Winter Solstice.)
            //The winter solstice, also called the hibernal solstice, occurs when either of Earth's poles reaches its maximum tilt away from the Sun

            //items.Add(new Holiday(year, 7, 16, "Virgen del Carmen", "Our Lady of Mount Carmel", countryCode, launchYear: 2007));
            //items.Add(new Holiday(year, 8, 15, "Asunción de la Virgen", "Assumption of Mary", countryCode));
            //items.Add(new Holiday(year, 9, 18, "Fiestas Patrias", "National holiday", countryCode));
            //items.Add(new Holiday(year, 9, 19, "Día de las Glorias del Ejército", "Army Day", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Día de Todos los Santos", "All Saints", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Inmaculada Concepción", "Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Navidad / Natividad del Señor", "Christmas Day", countryCode));

            //items.AddIfNotNull(this.SaintPeterAndSaintPaul(year, countryCode));
            //items.AddIfNotNull(this.ColumbusDay(year, countryCode));
            //items.AddIfNotNull(this.ReformationDay(year, countryCode));
            //items.AddIfNotNull(this.NationalPlebiscite(year, countryCode));
            //items.AddIfNotNull(this.NationalDayOfIndigenousPeoples(year, countryCode));

            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification SaintPeterAndSaintPaul(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1), //Move to Monday
                Wednesday = date => date.AddDays(-2), //Move to Monday
                Thursday = date => date.AddDays(-3), //Move to Monday
                Friday = date => date.AddDays(1), //Move to Saturday
            };

            return new HolidaySpecification
            {
                Date = new DateTime(year, 6, 27),
                EnglishName = "Saint Peter and Saint Paul",
                LocalName = "San Pedro y San Pablo",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(date, "San Pedro y San Pablo", "Saint Peter and Saint Paul", countryCode);
        }

        private HolidaySpecification ColumbusDay(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1), //Move to Monday
                Wednesday = date => date.AddDays(-2), //Move to Monday
                Thursday = date => date.AddDays(-3), //Move to Monday
                Friday = date => date.AddDays(1), //Move to Saturday
            };

            return new HolidaySpecification
            {
                Date = new DateTime(year, 10, 12),
                EnglishName = "Columbus Day",
                LocalName = "Día del Descubrimiento de Dos Mundos",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(date, "Día del Descubrimiento de Dos Mundos", "Columbus Day", countryCode);
        }

        private HolidaySpecification ReformationDay(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-4), //Move to Friday
                Wednesday = date => date.AddDays(2), //Move to Friday
            };

            return new HolidaySpecification
            {
                Date = new DateTime(year, 10, 31),
                EnglishName = "Reformation Day",
                LocalName = "Día Nacional de las Iglesias Evangélicas y Protestantes",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(date, "Día Nacional de las Iglesias Evangélicas y Protestantes", "Reformation Day", countryCode);
        }

        private HolidaySpecification NationalPlebiscite(int year)
        {
            if (year != 2022)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 9, 4),
                EnglishName = "National plebiscite",
                LocalName = "Plebiscito nacional",
                HolidayTypes = HolidayTypes.Public
            };

            //return new Holiday(year, 9, 4, "Plebiscito nacional", "National plebiscite", countryCode);
        }

        private DateTime? GetWinterSolstice(int year)
        {
            switch (year)
            {
                case 2021:
                    return new DateTime(year, 06, 21);
                case 2022:
                    return new DateTime(year, 06, 21);
                case 2023:
                    return new DateTime(year, 06, 21);
                case 2024:
                    return new DateTime(year, 06, 20);
                case 2025:
                    return new DateTime(year, 06, 21);
                case 2026:
                    return new DateTime(year, 06, 21);
                case 2027:
                    return new DateTime(year, 06, 21);
                case 2028:
                    return new DateTime(year, 06, 21);
                default:
                    return null;
            }
        }

        private HolidaySpecification NationalDayOfIndigenousPeoples(int year)
        {
            var winterSolstice = this.GetWinterSolstice(year);
            if (winterSolstice == null)
            {
                return null;
            }

            /*
             * N° Ley: 21.357
             * Fecha de promulgación: 2021-06-17
            */

            return new HolidaySpecification
            {
                Date = winterSolstice.Value,
                EnglishName = "National Day of Indigenous Peoples",
                LocalName = "Día Nacional de los Pueblos Indígenas",
                HolidayTypes = HolidayTypes.Public
            };

            //return new Holiday(winterSolstice.Value, "Día Nacional de los Pueblos Indígenas", "National Day of Indigenous Peoples", countryCode);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Chile",
            };
        }
    }
}
