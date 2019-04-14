using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Sweden
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Sweden
    /// </summary>
    public class SwedenProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// SwedenProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SwedenProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.SE;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var midsummerDay = DateSystem.FindDay(year, 6, 20, DayOfWeek.Saturday);
            var allSaintsDay = DateSystem.FindDay(year, 10, 31, DayOfWeek.Saturday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nyårsdagen", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Trettondedag jul", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Långfredagen", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Påskdagen", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Annandag påsk", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Första maj", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Kristi himmelfärds dag", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 6, "Sveriges nationaldag", "National Day of Sweden", countryCode));
            items.Add(new PublicHoliday(midsummerDay.AddDays(-1), "Midsommarafton", "Midsummer Eve", countryCode));
            items.Add(new PublicHoliday(midsummerDay, "Midsommar", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(allSaintsDay, "Alla helgons dag", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Julafton", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Juldagen", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Annandag jul", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Nyårsafton", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
