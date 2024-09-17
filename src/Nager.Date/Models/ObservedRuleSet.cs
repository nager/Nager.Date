using System;

namespace Nager.Date.Models
{
    /// <summary>
    /// Observed Rule Set
    /// </summary>
    public class ObservedRuleSet
    {
        /// <summary>
        /// Rule for observing a holiday when it falls on a Monday
        /// </summary>
        public Func<DateTime, DateTime>? Monday { get; set; }

        /// <summary>
        /// Rule for observing a holiday when it falls on a Tuesday
        /// </summary>
        public Func<DateTime, DateTime>? Tuesday { get; set; }

        /// <summary>
        /// Rule for observing a holiday when it falls on a Wednesday
        /// </summary>
        public Func<DateTime, DateTime>? Wednesday { get; set; }

        /// <summary>
        /// Rule for observing a holiday when it falls on a Thursday
        /// </summary>
        public Func<DateTime, DateTime>? Thursday { get; set; }

        /// <summary>
        ///  Rule for observing a holiday when it falls on a Friday
        /// </summary>
        public Func<DateTime, DateTime>? Friday { get; set; }

        /// <summary>
        /// Rule for observing a holiday when it falls on a Saturday
        /// </summary>
        public Func<DateTime, DateTime>? Saturday { get; set; }

        /// <summary>
        /// Rule for observing a holiday when it falls on a Sunday
        /// </summary>
        public Func<DateTime, DateTime>? Sunday { get; set; }

        /// <summary>
        /// Gets the observed date for a given date, according to the rules
        /// </summary>
        /// <param name="givenDate">The original date of the holiday</param>
        /// <returns>The observed date based on the rules</returns>
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
                default:
                    return this.Sunday?.Invoke(givenDate);
            }
        }
    }
}
