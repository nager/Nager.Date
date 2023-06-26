using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Belgium
    /// </summary>
    internal class BelgiumProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// BelgiumProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BelgiumProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BE;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nieuwjaar", "New Year's Day", countryCode, 1967));
            items.Add(this._catholicProvider.GoodFriday("Goede Vrijdag", year, countryCode).SetType(PublicHolidayType.Bank));
            items.Add(this._catholicProvider.EasterSunday("Pasen", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Paasmaandag", year, countryCode).SetLaunchYear(1642));
            items.Add(new PublicHoliday(year, 5, 1, "Dag van de arbeid", "Labour Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Onze Lieve Heer hemel", year, countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(40), "Day after Ascension Day", "Day after Ascension Day", countryCode).SetType(PublicHolidayType.Bank));
            items.Add(this._catholicProvider.WhitMonday("Pinkstermaandag", year, countryCode));
            items.Add(new PublicHoliday(year, 7, 21, "Nationale feestdag", "Belgian National Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Onze Lieve Vrouw hemelvaart", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Allerheiligen", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 11, "Wapenstilstand", "Armistice Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Kerstdag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode).SetType(PublicHolidayType.Bank));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Belgium",
                "https://www.nbb.be/en/about-national-bank/national-bank-belgium/public-holidays",
                "https://www.bnpparibasfortis.be/public/nl/public/particulieren/sluitingsdagen"
            };
        }
    }
}
