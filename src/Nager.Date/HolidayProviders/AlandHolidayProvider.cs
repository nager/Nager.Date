using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Åland HolidayProvider
    /// </summary>
    internal class AlandHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Aland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AlandHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AX;

            var thirdFridayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Friday, Occurrence.Third);
            var thirdSaturdayInJune = DateSystem.FindDay(year, Month.June, DayOfWeek.Saturday, Occurrence.Third);
            var firstSaturdayInNovember = DateSystem.FindDay(year, Month.November, DayOfWeek.Saturday, Occurrence.First);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nyårsdagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Trettondagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "Första maj",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 9),
                    EnglishName = "Autonomy Day",
                    LocalName = "Självstyrelsedagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdFridayInJune,
                    EnglishName = "Midsummer Evey",
                    LocalName = "Midsommarafton",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdSaturdayInJune,
                    EnglishName = "Midsummer Day",
                    LocalName = "Midsommardagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstSaturdayInNovember,
                    EnglishName = "All Saints Day",
                    LocalName = "Alla helgons dag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 6),
                    EnglishName = "Independence Day",
                    LocalName = "Självständighetsdagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Julafton",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Juldagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Annandag jul",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Långfredag", year),
                this._catholicProvider.EasterSunday("Påskdagen", year),
                this._catholicProvider.EasterMonday("Annandag påsk", year),
                this._catholicProvider.AscensionDay("Kristi himmelsfärdsdagn", year),
                this._catholicProvider.Pentecost("Pingstdagen", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Nyårsdagen", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Trettondagen", "Epiphany", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Långfredag", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Påskdagen", year, countryCode).SetLaunchYear(1642));
            //items.Add(this._catholicProvider.EasterMonday("Annandag påsk", year, countryCode).SetLaunchYear(1642));
            //items.Add(new Holiday(year, 5, 1, "Första maj", "May Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Kristi himmelsfärdsdagn", year, countryCode));
            //items.Add(this._catholicProvider.Pentecost("Pingstdagen", year, countryCode));
            //items.Add(new Holiday(year, 6, 9, "Självstyrelsedagen", "Autonomy Day", countryCode));
            //items.Add(new Holiday(thirdFridayInJune, "Midsommarafton", "Midsummer Eve", countryCode));
            //items.Add(new Holiday(thirdSaturdayInJune, "Midsommardagen", "Midsummer Day", countryCode));
            //items.Add(new Holiday(firstSaturdayInNovember, "Alla helgons dag", "All Saints Day", countryCode));
            //items.Add(new Holiday(year, 12, 6, "Självständighetsdagen", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Julafton", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Juldagen", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Annandag jul", "St. Stephen's Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
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
