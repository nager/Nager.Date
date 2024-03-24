using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Dominican Republic HolidayProvider
    /// </summary>
    internal sealed class DominicanRepublicHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Dominican Republic HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public DominicanRepublicHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.DO)
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
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Day of Kings",
                    LocalName = "Dia de Reyes",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 21),
                    EnglishName = "Our Lady of Altagracia",
                    LocalName = "Our Lady of Altagracia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 26),
                    EnglishName = "Duarte's Birthday",
                    LocalName = "Duarte's Birthday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 27),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 28),
                    EnglishName = "Mother's Day",
                    LocalName = "Mother's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 16),
                    EnglishName = "Restoration Day",
                    LocalName = "Restoration Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 24),
                    EnglishName = "Our Lady of Mercy",
                    LocalName = "Nuestra Senora de las Mercedes",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 6),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.CorpusChristi("Corpus Christi", year)
            };

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Dia de Reyes", "Day of Kings", countryCode));
            //items.Add(new Holiday(year, 1, 21, "Our Lady of Altagracia", "Our Lady of Altagracia", countryCode));
            //items.Add(new Holiday(year, 1, 26, "Duarte's Birthday", "Duarte's Birthday", countryCode));
            //items.Add(new Holiday(year, 2, 27, "Independence Day", "Independence Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            //items.Add(this._catholicProvider.CorpusChristi("Corpus Christi", year, countryCode));
            //items.Add(new Holiday(year, 5, 28, "Mother's Day", "Mother's Day", countryCode));
            //items.Add(new Holiday(year, 8, 16, "Restoration Day", "Restoration Day", countryCode));
            //items.Add(new Holiday(year, 9, 24, "Nuestra Senora de las Mercedes", "Our Lady of Mercy", countryCode));
            //items.Add(new Holiday(year, 11, 6, "Constitution Day", "Constitution Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Dominican_Republic",
            ];
        }
    }
}
