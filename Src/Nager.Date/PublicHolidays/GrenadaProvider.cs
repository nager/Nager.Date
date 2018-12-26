using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class GrenadaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        public GrenadaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            //Grenada
            //https://en.wikipedia.org/wiki/Public_holidays_in_Grenada

            var countryCode = CountryCode.GD;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 7, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), " Easter Monday", " Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Indian Arrival Day", "Indian Arrival Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Whit Monday", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Corpus Christi", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(firstMondayInAugust, "Emancipation Day", "Emancipation Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 11, "Carnival", "Carnival", countryCode));
            items.Add(new PublicHoliday(year, 10, 25, "Thanksgiving Day", "Thanksgiving Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
