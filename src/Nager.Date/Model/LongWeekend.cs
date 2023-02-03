using System;

namespace Nager.Date.Model
{
    /// <summary>
    /// LongWeekend
    /// The best long weekends  
    /// </summary>
    public class LongWeekend
    {
        /// <summary>
        /// Start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Count of days
        /// </summary>
        public int DayCount { get { return this.EndDate.Subtract(this.StartDate).Days + 1; } }

        /// <summary>
        /// If an additional holiday needed
        /// </summary>
        public bool Bridge { get; set; }

        /// <summary>
        /// ToString - StartDate EndDate and DayCount
        /// </summary>
        /// <returns>Long weekend info formated</returns>
        public override string ToString()
        {
            return $"{this.StartDate} - {this.EndDate} ({this.DayCount})";
        }
    }
}
