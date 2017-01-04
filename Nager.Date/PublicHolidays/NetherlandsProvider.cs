using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class NetherlandsProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Netherlands
            //https://en.wikipedia.org/wiki/Public_holidays_in_the_Netherlands
            var countryCode = CountryCode.NL;

            #region King's Day is Sunday fallback

            var kingsDay = 27;
            var kingsDate = new DateTime(year, 4, kingsDay);
            if (kingsDate.DayOfWeek == DayOfWeek.Sunday)
            {
                kingsDay = 26;
            }

            #endregion

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Nieuwjaarsdag", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Goede Vrijdag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), " Pasen", "Easter Monday", countryCode, 1642));
            items.Add(new PublicHoliday(kingsDay, 4, year, "Koningsdag", "King's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Hemelvaartsdag", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Pinksteren", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Eerste kerstdag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Tweede kerstdag", "Christmas Day", countryCode));

            #region Liberation Day

            var liberationDay = new PublicHoliday(5, 5, year, "Bevrijdingsdag", "Liberation Day", countryCode, 1945);

            if (year >= 1990)
            {
                //in 1990, the day was declared to be a national holiday
                items.Add(liberationDay);
            }
            else if (year >= 1945)
            {
                if (year % 5 == 0)
                {
                    items.Add(liberationDay);
                }
            }

            #endregion

            return items.OrderBy(o => o.Date);
        }
    }
}
