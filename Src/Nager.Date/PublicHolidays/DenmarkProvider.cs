﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class DenmarkProvider : CatholicBaseProvider
    {
        public DenmarkProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Denmark
            //https://en.wikipedia.org/wiki/Public_holidays_in_Denmark

            var countryCode = CountryCode.DK;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nytårsdag", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Skærtorsdag", "Maundy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Langfredag", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Påskedag", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "2. Påskedag", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(26), "Store bededag", "General Prayer Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(39), "Kristi Himmelfartsdag", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(40), "Banklukkedag", "Bank closing day", countryCode, countyOfficialHoliday: false, countyAdministrationHoliday: false, type: PublicHolidayType.Bank | PublicHolidayType.School | PublicHolidayType.Optional));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Pinsedag", "Pentecost", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "2. Pinsedag", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 6, 5, "Grundlovsdag", "Constitution Day", countryCode, countyOfficialHoliday: false, countyAdministrationHoliday: false, type: PublicHolidayType.Bank | PublicHolidayType.School | PublicHolidayType.Optional));
            items.Add(new PublicHoliday(year, 12, 24, "Juleaftensdag", "Christmas Eve", countryCode, countyOfficialHoliday: false, countyAdministrationHoliday: false, type: PublicHolidayType.Bank | PublicHolidayType.School | PublicHolidayType.Optional));
            items.Add(new PublicHoliday(year, 12, 25, "Juledag / 1. juledag", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "2. juledag", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Nytårsaftensdag", "New Year's Eve", countryCode, countyOfficialHoliday: false, countyAdministrationHoliday: false, type: PublicHolidayType.Bank | PublicHolidayType.School | PublicHolidayType.Optional));

            return items.OrderBy(o => o.Date);
        }
    }
}
