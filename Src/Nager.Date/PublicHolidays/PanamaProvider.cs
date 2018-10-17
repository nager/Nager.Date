﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class PanamaProvider : CatholicBaseProvider
    {
        public PanamaProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Panama
            //https://en.wikipedia.org/wiki/Public_holidays_in_Panama

            var countryCode = CountryCode.PA;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 9, "Martyr's Day", "Martyr's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Carnival", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnival", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            //presidential inauguration (not enough informations)
            items.Add(new PublicHoliday(year, 11, 3, "Separation Day", "Separation Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 4, "Flag Day", "Flag Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 5, "Colón Day", "Colon Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 10, "Shout in Villa de los Santos", "Shout in Villa de los Santos", countryCode));
            items.Add(new PublicHoliday(year, 11, 28, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Mothers' Day", "Mothers' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
