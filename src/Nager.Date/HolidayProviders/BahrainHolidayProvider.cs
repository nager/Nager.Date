using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bahrain HolidayProvider
    /// </summary>
    internal sealed class BahrainHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Bahrain HolidayProvider
        /// </summary>
        public BahrainHolidayProvider() : base(CountryCode.BH)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "رأس السنة الميلادية",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "SPORTSDAY-01",
                    Date = new DateTime(year, 2, 22),
                    EnglishName = "Sports Day",
                    LocalName = "اليوم الرياضي",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "يوم العمال",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY-01",
                    Date = new DateTime(year, 12, 16),
                    EnglishName = "National Day",
                    LocalName = "اليوم الوطني",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY-02",
                    Date = new DateTime(year, 12, 17),
                    EnglishName = "National Day",
                    LocalName = "اليوم الوطني",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            //TODO: Islamic Holidays
            //CalendarType: Lunar
            //DeterminationType: MoonSighting (By the Supreme Council for Islamic Affairs)
            //Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //1 Muharram	Islamic New Year	رأس السنة الهجرية	Islamic New Year (also known as: Hijri New Year).
            //9–10 Muharram	Day of Ashura	عاشوراء	Represent the 9th and 10th day of the Hijri month of Muharram. Coincide with the memory of the martyrdom of Imam Hussein.
            //12 Rabi' al-Awwal	Prophet Muhammad's day of birth	المولد النبوي	Commemorates Prophet Muhammad's day of birth, celebrated in most parts of the Muslim world.
            //1–3 Shawwal	Little Feast	عيد الفطر	Commemorates end of Ramadan.
            //9 Dhu al-Hijjah	Arafat Day	يوم عرفة	Commemoration of Muhammad's final sermon and completion of the message of Islam.
            //10–12 Dhu al-Hijjah	Feast of the Sacrifice	عيد الأضحى	Commemorates Ibrahim's willingness to sacrifice his son. Also known as the Big Feast (celebrated from the 10th to 13th).

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bahrain",
            ];
        }
    }
}
