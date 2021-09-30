using System;

namespace Nager.Date.Website.Models
{
    /// <summary>
    /// LongWeekend Dto
    /// </summary>
    public class LongWeekendDto
    {
        /// <summary>
        /// StartDate
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// EndDate
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// DayCount
        /// </summary>
        public int DayCount { get; set; }
        /// <summary>
        /// NeedBridgeDay
        /// </summary>
        public bool NeedBridgeDay { get; set; }
    }
}
