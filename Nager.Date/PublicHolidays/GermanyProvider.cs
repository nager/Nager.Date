using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class GermanyProvider : CatholicBaseProvider
    {
        public IDictionary<string, string> GetCounties()
        {
            var items = new Dictionary<string, string>();
            items.Add("DE-BW", "Baden-Württemberg");
            items.Add("DE-BY", "Bayern");
            items.Add("DE-BE", "Berlin");
            items.Add("DE-BB", "Brandenburg");
            items.Add("DE-HB", "Bremen");
            items.Add("DE-HH", "Hamburg");
            items.Add("DE-HE", "Hessen");
            items.Add("DE-MV", "Mecklenburg-Vorpommern");
            items.Add("DE-NI", "Niedersachsen");
            items.Add("DE-NW", "Nordrhein-Westfalen");
            items.Add("DE-RP", "Rheinland-Pfalz");
            items.Add("DE-SL", "Saarland");
            items.Add("DE-SN", "Sachsen");
            items.Add("DE-ST", "Sachsen-Anhalt");
            items.Add("DE-SH", "Schleswig-Holstein");
            items.Add("DE-TH", "Thüringen");
            return items;
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Germany
            //https://en.wikipedia.org/wiki/Public_holidays_in_Germany

            var countryCode = CountryCode.DE;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 6, "Heilige Drei Könige", "Epiphany", countryCode, 1967, new string[] { "DE-BW", "DE-BY", "DE-ST" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(year, 5, 1, "Tag der Arbeit", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode,null, new string[] { "DE-BW", "DE-BY", "DE-HE", "DE-NW", "DE-RP", "DE-SL" }));
            items.Add(new PublicHoliday(year, 8, 15, "Mariä Himmelfahrt", "Assumption Day", countryCode, null, new string[] { "DE-SL" }));
            items.Add(new PublicHoliday(year, 10, 3, "Tag der Deutschen Einheit", "German Unity Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Allerheiligen", "All Saints' Day", countryCode, null, new string[] { "DE-BW", "DE-BY", "DE-NW", "DE-RP", "DE-SL" }));
            items.Add(new PublicHoliday(year, 12, 25, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Stefanitag", "St. Stephen's Day", countryCode));

            var prayerDay = GetPrayerDay(year, countryCode);
            if (prayerDay != null)
            {
                items.Add(prayerDay);
            }

            if (year == 2017)
            {
                //In commemoration of the 500th anniversary of the beginning of the Reformation, it was unique as a whole German holiday
                items.Add(new PublicHoliday(year, 10, 31, "Reformationstag", "Reformation Day", countryCode, null));
            }
            else
            {
                items.Add(new PublicHoliday(year, 10, 31, "Reformationstag", "Reformation Day", countryCode, null, new string[] { "DE-BB", "DE-MV", "DE-SN", "DE-ST", "DE-TH" }));
            }

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday GetPrayerDay(int year, CountryCode countryCode)
        {
            var dayOfPrayer = base.AdventSunday(year).AddDays(-11);
            string localName = "Buß- und Bettag";
            string englishName = "Repentance and Prayer Day";

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
    }
}
