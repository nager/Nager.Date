using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Czech Republic
    /// </summary>
    internal class CzechRepublicProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// CzechRepublicProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CzechRepublicProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CZ;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Den obnovy samostatného českého státu; Nový rok", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Velký pátek", year, countryCode).SetLaunchYear(2016));
            items.Add(this._catholicProvider.EasterMonday("Velikonoční pondělí", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Svátek práce", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 8, "Den vítězství", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 5, "Den slovanských věrozvěstů Cyrila a Metoděje", "Saints Cyril and Methodius Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 6, "Den upálení mistra Jana Husa", "Jan Hus Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 28, "Den české státnosti", "St. Wenceslas Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 28, "Den vzniku samostatného československého státu", "Independent Czechoslovak State Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 17, "Den boje za svobodu a demokracii a Mezinárodní den studentstva", "Struggle for Freedom and Democracy Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Štědrý den", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "1. svátek vánoční", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "2. svátek vánoční", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Czech_Republic",
            };
        }
    }
}
