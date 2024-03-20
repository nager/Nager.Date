using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Nicaragua HolidayProvider
    /// </summary>
    internal sealed class NicaraguaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Nicaragua HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NicaraguaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.NI)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {

            var firstThursdayInApril = DateHelper.FindDay(year, Month.April, DayOfWeek.Thursday, Occurrence.First);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 1),
                    EnglishName = "Air Force Day",
                    LocalName = "Air Force Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstThursdayInApril,
                    EnglishName = "Holy Thursday",
                    LocalName = "Holy Thursday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 27),
                    EnglishName = "Army Day",
                    LocalName = "Army Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 19),
                    EnglishName = "Liberation Day",
                    LocalName = "Liberation Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 14),
                    EnglishName = "Battle of San Jacinto",
                    LocalName = "Battle of San Jacinto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 15),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Indigenous Resistance Day",
                    LocalName = "Indigenous Resistance Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Immaculate Conception",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "New Year's Eve",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 2, 1, "Air Force Day", "Air Force Day", countryCode));
            //items.Add(new Holiday(firstThursdayInApril, "Holy Thursday", "Holy Thursday", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 27, "Army Day", "Army Day", countryCode));
            //items.Add(new Holiday(year, 7, 19, "Liberation Day", "Liberation Day", countryCode));
            //Fiesta de Santiago
            //Fiesta de Santa Ana
            //Fiesta de Santo Domingo
            //Crab Soup Day
            //items.Add(new Holiday(year, 9, 14, "Battle of San Jacinto", "Battle of San Jacinto", countryCode));
            //items.Add(new Holiday(year, 9, 15, "Independence Day", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 10, 12, "Indigenous Resistance Day", "Indigenous Resistance Day", countryCode));
            //items.Add(new PublicHoliday(year, 12, 7, "Immaculate Conception", "Immaculate Conception", countryCode)); //León
            //items.Add(new Holiday(year, 12, 8, "Immaculate Conception", "Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "New Year's Eve", "New Year's Eve", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Nicaragua"
            ];
        }
    }
}
