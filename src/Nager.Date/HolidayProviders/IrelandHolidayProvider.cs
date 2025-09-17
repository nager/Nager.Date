using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Ireland HolidayProvider
    /// </summary>
    internal sealed class IrelandHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Ireland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IrelandHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.IE)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            var firstMondayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.First);
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var lastMondayInOctober = DateHelper.FindLastDay(year, Month.October, DayOfWeek.Monday);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Lá Caille",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "SAINTPATRICKSDAY-01",
                    Date = new DateTime(year, 3, 17),
                    EnglishName = "Saint Patrick's Day",
                    LocalName = "Lá Fhéile Pádraig",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "MAYDAY-01",
                    Date = firstMondayInMay,
                    EnglishName = "May Day",
                    LocalName = "Lá Bealtaine",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "JUNEHOLIDAY-01",
                    Date = firstMondayInJune,
                    EnglishName = "June Holiday",
                    LocalName = "Lá Saoire i mí an Mheithimh",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "AUGUSTHOLIDAY-01",
                    Date = firstMondayInAugust,
                    EnglishName = "August Holiday",
                    LocalName = "Lá Saoire i mí Lúnasa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "OCTOBERHOLIDAY-01",
                    Date = lastMondayInOctober,
                    EnglishName = "October Holiday",
                    LocalName = "Lá Saoire i mí Dheireadh Fómhair",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Lá Nollag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Lá Fhéile Stiofáin",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Aoine an Chéasta", year).SetHolidayTypes(HolidayTypes.Bank | HolidayTypes.School),
                this._catholicProvider.EasterMonday("Luan Cásca", year)
            };

            holidaySpecifications.AddIfNotNull(this.SaintBrigidsDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? SaintBrigidsDay(int year)
        {
            if (year < 2023)
            {
                return null;
            }

            var id = "SAINTBRIGIDSDAY-01";
            var englishName = "Saint Brigid's Day";
            var localName = "Lá Fhéile Bríde";

            var firstFebruary = new DateTime(year, 2, 1);
            if (firstFebruary.DayOfWeek == DayOfWeek.Friday)
            {
                return new HolidaySpecification
                {
                    Id = id,
                    Date = firstFebruary,
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public
                };
            }

            var firstMondayInFebruary = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.First);

            return new HolidaySpecification
            {
                Id = id,
                Date = firstMondayInFebruary,
                EnglishName = englishName,
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Republic_of_Ireland",
            ];
        }
    }
}
