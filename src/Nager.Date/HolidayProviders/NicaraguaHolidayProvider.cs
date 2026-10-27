using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Nicaragua HolidayProvider
    /// </summary>
    internal sealed class NicaraguaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Nicaragua HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NicaraguaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.NI)
        {
            this._catholicProvider = catholicProvider;
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
                    Id = "AIRFORCEDAY-01",
                    Date = new DateTime(year, 2, 1),
                    EnglishName = "Air Force Day",
                    LocalName = "Día de la Fuerza Aérea",
                    HolidayTypes = HolidayTypes.Authorities,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Día Internacional de los Trabajadores",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ARMYDAY-01",
                    Date = new DateTime(year, 5, 27),
                    EnglishName = "Army Day",
                    LocalName = "Día del Ejército",
                    HolidayTypes = HolidayTypes.Authorities,
                },
                new HolidaySpecification
                {
                    Id = "LIBERATIONDAY-01",
                    Date = new DateTime(year, 7, 19),
                    EnglishName = "Liberation Day",
                    LocalName = "Día de la Revolución Popular Sandinista",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "BATTLESANJACINTO-01",
                    Date = new DateTime(year, 9, 14),
                    EnglishName = "Battle of San Jacinto",
                    LocalName = "Batalla de San Jacinto",
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
                    Id = "INDIGENOUSRESISTANCEDAY-01",
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Indigenous Resistance Day",
                    LocalName = "Día de la Resistencia Indígena",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "IMMACULATECONCEPTION-01",
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Día de la Purísima Concepción",
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
                new HolidaySpecification
                {
                    Id = "NEWYEARSEVE-01",
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Fin de Año",
                    HolidayTypes = HolidayTypes.Observance,
                },
                this._catholicProvider.MaundyThursday("Jueves Santo", year),
                this._catholicProvider.GoodFriday("Viernes Santo", year),
            };

            holidaySpecifications.AddIfNotNull(this.MothersDay(year));
            holidaySpecifications.AddIfNotNull(this.RubenDarioBirthday(year));
            holidaySpecifications.AddIfNotNull(this.ReconciliationAndPeaceDay(year));
            holidaySpecifications.AddIfNotNull(this.SandinoDay(year));
            holidaySpecifications.AddIfNotNull(this.CarlosFonsecaDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification MothersDay(int year)
        {
            //Before 2022 the government only granted a day off for the public sector by decree
            //Since Ley N.º 1118 (La Gaceta N.º 92 of 20 May 2022) it is a mandatory national holiday (Código del Trabajo, Art. 66)
            var holidayTypes = year < 2022
                ? HolidayTypes.Authorities
                : HolidayTypes.Public;

            return new HolidaySpecification
            {
                Id = "MOTHERSDAY-01",
                Date = new DateTime(year, 5, 30),
                EnglishName = "Mother's Day",
                LocalName = "Día de las Madres",
                HolidayTypes = holidayTypes,
            };
        }

        private HolidaySpecification? RubenDarioBirthday(int year)
        {
            //Ley N.º 1272, La Gaceta N.º 11 of 20 January 2026
            if (year < 2026)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "RUBENDARIOBIRTHDAY-01",
                Date = new DateTime(year, 1, 18),
                EnglishName = "Birthday of Rubén Darío",
                LocalName = "Natalicio de Rubén Darío",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? ReconciliationAndPeaceDay(int year)
        {
            //Ley N.º 1272, La Gaceta N.º 11 of 20 January 2026
            if (year < 2026)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "RECONCILIATIONANDPEACEDAY-01",
                Date = new DateTime(year, 2, 2),
                EnglishName = "National Day of Reconciliation and Peace",
                LocalName = "Día Nacional de la Reconciliación y la Paz",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? SandinoDay(int year)
        {
            //Ley N.º 1272, La Gaceta N.º 11 of 20 January 2026
            if (year < 2026)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "SANDINODAY-01",
                Date = new DateTime(year, 2, 21),
                EnglishName = "Anniversary of the Death of Augusto C. Sandino",
                LocalName = "Paso a la Inmortalidad del General Augusto C. Sandino",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? CarlosFonsecaDay(int year)
        {
            //Ley N.º 1272, La Gaceta N.º 11 of 20 January 2026
            if (year < 2026)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "CARLOSFONSECADAY-01",
                Date = new DateTime(year, 11, 8),
                EnglishName = "Anniversary of the Death of Carlos Fonseca",
                LocalName = "Paso a la Inmortalidad del Comandante Carlos Fonseca Amador",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                // A Wikipedia article providing a comprehensive overview of public holidays in Nicaragua, including national mandatory holidays, regional traditions, and historical context.
                "https://en.wikipedia.org/wiki/Public_holidays_in_Nicaragua",

                // A news article from Revista Estrategia & Negocios reporting on the National Assembly's approval of new national holidays, bringing the country's total to 14 official public holidays.
                "https://www.revistaeyn.com/centroamericaymundo/nicaragua-con-mas-descansos-en-el-ano-14-feriados-NE28979444",

                // A Bloomberg Línea article explaining the Ministry of Labor (MITRAB) guidelines regarding mandatory pay, overtime rules, and employee rest for the July 19th Revolutionary Day public holiday in Nicaragua.
                "https://www.bloomberglinea.com/2025/07/17/esto-dice-mitrab-sobre-el-pago-del-feriado-del-19-de-julio-en-nicaragua/"
            ];
        }
    }
}
