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
        /// <returns>Holiday info for Catholic Maundy Thursday for given year</returns>
        HolidaySpecification MaundyThursday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Good Friday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Holiday info for Catholic Good Friday for given year</returns>
        HolidaySpecification GoodFriday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Easter Saturday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>PHoliday info for Catholic Easter Saturday for given year</returns>
        HolidaySpecification EasterSaturday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Easter Sunday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Holiday info for Catholic Easter Sunday for given year</returns>
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
        /// <returns>Holiday info for Catholic Easter Monday for given year</returns>
        HolidaySpecification EasterMonday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Ascension Day
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Holiday info for Ascension Day for given year</returns>
        HolidaySpecification AscensionDay(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Pentecost
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Holiday info for Pentecost for given year</returns>
        HolidaySpecification Pentecost(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Whit Monday
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Holiday info for Whit Monday for given year</returns>
        HolidaySpecification WhitMonday(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);

        /// <summary>
        /// Get Corpus Christi
        /// </summary>
        /// <param name="localName">The local name of the holiday</param>
        /// <param name="year"></param>
        /// <param name="observedRuleSet"></param>
        /// <returns>Holiday info for Corpus Christi for given year</returns>
        HolidaySpecification CorpusChristi(
            string localName,
            int year,
            ObservedRuleSet? observedRuleSet = null);
    }
}
