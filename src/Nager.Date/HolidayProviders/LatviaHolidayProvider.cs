using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Latvia HolidayProvider
    /// </summary>
    internal sealed class LatviaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Latvia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public LatviaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.LV)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var secondSundayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Sunday, Occurrence.Second);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Jaunais Gads",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Darba svētki",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 4),
                    EnglishName = "Restoration of Independence day",
                    LocalName = "Latvijas Republikas Neatkarības atjaunošanas diena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = secondSundayInMay,
                    EnglishName = "Mother's Day",
                    LocalName = "Mātes diena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 23),
                    EnglishName = "Midsummer Eve",
                    LocalName = "Līgo Diena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 24),
                    EnglishName = "Midsummer Day",
                    LocalName = "Jāņi",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 18),
                    EnglishName = "Proclamation Day of the Republic of Latvia",
                    LocalName = "Latvijas Republikas proklamēšanas diena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Ziemassvētku vakars",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Ziemassvētki",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Otrie Ziemassvētki",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Vecgada vakars",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Lielā Piektdiena", year),
                this._catholicProvider.EasterSunday("Lieldienas", year),
                this._catholicProvider.EasterMonday("Otrās Lieldienas", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Latvia"
            ];
        }
    }
}
