using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Singapore
    /// </summary>
    public class SingaporeProvider : IPublicHolidayProvider
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
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.SG;

            // Fixed holidays
            var items = new List<PublicHoliday>
            {
                new PublicHoliday(year, 1, 1, "New Year’s Day", "New Year’s Day", countryCode),
                new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode),
                new PublicHoliday(year, 8, 9, "National Day", "National Day", countryCode),
                new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode),
            };

            // Good Friday
            items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));

            var chineseCalendar = new ChineseLunisolarCalendar();
            if (year > chineseCalendar.MinSupportedDateTime.Year && year < chineseCalendar.MaxSupportedDateTime.Year)
            {
                var chineseNewYear = chineseCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);
                items.Add(new PublicHoliday(chineseNewYear, "Chinese New Year", "Chinese New Year", countryCode));
                items.Add(new PublicHoliday(chineseNewYear.AddDays(1), "Chinese New Year", "Chinese New Year", countryCode));
            }


            //switch (year)
            //{
            //    case 2018:
            //        items.Add(new PublicHoliday(year, 5, 19, "Vesak Day", "Vesak Day", countryCode));
            //        items.Add(new PublicHoliday(year, 6, 5, "Hari Raya Puasa", "Hari Raya Puasa", countryCode));
            //        items.Add(new PublicHoliday(year, 8, 11, "Hari Raya Haji", "Hari Raya Haji", countryCode));
            //        items.Add(new PublicHoliday(year, 10, 27, "Deepavali", "Deepavali", countryCode));
            //        break;
            //    case 2019:
            //        items.Add(new PublicHoliday(year, 5, 29, "Vesak Day", "Vesak Day", countryCode));
            //        items.Add(new PublicHoliday(year, 6, 15, "Hari Raya Puasa", "Hari Raya Puasa", countryCode));
            //        items.Add(new PublicHoliday(year, 8, 22, "Hari Raya Haji", "Hari Raya Haji", countryCode));
            //        items.Add(new PublicHoliday(year, 11, 6, "Deepavali", "Deepavali", countryCode));
            //        break;
            //    case 2020:
            //        items.Add(new PublicHoliday(year, 5, 7, "Vesak Day", "Vesak Day", countryCode));
            //        items.Add(new PublicHoliday(year, 5, 24, "Hari Raya Puasa", "Hari Raya Puasa", countryCode));
            //        items.Add(new PublicHoliday(year, 7, 31, "Hari Raya Haji", "Hari Raya Haji", countryCode));
            //        items.Add(new PublicHoliday(year, 11, 14, "Deepavali", "Deepavali", countryCode));
            //        break;
            //    case 2021:
            //        items.Add(new PublicHoliday(year, 5, 26, "Vesak Day", "Vesak Day", countryCode));
            //        items.Add(new PublicHoliday(year, 5, 13, "Hari Raya Puasa", "Hari Raya Puasa", countryCode));
            //        items.Add(new PublicHoliday(year, 7, 20, "Hari Raya Haji", "Hari Raya Haji", countryCode));
            //        items.Add(new PublicHoliday(year, 11, 4, "Deepavali", "Deepavali", countryCode));
            //        break;
            //    case 2022:
            //        items.Add(new PublicHoliday(year, 5, 2, "Hari Raya Puasa", "Hari Raya Puasa", countryCode));
            //        items.Add(new PublicHoliday(year, 5, 15, "Vesak Day", "Vesak Day", countryCode));
            //        items.Add(new PublicHoliday(year, 7, 9, "Hari Raya Haji", "Hari Raya Haji", countryCode));
            //        items.Add(new PublicHoliday(year, 10, 24, "Deepavali", "Deepavali", countryCode));
            //        break;
            //    default:
            //        break;
            //}

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://www.mom.gov.sg/newsroom/press-releases/2017/0405-singapore-public-holidays-2018",
                "https://www.mom.gov.sg/newsroom/press-releases/2018/0404-public-holidays-for-2019",
                "https://www.mom.gov.sg/employment-practices/public-holidays#Year-2020",
                "https://www.mom.gov.sg/employment-practices/public-holidays#Year-2021",
                "https://www.mom.gov.sg/employment-practices/public-holidays#Year-2022"
            };
        }
    }
}
