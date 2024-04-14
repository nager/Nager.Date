using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Egypt HolidayProvider
    /// </summary>
    internal sealed class EgyptHolidayProvider() : AbstractHolidayProvider(CountryCode.EG)
    {
        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO: Add Islamic calender logic
            //Sham El Nessim (Spring Festival)
            //Islamic New Year
            //Birthday of the Prophet Muhammad (Sunni)
            //Eid al-Fitr
            //Eid al-Adha

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

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Egypt",
            ];
        }
    }
}
