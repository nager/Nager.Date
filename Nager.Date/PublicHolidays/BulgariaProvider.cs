using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.PublicHolidays
{
    public class BulgariaProvider : IPublicHolidayProvider
    {
        public IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year)
        {
            //Bulgaria
            //https://en.wikipedia.org/wiki/Public_holidays_in_Bulgaria

            var countryCode = CountryCode.BG;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(1, 1, year, "Нова година", "New Year's Day", countryCode, 1967));
            items.Add(new PublicHoliday(3, 3, year, "Ден на Освобождението на България от османско робство", "Liberation Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Велики понеделник", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(1, 5, year, "Ден на труда и на международната работническа солидарност", "International Workers' Day", countryCode));
            items.Add(new PublicHoliday(6, 5, year, "Гергьовден, ден на храбростта и Българската армия", "Saint George's Day", countryCode));
            items.Add(new PublicHoliday(24, 5, year, "Ден на българската просвета и култура и на славянската писменост", "Saints Cyril and Methodius Day", countryCode));
            items.Add(new PublicHoliday(6, 8, year, "Ден на Съединението", "Unification Day", countryCode));
            items.Add(new PublicHoliday(22, 8, year, "Ден на независимостта на България", "Independence Day", countryCode));
            items.Add(new PublicHoliday(1, 11, year, "Ден на народните будители", "National Awakening Day", countryCode));
            items.Add(new PublicHoliday(24, 12, year, "Бъдни вечер", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(25, 12, year, "Рождество Христово", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(26, 12, year, "Рождество Христово", "St. Stephen's Day", countryCode));

            return items;
        }
    }
}
