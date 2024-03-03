using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Tunisia HolidayProvider
    /// </summary>
    internal class TunisiaHolidayProvider : IHolidayProvider
    {
        /// <summary>
        /// Tunisia HolidayProvider
        /// </summary>
        public TunisiaHolidayProvider()
        {
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            //TODO:Add moon calendar logic

            var countryCode = CountryCode.TN;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 14),
                    EnglishName = "Revolution and Youth Day",
                    LocalName = "Revolution and Youth Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 20),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 9),
                    EnglishName = "Martyrs' Day",
                    LocalName = "Martyrs' Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "Victory Day",
                    LocalName = "Victory Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 25),
                    EnglishName = "Republic Day",
                    LocalName = "Republic Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 13),
                    EnglishName = "Women's Day",
                    LocalName = "Women's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 15),
                    EnglishName = "Eid El Jala'",
                    LocalName = "Eid El Jala'",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //items.Add(new PublicHoliday(year, 9, 24, "Eid al-Idha", "Eid al-Idha", countryCode)); //depending on the moon calender
            //items.Add(new PublicHoliday(year, 10, 15, "Hegire (Islamic New Year)", "Hegire (Islamic New Year) (2015)", countryCode)); //depending on the moon calender
            //items.Add(new PublicHoliday(year, 2, 4, "Mouled (Prophet's Anniversary)", "Mouled (Prophet's Anniversary)", countryCode)); // depending on the moon calender
            //items.Add(new PublicHoliday(year, 7, 18, "Eid al-Fitr", "Eid al-Fitr", countryCode)); //depending on the moon calender

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 14, "Revolution and Youth Day", "Revolution and Youth Day", countryCode));
            //items.Add(new Holiday(year, 3, 20, "Independence Day", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 4, 9, "Martyrs' Day", "Martyrs' Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 6, 1, "Victory Day", "Victory Day", countryCode));
            //items.Add(new Holiday(year, 7, 25, "Republic Day", "Republic Day", countryCode));
            //items.Add(new Holiday(year, 8, 13, "Women's Day", "Women's Day", countryCode));
            //items.Add(new Holiday(year, 10, 15, "Eid El Jala'", "Eid El Jala'", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Tunisia"
            };
        }
    }
}
