using Nager.Date.Model;
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

        /// <summary>
        /// Get Pentecost
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        PublicHoliday Pentecost(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Whit Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <param name="counties"></param>
        /// <returns></returns>
        PublicHoliday WhitMonday(string localName, int year, CountryCode countryCode, string[] counties = null);
    }
}
