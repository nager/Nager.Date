using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Guinea-Bissau HolidayProvider
    /// </summary>
    internal sealed class GuineaBissauHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Guinea-Bissau HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GuineaBissauHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.GW)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var sovereigntyDayDate = DateHelper.FindDay(year, Month.June, DayOfWeek.Saturday, Occurrence.Second).AddDays(2);
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var augustThursdayDate = firstMondayInAugust.AddDays(3);
            var constitutionDayDate = firstMondayInAugust.AddDays(4);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALHEROESDAY-01",
                    Date = new DateTime(year, 1, 20),
                    EnglishName = "National Heroes' Day",
                    LocalName = "National Heroes' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "International Women's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "International Workers' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 9, 24),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ALLSOULSDAY-01",
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "All Souls' Day",
                    LocalName = "All Souls' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASEVE-01",
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Christmas Eve",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSEVE-01",
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Evey",
                    LocalName = "New Year's Eve",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterSunday("Easter Sunday", year),
            };

            //TODO: Islamic Holidays
            //CalendarType: Lunar
            //DeterminationType: MoonSighting (By the National Union of Imams / Supreme Council for Islamic Affairs)
            //Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //1 Shawwal	Korité	Festival of Breaking the Fast
            //10 Dhu al-Hijjah	Tabaski	Feast of the Sacrifice

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Guinea-Bissau",
            ];
        }
    }
}
