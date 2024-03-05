using System;

namespace Nager.Date.Models
{
    /// <summary>
    /// The source of holiday
    /// </summary>
    [Flags]
    public enum HolidaySources
    {
        /// <summary>
        /// Historical Holidays
        /// </summary>
        HistoricalHolidays,

        /// <summary>
        /// Cultural Holidays
        /// </summary>
        CulturalHolidays,

        /// <summary>
        /// Religious Orthodox Holidays
        /// </summary>
        ReligiousOrthodoxHolidays,

        /// <summary>
        /// Religious Christian Holidays
        /// </summary>
        ReligiousChristianHolidays,
    }
}
