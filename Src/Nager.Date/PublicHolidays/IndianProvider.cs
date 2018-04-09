using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.PublicHolidays
{
    public class IndianProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //India
            //https://www.indiapost.gov.in/VAS/Pages/holidays.aspx

            var countryCode = CountryCode.IN;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            //Fixed holidays
            //Hindi Nantional language 
            items.Add(new PublicHoliday(year, 1, 26, "गणतंत्र दिवस", "Republic Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "स्वतंत्रता दिवस", "Independance day", countryCode));
            items.Add(new PublicHoliday(year, 10, 2, "महात्मा गांधी जयंती", "Mahatma Gandhi Birthday", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "क्रिसमस", "Christmas", countryCode));

            //TODO: Need to add logic for every holiday which changes with date.
            return items.OrderBy(o => o.Date);
        }
    }
}
