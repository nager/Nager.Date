using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class GermanyProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Germany
            //https://en.wikipedia.org/wiki/Public_holidays_in_Germany

            var countryCode = CountryCode.DE;
            var easterSunday = base.EasterSunday(year);
            var adventSunday = base.AdventSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 6, "Heilige Drei Könige", "Epiphany", countryCode, 1967, new string[] { "BW", "BY", "ST" }));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(year, 5, 1, "Tag der Arbeit", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Christi Himmelfahrt", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode,null, new string[] { "BW", "BY","HE", "NW","RP", "SL" }));
            items.Add(new PublicHoliday(year, 10, 3, "Tag der Deutschen Einheit", "German Unity Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Allerheiligen", "All Saints' Day", countryCode, null, new string[] { "BW", "BY", "NW", "RP", "SL" }));
            items.Add(new PublicHoliday(year, 12, 25, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Stefanitag", "St. Stephen's Day", countryCode));
            

            if (year == 2017)
            {
                //In commemoration of the 500th anniversary of the beginning of the Reformation, it was unique as a whole German holiday
                items.Add(new PublicHoliday(year, 10, 31, "Reformationstag", "Reformation Day", countryCode, null));
            }
            else
            {
                items.Add(new PublicHoliday(year, 10, 31, "Reformationstag", "Reformation Day", countryCode, null, new string[] { "BB", "MV", "SN", "ST", "TH" }));
            }


            AddGermanDayOfPrayer(countryCode, year, items);

            return items.OrderBy(o => o.Date);
        }


        private void AddGermanDayOfPrayer(CountryCode countryCode, int year, List<PublicHoliday> items)
        {

            var dayOfPrayer = base.AdventSunday(year).AddDays(-11);
            string localName = "Buß- und Bettag";
            string englishName = "Day of Repentance and Prayer";

            if (year >= 1934 && year < 1939)
            {
                items.Add(new PublicHoliday(dayOfPrayer, localName, englishName, countryCode));
            }

            else if (year >= 1945 && year <= 1980)
            {
                items.Add(new PublicHoliday(dayOfPrayer, localName, englishName, countryCode, null, new string[] { "BW", "BE", "HB", "HH", "HE", "NI", "NW", "RP", "SL", "SH" }));
            }

            else if (year >= 1981 && year <= 1989)
            {
                items.Add(new PublicHoliday(dayOfPrayer, localName, englishName, countryCode, null, new string[] { "BW", "BY", "BE", "HB", "HH", "HE", "NI", "NW", "RP", "SL", "SH" }));
            }

            else if (year >= 1990 && year <= 1994)
            {
                items.Add(new PublicHoliday(dayOfPrayer, localName, englishName, countryCode));
            }

            else if (year >= 1995)
            {
                items.Add(new PublicHoliday(dayOfPrayer, localName, englishName, countryCode, null, new string[] { "SN" }));
            }

        }


    }
}
