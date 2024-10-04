using System;

namespace Nager.Date.Models
{
    /// <summary>
    /// The type of holiday
    /// </summary>
    [Flags]
    public enum HolidayTypes
    {
        /// <summary>
        /// A public holiday, typically designated by the government or public administration
        /// </summary>
        Public = 1,

        /// <summary>
        /// A holiday when banks and offices are commonly closed
        /// </summary>
        Bank = 2,

        /// <summary>
        /// A holiday when schools are closed
        /// </summary>
        School = 4,

        /// <summary>
        /// A holiday when authorities and public institutions are closed
        /// </summary>
        Authorities = 8,

        /// <summary>
        /// A holiday when the majority of people have a day off, but not necessarily everyone
        /// </summary>
        Optional = 16,

        /// <summary>
        /// An optional celebration that is celebrated by some people but does not involve a paid day off
        /// </summary>
        Observance = 32,
    }
}
