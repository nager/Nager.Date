using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Finland
    /// </summary>
    internal class FinlandProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// FinlandProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public FinlandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.FI;

            var midsummerEve = DateSystem.FindDay(year, Month.June, 19, DayOfWeek.Friday);
            var midsummerDay = DateSystem.FindDay(year, Month.June, 20, DayOfWeek.Saturday);
            var allSaintsDay = DateSystem.FindDayBetween(year, 10, 31, year, 11, 6, DayOfWeek.Saturday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Uudenvuodenpäivä", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Loppiainen", "Epiphany", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Pitkäperjantai", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Pääsiäispäivä", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Toinen pääsiäispäivä", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Vappu", "May Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Helatorstai", year, countryCode));
            items.Add(this._catholicProvider.Pentecost("Helluntaipäivä", year, countryCode));
            items.Add(new PublicHoliday(midsummerEve, "Juhannusaatto", "Midsummer Eve", countryCode));
            items.Add(new PublicHoliday(midsummerDay, "Juhannuspäivä", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(allSaintsDay.Value, "Pyhäinpäivä", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 6, "Itsenäisyyspäivä", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Jouluaatto", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Joulupäivä", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Tapaninpäivä", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Finland",
            };
        }
    }
}
