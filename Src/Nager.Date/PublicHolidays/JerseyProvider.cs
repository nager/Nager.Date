﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class JerseyProvider : CatholicBaseProvider
    {
        public JerseyProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Jersey
            //https://en.wikipedia.org/wiki/Public_holidays_in_Jersey

            var countryCode = CountryCode.JE;
            var easterSunday = base.EasterSunday(year);

            var firstMondayInMay = DateSystem.FindDay(year, 5, DayOfWeek.Monday, 1);
            var lastMondayInMay = DateSystem.FindLastDay(year, 5, DayOfWeek.Monday);
            var lastMondayInAugust = DateSystem.FindLastDay(year, 8, DayOfWeek.Monday);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(firstMondayInMay, "Early May Bank Holiday", "Early May Bank Holiday", countryCode));
            items.Add(new PublicHoliday(year, 5, 9, "Liberation Day", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(lastMondayInMay, "Spring Bank Holiday", "Spring Bank Holiday", countryCode));
            items.Add(new PublicHoliday(lastMondayInAugust, "Summer Bank Holiday", "Summer Bank Holiday", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
