using Nager.Date.Model;
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
        /// <returns>Date of Catholic Easter Sunday for given year</returns>
        DateTime EasterSunday(int year);

        /// <summary>
        /// Get advent sunday for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns>Date of Catholic Advent Sunday for given year</returns>
        DateTime AdventSunday(int year);

        /// <summary>
        /// Get Maundy Thursday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Catholic Maundy Thursday for given year and country</returns>
        PublicHoliday MaundyThursday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Good Friday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Catholic Good Friday for given year and country</returns>
        PublicHoliday GoodFriday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Easter Sunday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Catholic Easter Sunday for given year and country</returns>
        PublicHoliday EasterSunday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Easter Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Catholic Easter Monday for given year and country</returns>
        PublicHoliday EasterMonday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Ascension Day
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Ascension Day for given year and country</returns>
        PublicHoliday AscensionDay(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Pentecost
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Pentecost for given year and country</returns>
        PublicHoliday Pentecost(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Whit Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Whit Monday for given year and country</returns>
        PublicHoliday WhitMonday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Corpus Christi
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns>Public holiday info for Corpus Christi for given year and country</returns>
        PublicHoliday CorpusChristi(string localName, int year, CountryCode countryCode);
    }
}
