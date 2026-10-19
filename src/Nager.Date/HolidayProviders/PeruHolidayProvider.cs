using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Peru HolidayProvider
    /// </summary>
    internal sealed class PeruHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Peru HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PeruHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.PE)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

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
                    Id = "SAINTSPETERPAUL-01",
                    Date = new DateTime(year, 6, 29),
                    EnglishName = "Saint Peter and Saint Paul",
                    LocalName = "Día de San Pedro y San Pablo",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "FIESTASPATRIAS-01",
                    Date = new DateTime(year, 7, 28),
                    EnglishName = "Independence Day",
                    LocalName = "Fiestas Patrias",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "FIESTASPATRIAS-02",
                    Date = new DateTime(year, 7, 29),
                    EnglishName = "Independence Day",
                    LocalName = "Fiestas Patrias",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "SANTAROSADELIMA-01",
                    Date = new DateTime(year, 8, 30),
                    EnglishName = "Santa Rosa de Lima",
                    LocalName = "Santa Rosa de Lima",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "BATTLEOFANGAMOS-01",
                    Date = new DateTime(year, 10, 8),
                    EnglishName = "Battle of Angamos",
                    LocalName = "Combate de Angamos",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "Día de Todos los Santos",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "IMMACULATECONCEPTION-01",
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Inmaculada Concepción",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "BATTLEOFAYACUCHO-01",
                    Date = new DateTime(year, 12, 9),
                    EnglishName = "Battle of Ayacucho",
                    LocalName = "Batalla de Ayacucho",
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
                this._catholicProvider.EasterSunday("Domingo Santo", year)
            };

            holidaySpecifications.AddIfNotNull(this.FlagDay(year));
            holidaySpecifications.AddIfNotNull(this.AirForceDay(year));
            holidaySpecifications.AddIfNotNull(this.BattleOfJunin(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? FlagDay(int year)
        {
            //Ley N.° 31788, published on 15 June 2023
            if (year < 2024)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "FLAGDAY-01",
                Date = new DateTime(year, 6, 7),
                EnglishName = "Battle of Arica and Flag Day",
                LocalName = "Batalla de Arica y Día de la Bandera",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? AirForceDay(int year)
        {
            if (year < 2023)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "AIRFORCEDAY-01",
                Date = new DateTime(year, 7, 23),
                EnglishName = "Air Force Day",
                LocalName = "Día de la Fuerza Aérea",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? BattleOfJunin(int year)
        {
            if (year < 2022)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "BATTLEOFJUNIN-01",
                Date = new DateTime(year, 8, 6),
                EnglishName = "Battle of Junin",
                LocalName = "Batalla de Junin",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://www.gob.pe/feriados/historicos?year=2026",
                "https://en.wikipedia.org/wiki/Public_holidays_in_Peru",
                "https://www.gob.pe/feriados",
                "https://www.radionacional.gob.pe/noticias/locales/feriado-nacional-conoce-aqui-que-se-celebra-este-martes-23-de-julio",
            ];
        }
    }
}
