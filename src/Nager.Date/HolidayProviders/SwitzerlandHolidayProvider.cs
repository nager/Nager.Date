using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Switzerland HolidayProvider
    /// </summary>
    internal sealed class SwitzerlandHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Switzerland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SwitzerlandHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.CH)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "CH-AG", "Aargau" },
                { "CH-AI", "Appenzell Innerrhoden" },
                { "CH-AR", "Appenzell Ausserrhoden" },
                { "CH-BL", "Basel-Landschaft" },
                { "CH-BS", "Basel-Stadt" },
                { "CH-BE", "Bern" },
                { "CH-FR", "Freiburg" },
                { "CH-GE", "Genf" },
                { "CH-GL", "Glarus" },
                { "CH-GR", "Graubünden" },
                { "CH-JU", "Jura" },
                { "CH-LU", "Luzern" },
                { "CH-NE", "Neuenburg" },
                { "CH-NW", "Nidwalden" },
                { "CH-OW", "Obwalden" },
                { "CH-SG", "St. Gallen" },
                { "CH-SH", "Schaffhausen" },
                { "CH-SZ", "Schwyz" },
                { "CH-SO", "Solothurn" },
                { "CH-TG", "Thurgau" },
                { "CH-TI", "Tessin" },
                { "CH-UR", "Uri" },
                { "CH-VS", "Wallis" },
                { "CH-VD", "Waadt" },
                { "CH-ZG", "Zug" },
                { "CH-ZH", "Zürich" }
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstSundayOfSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Sunday, Occurrence.First);
            var thirdSundayOfSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Sunday, Occurrence.Third);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Neujahr",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 1),
                    EnglishName = "Republic Day",
                    LocalName = "Jahrestag der Ausrufung der Republik",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-NE"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 4),
                    EnglishName = "Näfels procession",
                    LocalName = "Näfelser Fahrt",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-GL"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 29),
                    EnglishName = "Saints Peter and Paul",
                    LocalName = "Peter und Paul",
                    HolidayTypes = HolidayTypes.Observance,
                    SubdivisionCodes = ["CH-TI"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 1),
                    EnglishName = "Swiss National Day",
                    LocalName = "Bundesfeier",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Weihnachten",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstSundayOfSeptember.AddDays(4),
                    EnglishName = "Geneva Prayday",
                    LocalName = "Jeûne genevois",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-GE"]
                },
                new HolidaySpecification
                {
                    Date = thirdSundayOfSeptember,
                    EnglishName = "Federal Day of Thanksgiving",
                    LocalName = "Eidgenössischer Dank-, Buss- und Bettag",
                    HolidayTypes = HolidayTypes.Observance,
                    SubdivisionCodes = ["CH-ZH", "CH-BE", "CH-LU", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-SG", "CH-GR"]
                },
                new HolidaySpecification
                {
                    Date = thirdSundayOfSeptember.AddDays(1),
                    EnglishName = "Federal Fast Monday",
                    LocalName = "Bettagsmontag",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-VD"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "Restoration Day",
                    LocalName = "Restauration de la République",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-GE"]
                },
                this._catholicProvider.GoodFriday("Karfreitag", year).SetSubdivisionCodes("CH-ZH", "CH-BE", "CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-VD", "CH-NE", "CH-GE", "CH-JU"),
                this._catholicProvider.AscensionDay("Auffahrt", year),
            };

            holidaySpecifications.AddRangeIfNotNull(this.StephensDay(year));
            holidaySpecifications.AddRangeIfNotNull(this.LabourDay(year));
            holidaySpecifications.AddRangeIfNotNull(this.ImmaculateConception(year));
            holidaySpecifications.AddRangeIfNotNull(this.WhitMonday(year));
            holidaySpecifications.AddRangeIfNotNull(this.EasterMonday(year));
            holidaySpecifications.AddRangeIfNotNull(this.Epiphany(year));
            holidaySpecifications.AddRange(this.AssumptionOfTheVirginMary(year));
            holidaySpecifications.AddRange(this.AllSaintsDay(year));
            holidaySpecifications.AddIfNotNull(this.BerchtoldsDay(year));
            holidaySpecifications.AddRangeIfNotNull(this.SaintJosephsDay(year));
            holidaySpecifications.AddRangeIfNotNull(this.CorpusChristi(year));

            return holidaySpecifications;
        }

        private HolidaySpecification[] Epiphany(int year)
        {
            var englishName = "Epiphany";
            var localName = "Heilige Drei Könige";

            return
            [
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-TI"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Observance,
                    SubdivisionCodes = ["CH-UR", "CH-SZ"]
                }
            ];
        }

        private HolidaySpecification[] AssumptionOfTheVirginMary(int year)
        {
            var englishName = "Assumption of the Virgin Mary";
            var localName = "Maria Himmelfahrt";

            return
            [
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-SO", "CH-AG", "CH-TI", "CH-VS"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Observance,
                    SubdivisionCodes = ["CH-AI", "CH-JU"]
                }
            ];
        }

        private HolidaySpecification BerchtoldsDay(int year)
        {
            var subdivisionCodes = new List<string>(["CH-BE", "CH-FR", "CH-SH", "CH-AG", "CH-TG", "CH-VD"]);

            if (new DateTime(year, 1, 1).DayOfWeek == DayOfWeek.Sunday)
            {
                subdivisionCodes.Add("CH-NE");
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 1, 2),
                EnglishName = "St. Berchtold's Day",
                LocalName = "Berchtoldstag",
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = [.. subdivisionCodes]
            };
        }

        private HolidaySpecification[] SaintJosephsDay(int year)
        {
            var englishName = "Saint Joseph's Day";
            var localName = "Josefstag";

            return
            [
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 19),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-SZ", "CH-VS"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 19),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Observance,
                    SubdivisionCodes = ["CH-LU", "CH-UR", "CH-NW", "CH-TI"]
                }
            ];
        }

        private HolidaySpecification[] AllSaintsDay(int year)
        {
            var englishName = "All Saints' Day";
            var localName = "Allerheiligen";

            return
            [
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-GL", "CH-ZG", "CH-FR", "CH-SO", "CH-SG", "CH-AG", "CH-TI", "CH-VS"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Observance,
                    SubdivisionCodes = ["CH-AI", "CH-JU"]
                }
            ];
        }

        private HolidaySpecification[] EasterMonday(int year)
        {
            var localName = "Ostermontag";

            var specificationPublic = this._catholicProvider.EasterMonday(localName, year).SetSubdivisionCodes("CH-ZH", "CH-BE", "CH-GL", "CH-FR", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-TI", "CH-VD", "CH-GE", "CH-JU");
            var specificationObservance = this._catholicProvider.EasterMonday(localName, year).SetSubdivisionCodes("CH-UR", "CH-SZ", "CH-OW").SetHolidayTypes(HolidayTypes.Observance);

            return
            [
                specificationPublic,
                specificationObservance
            ];
        }

        private HolidaySpecification[] WhitMonday(int year)
        {
            var localName = "Pfingstmontag";

            var specificationPublic = this._catholicProvider.WhitMonday(localName, year).SetSubdivisionCodes("CH-ZH", "CH-BE", "CH-GL", "CH-FR", "CH-BS", "CH-BL", "CH-SH", "CH-AR", "CH-AI", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-VD", "CH-GE", "CH-JU");
            var specificationObservance = this._catholicProvider.WhitMonday(localName, year).SetSubdivisionCodes("CH-UR", "CH-SZ", "CH-OW", "CH-TI").SetHolidayTypes(HolidayTypes.Observance);

            return
            [
                specificationPublic,
                specificationObservance
            ];
        }

        private HolidaySpecification[] CorpusChristi(int year)
        {
            var localName = "Fronleichnam";

            var specificationPublic = this._catholicProvider.CorpusChristi(localName, year).SetSubdivisionCodes("CH-LU", "CH-UR", "CH-SZ", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-SO", "CH-AI", "CH-AG", "CH-VS", "CH-JU");
            var specificationObservance = this._catholicProvider.CorpusChristi(localName, year).SetSubdivisionCodes("CH-TI").SetHolidayTypes(HolidayTypes.Observance);

            return
            [
                specificationPublic,
                specificationObservance
            ];
        }

        private HolidaySpecification[] ImmaculateConception(int year)
        {
            var englishName = "Immaculate Conception";
            var localName = "Mariä Empfängnis";

            return
            [
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-UR", "CH-OW", "CH-NW", "CH-ZG", "CH-FR", "CH-AG", "CH-VS"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Observance,
                    SubdivisionCodes = ["CH-AI", "CH-JU", "CH-LU", "CH-SZ", "CH-TI"]
                }
            ];
        }

        private HolidaySpecification[] LabourDay(int year)
        {
            var englishName = "Labour Day";
            var localName = "Tag der Arbeit";

            return
            [
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CH-ZH", "CH-SO", "CH-BS", "CH-BL", "CH-SH", "CH-NE", "CH-JU"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Observance,
                    SubdivisionCodes = ["CH-TG", "CH-TI"]
                }
            ];
        }

        private HolidaySpecification[] StephensDay(int year)
        {
            var englishName = "St. Stephen's Day";
            var localName = "Stephanstag";

            var subdivisionCodes = new List<string>(["CH-ZH", "CH-BE", "CH-LU", "CH-GL", "CH-FR", "CH-BS", "CH-BL", "CH-SH", "CH-SG", "CH-GR", "CH-AG", "CH-TG", "CH-TI"]);

            if (new DateTime(year, 12, 26).DayOfWeek != DayOfWeek.Tuesday &&
                new DateTime(year, 12, 26).DayOfWeek != DayOfWeek.Saturday)
            {
                subdivisionCodes.AddRange(["CH-AR", "CH-AI"]);
            }

            if (new DateTime(year, 12, 25).DayOfWeek == DayOfWeek.Sunday)
            {
                subdivisionCodes.Add("CH-NE");
            }

            return
            [
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = [.. subdivisionCodes]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Observance,
                    SubdivisionCodes = ["CH-UR", "CH-SZ", "CH-OW" ]
                }
            ];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://de.wikipedia.org/wiki/Feiertage_in_der_Schweiz",
                "https://en.wikipedia.org/wiki/Federal_Day_of_Thanksgiving,_Repentance_and_Prayer",
                "https://en.wikipedia.org/wiki/Je%C3%BBne_genevois"
            ];
        }
    }
}
