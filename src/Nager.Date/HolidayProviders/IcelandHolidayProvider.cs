using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Iceland HolidayProvider
    /// </summary>
    internal sealed class IcelandHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Iceland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IcelandHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.IS)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstDayOfSummer = DateHelper.FindDay(year, Month.April, 19, DayOfWeek.Thursday);
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nýársdagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstDayOfSummer,
                    EnglishName = "First Day of Summer",
                    LocalName = "Sumardagurinn fyrsti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "Verkalýðsdagurinn",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 17),
                    EnglishName = "Icelandic National Day",
                    LocalName = "Þjóðhátíðardagurinn",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "Commerce Day",
                    LocalName = "Frídagur verslunarmanna",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Aðfangadagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Jóladagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Annar í jólum",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Gamlársdagur",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.MaundyThursday("Skírdagur", year),
                this._catholicProvider.GoodFriday("Föstudagurinn langi", year),
                this._catholicProvider.EasterSunday("Páskadagur", year),
                this._catholicProvider.EasterMonday("Annar í páskum", year),
                this._catholicProvider.AscensionDay("Uppstigningardagur", year),
                this._catholicProvider.Pentecost("Hvítasunnudagur", year),
                this._catholicProvider.WhitMonday("Annar í hvítasunnu", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Iceland",
            ];
        }
    }
}
