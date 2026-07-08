using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Libya HolidayProvider
    /// </summary>
    internal sealed class LibyaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Libya HolidayProvider
        /// </summary>
        public LibyaHolidayProvider() : base(CountryCode.LY)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "REVOLUTIONDAY-01",
                    Date = new DateTime(year, 2, 17),
                    EnglishName = "Revolution Day",
                    LocalName = "يوم ثورة 17 فبراير",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "عيد العمال",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MARTYRSDAY-01",
                    Date = new DateTime(year, 9, 16),
                    EnglishName = "Martyrs' Day",
                    LocalName = "يوم الشهيد",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LIBERATIONDAY-01",
                    Date = new DateTime(year, 10, 23),
                    EnglishName = "Liberation Day",
                    LocalName = "يوم التحرير",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Independence Day",
                    LocalName = "عيد الاستقلال",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            // Islamic Holidays
            // CalendarType: Lunar
            // DeterminationType: MoonSighting (By Dar al-Ifta / The Libyan Crescent Sighting Committee)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //1st Muharram	Islamic New Year	رأس السنة الهجرية	Islamic New Year (also known as: Hijri New Year).
            //12th Rabiul Awwal	The Prophet's Birthday	المولد النبوي	Commemorates Muhammad's Birthday, celebrated in most parts of the Muslim world.
            //1st, 2nd, 3rd Shawwal	End of Ramadan	عيد الفطر	Commemorates end of Ramadan.
            //9th Zulhijjah	Arafat Day	يوم عرفة	The peak of the Hajj pilgrimage season and the eve of the Eid-ul-Adha celebrations.
            //10th, 11th, 12th Zulhijjah	Feast of Sacrifice	عيد الأضحى	Commemorates Ibrahim's willingness to sacrifice his son. Also known as the Big Feast (celebrated from the 10th to 12th).

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Libya",
            ];
        }
    }
}
