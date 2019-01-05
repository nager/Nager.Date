using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Malta
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Malta
    /// </summary>
    public class MaltaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        public MaltaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.MT;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "L-Ewwel tas-Sena", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 10, "In-Nawfraġju ta’ San Pawl", "Feast of St. Paul's Shipwreck", countryCode));
            items.Add(new PublicHoliday(year, 3, 19, "San Ġużepp", "Feast of St. Joseph", countryCode));
            items.Add(new PublicHoliday(year, 3, 31, "Jum il-Ħelsien", "Freedom Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Il-Ġimgħa l-Kbira", "Good Friday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Jum il-Ħaddiem", "Worker's Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 7, "Sette Giugno", "​Sette Giugno", countryCode));
            items.Add(new PublicHoliday(year, 6, 29, "L-Imnarja", "​​Feast of St.Peter and St.Paul", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Santa Marija", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 8, "Il-Vittorja", "Feast of Our Lady of Victories", countryCode));
            items.Add(new PublicHoliday(year, 9, 21, "L-Indipendenza", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "L-Immakulata Kunċizzjoni", "​Feast of the Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 13, "Jum ir-Repubblika", "Republic Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Il-Milied​", "​Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
