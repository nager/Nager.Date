using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Sweden HolidayProvider
    /// </summary>
    internal sealed class SwedenHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Sweden HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SwedenHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.SE)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var midsummerDay = DateHelper.FindDay(year, Month.June, 20, DayOfWeek.Saturday);
            var midsummerEve = midsummerDay.AddDays(-1);
            var allSaintsDay = DateHelper.FindDay(year, Month.October, 31, DayOfWeek.Saturday);

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

            return holidaySpecifications;
        }

        private HolidaySpecification? NationalDayOfSweden(int year)
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
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Sweden"
            ];
        }
    }
}
