using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Vietnam
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Vietnam
    /// </summary>
    public class VietnamProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// VietnamProvider
        /// </summary>
        public VietnamProvider()
        {
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            //TODO: Add Lunar Calendar support
            //Add Tết (Tết Nguyên Đán)
            //Add Hung Kings Commemorations (Giỗ tổ Hùng Vương)

            var countryCode = CountryCode.VN;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Tết dương lịch", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 30, "Ngày Giải phóng miền Nam, thống nhất đất nước", "Reunification Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Ngày Quốc tế lao động", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 1, "Quốc khánh", "National Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
