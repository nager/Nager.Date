using System;

namespace Nager.Date.Model
{
    public class LongWeekend
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayCount { get { return this.EndDate.Subtract(this.StartDate).Days + 1; } }
        public bool Bridge { get; set; }

        public override string ToString()
        {
            return $"{this.StartDate} - {this.EndDate} ({this.DayCount})";
        }
    }
}
