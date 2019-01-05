using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Liechtenstein
    /// http://en.wikipedia.org/wiki/Public_holidays_in_Liechtenstein
    /// </summary>
    public class LiechtensteinProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        public LiechtensteinProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.LI;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 2, "Berchtoldstag", "St. Berchtold's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Heilige Drei Könige", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 2, 2, "Mariä Lichtmess", "Candlemas", countryCode));
            items.Add(new PublicHoliday(year, 3, 19, "Josefstag", "Saint Joseph's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Karfreitag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Ostermontag", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(year, 5, 1, "Tag der Arbeit", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 29, "Auffahrt", "Ascension", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pfingstmontag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Fronleichnam", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Staatsfeiertag", "National Holiday", countryCode));
            items.Add(new PublicHoliday(year, 9, 8, "Maria Geburt", "Nativity of Our Lady", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Allerheiligen", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Mariä Empfängnis", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Heiliger Abend", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Stephanstag", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Silvester", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
