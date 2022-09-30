using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Nicaragua
    /// </summary>
    internal class NicaraguaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// NicaraguaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NicaraguaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.NI;

            var firstThursdayInApril = DateSystem.FindDay(year, Month.April, DayOfWeek.Thursday, Occurrence.First);

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

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Nicaragua"
            };
        }
    }
}
