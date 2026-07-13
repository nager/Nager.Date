using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Kiribati HolidayProvider
    /// </summary>
    internal sealed class KiribatiHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Kiribati HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public KiribatiHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.KI)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstFridayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Friday, Occurrence.First);

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
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "International Women's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "HEALTHDAY-01",
                    Date = new DateTime(year, 4, 7),
                    EnglishName = "Health Day",
                    LocalName = "Health Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "POLICEDAY-01",
                    Date = new DateTime(year, 6, 20),
                    EnglishName = "Police Day",
                    LocalName = "Police Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "GOSPELDAY-01",
                    Date = new DateTime(year, 7, 10),
                    EnglishName = "Gospel Day",
                    LocalName = "Gospel Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALCULTURESENIORCITIZENSDAY-01",
                    Date = new DateTime(year, 7, 11),
                    EnglishName = "National Culture and Senior Citizens Day",
                    LocalName = "National Culture and Senior Citizens Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY-01",
                    Date = new DateTime(year, 7, 12),
                    EnglishName = "National Day",
                    LocalName = "National Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "SPECIALDAY-01",
                    Date = new DateTime(year, 7, 13),
                    EnglishName = "Special Day",
                    LocalName = "Special Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALYOUTHDAY-01",
                    Date = firstFridayInAugust,
                    EnglishName = "National Youth Day",
                    LocalName = "National Youth Dayy",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "WORLDTEACHERSDAY-01",
                    Date = new DateTime(year, 10, 5),
                    EnglishName = "World Teachers' Day",
                    LocalName = "World Teachers' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "HUMANRIGHTSANDPEACEDAY-01",
                    Date = new DateTime(year, 12, 10),
                    EnglishName = "Human Rights and Peace Day",
                    LocalName = "Human Rights and Peace Day",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Kiribati",
            ];
        }
    }
}
