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
        /// Undefined Holidays
        /// </summary>
        UndefinedHoliday,

        /// <summary>
        /// Historical Holidays
        /// </summary>
        HistoricalHolidays,

        /// <summary>
        /// Cultural Holidays
        /// </summary>
        CulturalHolidays,

        /// <summary>
        /// Religious Holidays
        /// </summary>
        ReligiousHolidays,
    }
}
