using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Finland HolidayProvider
    /// </summary>
    internal class FinlandHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Finland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public FinlandHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.FI;

            var midsummerEve = DateHelper.FindDay(year, Month.June, 19, DayOfWeek.Friday);
            var midsummerDay = DateHelper.FindDay(year, Month.June, 20, DayOfWeek.Saturday);
            var allSaintsDay = DateHelper.FindDayBetween(year, 10, 31, year, 11, 6, DayOfWeek.Saturday);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Uudenvuodenpäivä",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Loppiainen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "Vappu",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = midsummerEve,
                    EnglishName = "Midsummer Eve",
                    LocalName = "Juhannusaatto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = midsummerDay,
                    EnglishName = "Midsummer Day",
                    LocalName = "Juhannuspäivä",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = allSaintsDay.Value,
                    EnglishName = "All Saints' Day",
                    LocalName = "Pyhäinpäivä",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 6),
                    EnglishName = "Independence Day",
                    LocalName = "Itsenäisyyspäivä",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Jouluaatto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Joulupäivä",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Tapaninpäivä",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Pitkäperjantai", year),
                this._catholicProvider.EasterSunday("Pääsiäispäivä", year),
                this._catholicProvider.EasterMonday("Toinen pääsiäispäivä", year),
                this._catholicProvider.AscensionDay("Helatorstai", year),
                this._catholicProvider.Pentecost("Helluntaipäivä", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Uudenvuodenpäivä", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Loppiainen", "Epiphany", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Pitkäperjantai", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Pääsiäispäivä", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Toinen pääsiäispäivä", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Vappu", "May Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Helatorstai", year, countryCode));
            //items.Add(this._catholicProvider.Pentecost("Helluntaipäivä", year, countryCode));
            //items.Add(new Holiday(midsummerEve, "Juhannusaatto", "Midsummer Eve", countryCode));
            //items.Add(new Holiday(midsummerDay, "Juhannuspäivä", "Midsummer Day", countryCode));
            //items.Add(new Holiday(allSaintsDay.Value, "Pyhäinpäivä", "All Saints' Day", countryCode));
            //items.Add(new Holiday(year, 12, 6, "Itsenäisyyspäivä", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Jouluaatto", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Joulupäivä", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Tapaninpäivä", "St. Stephen's Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Finland",
            };
        }
    }
}
