using Nager.Date.Models;
using System;

namespace Nager.Date.ReligiousProviders
{
    /// <summary>
    /// Catholic Provider Interface
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
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Catholic Maundy Thursday for given year and country</returns>
        HolidaySpecification MaundyThursday(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null);

        /// <summary>
        /// Get Good Friday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Catholic Good Friday for given year and country</returns>
        HolidaySpecification GoodFriday(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null);

        /// <summary>
        /// Get Easter Sunday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Catholic Easter Sunday for given year and country</returns>
        HolidaySpecification EasterSunday(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null);

        /// <summary>
        /// Get Easter Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Catholic Easter Monday for given year and country</returns>
        HolidaySpecification EasterMonday(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null);

        /// <summary>
        /// Get Ascension Day
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Ascension Day for given year and country</returns>
        HolidaySpecification AscensionDay(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null);

        /// <summary>
        /// Get Pentecost
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Pentecost for given year and country</returns>
        HolidaySpecification Pentecost(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null);

        /// <summary>
        /// Get Whit Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Whit Monday for given year and country</returns>
        HolidaySpecification WhitMonday(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null);

        /// <summary>
        /// Get Corpus Christi
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Public holiday info for Corpus Christi for given year and country</returns>
        HolidaySpecification CorpusChristi(
            string localName,
            int year,
            ObservedRuleSet observedRuleSet = null);
    }
}
