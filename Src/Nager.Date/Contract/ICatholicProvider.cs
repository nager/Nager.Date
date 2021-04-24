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
        /// <returns></returns>
        DateTime EasterSunday(int year);

        /// <summary>
        /// Get advent sunday for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DateTime AdventSunday(int year);

        /// <summary>
        /// Get Easter Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        PublicHoliday EasterMonday(string localName, int year, CountryCode countryCode);

        /// <summary>
        /// Get Ascension Day
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        PublicHoliday AscensionDay(string localName, int year, CountryCode countryCode);

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
        /// <returns></returns>
        PublicHoliday WhitMonday(string localName, int year, CountryCode countryCode);
    }
}
