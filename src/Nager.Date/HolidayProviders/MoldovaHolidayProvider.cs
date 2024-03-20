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

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 7, "Craciun pe stil Vechi (Orthodox Christmas)", "Craciun pe stil Vechi (Orthodox Christmas)", countryCode));
            //items.Add(new Holiday(year, 1, 8, "Craciun pe stil Vechi (Orthodox Christmas)", "Craciun pe stil Vechi (Orthodox Christmas)", countryCode));
            //items.Add(new Holiday(year, 2, 23, "Day of Veterans of the Armed Forces and Law Enforcement Agencies", "Day of Veterans of the Armed Forces and Law Enforcement Agencies", countryCode));
            //items.Add(new Holiday(year, 3, 8, "International Women's Day", "International Women's Day", countryCode));
            //items.Add(this._orthodoxProvider.EasterSunday("Orthodox Easter", year, countryCode));
            //items.Add(new Holiday(lastMondayInMay, "Memorial Day", "Memorial Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Labour Day (Moldova)", "Labour Day (Moldova)", countryCode));
            //items.Add(new Holiday(year, 5, 9, "Victory and Commemoration Day", "Victory and Commemoration Day", countryCode));
            //items.Add(new Holiday(year, 5, 22, "Bălţi Day", "Bălţi Day", countryCode));           
            //items.Add(new Holiday(year, 8, 27, "Independence Day (Moldova)", "Independence Day (Moldova)", countryCode));
            //items.Add(new Holiday(year, 8, 31, "Limba Noastra (National Language Day (Moldova))", "Limba Noastra (National Language Day (Moldova))", countryCode));
            //items.Add(new Holiday(year, 9, 3, "Day of the Moldovan National Army", "Day of the Moldovan National Army", countryCode));
            //items.Add(new Holiday(year, 10, 14, "Capital's Day", "Capital's Day", countryCode));
            //items.Add(new Holiday(year, 11, 21, "South Capital's Day Cahul", "South Capital's Day Cahul", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Craciun pe stil Nou (Western Christmas)", "Craciun pe stil Nou (Western Christmas)", countryCode));

            //Not a public holiday
            //items.Add(new PublicHoliday(year, 3, 1, "Martisor (first day of spring)", "Martisor (first day of spring)", countryCode, null, null, false));
            //items.Add(new PublicHoliday(year, 6, 1, "Children's Day", "Children's Day", countryCode, null, null, false));

            //return items.OrderBy(o => o.Date);
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
