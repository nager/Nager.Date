using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static System.Collections.Specialized.BitVector32;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Singapore
    /// </summary>
    internal class SingaporeProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// SingaporeProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SingaporeProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SG;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year’s Day", "New Year’s Day", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            items.Add(new PublicHoliday(year, 8, 9, "National Day", "National Day", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));

            var chineseCalendar = new ChineseLunisolarCalendar();
            if (year > chineseCalendar.MinSupportedDateTime.Year && year < chineseCalendar.MaxSupportedDateTime.Year)
            {
                var chineseNewYear = chineseCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);
                items.Add(new PublicHoliday(chineseNewYear, "Chinese New Year", "Chinese New Year", countryCode));
                items.Add(new PublicHoliday(chineseNewYear.AddDays(1), "Chinese New Year", "Chinese New Year", countryCode));
            }

            items.AddIfNotNull(this.HariRayaPuasa(year, countryCode));
            items.AddIfNotNull(this.VesakDay(year, countryCode));
            items.AddIfNotNull(this.HariRayaHaji(year, countryCode));
            items.AddIfNotNull(this.Deepavali(year, countryCode));
            items.AddIfNotNull(this.PollingDay(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday HariRayaPuasa(int year, CountryCode countryCode)
        {
            var name = "Hari Raya Puasa";

            switch (year)
            {
                case 2017:
                    return new PublicHoliday(year, 6, 25, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2018:
                    return new PublicHoliday(year, 6, 15, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2019:
                    return new PublicHoliday(year, 6, 5, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2020:
                    return new PublicHoliday(year, 5, 24, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2021:
                    return new PublicHoliday(year, 5, 13, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2022:
                    return new PublicHoliday(year, 5, 3, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2023:
                    return new PublicHoliday(year, 4, 22, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2024:
                    return new PublicHoliday(year, 4, 10, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2025:
                    return new PublicHoliday(year, 3, 31, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2026:
                    return new PublicHoliday(year, 3, 20, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2027:
                    return new PublicHoliday(year, 3, 10, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                default:
                    break;
            }

            return null;
        }

        private PublicHoliday VesakDay(int year, CountryCode countryCode)
        {
            var name = "Vesak Day";

            switch (year)
            {
                case 2017:
                    return new PublicHoliday(year, 5, 10, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2018:
                    return new PublicHoliday(year, 5, 29, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2019:
                    return new PublicHoliday(year, 5, 19, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2020:
                    return new PublicHoliday(year, 5, 7, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2021:
                    return new PublicHoliday(year, 5, 26, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2022:
                    return new PublicHoliday(year, 5, 15, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2023:
                    return new PublicHoliday(year, 6, 2, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2024:
                    return new PublicHoliday(year, 5, 22, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2025:
                    return new PublicHoliday(year, 5, 12, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                default:
                    break;
            }

            return null;
        }

        private PublicHoliday HariRayaHaji(int year, CountryCode countryCode)
        {
            var name = "Hari Raya Haji";

            switch (year)
            {
                case 2017:
                    return new PublicHoliday(year, 9, 1, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2018:
                    return new PublicHoliday(year, 8, 22, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2019:
                    return new PublicHoliday(year, 8, 11, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2020:
                    return new PublicHoliday(year, 7, 31, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2021:
                    return new PublicHoliday(year, 7, 20, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2022:
                    return new PublicHoliday(year, 7, 10, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2023:
                    return new PublicHoliday(year, 6, 29, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2024:
                    return new PublicHoliday(year, 6, 17, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2025:
                    return new PublicHoliday(year, 6, 6, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                default:
                    break;
            }

            return null;
        }

        private PublicHoliday Deepavali(int year, CountryCode countryCode)
        {
            var name = "Deepavali";

            switch (year)
            {
                case 2017:
                    return new PublicHoliday(year, 10, 18, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2018:
                    return new PublicHoliday(year, 11, 6, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2019:
                    return new PublicHoliday(year, 10, 27, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2020:
                    return new PublicHoliday(year, 11, 14, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2021:
                    return new PublicHoliday(year, 11, 4, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2022:
                    return new PublicHoliday(year, 10, 24, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2023:
                    return new PublicHoliday(year, 11, 13, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2024:
                    return new PublicHoliday(year, 11, 1, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2025:
                    return new PublicHoliday(year, 10, 21, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2026:
                    return new PublicHoliday(year, 11, 8, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2027:
                    return new PublicHoliday(year, 10, 29, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                default:
                    break;
            }
            return null;
        }

        private PublicHoliday PollingDay(int year, CountryCode countryCode)
        {
            if (year == 2023)
            {
                return new PublicHoliday(year, 9, 1, "Polling Day", "Polling Day", countryCode);
            }

            return null;
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Singapore",
                "https://www.mom.gov.sg/newsroom/press-releases?keywords=holiday",
                "https://www.mom.gov.sg/employment-practices/public-holidays",
            };
        }
    }
}
