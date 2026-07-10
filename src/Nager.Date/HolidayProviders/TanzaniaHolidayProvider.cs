using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Tanzania HolidayProvider
    /// </summary>
    internal sealed class TanzaniaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Tanzania HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public TanzaniaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.TZ)
        {
            this._catholicProvider = catholicProvider;
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
                    LocalName = "Mwaka mpya",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ZANZIBARREVOLUTIONDAY-01",
                    Date = new DateTime(year, 1, 12),
                    EnglishName = "Zanzibar Revolution Day",
                    LocalName = "Sikukuu ya Mapinduzi ya Zanzibar",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "KARUMEDAY-01",
                    Date = new DateTime(year, 4, 7),
                    EnglishName = "Karume Day",
                    LocalName = "Siku ya Karume",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "UNIONDAY-01",
                    Date = new DateTime(year, 4, 26),
                    EnglishName = "Union Day",
                    LocalName = "Sikukuu ya Muungano",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWORKERSDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "Sikukuu ya Wafanyakazi",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "SABASABADAY-01",
                    Date = new DateTime(year, 7, 7),
                    EnglishName = "Saba Saba Day",
                    LocalName = "Saba Saba",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NANENANEDAY-01",
                    Date = new DateTime(year, 8, 8),
                    EnglishName = "Nane Nane Day",
                    LocalName = "Nane Nane",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NYEREREDAY-01",
                    Date = new DateTime(year, 10, 14),
                    EnglishName = "Nyerere Day",
                    LocalName = "Siku ya Nyerere",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 12, 9),
                    EnglishName = "Independence Day",
                    LocalName = "Siku ya Uhuru",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Krismasi",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Siku ya kufungua Zawadi",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Ijumaa Kuu", year),
                this._catholicProvider.EasterMonday("Jumatatu ya Pasaka", year),
            };

            // Islamic Holidays
            // CalendarType: Lunar
            // DeterminationType: MoonSighting (By the National Muslim Council of Tanzania / BAKWATA, announced by the Mufti)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual local sighting)
            //12 Rabi' al-awwal *	Mawlid	Mawlid	Prophet Muhammad’s Birthday
            //1 Shawwal and 2 Shawwal *	Idd-el-Fitri	Idd el Fitri	End of the holy month of Ramadan. Breaking of the Fast. 2 days.
            //10 Dhu al-Hijja *	Idd-el-Haji	Idd el Haji	Feast of Sacrifice

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Tanzania",
            ];
        }
    }
}
