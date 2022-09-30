using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// //Åland
    /// </summary>
    internal class AlandProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// AlandProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AlandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AX;

            var thirdFridayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Friday, Occurrence.Third);
            var thirdSaturdayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Saturday, Occurrence.Third);
            var firstSaturdayInNovember = DateSystem.FindDay(year, Month.November, DayOfWeek.Saturday, Occurrence.First);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nyårsdagen", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 1, "Trettondagen", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 3, 30, "Ålands demilitariseringsdag", "Demilitarization Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Långfredag", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Påskdagen", year, countryCode).SetLaunchYear(1642));
            items.Add(this._catholicProvider.EasterMonday("Annandag påsk", year, countryCode).SetLaunchYear(1642));
            items.Add(new PublicHoliday(year, 4, 30, "Valborgsmässoafton", "Walpurgis Night", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Första maj", "May Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Kristi himmelsfärdsdagn", year, countryCode));
            items.Add(this._catholicProvider.Pentecost("Pingstdagen", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Annandag Pingst", year, countryCode));
            items.Add(new PublicHoliday(year, 6, 9, "Självstyrelsedagen", "Autonomy Day", countryCode));
            items.Add(new PublicHoliday(thirdFridayInJune, "Midsommarafton", "Midsummer Eve", countryCode));
            items.Add(new PublicHoliday(thirdSaturdayInJune, "Midsommardagen", "Midsummer Day", countryCode));
            items.Add(new PublicHoliday(firstSaturdayInNovember, "Alla helgons dag", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 6, "Självständighetsdagen", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Julafton", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Juldagen", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Annandag jul", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_%C3%85land",
                "https://de.wikipedia.org/wiki/%C3%85land"
            };
        }
    }
}
