using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Moldova HolidayProvider
    /// </summary>
    internal sealed class MoldovaHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Moldova HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public MoldovaHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.MD)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var lastMondayInMay = DateHelper.FindLastDay(year, Month.August, DayOfWeek.Monday);

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
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Craciun pe stil Vechi (Orthodox Christmas)",
                    LocalName = "Craciun pe stil Vechi (Orthodox Christmas)",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 8),
                    EnglishName = "Craciun pe stil Vechi (Orthodox Christmas)",
                    LocalName = "Craciun pe stil Vechi (Orthodox Christmas)",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 23),
                    EnglishName = "Day of Veterans of the Armed Forces and Law Enforcement Agencies",
                    LocalName = "Day of Veterans of the Armed Forces and Law Enforcement Agencies",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "International Women's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = lastMondayInMay,
                    EnglishName = "Memorial Day",
                    LocalName = "Memorial Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day (Moldova)",
                    LocalName = "Labour Day (Moldova)",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Victory and Commemoration Day",
                    LocalName = "Victory and Commemoration Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 22),
                    EnglishName = "Bălţi Day",
                    LocalName = "Bălţi Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 27),
                    EnglishName = "Independence Day (Moldova)",
                    LocalName = "Independence Day (Moldova)",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 31),
                    EnglishName = "Limba Noastra (National Language Day (Moldova))",
                    LocalName = "Limba Noastra (National Language Day (Moldova))",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 3),
                    EnglishName = "Day of the Moldovan National Army",
                    LocalName = "Day of the Moldovan National Army",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 14),
                    EnglishName = "Capital's Day",
                    LocalName = "Capital's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 21),
                    EnglishName = "South Capital's Day Cahul",
                    LocalName = "South Capital's Day Cahul",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Craciun pe stil Nou (Western Christmas)",
                    HolidayTypes = HolidayTypes.Public
                },
                this._orthodoxProvider.EasterSunday("Orthodox Easter", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Moldova"
            ];
        }
    }
}
