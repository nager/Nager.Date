using System;

namespace Nager.Date.Model
{
    /// <summary>
    /// The type of a public holiday
    /// </summary>
    [Flags]
    public enum PublicHolidayType
    {
        /// <summary>
        /// Public holiday
        /// </summary>
        Public = 1,
        /// <summary>
        /// Bank holiday, banks and offices are closed
        /// </summary>
        Bank = 2,
        /// <summary>
        /// School holiday, schools are closed
        /// </summary>
        School = 4,
        /// <summary>
        /// Authorities are closed
        /// </summary>
        Authorities = 8,
        /// <summary>
        /// Majority of people take a day off
        /// </summary>
        Optional = 16,
        /// <summary>
        /// Optional festivity, no paid day off
        /// </summary>
        Observance = 32,
    }
}
