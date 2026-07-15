using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Syria HolidayProvider
    /// </summary>
    internal sealed class SyriaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Syria HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        /// <param name="orthodoxProvider"></param>
        public SyriaHolidayProvider(
            ICatholicProvider catholicProvider,
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.SY)
        {
            this._catholicProvider = catholicProvider;
            this._orthodoxProvider = orthodoxProvider;
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
                    LocalName = "عيد رأس السنة الميلادية",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "ara", "‘Īd Ra’s as-Sanät al-Mīlādīyä" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "SYRIANREVOLUTIONDAY-01",
                    Date = new DateTime(year, 3, 18),
                    EnglishName = "Syrian Revolution Day",
                    LocalName = "عيد الثورة السورية",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "ara", "ʿĪd ath-Thawrah as-Sūriyah" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "NEWROZ-01",
                    Date = new DateTime(year, 3, 21),
                    EnglishName = "Newroz",
                    LocalName = "عيد النوروز",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "ara", "‘Īd al-’Nāwroz" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "MOTHERSDAY-01",
                    Date = new DateTime(year, 3, 21),
                    EnglishName = "Mother's Day",
                    LocalName = "عيد الأم",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "ara", "‘Īd al-’Umm" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 4, 17),
                    EnglishName = "Independence Day",
                    LocalName = "عيد الجلاء",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "ara", "‘Īd al-Ğalā’" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "عيد العمال",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "ara", "‘Īd al-‘Ummāl" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "LIBERATIONDAY-01",
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Liberation Day",
                    LocalName = "يوم التحرير",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "ara", "Yawm al-Tahrir" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "عيد الميلاد المجيد",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "ara", "‘Īd al-Mīlād al-Mağīd" },
                    },
                },
                this._catholicProvider.EasterSunday("عيد الفصح غريغوري", year)
                    .SetAdditionalTranslations(
                    new Dictionary<string, string>
                    {
                        { "ara", "‘Īd al-Fiṣḥ Ġrīġūrī" },
                    }),
                this._orthodoxProvider.EasterSunday("عيد الفصح اليوليوسي", year)
                    .SetAdditionalTranslations(
                    new Dictionary<string, string>
                    {
                        { "ara", "‘Īd al-Fiṣḥ al-Yūliyūsī" },
                    }),
            };

            // TODO: Islamic Holidays
            // CalendarType: Lunar
            // DeterminationType: MoonSighting (By the Jurisprudential Scientific Council of the Ministry of Awqaf)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual local sighting)
            //Dhu al-Hijjah 10	Eid al-Adha	عيد الأضحى - ‘Īd al-’Aḍḥà The four days of Eid Al - Adha(ayyam al tashriq) are holidays
            //Shawwal 1	Eid al-Fitr	عيد الفطر - ‘Īd al-Fiṭr The three days of Eid Al-Fitr are holidays
            //Rabi' al-awwal 12	Mawlid	المولد النبوي - al - Maulid an - Nabawī Prophet Muhammad's Birthday
            //Muharram 1	Islamic New Year	عيد رأس السنة الهجرية - ‘Īd Ra’s as- Sanät al - Hījrīyä

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Syria",
            ];
        }
    }
}
