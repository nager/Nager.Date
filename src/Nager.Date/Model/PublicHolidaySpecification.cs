using System;

namespace Nager.Date.Model
{
    /// <summary>
    /// Public Holiday Specification
    /// </summary>
    public class PublicHolidaySpecification
    {
        /// <summary>
        /// The date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Local name
        /// </summary>
        public string LocalName { get; set; }
        /// <summary>
        /// English name
        /// </summary>
        public string EnglishName { get; set; }
        /// <summary>
        /// ISO-3166-2 - Federal states
        /// </summary>
        public string[] Counties { get; set; }
        /// <summary>
        /// A list of types the public holiday it is valid
        /// </summary>
        public PublicHolidayType Type { get; set; }
        /// <summary>
        /// The launch year of the public holiday
        /// </summary>
        public int? LaunchYear { get; set; }

        /// <summary>
        /// An Observed Holiday is when a public holiday is celebrated on a date that is not the actual event's anniversary date.
        /// </summary>
        public ObservedRuleSet ObservedRuleSet { get; set; }
    }
}
