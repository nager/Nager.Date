using System;

namespace Nager.Date.Contract
{
    /// <summary>
    /// Catholic Provider
    /// </summary>
    public interface ICatholicProvider
    {
        /// <summary>
        /// Get Catholic easter for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DateTime EasterSunday(int year);
        /// <summary>
        /// Get advent sunday for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DateTime AdventSunday(int year);
    }
}
