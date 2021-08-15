using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Singapore
    /// </summary>
    public class SingaporeProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// SingaporeProvider
        /// </summary>
        public SingaporeProvider()
        {
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            if (year < 2020 || year > 2022)
            {
                throw new NotImplementedException($"Year {year} for Singapore is not implemented.");
            }

            var countryCode = CountryCode.SG;

            // Fixed holidays
            var items = new List<PublicHoliday>
            {
                new PublicHoliday(year, 1, 1, "New Year’s Day", "New Year’s Day", countryCode),
                new PublicHoliday(year, 2, 1, "Chinese New Year", "Chinese New Year", countryCode),
                new PublicHoliday(year, 2, 2, "Chinese New Year", "Chinese New Year", countryCode),
                new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode),
                new PublicHoliday(year, 8, 9, "National Day", "National Day", countryCode),
                new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode),
            };

            switch (year)
            {
                case 2020:
                    items.Add(new PublicHoliday(year, 4, 10, "Good Friday", "Good Friday", countryCode));
                    items.Add(new PublicHoliday(year, 5, 24, "Hari Raya Puasa", "Hari Raya Puasa", countryCode));
                    items.Add(new PublicHoliday(year, 5, 07, "Vesak Day", "Vesak Day", countryCode));
                    items.Add(new PublicHoliday(year, 7, 31, "Hari Raya Haji", "Hari Raya Haji", countryCode));
                    items.Add(new PublicHoliday(year, 11, 14, "Deepavali", "Deepavali", countryCode));
                    break;
                case 2021:
                    items.Add(new PublicHoliday(year, 4, 2, "Good Friday", "Good Friday", countryCode));
                    items.Add(new PublicHoliday(year, 5, 13, "Hari Raya Puasa", "Hari Raya Puasa", countryCode));
                    items.Add(new PublicHoliday(year, 5, 26, "Vesak Day", "Vesak Day", countryCode));
                    items.Add(new PublicHoliday(year, 7, 20, "Hari Raya Haji", "Hari Raya Haji", countryCode));
                    items.Add(new PublicHoliday(year, 11, 4, "Deepavali", "Deepavali", countryCode));
                    break;
                case 2022:
                    items.Add(new PublicHoliday(year, 4, 15, "Good Friday", "Good Friday", countryCode));
                    items.Add(new PublicHoliday(year, 5, 2, "Hari Raya Puasa", "Hari Raya Puasa", countryCode));
                    items.Add(new PublicHoliday(year, 5, 15, "Vesak Day", "Vesak Day", countryCode));
                    items.Add(new PublicHoliday(year, 7, 9, "Hari Raya Haji", "Hari Raya Haji", countryCode));
                    items.Add(new PublicHoliday(year, 10, 24, "Deepavali", "Deepavali", countryCode));
                    break;
                default:
                    break;
            }

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://www.mom.gov.sg/employment-practices/public-holidays#Year-2020",
                "https://www.mom.gov.sg/employment-practices/public-holidays#Year-2021",
                "https://www.mom.gov.sg/employment-practices/public-holidays#Year-2022"
            };
        }
    }
}
