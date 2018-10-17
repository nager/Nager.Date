﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class EgyptProvider : IOffDaysProvider
    {
        private readonly IWeekendProvider _weekendProvider;

        public EgyptProvider(IWeekendProvider weekendProvider)
        {
            _weekendProvider = weekendProvider ?? throw new ArgumentNullException(nameof(weekendProvider));
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            //Egypt
            //https://en.wikipedia.org/wiki/Public_holidays_in_Egypt

            var countryCode = CountryCode.EG;

            var items = new List<PublicHoliday>();

            //TODO: Add Islamic calender logic
            //Sham El Nessim (Spring Festival)
            //Islamic New Year
            //Birthday of the Prophet Muhammad (Sunni)
            //Eid al-Fitr
            //Eid al-Adha

            items.Add(new PublicHoliday(year, 1, 7, "عيد الميلاد المجيد", "Christmas", countryCode));
            items.Add(new PublicHoliday(year, 1, 25, "عيد الثورة 25 يناير", "Revolution Day 2011 National Police Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 25, "عيد تحرير سيناء", "Sinai Liberation Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "عيد العمال", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 23, "عيد ثورة 23 يوليو", "Revolution Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 6, "عيد القوات المسلحة", "Armed Forces Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        public bool IsWeekend(DateTime date) =>
            _weekendProvider.IsWeekend(date);
    }
}
