using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Tuvalu HolidayProvider
    /// </summary>
    internal sealed class TuvaluHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Tuvalu HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public TuvaluHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.TV)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var secondMondayInMarch = DateHelper.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second);
            var secondMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.Second);
            var secondSaturdayInJune = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.Second);
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Tausaga Fou",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "COMMONWEALTHDAY-01",
                    Date = secondMondayInMarch,
                    EnglishName = "Commonwealth Day",
                    LocalName = "Commonwealth Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "GOSPELDAY-01",
                    Date = secondMondayInMay,
                    EnglishName = "Gospel Day",
                    LocalName = "Te Aso o te Tala Lei",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "KINGSOFFICIALBIRTHDAY-01",
                    Date = secondSaturdayInJune,
                    EnglishName = "King's Official Birthday",
                    LocalName = "King's Official Birthday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALCHILDRENSDAY-01",
                    Date = firstMondayInAugust,
                    EnglishName = "National Children's Day",
                    LocalName = "Aso Tamaliki",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "TUVALUDAY-01",
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "Tuvalu Day",
                    LocalName = "Tuvalu Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "TUVALUDAY-02",
                    Date = new DateTime(year, 10, 2),
                    EnglishName = "Tuvalu Day Holiday",
                    LocalName = "Tuvalu Day Holiday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Kilisimasi",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Tuvalu",
            ];
        }
    }
}
