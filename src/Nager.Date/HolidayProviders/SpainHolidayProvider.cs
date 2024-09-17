using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Spain HolidayProvider
    /// </summary>
    internal sealed class SpainHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Spain HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SpainHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.ES)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            //https://en.wikipedia.org/wiki/ISO_3166-2:ES

            return new Dictionary<string, string>
            {
                { "ES-AN", "Andalusia" },
                { "ES-AR", "Aragon" },
                { "ES-AS", "Principality of Asturias" },
                { "ES-CN", "Canary Islands" },
                { "ES-CB", "Cantabria" },
                { "ES-CL", "Castile and León" },
                { "ES-CM", "Castile-La Mancha" },
                { "ES-CT", "Catalonia" },
                { "ES-EX", "Extremadura" },
                { "ES-GA", "Galicia" },
                { "ES-IB", "Balearic Islands" },
                { "ES-RI", "La Rioja" },
                { "ES-MD", "Community of Madrid" },
                { "ES-MC", "Region of Murcia" },
                { "ES-NC", "Chartered Community of Navarre" },
                { "ES-PV", "Basque Country" },
                { "ES-VC", "Valencian Community" },
                //Not a community
                //{ "ES-CE", "Ceuta" },
                //{ "ES-ML", "Melilla" },
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Día de Reyes / Epifanía del Señor",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Fiesta del trabajo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Fiesta Nacional de España",
                    LocalName = "Fiesta Nacional de España",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "Día de todos los Santos",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 6),
                    EnglishName = "Constitution Day",
                    LocalName = "Día de la Constitución",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Inmaculada Concepción",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Viernes Santo", year)
            };

            holidaySpecifications.AddIfNotNull(this.ChristmasDay(year));
            holidaySpecifications.AddIfNotNull(this.CorpusChristi(year));
            holidaySpecifications.AddIfNotNull(this.EasterMonday(year));
            holidaySpecifications.AddIfNotNull(this.MaundyThursday(year));
            holidaySpecifications.AddIfNotNull(this.Assumption(year));
            holidaySpecifications.AddIfNotNull(this.CarnivalTuesday(year));
            holidaySpecifications.AddIfNotNull(this.CastileAndLeonDay(year));
            holidaySpecifications.AddIfNotNull(this.DayOfAndalucia(year));
            holidaySpecifications.AddIfNotNull(this.DayOfAragon(year));
            holidaySpecifications.AddIfNotNull(this.DayOfAsturias(year));
            holidaySpecifications.AddIfNotNull(this.DayOfCastillaLaMancha(year));
            holidaySpecifications.AddIfNotNull(this.DayOfExtremadura(year));
            holidaySpecifications.AddIfNotNull(this.DayOfLaRioja(year));
            holidaySpecifications.AddIfNotNull(this.DayOfMadrid(year));
            holidaySpecifications.AddIfNotNull(this.DayOfMurcia(year));
            holidaySpecifications.AddIfNotNull(this.DayOfTheBalearicIslands(year));
            holidaySpecifications.AddIfNotNull(this.DayOfTheCanaryIslands(year));
            holidaySpecifications.AddIfNotNull(this.DayOfTheCantabrianInstitutions(year));
            holidaySpecifications.AddIfNotNull(this.DayOfTheValencianCommunity(year));
            holidaySpecifications.AddIfNotNull(this.GalicianLiteratureDay(year));
            holidaySpecifications.AddIfNotNull(this.LaBienAparecida(year));
            holidaySpecifications.AddIfNotNull(this.NationalDayOfCatalonia(year));
            holidaySpecifications.AddRangeIfNotNull(this.NewYearsDay(year));
            holidaySpecifications.AddIfNotNull(this.SantiagoApostol(year));
            holidaySpecifications.AddIfNotNull(this.StJohnsDay(year));
            holidaySpecifications.AddIfNotNull(this.StJosephsDay(year));
            holidaySpecifications.AddIfNotNull(this.StStephensDay(year));
            holidaySpecifications.AddIfNotNull(this.WhitMonday(year));

            return holidaySpecifications;
        }

        private HolidaySpecification[] NewYearsDay(int year)
        {
            var newYearsDay1 = new HolidaySpecification
            {
                Date = new DateTime(year, 1, 1),
                EnglishName = "New Year's Day",
                LocalName = "Año Nuevo",
                HolidayTypes = HolidayTypes.Public
            };

            switch (year)
            {
                case 2023:
                    var newYearsDay2 = new HolidaySpecification
                    {
                        Date = new DateTime(year, 1, 1),
                        EnglishName = "New Year's Day",
                        LocalName = "Año Nuevo",
                        HolidayTypes = HolidayTypes.Public,
                        SubdivisionCodes = ["ES-AN", "ES-AR", "ES-AS", "ES-CL", "ES-MC"]
                    };

                    return
                    [
                        newYearsDay1,
                        newYearsDay2
                    ];
                default:
                    break;
            }

            return
            [
                newYearsDay1
            ];
        }

        private HolidaySpecification EasterMonday(int year)
        {
            return this._catholicProvider.EasterMonday("Lunes de Pascua", year).SetSubdivisionCodes("ES-CT", "ES-IB", "ES-RI", "ES-NC", "ES-PV", "ES-VC");
        }

        private HolidaySpecification CorpusChristi(int year)
        {
            return this._catholicProvider.CorpusChristi("Corpus Christi", year).SetSubdivisionCodes("ES-CM");
        }

        private HolidaySpecification MaundyThursday(int year)
        {
            return this._catholicProvider.MaundyThursday("Jueves Santo", year).SetSubdivisionCodes("ES-AN", "ES-AR", "ES-CL", "ES-CM", "ES-CN", "ES-EX", "ES-GA", "ES-IB", "ES-RI", "ES-MD", "ES-MC", "ES-NC", "ES-AS", "ES-PV", "ES-CB");
        }

        private HolidaySpecification ChristmasDay(int year)
        {
            if (year == 2022)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["ES-AN", "ES-AR", "ES-AS", "ES-CN", "ES-CB", "ES-CL", "ES-CM", "ES-EX", "ES-GA", "ES-IB", "ES-RI", "ES-MD", "ES-MC", "ES-NC"]
                };
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 12, 25),
                EnglishName = "Christmas Day",
                LocalName = "Navidad",
                HolidayTypes = HolidayTypes.Public
            };
        }

        private HolidaySpecification? WhitMonday(int year)
        {
            if (year == 2022)
            {
                return this._catholicProvider.WhitMonday("Lunes de Pascua Granada", year).SetSubdivisionCodes("ES-CT");
            }

            return null;
        }

        private HolidaySpecification Assumption(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            return new HolidaySpecification
            {
                Date = new DateTime(year, 8, 15),
                EnglishName = "Assumption",
                LocalName = "Asunción",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };
        }

        private HolidaySpecification DayOfMadrid(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            return new HolidaySpecification
            {
                Date = new DateTime(year, 5, 2),
                EnglishName = "Day of Madrid",
                LocalName = "Fiesta de la Comunidad de Madrid",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-MD"],
                ObservedRuleSet = observedRuleSet
            };
        }

        private HolidaySpecification? StJosephsDay(int year)
        {
            if (year < 2000)
            {
                return null;
            }

            string[] subdivisionCodes;

            switch (year)
            {
                case 2000:
                case 2001:
                case 2002:
                case 2003:
                case 2004:
                case 2005:
                case 2006:
                case 2007:
                case 2008:
                case 2009:
                case 2010:
                case 2011:
                case 2012:
                case 2013:
                case 2014:
                    subdivisionCodes = ["ES-AR", "ES-CL", "ES-CM", "ES-EX", "ES-GA", "ES-MD", "ES-PV", "ES-VC"];
                    break;
                case 2015:
                    subdivisionCodes = ["ES-CM", "ES-MD", "ES-PV", "ES-VC"];
                    break;
                case 2016:
                    subdivisionCodes = ["ES-PV", "ES-VC"];
                    break;
                case 2017:
                    subdivisionCodes = ["ES-EX", "ES-MD"];
                    break;
                case 2018:
                case 2019:
                    subdivisionCodes = ["ES-GA", "ES-PV", "ES-VC"];
                    break;
                case 2020:
                    subdivisionCodes = ["ES-CM", "ES-GA", "ES-PV", "ES-VC"];
                    break;
                case 2021:
                    subdivisionCodes = ["ES-EX", "ES-GA", "ES-MD", "ES-PV", "ES-VC"];
                    break;
                case 2022:
                    subdivisionCodes = ["ES-VC"];
                    break;
                case 2023:
                    subdivisionCodes = ["ES-MD"];
                    break;
                default:
                    return null;
            }

            var observedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            return new HolidaySpecification
            {
                Date = new DateTime(year, 3, 19),
                EnglishName = "St. Joseph's Day",
                LocalName = "San José",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = subdivisionCodes,
                ObservedRuleSet = observedRuleSet
            };
        }

        private HolidaySpecification? SantiagoApostol(int year)
        {
            string[] subdivisionCodes;

            switch (year)
            {
                case 2017:
                    subdivisionCodes = ["ES-CL", "ES-CN", "ES-GA", "ES-MD", "ES-PV"];
                    break;
                case 2018:
                    subdivisionCodes = ["ES-GA"];
                    break;
                case 2019:
                    subdivisionCodes = ["ES-GA", "ES-PV"];
                    break;
                case 2020:
                    subdivisionCodes = ["ES-GA", "ES-PV"];
                    break;
                case 2022:
                    subdivisionCodes = ["ES-GA", "ES-MD", "ES-PV"];
                    break;
                case 2023:
                    subdivisionCodes = ["ES-CL", "ES-GA", "ES-NC", "ES-PV"];
                    break;
                case 2024:
                case 2025:
                case 2026:
                case 2027:
                    subdivisionCodes = ["ES-GA", "ES-PV"];
                    break;
                default:
                    return null;
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 7, 25),
                EnglishName = "Santiago Apóstol",
                LocalName = "Santiago Apóstol",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = subdivisionCodes
            };
        }

        private HolidaySpecification StStephensDay(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 12, 26),
                EnglishName = "Santiago Apóstol",
                LocalName = "St. Stephen's Day",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-CT"]
            };
        }

        private HolidaySpecification DayOfTheValencianCommunity(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 10, 9),
                EnglishName = "Day of the Valencian Community",
                LocalName = "Dia de la Comunitat Valenciana",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-VC"]
            };
        }

        private HolidaySpecification LaBienAparecida(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 9, 15),
                EnglishName = "Regional Holiday",
                LocalName = "La Bien Aparecida",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-CB"]
            };
        }

        private HolidaySpecification NationalDayOfCatalonia(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 9, 11),
                EnglishName = "National Day of Catalonia",
                LocalName = "Diada Nacional de Catalunya",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-CT"]
            };
        }

        private HolidaySpecification DayOfExtremadura(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 9, 8),
                EnglishName = "Day of Extremadura",
                LocalName = "Día de Extremadura",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-EX"]
            };
        }

        private HolidaySpecification DayOfAsturias(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 9, 8),
                EnglishName = "Day of Asturias",
                LocalName = "Día de Asturias",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-AS"]
            };
        }

        private HolidaySpecification DayOfTheCantabrianInstitutions(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 7, 28),
                EnglishName = "Day of the Cantabrian Institutions",
                LocalName = "Día de las Instituciones de Cantabria",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-CB"]
            };
        }

        private HolidaySpecification StJohnsDay(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 6, 24),
                EnglishName = "St. John's Day",
                LocalName = "Sant Joan",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-CT", "ES-VC"]
            };
        }

        private HolidaySpecification DayOfLaRioja(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 6, 9),
                EnglishName = "Day of La Rioja",
                LocalName = "Día de La Rioja",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-RI"]
            };
        }

        private HolidaySpecification DayOfMurcia(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 6, 9),
                EnglishName = "Day of Murcia",
                LocalName = "Día de la Región de Murcia",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-MC"]
            };
        }

        private HolidaySpecification DayOfCastillaLaMancha(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 5, 31),
                EnglishName = "Day of Castilla-La Mancha",
                LocalName = "Día de la Región Castilla-La Mancha",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-CM"]
            };
        }

        private HolidaySpecification? CastileAndLeonDay(int year)
        {
            switch (year)
            {
                case 2023:
                    return null;
                default:
                    break;
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 4, 23),
                EnglishName = "Castile and León Day",
                LocalName = "Día de Castilla y León",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-CL"]
            };
        }

        private HolidaySpecification GalicianLiteratureDay(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 5, 17),
                EnglishName = "Galician Literature Day",
                LocalName = "Día das Letras Galegas",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-GA"]
            };
        }

        private HolidaySpecification DayOfAragon(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            return new HolidaySpecification
            {
                Date = new DateTime(year, 4, 23),
                EnglishName = "Day of Aragón",
                LocalName = "San Jorge (Día de Aragón)",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-AR"],
                ObservedRuleSet = observedRuleSet
            };
        }

        private HolidaySpecification DayOfTheBalearicIslands(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 3, 1),
                EnglishName = "Day of the Balearic Islands",
                LocalName = "Dia de les Illes Balears",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-IB"]
            };
        }

        private HolidaySpecification DayOfAndalucia(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 2, 28),
                EnglishName = "Day of Andalucía",
                LocalName = "Día de Andalucía",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-AN"]
            };
        }

        private HolidaySpecification DayOfTheCanaryIslands(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 5, 30),
                EnglishName = "Day of the Canary Islands",
                LocalName = "Día de Canarias",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["ES-CN"]
            };
        }

        private HolidaySpecification? CarnivalTuesday(int year)
        {
            switch (year)
            {
                case 2023:
                    return new HolidaySpecification
                    {
                        Date = new DateTime(year, 2, 21),
                        EnglishName = "Carnival Tuesday",
                        LocalName = "Martes de Carnaval",
                        HolidayTypes = HolidayTypes.Public,
                        SubdivisionCodes = ["ES-EX"]
                    };
                default:
                    break;
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Spain",
                "https://www.boe.es/boe/dias/2020/11/02/pdfs/BOE-A-2020-13343.pdf",
                "https://www.boe.es/diario_boe/txt.php?id=BOE-A-2021-17113"
            ];
        }
    }
}
