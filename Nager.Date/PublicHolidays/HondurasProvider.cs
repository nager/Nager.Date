using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class HondurasProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Honduras
            //https://en.wikipedia.org/wiki/Public_holidays_in_Honduras

            var countryCode = CountryCode.HN;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 14, "America's Day", "America's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-3), "Holy Thursday", "Holy Thursday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Holy Saturday", "Holy Saturday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labor Day", "Labor Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 15, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 3, "Francisco Morazán's Day/Soldier's Day", "Francisco Morazán's Day/Soldier's Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 12, "Columbus Day", "Columbus Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 21, "Army Day", "Army Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            
            return items.OrderBy(o => o.Date);
        }
    }
}
