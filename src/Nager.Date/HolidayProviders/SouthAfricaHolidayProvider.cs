using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// South Africa HolidayProvider
    /// </summary>
    internal class SouthAfricaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// South Africa HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SouthAfricaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
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

            var items = new List<Holiday>();
            items.Add(new Holiday(newYearsDay, "New Year's Day", "New Year's Day", countryCode, 1910));
            items.Add(new Holiday(humanRightsDay, "Human Rights Day", "Human Rights Day", countryCode, 1990));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode).SetLaunchYear(1910));
            items.Add(new Holiday(easterSunday.AddDays(1), "Family Day", "Family Day", countryCode, 1910));
            items.Add(new Holiday(freedomDay, "Freedom Day", "Freedom Day", countryCode, 1994));
            items.Add(new Holiday(workersDay, "Workers' Day", "Workers' Day", countryCode, 1910));
            items.Add(new Holiday(youthDay, "Youth Day", "Youth Day", countryCode, 1995));
            items.Add(new Holiday(nationalWomensDay, "National Women's Day", "National Women's Day", countryCode, 1995));
            items.Add(new Holiday(heritageDay, "Heritage Day", "Heritage Day", countryCode, 1995));
            items.Add(new Holiday(dayOfReconciliation, "Day of Reconciliation", "Day of Reconciliation", countryCode, 1995));
            items.Add(new Holiday(christmasDay, "Christmas Day", "Christmas Day", countryCode, 1910));
            items.Add(new Holiday(sanktStephensDay, "Day of Goodwill", "St. Stephen's Day", countryCode, 1910));

            items.AddIfNotNull(this.SpringboksVictory(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday SpringboksVictory(int year, CountryCode countryCode)
        {
            if (year == 2023)
            {
                return new Holiday(year, 12, 15, "Springboks Victory", "Springboks Victory", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_South_Africa"
            };
        }
    }
}