using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Marshall Islands HolidayProvider
    /// </summary>
    internal sealed class MarshallIslandsHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Marshall Islands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MarshallIslandsHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.MH)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstFridayInJuly = DateHelper.FindDay(year, Month.July, DayOfWeek.Friday, Occurrence.First);
            var firstFridayInSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Friday, Occurrence.First);
            var lastFridayInSeptember = DateHelper.FindLastDay(year, Month.September, DayOfWeek.Friday);
            var firstFridayInDecember = DateHelper.FindDay(year, Month.December, DayOfWeek.Friday, Occurrence.First);

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
                    Id = "REMEMBRANCEDAY-01",
                    Date = new DateTime(year, 3, 1),
                    EnglishName = "Remembrance Day",
                    LocalName = "Remembrance Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "FISHERMENSDAY-01",
                    Date = firstFridayInJuly,
                    EnglishName = "Fishermen's Day",
                    LocalName = "Fishermen's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = firstFridayInSeptember,
                    EnglishName = "Labour Day",
                    LocalName = "Labor Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MANITDAY-01",
                    Date = lastFridayInSeptember,
                    EnglishName = "Manit Day",
                    LocalName = "Manit Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PRESIDENTSDAY-01",
                    Date = new DateTime(year, 11, 17),
                    EnglishName = "Presidents' Day",
                    LocalName = "Presidents' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "GOSPELDAY-01",
                    Date = firstFridayInDecember,
                    EnglishName = "Gospel Day",
                    LocalName = "Gospel Day",
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
                    EnglishName = "New Year's Eve",
                    LocalName = "New Year's Eve",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Marshall_Islands",
            ];
        }
    }
}
