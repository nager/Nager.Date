using Nager.Date.Models;
using System;

namespace Nager.Date.ReligiousProviders
{
    /// <summary>
    /// Orthodox Provider Interface
    /// </summary>
    public interface IOrthodoxProvider
    {
        /// <summary>
        /// Get Orthodox easter for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of Orthodox Easter Sunday for given year</returns>
        DateTime EasterSunday(int year);

        /// <summary>
        /// Get Good Friday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Orthodox Good Friday for given year and country</returns>
        Holiday GoodFriday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Holy Saturday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Orthodox Holy Saturday for given year and country</returns>
        Holiday HolySaturday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Easter Sunday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Orthodox Easter Sunday for given year and country</returns>
        Holiday EasterSunday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Easter Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Orthodox Easter Monday for given year and country</returns>
        Holiday EasterMonday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Pentecost
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Orthodox Pentecost for given year and country</returns>
        Holiday Pentecost(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Whit Monday / Pentecost Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <param name="counties"></param>
        /// <returns>Public holiday info for Orthodox Whit Monday / Pentecost Monday for given year, country and counties</returns>
        Holiday WhitMonday(string localName, int year, CountryCode countryCode, string[] counties = null);
    }
}
