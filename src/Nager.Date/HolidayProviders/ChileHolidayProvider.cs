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
                { "CL-NB", "Región de Ñuble" },
                { "CL-RM", "Región Metropolitana" },
                { "CL-TA", "Región de Tarapacá" },
                { "CL-VS", "Región de Valparaíso" }
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Día Nacional del Trabajo",
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
                    Id = "ASSUMPTIONOFMARY-01",
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption of Mary",
                    LocalName = "Asunción de la Virgen",
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

            holidaySpecifications.AddIfNotNull(this.NewYearsDay(year));
            holidaySpecifications.AddIfNotNull(this.CorpusChristi(year));
            holidaySpecifications.AddIfNotNull(this.OurLadyOfMountCarmel(year));
            holidaySpecifications.AddIfNotNull(this.SaintPeterAndSaintPaul(year));
            holidaySpecifications.AddIfNotNull(this.ColumbusDay(year));
            holidaySpecifications.AddIfNotNull(this.ReformationDay(year));
            holidaySpecifications.AddIfNotNull(this.NationalDayOfIndigenousPeoples(year));
            holidaySpecifications.AddRangeIfNotNull(this.FiestasPatrias(year));
            holidaySpecifications.AddIfNotNull(this.NationalPlebiscite(year));
            holidaySpecifications.AddIfNotNull(this.NationalCensus(year));
            holidaySpecifications.AddIfNotNull(this.BattleOfArica(year));
            holidaySpecifications.AddIfNotNull(this.BirthOfBernardoOHiggins(year));
            holidaySpecifications.AddRangeIfNotNull(this.PapalVisit(year));

            return holidaySpecifications;
        }

        private HolidaySpecification NewYearsDay(int year)
        {
            //Ley 20.983: If 1 January falls on a Sunday, Monday 2 January is a holiday (from 2017)
            var observedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            return new HolidaySpecification
            {
                Id = "NEWYEARSDAY-01",
                Date = new DateTime(year, 1, 1),
                EnglishName = "New Year's Day",
                LocalName = "Año Nuevo",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = year >= 2017 ? observedRuleSet : null //Ley 20.983
            };
        }

        private HolidaySpecification? CorpusChristi(int year)
        {
            //Ley 20.148: Corpus Christi removed as public holiday (replaced by Our Lady of Mount Carmel from 2007)
            if (year > 2006)
            {
                return null;
            }

            //Ley 19.668: Corpus Christi (always a Thursday) moved to the Monday of the same week
            var observedRuleSet = new ObservedRuleSet
            {
                Thursday = date => date.AddDays(-3), //Move to Monday
            };

            return this._catholicProvider.CorpusChristi("Corpus Christi", year, year >= 2000 ? observedRuleSet : null);
        }

        private HolidaySpecification? OurLadyOfMountCarmel(int year)
        {
            //Ley 20.148
            if (year < 2007)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "OURLADYMOUNTCARMEL-01",
                Date = new DateTime(year, 7, 16),
                EnglishName = "Our Lady of Mount Carmel",
                LocalName = "Día de la Virgen del Carmen",
                HolidayTypes = HolidayTypes.Public,
            };
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
                LocalName = "Encuentro de Dos Mundos",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = year >= 2000 ? observedRuleSet : null //Ley 19.668
            };
        }

        private HolidaySpecification? ReformationDay(int year)
        {
            //Ley 20.299
            if (year < 2008)
            {
                return null;
            }

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

        private HolidaySpecification? NationalDayOfIndigenousPeoples(int year)
        {
            //Ley 21.357: Holiday on the day of the June solstice
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

        private HolidaySpecification[] FiestasPatrias(int year)
        {
            var nationalHoliday = new DateTime(year, 9, 18);
            var armyDay = new DateTime(year, 9, 19);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NATIONALHOLIDAY-01",
                    Date = nationalHoliday,
                    EnglishName = "National holiday",
                    LocalName = "Independencia Nacional",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ARMYDAY-01",
                    Date = armyDay,
                    EnglishName = "Army Day",
                    LocalName = "Día de las Glorias del Ejército",
                    HolidayTypes = HolidayTypes.Public,
                }
            };

            //Additional holiday depending on the weekdays of 18 and 19 September
            DateTime? additionalHolidayDate = nationalHoliday.DayOfWeek switch
            {
                //Ley 20.215, Código del Trabajo art. 35 ter
                DayOfWeek.Tuesday when year >= 2007 => nationalHoliday.AddDays(-1), //Monday 17 September
                DayOfWeek.Wednesday when year >= 2007 => nationalHoliday.AddDays(2), //Friday 20 September
                //Ley 20.983
                DayOfWeek.Saturday when year >= 2017 => nationalHoliday.AddDays(-1), //Friday 17 September
                //Ley 21.482 (one-off)
                DayOfWeek.Sunday when year == 2022 => nationalHoliday.AddDays(-2), //Friday 16 September 2022
                _ => null,
            };

            if (additionalHolidayDate is not null)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "NATIONALHOLIDAY-02",
                    Date = additionalHolidayDate.Value,
                    EnglishName = "Additional National Holiday",
                    LocalName = "Feriado adicional de Fiestas Patrias",
                    HolidayTypes = HolidayTypes.Public,
                });
            }

            return [.. holidaySpecifications];
        }

        private HolidaySpecification? NationalPlebiscite(int year)
        {
            //Ley 18.700: The day of an election or plebiscite is a legal holiday
            DateTime? plebisciteDate = year switch
            {
                2020 => new DateTime(year, 10, 25),
                2022 => new DateTime(year, 9, 4),
                2023 => new DateTime(year, 12, 17),
                _ => null,
            };

            if (plebisciteDate is null)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "NATIONALPLEBISCITE-01",
                Date = plebisciteDate.Value,
                EnglishName = "National plebiscite",
                LocalName = "Plebiscito nacional",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? NationalCensus(int year)
        {
            //Ley 17.374 (added by Ley 19.790): The day of a national census is a legal holiday
            DateTime? censusDate = year switch
            {
                2002 => new DateTime(year, 4, 24),
                2017 => new DateTime(year, 4, 19),
                _ => null,
            };

            if (censusDate is null)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "NATIONALCENSUS-01",
                Date = censusDate.Value,
                EnglishName = "National census",
                LocalName = "Censo Nacional",
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? BattleOfArica(int year)
        {
            //Ley 20.663
            if (year < 2013)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "BATTLEOFARICA-01",
                Date = new DateTime(year, 6, 7),
                EnglishName = "Battle of Arica",
                LocalName = "Asalto y Toma del Morro de Arica",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["CL-AP"]
            };
        }

        private HolidaySpecification? BirthOfBernardoOHiggins(int year)
        {
            //Ley 20.768: Only for the communes of Chillán and Chillán Viejo (Región de Ñuble)
            if (year < 2014)
            {
                return null;
            }

            return new HolidaySpecification
            {
                Id = "BIRTHOFBERNARDOOHIGGINS-01",
                Date = new DateTime(year, 8, 20),
                EnglishName = "Birth of Bernardo O'Higgins",
                LocalName = "Nacimiento del Prócer de la Independencia",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["CL-NB"]
            };
        }

        private HolidaySpecification[] PapalVisit(int year)
        {
            //Ley 21.051 (Araucanía, Tarapacá) and Ley 21.065 (Región Metropolitana)
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
                // A Wikipedia article providing a comprehensive overview of public holidays in Chile, including national holidays, regional observations, mandatory non-working days (feriados irrenunciables), and historical context.
                "https://en.wikipedia.org/wiki/Public_holidays_in_Chile",

                // An official news article from the Chilean Government (Gobierno de Chile) listing the public holidays for 2026, highlighting mandatory non-working days and long weekends.
                "https://www.gob.cl/noticias/feriados-2026-revisa-cuantos-habra-y-cuales-son-irrenunciables/",

                // An informational publication by the Chilean Labor Directorate (Dirección del Trabajo) detailing labor laws, employee rights, and mandatory closures for commercial workers on designated mandatory holidays.
                "https://www.dt.gob.cl/portal/1628/w3-article-60252.html",

                // An official PDF extract from Chile's Official Gazette (Diario Oficial de la República de Chile) publishing Law No. 20,983, establishing specific holiday rules.
                "https://www.diariooficial.interior.gob.cl/publicaciones/2016/12/30/41646/01/1161478.pdf",

                // A legal wiki entry explaining Article 35 ter of the Chilean Labor Code, which governs compensation, rest days, and legal holiday adjustments for employees under specific shift arrangements.
                "https://www.derechopedia.cl/Art%C3%ADculo_35_ter_del_C%C3%B3digo_del_Trabajo",

                // An official administrative ruling by the Labor Directorate providing legal interpretation on labor regulations, rest periods, and employer obligations during public holidays.
                "https://www.dt.gob.cl/legislacion/1624/w3-article-111948.html",

                // A Labor Directorate resource page focusing on compliance guidelines, oversight, and penalties for commercial establishments operating illegally during mandatory non-working days.
                "https://dt.gob.cl/portal/1627/w3-article-114348.html",

                // An official legal opinion from the Labor Directorate clarifying specific exemptions (e.g., restaurants, entertainment, gas stations) where employees are allowed to work on mandatory holidays.
                "https://dt.gob.cl/legislacion/1624/w3-article-122697.html",
            ];
        }
    }
}
