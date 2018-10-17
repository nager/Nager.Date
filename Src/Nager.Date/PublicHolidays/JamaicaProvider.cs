﻿using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class JamaicaProvider : CatholicBaseProvider
    {
        public JamaicaProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Jamaica
            //https://en.wikipedia.org/wiki/Public_holidays_in_Jamaica

            var countryCode = CountryCode.JM;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-46), "Ash Wednesday", "Ash Wednesday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 23, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 1, "Emancipation Day", "Emancipation Day", countryCode));

            #region Independence Day

            var independenceDay = new DateTime(year, 8, 6).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            items.Add(new PublicHoliday(independenceDay, "Independence Day", "Independence Day", countryCode));

            #endregion

            items.Add(new PublicHoliday(year, 10, 16, "National Heroes Day", "National Heroes Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
