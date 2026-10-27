using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// El Salvador HolidayProvider
    /// </summary>
    internal sealed class ElSalvadorHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// El Salvador HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ElSalvadorHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.SV)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "SV-AH", "Ahuachapán" },
                { "SV-CA", "Cabañas" },
                { "SV-CH", "Chalatenango" },
                { "SV-CU", "Cuscatlán" },
                { "SV-LI", "La Libertad" },
                { "SV-MO", "Morazán" },
                { "SV-PA", "La Paz" },
                { "SV-SA", "Santa Ana" },
                { "SV-SM", "San Miguel" },
                { "SV-SO", "Sonsonate" },
                { "SV-SS", "San Salvador" },
                { "SV-SV", "San Vicente" },
                { "SV-UN", "La Unión" },
                { "SV-US", "Usulután" },
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Día del Trabajo",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MOTHERSDAY-01",
                    Date = new DateTime(year, 5, 10),
                    EnglishName = "Mother's Day",
                    LocalName = "Día de las Madres",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "AUGUSTFESTIVALS-01",
                    Date = new DateTime(year, 8, 3),
                    EnglishName = "August Festivals",
                    LocalName = "Fiestas Agostinas",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["SV-SS"]
                },
                new HolidaySpecification
                {
                    Id = "AUGUSTFESTIVALS-02",
                    Date = new DateTime(year, 8, 5),
                    EnglishName = "August Festivals",
                    LocalName = "Fiestas Agostinas",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["SV-SS"]
                },
                new HolidaySpecification
                {
                    Id = "DIVINESAVIOUR-01",
                    Date = new DateTime(year, 8, 6),
                    EnglishName = "Feast of the Divine Saviour of the World",
                    LocalName = "Fiesta del Divino Salvador del Mundo",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 9, 15),
                    EnglishName = "Independence Day",
                    LocalName = "Día de la Independencia",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ALLSOULSDAY-01",
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "All Souls' Day",
                    LocalName = "Día de los Difuntos",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.MaundyThursday("Jueves Santo", year),
                this._catholicProvider.GoodFriday("Viernes Santo", year),
                this._catholicProvider.EasterSaturday("Sábado Santo", year),
            };

            holidaySpecifications.AddIfNotNull(this.FathersDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? FathersDay(int year)
        {
            if (year < 2013)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "FATHERSDAY-01",
                Date = new DateTime(year, 6, 17),
                EnglishName = "Father's Day",
                LocalName = "Día del Padre",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_El_Salvador",
                "https://diario.elmundo.sv/economia/que-dias-son-los-asuetos-remunerados-en-2025",
            ];
        }
    }
}
