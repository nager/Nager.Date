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
        /// <returns>Date of Orthodox Easter Sunday for given year</returns>
        DateTime EasterSunday(int year);

        /// <summary>
        /// Get Good Friday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Orthodox Good Friday for given year and country</returns>
        PublicHoliday GoodFriday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Holy Saturday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Orthodox Holy Saturday for given year and country</returns>
        PublicHoliday HolySaturday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Easter Sunday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Orthodox Easter Sunday for given year and country</returns>
        PublicHoliday EasterSunday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Easter Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Orthodox Easter Monday for given year and country</returns>
        PublicHoliday EasterMonday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Pentecost
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Orthodox Pentecost for given year and country</returns>
        PublicHoliday Pentecost(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Whit Monday / Pentecost Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <param name="counties"></param>
        /// <returns>Public holiday info for Orthodox Whit Monday / Pentecost Monday for given year, country and counties</returns>
        PublicHoliday WhitMonday(string localName, int year, CountryCode countryCode, string[] counties = null);
    }
}
