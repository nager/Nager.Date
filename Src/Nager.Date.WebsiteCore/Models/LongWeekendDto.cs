using System;

namespace Nager.Date.WebsiteCore.Models
{
    public class LongWeekendDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayCount { get; set; }
        public bool NeedBridgeDay { get; set; }
    }
}
