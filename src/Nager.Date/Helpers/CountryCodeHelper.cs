using System;

namespace Nager.Date.Helpers
{
    /// <summary>
    /// CountryCode Helper
    /// </summary>
    public static class CountryCodeHelper
    {
        /// <summary>
        /// Parse given string to CountryCode
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="parsedCountryCode"></param>
        /// <returns>
        /// True for existing country code, false for non existent.
        /// Parsed country code is returned in out parameter.
        /// </returns>
        public static bool TryParseCountryCode(string countryCode, out CountryCode parsedCountryCode)
        {
            return Enum.TryParse(countryCode, true, out parsedCountryCode) && Enum.IsDefined(typeof(CountryCode), parsedCountryCode);
        }
    }
}
