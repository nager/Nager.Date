using Nager.Date.Models;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Vietnam
    /// </summary>
    internal class VietnamProvider : IHolidayProvider
    {
        /// <summary>
        /// VietnamProvider
        /// </summary>
        public VietnamProvider()
        {
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            //TODO: Add Lunar Calendar support
            //Add Tết (Tết Nguyên Đán)
            //Add Hung Kings Commemorations (Giỗ tổ Hùng Vương)

            var countryCode = CountryCode.VN;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Tết dương lịch", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 4, 30, "Ngày Giải phóng miền Nam, thống nhất đất nước", "Reunification Day", countryCode));
            items.Add(new Holiday(year, 5, 1, "Ngày Quốc tế lao động", "Labour Day", countryCode));
            items.Add(new Holiday(year, 9, 2, "Quốc khánh", "National Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Vietnam"
            };
        }
    }
}
