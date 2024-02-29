using System;

namespace Nager.Date.Models
{
    /// <summary>
    /// Observed Rule Set
    /// </summary>
    public class ObservedRuleSet
    {
        /// <summary>
        /// Observed Date Rule Monday
        /// </summary>
        public Func<DateTime, DateTime> Monday { get; set; }

        /// <summary>
        /// Observed Date Rule Tuesday
        /// </summary>
        public Func<DateTime, DateTime> Tuesday { get; set; }

        /// <summary>
        /// Observed Date Rule Wednesday
        /// </summary>
        public Func<DateTime, DateTime> Wednesday { get; set; }

        /// <summary>
        /// Observed Date Rule Thursday
        /// </summary>
        public Func<DateTime, DateTime> Thursday { get; set; }

        /// <summary>
        /// Observed Date Rule Friday
        /// </summary>
        public Func<DateTime, DateTime> Friday { get; set; }

        /// <summary>
        /// Observed Date Rule Saturday
        /// </summary>
        public Func<DateTime, DateTime> Saturday { get; set; }

        /// <summary>
        /// Observed Date Rule Sunday
        /// </summary>
        public Func<DateTime, DateTime> Sunday { get; set; }

        /// <summary>
        /// Get observed date
        /// </summary>
        /// <param name="givenDate"></param>
        /// <returns></returns>
        public DateTime? GetObservedDate(DateTime givenDate)
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
