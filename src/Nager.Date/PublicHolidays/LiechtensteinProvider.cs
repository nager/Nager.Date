using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Liechtenstein
    /// </summary>
    internal class LiechtensteinProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// LiechtensteinProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public LiechtensteinProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.LI;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Neujahr", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(year, 1, 2, "Berchtoldstag", "St. Berchtold's Day", countryCode, type: PublicHolidayType.Bank));
            items.Add(new PublicHoliday(year, 1, 6, "Heilige Drei Könige", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 2, 2, "Mariä Lichtmess", "Candlemas", countryCode));
            items.Add(new PublicHoliday(year, 3, 19, "Josefstag", "Saint Joseph's Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Karfreitag", year, countryCode).SetType(PublicHolidayType.Bank));
            items.Add(this._catholicProvider.EasterMonday("Ostermontag", year, countryCode).SetLaunchYear(1642));
            items.Add(new PublicHoliday(year, 5, 1, "Tag der Arbeit", "Labour Day", countryCode));
            items.Add(this._catholicProvider.Pentecost("Pfingstsonntag", year, countryCode));
            items.Add(this._catholicProvider.AscensionDay("Auffahrt", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Pfingstmontag", year, countryCode));
            items.Add(this._catholicProvider.CorpusChristi("Fronleichnam", year, countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Staatsfeiertag", "National Holiday", countryCode));
            items.Add(new PublicHoliday(year, 9, 8, "Maria Geburt", "Nativity of Our Lady", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Allerheiligen", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Mariä Empfängnis", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Heiliger Abend", "Christmas Eve", countryCode, type: PublicHolidayType.Bank));
            items.Add(new PublicHoliday(year, 12, 25, "Weihnachten", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Stephanstag", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Silvester", "New Year's Eve", countryCode, type: PublicHolidayType.Bank));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Liechtenstein",
                "https://www.llb.li/de/kontakt/bankfeiertage"
            };
        }
    }
}
