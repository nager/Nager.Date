using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Vietnam HolidayProvider
    /// </summary>
    internal sealed class VietnamHolidayProvider : IHolidayProvider
    {
        /// <summary>
        /// Vietnam HolidayProvider
        /// </summary>
        public VietnamHolidayProvider()
        {
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            //TODO: Add Lunar Calendar support
            //Add Tết (Tết Nguyên Đán)
            //Add Hung Kings Commemorations (Giỗ tổ Hùng Vương)

            var countryCode = CountryCode.VN;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Tết dương lịch",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 30),
                    EnglishName = "Reunification Day",
                    LocalName = "Ngày Giải phóng miền Nam, thống nhất đất nước",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Ngày Quốc tế lao động",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 2),
                    EnglishName = "National Day",
                    LocalName = "Quốc khánh",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Tết dương lịch", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 4, 30, "Ngày Giải phóng miền Nam, thống nhất đất nước", "Reunification Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Ngày Quốc tế lao động", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 9, 2, "Quốc khánh", "National Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Vietnam"
            };
        }
    }
}
