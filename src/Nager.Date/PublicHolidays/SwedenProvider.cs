using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Sweden
    /// </summary>
    internal class SwedenProvider : IPublicHolidayProvider
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

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SE;

            var midsummerDay = DateSystem.FindDay(year, Month.June, 20, DayOfWeek.Saturday);
            var allSaintsDay = DateSystem.FindDay(year, Month.October, 31, DayOfWeek.Saturday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nyårsdagen", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Trettondedag jul", "Epiphany", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Långfredagen", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Påskdagen", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Annandag påsk", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Första maj", "International Workers' Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Kristi himmelsfärdsdag", year, countryCode));
            if (year >= 2005)
            {
                items.Add(new PublicHoliday(year, 6, 6, "Sveriges nationaldag", "National Day of Sweden", countryCode));
            }
            items.Add(this._catholicProvider.Pentecost("Pingstdagen", year, countryCode));
            if (year < 2005)
            {
                items.Add(this._catholicProvider.WhitMonday("Annandag Pingst", year, countryCode));
            }
            items.Add(new PublicHoliday(midsummerDay.AddDays(-1), "Midsommarafton", "Midsummer Eve", countryCode));
            items.Add(new PublicHoliday(midsummerDay, "Midsommardagen", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(allSaintsDay, "Alla helgons dag", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Julafton", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Juldagen", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Annandag jul", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Nyårsafton", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Sweden"
            };
        }
    }
}
