using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Yemen HolidayProvider
    /// </summary>
    internal sealed class YemenHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Yemen HolidayProvider
        /// </summary>
        public YemenHolidayProvider() : base(CountryCode.YE)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
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
                    Id = "UNITYDAY-01",
                    Date = new DateTime(year, 2, 5),
                    EnglishName = "Unity Day",
                    LocalName = "اليوم الوطني للجمهورية اليمنية",
                    HolidayTypes = HolidayTypes.Public,
                },
                
                new HolidaySpecification
                {
                    Id = "REVOLUTIONDAY-01",
                    Date = new DateTime(year, 9, 26),
                    EnglishName = "Revolution Day",
                    LocalName = "ثورة 26 سبتمبر المجيدة",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LIBERATIONDAY-01",
                    Date = new DateTime(year, 10, 14),
                    EnglishName = "Liberation Day",
                    LocalName = "ثورة 14 أكتوبر المجيدة",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 11, 30),
                    EnglishName = "Independence Day",
                    LocalName = "عيد الجلاء",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            // TODO: Islamic Holidays
            // CalendarType: Lunar
            // DeterminationType: MoonSighting (By Ministry of Endowments and Guidance, Yemen)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //Shawwal 1-3[2]	Eid al-Fitr	عيد الفطر ‘Īd al-Fiṭr ثلاثة ايام اجازة
            //Dhu'l-Hijja 10-13[2]	Eid al-Adha	عيد الأضحى ‘Īd al-’Aḍḥà اربعة ايام اجازة
            //Muharram 1[2]   Hijri New Year عيد راس السنة الهجرية ‘Īd Ra’s as- Sanät al - Hījrīyä First Day of New Islamic or Arabic Hjri Calendar Lunar Year
            //Rabi' al-Awwal 12[3]	Mawlid	المولد النبوي al - Maulid an - Nabawī Islamic prophet Muhammad's birthday

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Yemen",
            ];
        }
    }
}
