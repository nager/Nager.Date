using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Suriname HolidayProvider
    /// </summary>
    internal sealed class SurinameHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Suriname HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SurinameHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.SR)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO:Largest festival of Hindus
            //TODO:Holi

            var thirdSundayInJanuary = DateHelper.FindDay(year, Month.January, DayOfWeek.Sunday, Occurrence.Third);

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
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Three Kings Day",
                    LocalName = "Three Kings Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdSundayInJanuary,
                    EnglishName = "World Religion Day",
                    LocalName = "World Religion Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 25),
                    EnglishName = "Day of the Revolution",
                    LocalName = "Day of the Revolution",
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
                    Date = new DateTime(year, 6, 5),
                    EnglishName = "Indian Arrival Day",
                    LocalName = "Indian Arrival Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 1),
                    EnglishName = "Keti Koti",
                    LocalName = "Keti Koti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 8),
                    EnglishName = "Javanese Arrival Day",
                    LocalName = "Javanese Arrival Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 9),
                    EnglishName = "Indigenous People's Day",
                    LocalName = "Indigenous People's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 10),
                    EnglishName = "Day of the Maroons",
                    LocalName = "Day of the Maroons",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 20),
                    EnglishName = "Chinese Arrival day",
                    LocalName = "Chinese Arrival day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 25),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
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
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterSunday("Easter Sunday", year),
                this._catholicProvider.AscensionDay("Ascension Day", year)
            };

            holidaySpecifications.AddIfNotNull(this.ChineseNewYear(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? ChineseNewYear(int year)
        {
            //LunisolarCalendar .net implementation only valid are between 1901 and 2100, inclusive.
            //https://github.com/dotnet/coreclr/blob/master/src/mscorlib/shared/System/Globalization/ChineseLunisolarCalendar.cs
            //https://stackoverflow.com/questions/30719176/algorithm-to-find-the-gregorian-date-of-the-chinese-new-year-of-a-certain-gregor
            var chineseCalendar = new ChineseLunisolarCalendar();
            if (year > chineseCalendar.MinSupportedDateTime.Year && year < chineseCalendar.MaxSupportedDateTime.Year)
            {
                var chineseNewYear = chineseCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);

                return new HolidaySpecification
                {
                    Date = chineseNewYear,
                    EnglishName = "Chinese New Year",
                    LocalName = "Chinese New Year",
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
                "https://en.wikipedia.org/wiki/Suriname#National_holidays"
            ];
        }
    }
}
