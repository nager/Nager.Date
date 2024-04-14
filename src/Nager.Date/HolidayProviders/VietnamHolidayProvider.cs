using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Vietnam HolidayProvider
    /// </summary>
    internal sealed class VietnamHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Vietnam HolidayProvider
        /// </summary>
        public VietnamHolidayProvider() : base(CountryCode.VN)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO: Add Lunar Calendar support
            //Add Tết (Tết Nguyên Đán)
            //Add Hung Kings Commemorations (Giỗ tổ Hùng Vương)

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

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Vietnam"
            ];
        }
    }
}
