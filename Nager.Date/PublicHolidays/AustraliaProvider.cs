using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class AustraliaProvider : CatholicBaseProvider
    {
        public IDictionary<string, string> GetCounties()
        {
            return new Dictionary<string, string>
            {
                { "AUT-ACT", "Australian Capital Territory" },
                { "AUS-NSW", "New South Wales" },
                { "AUS-NT", "Northern Territory" },
                { "AUS-QLD", "Queensland" },
                { "AUS-SA", "South Australia" },
                { "AUS-TAS", "Tasmania" },
                { "AUS-VIC", "Victoria" },
                { "AUS-WA", "Western Australia" }
            };
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Australia
            //https://en.wikipedia.org/wiki/Public_holidays_in_Australia

            var countryCode = CountryCode.AU;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 26, "Australia Day", "Australia Day", countryCode));
            //TODO: 2nd Monday in March (multiple...)
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            //TODO: Easter Eve, Easter Sunday
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            //TODO: Easter Tuesday
            items.Add(new PublicHoliday(year, 3, 25, "Anzac Day", "Anzac Day", countryCode));


            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
