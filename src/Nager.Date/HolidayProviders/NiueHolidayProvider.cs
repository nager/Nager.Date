using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Niue HolidayProvider
    /// </summary>
    internal sealed class NiueHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Niue HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NiueHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.NU)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstMondayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.First);
            var fourthMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Fourth);

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
                    Id = "TAKAICOMMISSIONHOLIDAY-01",
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "Takai Commission Holiday",
                    LocalName = "Takai Commission Holiday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "KINGSOFFICIALBIRTHDAY-01",
                    Date = firstMondayInJune,
                    EnglishName = "King's Official Birthday",
                    LocalName = "King's Official Birthday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 10, 19),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PENIAMINAGOSPELDAY-01",
                    Date = fourthMondayInOctober,
                    EnglishName = "Peniamina Gospel Day",
                    LocalName = "Peniamina Gospel Day",
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
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Niue",
            ];
        }
    }
}
