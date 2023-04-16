using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Bulgaria
    /// </summary>
    internal class BulgariaProvider : IPublicHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// BulgariaProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public BulgariaProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BG;

            var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            var liberationDay = new DateTime(year, 3, 3).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            var saintGeorgesDay = new DateTime(year, 5, 6).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            var independenceDay = new DateTime(year, 9, 22).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            var christmasEve = new DateTime(year, 12, 24).Shift(saturday => saturday, sunday => sunday.AddDays(3));
            var christmasDay1 = new DateTime(year, 12, 25).Shift(saturday => saturday, sunday => sunday.AddDays(2));
            var christmasDay2 = new DateTime(year, 12, 26).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(newYearDay, "Нова година", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(liberationDay, "Ден на oсвобождението на България от Oсманско робство", "Liberation Day", countryCode));
            items.Add(this._orthodoxProvider.GoodFriday("Разпети петък", year, countryCode));
            items.Add(this._orthodoxProvider.HolySaturday("Велика събота", year, countryCode));
            items.Add(this._orthodoxProvider.EasterSunday("Великден", year, countryCode));
            items.Add(this._orthodoxProvider.EasterMonday("Велики понеделник", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Ден на труда и на международната работническа солидарност", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(saintGeorgesDay, "Гергьовден, ден на храбростта и Българската армия", "Saint George's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 24, "Ден на Българската просвета и култура и на славянската писменост", "Saints Cyril and Methodius Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 6, "Ден на съединението", "Unification Day", countryCode));
            items.Add(new PublicHoliday(independenceDay, "Ден на независимостта на България", "Independence Day", countryCode));
            items.Add(new PublicHoliday(christmasEve, "Бъдни вечер", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(christmasDay1, "Рождество Христово", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(christmasDay2, "Рождество Христово", "Second day of Christmas", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bulgaria",
            };
        }
    }
}
