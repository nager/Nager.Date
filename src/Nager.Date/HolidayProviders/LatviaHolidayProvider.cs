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

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Jaunais Gads", "New Year's Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Lielā Piektdiena", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Lieldienas", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Otrās Lieldienas", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Darba svētki", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 4, "Latvijas Republikas Neatkarības atjaunošanas diena", "Restoration of Independence day", countryCode));
            //items.Add(new Holiday(secondSundayInMay, "Mātes diena", "Mother's day", countryCode));
            //items.Add(new Holiday(year, 6, 23, "Līgo Diena", "Midsummer Eve", countryCode));
            //items.Add(new Holiday(year, 6, 24, "Jāņi", "Midsummer Day", countryCode));
            //items.Add(new Holiday(year, 11, 18, "Latvijas Republikas proklamēšanas diena", "Proclamation Day of the Republic of Latvia", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Ziemassvētku vakars", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Ziemassvētki", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Otrie Ziemassvētki", "St. Stephen's Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "Vecgada vakars", "New Year's Eve", countryCode));

            //return items.OrderBy(o => o.Date);
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
