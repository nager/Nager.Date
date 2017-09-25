using System.Collections.Generic;

namespace Nager.Date.Website.Model
{
    public class PublicHolidayInfo
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public int Year { get; set; }

        public List<Date.Model.PublicHoliday> PublicHolidays { get; set; }
        public List<Date.Model.LongWeekend> LongWeekends { get; set; }
    }
}