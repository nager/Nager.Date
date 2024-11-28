using Nager.Date.Models;
using System.Collections.Generic;
using System;
using Nager.Date.Extensions;
using Nager.Date.ReligiousProviders;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Germany HolidayProvider
    /// </summary>
    internal sealed class GermanyHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Germany HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GermanyHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.DE)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "DE-BW", "Baden-Württemberg" },
                { "DE-BY", "Bayern" },
                { "DE-BE", "Berlin" },
                { "DE-BB", "Brandenburg" },
                { "DE-HB", "Bremen" },
                { "DE-HH", "Hamburg" },
                { "DE-HE", "Hessen" },
                { "DE-MV", "Mecklenburg-Vorpommern" },
                { "DE-NI", "Niedersachsen" },
                { "DE-NW", "Nordrhein-Westfalen" },
                { "DE-RP", "Rheinland-Pfalz" },
                { "DE-SL", "Saarland" },
                { "DE-SN", "Sachsen" },
                { "DE-ST", "Sachsen-Anhalt" },
                { "DE-SH", "Schleswig-Holstein" },
                { "DE-TH", "Thüringen" }
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Heilige Drei Könige",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-BW", "DE-BY", "DE-ST"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Tag der Arbeit",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Mariä Himmelfahrt",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-SL"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 3),
                    EnglishName = "German Unity Day",
                    LocalName = "Tag der Deutschen Einheit",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Allerheiligen",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-BW", "DE-BY", "DE-NW", "DE-RP", "DE-SL"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Erster Weihnachtstag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Zweiter Weihnachtstag",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Karfreitag", year),
                this._catholicProvider.EasterSunday("Ostersonntag", year).SetSubdivisionCodes("DE-BB"),
                this._catholicProvider.EasterMonday("Ostermontag", year),
                this._catholicProvider.AscensionDay("Christi Himmelfahrt", year),
                this._catholicProvider.Pentecost("Pfingstsonntag", year).SetSubdivisionCodes("DE-BB", "DE-HE"),
                this._catholicProvider.WhitMonday("Pfingstmontag", year),
                this._catholicProvider.CorpusChristi("Fronleichnam", year).SetSubdivisionCodes("DE-BW", "DE-BY", "DE-HE", "DE-NW", "DE-RP", "DE-SL")
            };

            holidaySpecifications.AddIfNotNull(this.InternationalWomensDay(year));
            holidaySpecifications.AddIfNotNull(this.PrayerDay(year));
            holidaySpecifications.AddIfNotNull(this.LiberationDay(year));
            holidaySpecifications.AddIfNotNull(this.ReformationDay(year));
            holidaySpecifications.AddIfNotNull(this.WorldChildrensDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? WorldChildrensDay(int year)
        {
            if (year >= 2019)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 20),
                    EnglishName = "World Children's Day",
                    LocalName = "Weltkindertag",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-TH"]
                };
            }

            return null;
        }

        private HolidaySpecification? InternationalWomensDay(int year)
        {
            var localName = "Internationaler Frauentag";
            var englishName = "International Women's Day";

            if (year >= 2019 && year <= 2022)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-BE"]
                };
            }

            if (year >= 2023)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-BE", "DE-MV"]
                };
            }

            return null;
        }

        private HolidaySpecification ReformationDay(int year)
        {
            var localName = "Reformationstag";
            var englishName = "Reformation Day";

            if (year == 2017)
            {
                //In commemoration of the 500th anniversary of the beginning of the Reformation, it was unique as a whole German holiday

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 31),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public
                };
            }

            var subdivisionCodes = new List<string> { "DE-BB", "DE-MV", "DE-SN", "DE-ST", "DE-TH" };

            if (year >= 2018)
            {
                subdivisionCodes.AddRange(new[] { "DE-HB", "DE-HH", "DE-NI", "DE-SH" });
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 10, 31),
                EnglishName = englishName,
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = subdivisionCodes.ToArray()
            };
        }

        private HolidaySpecification? PrayerDay(int year)
        {
            var dayOfPrayer = this._catholicProvider.AdventSunday(year).AddDays(-11);
            var localName = "Buß- und Bettag";
            var englishName = "Repentance and Prayer Day";

            if (year >= 1934 && year < 1939)
            {
                return new HolidaySpecification
                {
                    Date = dayOfPrayer,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public
                };
            }

            else if (year >= 1945 && year <= 1980)
            {
                return new HolidaySpecification
                {
                    Date = dayOfPrayer,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-BW", "DE-BE", "DE-HB", "DE-HH", "DE-HE", "DE-NI", "DE-NW", "DE-RP", "DE-SL", "DE-SH"]
                };
            }

            else if (year >= 1981 && year <= 1989)
            {
                return new HolidaySpecification
                {
                    Date = dayOfPrayer,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-BW", "DE-BY", "DE-BE", "DE-HB", "DE-HH", "DE-HE", "DE-NI", "DE-NW", "DE-RP", "DE-SL", "DE-SH"]
                };
            }

            else if (year >= 1990 && year <= 1994)
            {
                return new HolidaySpecification
                {
                    Date = dayOfPrayer,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public
                };
            }

            else if (year >= 1995)
            {
                return new HolidaySpecification
                {
                    Date = dayOfPrayer,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-SN"]
                };
            }

            return null;
        }

        private HolidaySpecification? LiberationDay(int year)
        {
            if (year == 2020 || year == 2025)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 8),
                    EnglishName = "Liberation Day",
                    LocalName = "Tag der Befreiung",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-BE"]
                };
            }

            return null;
        }

        private HolidaySpecification? UprisingOfJune171953(int year)
        {
            if (year == 2028)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 8),
                    EnglishName = "75th anniversary of the uprising of June 17, 1953",
                    LocalName = "75. Jahrestag des Aufstandes vom 17. Juni 1953",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["DE-BE"]
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://de.wikipedia.org/wiki/Gesetzliche_Feiertage_in_Deutschland",
                "https://pardok.parlament-berlin.de/starweb/adis/citat/VT/19/gvbl/g24280460.pdf"
            ];
        }
    }
}
