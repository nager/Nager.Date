using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class GreenlandProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        public GreenlandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            //Greenland
            //https://en.wikipedia.org/wiki/Public_holidays_in_Greenland

            var countryCode = CountryCode.GL;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Epiphany", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Maundy Thursday", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Vendredi saint", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Easter Sunday", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Lundi de Pâques", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(26), "Store Bededag", "Store Bededag", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Ascension Day", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Whit Monday", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 6, 21, "Ullortuneq", "Ullortuneq", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Christmas Eve", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "St. Stephen's Day", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "New Year's Eve", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
