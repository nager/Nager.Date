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
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Orthodox Good Friday for given year and country</returns>
        HolidaySpecification GoodFriday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Holy Saturday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Orthodox Holy Saturday for given year and country</returns>
        HolidaySpecification HolySaturday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Easter Sunday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Orthodox Easter Sunday for given year and country</returns>
        HolidaySpecification EasterSunday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Easter Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Orthodox Easter Monday for given year and country</returns>
        HolidaySpecification EasterMonday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Pentecost
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Orthodox Pentecost for given year and country</returns>
        HolidaySpecification Pentecost(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Whit Monday / Pentecost Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Orthodox Whit Monday / Pentecost Monday for given year, country and counties</returns>
        HolidaySpecification WhitMonday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);
    }
}
