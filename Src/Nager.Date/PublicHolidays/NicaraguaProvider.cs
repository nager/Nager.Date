using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class NicaraguaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        public NicaraguaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            //Nicaragua
            //https://en.wikipedia.org/wiki/Public_holidays_in_Nicaragua

            var countryCode = CountryCode.NI;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var firstThursdayInApril = DateSystem.FindDay(year, 4, DayOfWeek.Thursday, 1);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 1, "Air Force Day", "Air Force Day", countryCode));
            items.Add(new PublicHoliday(firstThursdayInApril, "Holy Thursday", "Holy Thursday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 27, "Army Day", "Army Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 19, "Liberation Day", "Liberation Day", countryCode));
            //Fiesta de Santiago
            //Fiesta de Santa Ana
            //Fiesta de Santo Domingo
            //Crab Soup Day
            items.Add(new PublicHoliday(year, 9, 14, "Battle of San Jacinto", "Battle of San Jacinto", countryCode));
            items.Add(new PublicHoliday(year, 9, 15, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Indigenous Resistance Day", "Indigenous Resistance Day", countryCode));
            //items.Add(new PublicHoliday(year, 12, 7, "Immaculate Conception", "Immaculate Conception", countryCode)); //León
            items.Add(new PublicHoliday(year, 12, 8, "Immaculate Conception", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "New Year's Eve", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
