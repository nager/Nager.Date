using System;

namespace Nager.Date.Model
{
    public class ObservedRuleSet
    {
        public Func<DateTime, DateTime> Monday { get; set; }
        public Func<DateTime, DateTime> Tuesday { get; set; }
        public Func<DateTime, DateTime> Wednesday { get; set; }
        public Func<DateTime, DateTime> Thursday { get; set; }
        public Func<DateTime, DateTime> Friday { get; set; }
        public Func<DateTime, DateTime> Saturday { get; set; }
        public Func<DateTime, DateTime> Sunday { get; set; }

        public DateTime? GetObservedData(DateTime givenDate)
        {
            switch (givenDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return this.Monday?.Invoke(givenDate);

                case DayOfWeek.Tuesday:
                    return this.Tuesday?.Invoke(givenDate);

                case DayOfWeek.Wednesday:
                    return this.Wednesday?.Invoke(givenDate);

                case DayOfWeek.Thursday:
                    return this.Thursday?.Invoke(givenDate);

                case DayOfWeek.Friday:
                    return this.Friday?.Invoke(givenDate);

                case DayOfWeek.Saturday:
                    return this.Saturday?.Invoke(givenDate);

                case DayOfWeek.Sunday:
                    return this.Sunday?.Invoke(givenDate);
            }

            return null;
        }
    }
}
