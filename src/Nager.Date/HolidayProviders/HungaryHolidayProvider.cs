using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Hungary HolidayProvider
    /// </summary>
    internal sealed class HungaryHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Hungary HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public HungaryHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.HU)
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
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Újév",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 15),
                    EnglishName = "1848 Revolution Memorial Day",
                    LocalName = "Nemzeti ünnep",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour day",
                    LocalName = "A munka ünnepe",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 20),
                    EnglishName = "State Foundation Day",
                    LocalName = "Az államalapítás ünnepe",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 23),
                    EnglishName = "1956 Revolution Memorial Day",
                    LocalName = "Nemzeti ünnep",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "Mindenszentek",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Karácsony",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Karácsony másnapja",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("Húsvétvasárnap", year),
                this._catholicProvider.EasterMonday("Húsvéthétfő", year),
                this._catholicProvider.Pentecost("Pünkösdvasárnap", year),
                this._catholicProvider.WhitMonday("Pünkösdhétfő", year)
            };

            if (year >= 2017)
            {
                holidaySpecifications.AddIfNotNull(this._catholicProvider.GoodFriday("Nagypéntek", year));
            }

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Hungary",
            ];
        }
    }
}
