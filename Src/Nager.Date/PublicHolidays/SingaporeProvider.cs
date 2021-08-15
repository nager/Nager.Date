using Nager.Date.Contract;
using Nager.Date.Model;
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
            var countryCode = CountryCode.SG;

            var items = new List<PublicHoliday>
            {
                new PublicHoliday(year, 1, 1, "New Year’s Day", "New Year’s Day", countryCode),
                new PublicHoliday(year, 2, 1, "Chinese New Year", "Chinese New Year", countryCode),
                new PublicHoliday(year, 2, 2, "Chinese New Year", "Chinese New Year", countryCode),
                new PublicHoliday(year, 4, 15, "Good Friday", "Good Friday", countryCode),
                new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode),
                new PublicHoliday(year, 8, 9, "National Day", "National Day", countryCode),
                new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode),
            };

            switch (year)
            {
                case 2022:
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
                "https://www.mom.gov.sg/employment-practices/public-holidays#Year-2022"
            };
        }
    }
}
