using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Suriname HolidayProvider
    /// </summary>
    internal class SurinameHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Suriname HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SurinameHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            //TODO:Largest festival of Hindus
            //TODO:Holi

            var countryCode = CountryCode.SR;

            var thirdSundayInJanuary = DateSystem.FindDay(year, Month.January, DayOfWeek.Sunday, Occurrence.Third);

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

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Three Kings Day", "Three Kings Day", countryCode));
            //items.Add(new Holiday(thirdSundayInJanuary, "World Religion Day", "World Religion Day", countryCode));
            //items.Add(new Holiday(year, 2, 25, "Day of the Revolution", "Day of the Revolution", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Easter Sunday", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Ascension Day", year, countryCode));
            //items.Add(new Holiday(year, 6, 5, "Indian Arrival Day", "Indian Arrival Day", countryCode));
            //items.Add(new Holiday(year, 7, 1, "Keti Koti", "Keti Koti", countryCode));
            //items.Add(new Holiday(year, 8, 8, "Javanese Arrival Day", "Javanese Arrival Day", countryCode));
            //items.Add(new Holiday(year, 8, 9, "Indigenous People's Day", "Indigenous People's Day", countryCode));
            //items.Add(new Holiday(year, 10, 10, "Day of the Maroons", "Day of the Maroons", countryCode));
            //items.Add(new Holiday(year, 10, 20, "Chinese Arrival day", "Chinese Arrival day", countryCode));
            //items.Add(new Holiday(year, 11, 25, "Independence Day", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode));

            //if (year > 1901 && year < 2100)
            //{
            //    //LunisolarCalendar .net implementation only valid are between 1901 and 2100, inclusive.
            //    //https://github.com/dotnet/coreclr/blob/master/src/mscorlib/shared/System/Globalization/ChineseLunisolarCalendar.cs
            //    //https://stackoverflow.com/questions/30719176/algorithm-to-find-the-gregorian-date-of-the-chinese-new-year-of-a-certain-gregor
            //    var chineseCalendar = new ChineseLunisolarCalendar();
            //    var chineseNewYear = chineseCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);
            //    items.Add(new Holiday(chineseNewYear, "Chinese New Year", "Chinese New Year", countryCode));
            //}

            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification ChineseNewYear(int year)
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

                //items.Add(new Holiday(chineseNewYear, "Chinese New Year", "Chinese New Year", countryCode));
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Suriname#National_holidays"
            };
        }
    }
}
