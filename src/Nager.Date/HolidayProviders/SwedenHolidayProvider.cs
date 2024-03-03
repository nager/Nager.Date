using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Sweden HolidayProvider
    /// </summary>
    internal class SwedenHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Sweden HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SwedenHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SE;

            var midsummerDay = DateSystem.FindDay(year, Month.June, 20, DayOfWeek.Saturday);
            var midsummerEve = midsummerDay.AddDays(-1);
            var allSaintsDay = DateSystem.FindDay(year, Month.October, 31, DayOfWeek.Saturday);

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
                    LocalName = "Trettondedag jul",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "Första maj",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = midsummerEve,
                    EnglishName = "Midsummer Eve",
                    LocalName = "Midsommarafton",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = midsummerDay,
                    EnglishName = "Midsummer Day",
                    LocalName = "Midsommardagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = allSaintsDay,
                    EnglishName = "All Saints' Day",
                    LocalName = "Alla helgons dag",
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
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Nyårsafton",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Långfredagen", year),
                this._catholicProvider.EasterSunday("Påskdagen", year),
                this._catholicProvider.EasterMonday("Annandag påsk", year),
                this._catholicProvider.AscensionDay("Kristi himmelsfärdsdag", year),
                this._catholicProvider.Pentecost("Pingstdagen", year)
            };

            if (year < 2005)
            {
                holidaySpecifications.AddIfNotNull(this._catholicProvider.WhitMonday("Annandag Pingst", year));
            }

            holidaySpecifications.AddIfNotNull(this.NationalDayOfSweden(year));

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Nyårsdagen", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Trettondedag jul", "Epiphany", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Långfredagen", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Påskdagen", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Annandag påsk", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Första maj", "International Workers' Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Kristi himmelsfärdsdag", year, countryCode));           
            //items.Add(this._catholicProvider.Pentecost("Pingstdagen", year, countryCode));
            //items.Add(new Holiday(midsummerDay.AddDays(-1), "Midsommarafton", "Midsummer Eve", countryCode));
            //items.Add(new Holiday(midsummerDay, "Midsommardagen", "Midsummer Day", countryCode));
            //items.Add(new Holiday(allSaintsDay, "Alla helgons dag", "All Saints' Day", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Julafton", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Juldagen", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Annandag jul", "St. Stephen's Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "Nyårsafton", "New Year's Eve", countryCode));
            //if (year < 2005)
            //{
            //    items.Add(this._catholicProvider.WhitMonday("Annandag Pingst", year, countryCode));
            //}
            //items.AddIfNotNull(this.NationalDayOfSweden(year, countryCode);
            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification NationalDayOfSweden(int year)
        {
            if (year >= 2005)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 6),
                    EnglishName = "National Day of Sweden",
                    LocalName = "Sveriges nationaldag",
                    HolidayTypes = HolidayTypes.Public
                };

                //return new Holiday(year, 6, 6, "Sveriges nationaldag", "National Day of Sweden", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Sweden"
            };
        }
    }
}
