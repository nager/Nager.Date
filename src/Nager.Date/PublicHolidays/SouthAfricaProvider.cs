using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// South Africa
    /// </summary>
    internal class SouthAfricaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// SouthAfricaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SouthAfricaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.ZA;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var humanRightsDay = new DateTime(year, 3, 21).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var freedomDay = new DateTime(year, 4, 27).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var workersDay = new DateTime(year, 5, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var youthDay = new DateTime(year, 6, 16).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var nationalWomensDay = new DateTime(year, 8, 9).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var heritageDay = new DateTime(year, 9, 24).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var dayOfReconciliation = new DateTime(year, 12, 16).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday, sunday => sunday.AddDays(2));
            var sanktStephensDay = new DateTime(year, 12, 26).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(newYearsDay, "New Year's Day", "New Year's Day", countryCode, 1910));
            items.Add(new PublicHoliday(humanRightsDay, "Human Rights Day", "Human Rights Day", countryCode, 1990));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode).SetLaunchYear(1910));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Family Day", "Family Day", countryCode, 1910));
            items.Add(new PublicHoliday(freedomDay, "Freedom Day", "Freedom Day", countryCode, 1994));
            items.Add(new PublicHoliday(workersDay, "Workers' Day", "Workers' Day", countryCode, 1910));
            items.Add(new PublicHoliday(youthDay, "Youth Day", "Youth Day", countryCode, 1995));
            items.Add(new PublicHoliday(nationalWomensDay, "National Women's Day", "National Women's Day", countryCode, 1995));
            items.Add(new PublicHoliday(heritageDay, "Heritage Day", "Heritage Day", countryCode, 1995));
            items.Add(new PublicHoliday(dayOfReconciliation, "Day of Reconciliation", "Day of Reconciliation", countryCode, 1995));
            items.Add(new PublicHoliday(christmasDay, "Christmas Day", "Christmas Day", countryCode, 1910));
            items.Add(new PublicHoliday(sanktStephensDay, "Day of Goodwill", "St. Stephen's Day", countryCode, 1910));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_South_Africa"
            };
        }
    }
}
