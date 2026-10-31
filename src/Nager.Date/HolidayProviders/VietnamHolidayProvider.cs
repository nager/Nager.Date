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
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Tết dương lịch",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "COMMUNISTPARTYOFVIETNAMFOUNDATION-01",
                    Date = new DateTime(year, 2, 3),
                    EnglishName = "Communist Party of Vietnam Foundation Anniversary",
                    LocalName = "Ngày thành lập Đảng",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "VIETNAMESEPHYSICIANSDAY-01",
                    Date = new DateTime(year, 2, 27),
                    EnglishName = "Vietnamese Physician's Day",
                    LocalName = "Ngày Thầy thuốc Việt Nam",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Ngày Quốc tế Phụ nữ",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "COMMUNISTYOUTHUNIONFOUNDATIONDAY-01",
                    Date = new DateTime(year, 3, 26),
                    EnglishName = "Ho Chi Minh Communist Youth Union Foundation Day",
                    LocalName = "Ngày Thành lập Đoàn Thanh niên Cộng sản Hồ Chí Minh",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "VIETNAMBOOKDAY-01",
                    Date = new DateTime(year, 4, 21),
                    EnglishName = "Vietnam Book Day",
                    LocalName = "Ngày Sách và Văn hóa đọc Việt Nam",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "REUNIFICATIONDAY-01",
                    Date = new DateTime(year, 4, 30),
                    EnglishName = "Reunification Day",
                    LocalName = "Ngày Giải phóng miền Nam, thống nhất đất nước",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Ngày Quốc tế lao động",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "DIENBIENPHUVICTORYDAY-01",
                    Date = new DateTime(year, 5, 7),
                    EnglishName = "Dien Bien Phu Victory Day",
                    LocalName = "Ngày Chiến thắng Điện Biên Phủ",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "PRESIDENTHOCHIMINHSBIRTHDAY-01",
                    Date = new DateTime(year, 5, 19),
                    EnglishName = "President Ho Chi Minh's Birthday",
                    LocalName = "Ngày sinh Chủ tịch Hồ Chí Minh",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALCHILDRENSDAY-01",
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "International Children's Day",
                    LocalName = "Ngày Quốc tế Thiếu nhi",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "WARINVALIDSANDMARTYRSDAY-01",
                    Date = new DateTime(year, 7, 27),
                    EnglishName = "Vietnamese War Invalids and Martyrs Day",
                    LocalName = "Ngày Thương binh Liệt sĩ",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "AUGUSTREVOLUTIONDAY-01",
                    Date = new DateTime(year, 8, 19),
                    EnglishName = "August Revolution Commemoration Day",
                    LocalName = "Ngày Cách mạng Tháng 8",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY-01",
                    Date = new DateTime(year, 9, 2),
                    EnglishName = "National Day",
                    LocalName = "Quốc khánh",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CAPITALLIBERATIONDAY-01",
                    Date = new DateTime(year, 10, 10),
                    EnglishName = "Capital Liberation Day",
                    LocalName = "Ngày Giải phóng Thủ đô",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "VIETNAMESEWOMENSDAY-01",
                    Date = new DateTime(year, 10, 20),
                    EnglishName = "Vietnamese Women's Day",
                    LocalName = "Ngày Phụ nữ Việt Nam",
                    HolidayTypes = HolidayTypes.Observance,
                },
                new HolidaySpecification
                {
                    Id = "VIETNAMESETEACHERSDAY-01",
                    Date = new DateTime(year, 11, 20),
                    EnglishName = "Vietnamese Teacher's Day",
                    LocalName = "Ngày Nhà giáo Việt Nam",
                    HolidayTypes = HolidayTypes.School,
                },
                new HolidaySpecification
                {
                    Id = "PEOPLESARMYOFVIETNAMFOUNDATION-01",
                    Date = new DateTime(year, 12, 22),
                    EnglishName = "People's Army of Vietnam Foundation Anniversary",
                    LocalName = "Ngày thành lập Quân đội nhân dân Việt Nam",
                    HolidayTypes = HolidayTypes.Observance,
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
