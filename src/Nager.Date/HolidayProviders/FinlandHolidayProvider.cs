using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Finland HolidayProvider
    /// </summary>
    internal sealed class FinlandHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Finland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public FinlandHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.FI)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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

            if (allSaintsDay.HasValue)
            {
                holidaySpecifications.AddIfNotNull(new HolidaySpecification
                {
                    Date = allSaintsDay.Value,
                    EnglishName = "All Saints' Day",
                    LocalName = "Pyhäinpäivä",
                    HolidayTypes = HolidayTypes.Public
                });
            }

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Finland",
            ];
        }
    }
}
