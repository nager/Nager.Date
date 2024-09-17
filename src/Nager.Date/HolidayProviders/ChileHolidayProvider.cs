using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Chile HolidayProvider
    /// </summary>
    internal sealed class ChileHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Chile HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ChileHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.CL)
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
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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

            return holidaySpecifications;
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
        }

        private HolidaySpecification? NationalPlebiscite(int year)
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

        private HolidaySpecification? NationalDayOfIndigenousPeoples(int year)
        {
            var winterSolstice = this.GetWinterSolstice(year);
            if (winterSolstice is null)
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
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Chile",
            ];
        }
    }
}
