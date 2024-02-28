using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Moldova
    /// </summary>
    internal class MoldovaProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// MoldovaProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public MoldovaProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MD;

            var lastMondayInMay = DateSystem.FindLastDay(year, Month.August, DayOfWeek.Monday);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 7, "Craciun pe stil Vechi (Orthodox Christmas)", "Craciun pe stil Vechi (Orthodox Christmas)", countryCode));
            items.Add(new Holiday(year, 1, 8, "Craciun pe stil Vechi (Orthodox Christmas)", "Craciun pe stil Vechi (Orthodox Christmas)", countryCode));
            items.Add(new Holiday(year, 2, 23, "Day of Veterans of the Armed Forces and Law Enforcement Agencies", "Day of Veterans of the Armed Forces and Law Enforcement Agencies", countryCode));
            items.Add(new Holiday(year, 3, 8, "International Women's Day", "International Women's Day", countryCode));
            items.Add(this._orthodoxProvider.EasterSunday("Orthodox Easter", year, countryCode));
            items.Add(new Holiday(lastMondayInMay, "Memorial Day", "Memorial Day", countryCode));
            items.Add(new Holiday(year, 5, 1, "Labour Day (Moldova)", "Labour Day (Moldova)", countryCode));
            items.Add(new Holiday(year, 5, 9, "Victory and Commemoration Day", "Victory and Commemoration Day", countryCode));
            items.Add(new Holiday(year, 5, 22, "Bălţi Day", "Bălţi Day", countryCode));           
            items.Add(new Holiday(year, 8, 27, "Independence Day (Moldova)", "Independence Day (Moldova)", countryCode));
            items.Add(new Holiday(year, 8, 31, "Limba Noastra (National Language Day (Moldova))", "Limba Noastra (National Language Day (Moldova))", countryCode));
            items.Add(new Holiday(year, 9, 3, "Day of the Moldovan National Army", "Day of the Moldovan National Army", countryCode));
            items.Add(new Holiday(year, 10, 14, "Capital's Day", "Capital's Day", countryCode));
            items.Add(new Holiday(year, 11, 21, "South Capital's Day Cahul", "South Capital's Day Cahul", countryCode));
            items.Add(new Holiday(year, 12, 25, "Craciun pe stil Nou (Western Christmas)", "Craciun pe stil Nou (Western Christmas)", countryCode));

            //Not a public holiday
            //items.Add(new PublicHoliday(year, 3, 1, "Martisor (first day of spring)", "Martisor (first day of spring)", countryCode, null, null, false));
            //items.Add(new PublicHoliday(year, 6, 1, "Children's Day", "Children's Day", countryCode, null, null, false));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Moldova"
            };
        }
    }
}
