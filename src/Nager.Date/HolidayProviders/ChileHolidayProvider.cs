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
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
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
                    Id = "NAVYDAY-01",
                    Date = new DateTime(year, 5, 21),
                    EnglishName = "Navy Day",
                    LocalName = "Día de las Glorias Navales",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "BATTLEOFARICA-01",
                    Date = new DateTime(year, 6, 7),
                    EnglishName = "Battle of Arica",
                    LocalName = "Asalto y Toma del Morro de Arica",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CL-AP"]
                },
                new HolidaySpecification
                {
                    Id = "OURLADYMOUNTCARMEL-01",
                    Date = new DateTime(year, 7, 16),
                    EnglishName = "Our Lady of Mount Carmel",
                    LocalName = "Virgen del Carmen",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ASSUMPTIONOFMARY-01",
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption of Mary",
                    LocalName = "Asunción de la Virgen",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALHOLIDAY-01",
                    Date = new DateTime(year, 9, 18),
                    EnglishName = "National holiday",
                    LocalName = "Fiestas Patrias",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ARMYDAY-01",
                    Date = new DateTime(year, 9, 19),
                    EnglishName = "Army Day",
                    LocalName = "Día de las Glorias del Ejército",
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
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad / Natividad del Señor",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Viernes Santo", year),
                this._catholicProvider.EasterSaturday("Sábado Santo", year)
            };

            holidaySpecifications.AddIfNotNull(this.SaintPeterAndSaintPaul(year));
            holidaySpecifications.AddIfNotNull(this.ColumbusDay(year));
            holidaySpecifications.AddIfNotNull(this.ReformationDay(year));
            holidaySpecifications.AddIfNotNull(this.NationalPlebiscite(year));
            holidaySpecifications.AddIfNotNull(this.NationalDayOfIndigenousPeoples(year));
            holidaySpecifications.AddIfNotNull(this.AdditionalNationalHoliday(year));
            holidaySpecifications.AddIfNotNull(this.NationalCensus(year));
            holidaySpecifications.AddIfNotNull(this.NationalHolidaySeptember16(year));
            holidaySpecifications.AddRangeIfNotNull(this.PapalVisit(year));

            return holidaySpecifications;
        }

        private HolidaySpecification SaintPeterAndSaintPaul(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1), //Move to Monday
                Wednesday = date => date.AddDays(-2), //Move to Monday
                Thursday = date => date.AddDays(-3), //Move to Monday
                Friday = date => date.AddDays(3), //Move to next Monday
            };

            return new HolidaySpecification
            {
                Id = "SAINTSPETERPAUL-01",
                Date = new DateTime(year, 6, 29),
                EnglishName = "Saint Peter and Saint Paul",
                LocalName = "San Pedro y San Pablo",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = year >= 2000 ? observedRuleSet : null //Ley 19.668
            };
        }

        private HolidaySpecification ColumbusDay(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1), //Move to Monday
                Wednesday = date => date.AddDays(-2), //Move to Monday
                Thursday = date => date.AddDays(-3), //Move to Monday
                Friday = date => date.AddDays(3), //Move to next Monday
            };

            return new HolidaySpecification
            {
                Id = "COLUMBUSDAY-01",
                Date = new DateTime(year, 10, 12),
                EnglishName = "Columbus Day",
                LocalName = "Día del Descubrimiento de Dos Mundos",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = year >= 2000 ? observedRuleSet : null //Ley 19.668
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
                Id = "REFORMATIONDAY-01",
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
                Id = "NATIONALPLEBISCITE-01",
                Date = new DateTime(year, 9, 4),
                EnglishName = "National plebiscite",
                LocalName = "Plebiscito nacional",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? NationalDayOfIndigenousPeoples(int year)
        {
            DateTime? holidayDate = year switch
            {
                2021 => new DateTime(year, 06, 21),
                2022 => new DateTime(year, 06, 21),
                2023 => new DateTime(year, 06, 21),
                2024 => new DateTime(year, 06, 20),
                2025 => new DateTime(year, 06, 20),
                2026 => new DateTime(year, 06, 21),
                2027 => new DateTime(year, 06, 21),
                2028 => new DateTime(year, 06, 20),
                2029 => new DateTime(year, 06, 20),
                2030 => new DateTime(year, 06, 21),
                _ => null,
            };

            if (holidayDate is null)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "NATIONALDAYINDIGENOUSPEOPLES-01",
                Date = holidayDate.Value,
                EnglishName = "National Day of Indigenous Peoples",
                LocalName = "Día Nacional de los Pueblos Indígenas",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? AdditionalNationalHoliday(int year)
        {
            var nationalHoliday = new DateTime(year, 9, 18);

            DateTime? holidayDate = nationalHoliday.DayOfWeek switch
            {
                //Ley 20.215, Código del Trabajo art. 35 ter
                DayOfWeek.Tuesday when year >= 2007 => nationalHoliday.AddDays(-1),
                DayOfWeek.Wednesday when year >= 2007 => nationalHoliday.AddDays(2),
                //Ley 20.983
                DayOfWeek.Saturday when year >= 2017 => nationalHoliday.AddDays(-1),
                _ => null,
            };

            if (holidayDate is null)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "NATIONALHOLIDAY-02",
                Date = holidayDate.Value,
                EnglishName = "Additional National holiday",
                LocalName = "Feriado adicional de Fiestas Patrias",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? NationalCensus(int year)
        {
            //Ley 17.374 art. 47
            if (year != 2017)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "NATIONALCENSUS-01",
                Date = new DateTime(year, 4, 19),
                EnglishName = "National census",
                LocalName = "Censo Nacional",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? NationalHolidaySeptember16(int year)
        {
            //Ley 21.482
            if (year != 2022)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "NATIONALHOLIDAY-03",
                Date = new DateTime(year, 9, 16),
                EnglishName = "Additional National holiday",
                LocalName = "Feriado adicional de Fiestas Patrias",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification[] PapalVisit(int year)
        {
            if (year != 2018)
            {
                return [];
            }

            return
            [
                new HolidaySpecification
                {
                    Id = "PAPALVISIT-01",
                    Date = new DateTime(year, 1, 16),
                    EnglishName = "Papal visit",
                    LocalName = "Visita del Papa Francisco",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CL-RM"]
                },
                new HolidaySpecification
                {
                    Id = "PAPALVISIT-02",
                    Date = new DateTime(year, 1, 17),
                    EnglishName = "Papal visit",
                    LocalName = "Visita del Papa Francisco",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CL-AR"]
                },
                new HolidaySpecification
                {
                    Id = "PAPALVISIT-03",
                    Date = new DateTime(year, 1, 18),
                    EnglishName = "Papal visit",
                    LocalName = "Visita del Papa Francisco",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CL-TA"]
                }
            ];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Chile",
                "https://www.dt.gob.cl/portal/1628/w3-article-60252.html",
                "https://www.diariooficial.interior.gob.cl/publicaciones/2016/12/30/41646/01/1161478.pdf",
                "https://www.derechopedia.cl/Art%C3%ADculo_35_ter_del_C%C3%B3digo_del_Trabajo",
                "https://www.dt.gob.cl/legislacion/1624/w3-article-111948.html",
                "https://dt.gob.cl/portal/1627/w3-article-114348.html",
                "https://dt.gob.cl/legislacion/1624/w3-article-122697.html",
            ];
        }
    }
}
