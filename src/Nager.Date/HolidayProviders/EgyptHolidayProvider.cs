using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Egypt HolidayProvider
    /// </summary>
    internal sealed class EgyptHolidayProvider : IHolidayProvider
    {
        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.EG;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Christmas",
                    LocalName = "عيد الميلاد المجيد",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 25),
                    EnglishName = "Revolution Day 2011 National Police Day",
                    LocalName = "عيد الثورة 25 يناير",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 25),
                    EnglishName = "Sinai Liberation Day",
                    LocalName = "عيد تحرير سيناء",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "عيد العمال",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 23),
                    EnglishName = "Revolution Day",
                    LocalName = "عيد ثورة 23 يوليو",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 6),
                    EnglishName = "Armed Forces Day",
                    LocalName = "عيد القوات المسلحة",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();

            //TODO: Add Islamic calender logic
            //Sham El Nessim (Spring Festival)
            //Islamic New Year
            //Birthday of the Prophet Muhammad (Sunni)
            //Eid al-Fitr
            //Eid al-Adha

            //items.Add(new Holiday(year, 1, 7, "عيد الميلاد المجيد", "Christmas", countryCode));
            //items.Add(new Holiday(year, 1, 25, "عيد الثورة 25 يناير", "Revolution Day 2011 National Police Day", countryCode));
            //items.Add(new Holiday(year, 4, 25, "عيد تحرير سيناء", "Sinai Liberation Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "عيد العمال", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 7, 23, "عيد ثورة 23 يوليو", "Revolution Day", countryCode));
            //items.Add(new Holiday(year, 10, 6, "عيد القوات المسلحة", "Armed Forces Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Egypt",
            ];
        }
    }
}
