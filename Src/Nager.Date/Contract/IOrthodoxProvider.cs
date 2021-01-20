using System;

namespace Nager.Date.Contract
{
    /// <summary>
    /// Orthodox
    /// </summary>
    public interface IOrthodoxProvider
    {
        /// <summary>
        /// Get Orthodox easter for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DateTime EasterSunday(int year);
    }
}
