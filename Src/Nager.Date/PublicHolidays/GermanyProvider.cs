using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Germany
    /// </summary>
    public class GermanyProvider : IPublicHolidayProvider, ICountyProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// GermanyProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GermanyProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// GetCounties
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetCounties()
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

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.DE;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 6, "Heilige Drei Könige", "Epiphany", countryCode, 1967, new string[] { "DE-BW", "DE-BY", "DE-ST" }));
            items.Add(new PublicHoliday(year, 3, 8, "Internationaler Frauentag", "International Women's Day", countryCode, 2019, new string[] { "DE-BE" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(year, 5, 1, "Tag der Arbeit", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode,null, new string[] { "DE-BW", "DE-BY", "DE-HE", "DE-NW", "DE-RP", "DE-SL" }));
            items.Add(new PublicHoliday(year, 8, 15, "Mariä Himmelfahrt", "Assumption Day", countryCode, null, new string[] { "DE-SL" }));
            items.Add(new PublicHoliday(year, 9, 20, "Weltkindertag", "World Children's Day", countryCode, 2019, new string[] { "DE-TH" }));
            items.Add(new PublicHoliday(year, 10, 3, "Tag der Deutschen Einheit", "German Unity Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Allerheiligen", "All Saints' Day", countryCode, null, new string[] { "DE-BW", "DE-BY", "DE-NW", "DE-RP", "DE-SL" }));
            items.Add(new PublicHoliday(year, 12, 25, "Erster Weihnachtstag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Zweiter Weihnachtstag", "St. Stephen's Day", countryCode));

            var prayerDay = this.GetPrayerDay(year, countryCode);
            if (prayerDay != null)
            {
                items.Add(prayerDay);
            }

            var liberationDay = this.GetLiberationDay(year, countryCode);
            if (liberationDay != null)
            {
                items.Add(liberationDay);
            }

            items.Add(this.GetReformationDay(year, CountryCode.DE));

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday GetReformationDay(int year, CountryCode countryCode)
        {
            var localName = "Reformationstag";
            var englishName = "Reformation Day";

            if (year == 2017)
            {
                //In commemoration of the 500th anniversary of the beginning of the Reformation, it was unique as a whole German holiday
                return new PublicHoliday(year, 10, 31, localName, englishName, countryCode, null);
            }

            var counties = new List<string> { "DE-BB", "DE-MV", "DE-SN", "DE-ST", "DE-TH" };

            if (year >= 2018)
            {
                counties.AddRange(new[] { "DE-HB", "DE-HH", "DE-NI", "DE-SH" });
            }

            return new PublicHoliday(year, 10, 31, localName, englishName, countryCode, null, counties.ToArray());
        }

        private PublicHoliday GetPrayerDay(int year, CountryCode countryCode)
        {
            var dayOfPrayer = this._catholicProvider.AdventSunday(year).AddDays(-11);
            var localName = "Buß- und Bettag";
            var englishName = "Repentance and Prayer Day";

            if (year >= 1934 && year < 1939)
            {
                return new PublicHoliday(dayOfPrayer, localName, englishName, countryCode);
            }

            else if (year >= 1945 && year <= 1980)
            {
                return new PublicHoliday(dayOfPrayer, localName, englishName, countryCode, null, new string[] { "DE-BW", "DE-BE", "DE-HB", "DE-HH", "DE-HE", "DE-NI", "DE-NW", "DE-RP", "DE-SL", "DE-SH" });
            }

            else if (year >= 1981 && year <= 1989)
            {
                return new PublicHoliday(dayOfPrayer, localName, englishName, countryCode, null, new string[] { "DE-BW", "DE-BY", "DE-BE", "DE-HB", "DE-HH", "DE-HE", "DE-NI", "DE-NW", "DE-RP", "DE-SL", "DE-SH" });
            }

            else if (year >= 1990 && year <= 1994)
            {
                return new PublicHoliday(dayOfPrayer, localName, englishName, countryCode);
            }

            else if (year >= 1995)
            {
                return new PublicHoliday(dayOfPrayer, localName, englishName, countryCode, null, new string[] { "DE-SN" });
            }

            return null;
        }

        private PublicHoliday GetLiberationDay(int year, CountryCode countryCode)
        {
            if (year == 2020)
            {
                return new PublicHoliday(new DateTime(2020, 5, 8), "Tag der Befreiung", "Liberation Day", countryCode, null, new string[] { "DE-BE" });
            }

            return null;
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://de.wikipedia.org/wiki/Gesetzliche_Feiertage_in_Deutschland",
            };
        }
    }
}
