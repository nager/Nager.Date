using System.Collections.Generic;

namespace Nager.Date.WebsiteCore.Models
{
    public class PublicHolidayInfo
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public int Year { get; set; }

        public List<Model.PublicHoliday> PublicHolidays { get; set; }
        public List<Model.LongWeekend> LongWeekends { get; set; }
    }
}