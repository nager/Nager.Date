using Nager.Date.Helpers;
using Nager.Date.WeekendProviders;
using Nager.Date.Weekends;
using System;
using System.Collections.Generic;

namespace Nager.Date
{
    /// <summary>
    /// Weekend System
    /// </summary>
    public static class WeekendSystem
    {
        private const string CountryCodeParsingError = "Country code {0} is not valid according to ISO 3166-1 ALPHA-2";

        private static readonly Dictionary<CountryCode, Lazy<IWeekendProvider>> _nonUniversalWeekendProviders =
            new Dictionary<CountryCode, Lazy<IWeekendProvider>>
            {
                // https://en.wikipedia.org/wiki/Workweek_and_weekend
                { CountryCode.AE, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) }, // since 2006 // TODO handle launch dates in weekends
                { CountryCode.AF, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.BD, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.BH, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.BN, new Lazy<IWeekendProvider>(() => WeekendProvider.FridaySunday) },
                // { CountryCode.CO, new Lazy<IWeekendProvider>(() => WeekendProvider.SundayOnly) }, // No information on in which case it occurs
                { CountryCode.DJ, new Lazy<IWeekendProvider>(() => WeekendProvider.FridayOnly) },
                { CountryCode.DZ, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.EG, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.GQ, new Lazy<IWeekendProvider>(() => WeekendProvider.SundayOnly) },
                { CountryCode.HK, new Lazy<IWeekendProvider>(() => WeekendProvider.SundayOnly) },
                { CountryCode.IL, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                // { CountryCode.IN, new Lazy<IWeekendProvider>(() => WeekendProvider.SundayOnly) }, // Except for Government offices and IT industry
                { CountryCode.IQ, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.IR, new Lazy<IWeekendProvider>(() => WeekendProvider.FridayOnly) },
                { CountryCode.JO, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.KW, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.LY, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.MV, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.MX, new Lazy<IWeekendProvider>(() => WeekendProvider.SundayOnly) },
                // { CountryCode.MY, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) }, // except in some counties // TODO Add county in weekend handling
                { CountryCode.NP, new Lazy<IWeekendProvider>(() => WeekendProvider.SaturdayOnly) },
                { CountryCode.OM, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.PH, new Lazy<IWeekendProvider>(() => WeekendProvider.SundayOnly) },
                // { CountryCode.PK, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) }, // only partially, often universal
                { CountryCode.PS, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.QA, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.SA, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.SD, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.SO, new Lazy<IWeekendProvider>(() => WeekendProvider.FridayOnly) },
                { CountryCode.SY, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
                { CountryCode.UG, new Lazy<IWeekendProvider>(() => WeekendProvider.SundayOnly) },
                { CountryCode.YE, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) }
            };

        /// <summary>
        /// Get the weekend provider for the specified country
        /// </summary>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Specialized weekend provider for country if exists, universal weekend provider otherwise</returns>
        /// <exception cref="ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static IWeekendProvider GetWeekendProvider(string countryCode)
        {
            if (!CountryCodeHelper.TryParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return GetWeekendProvider(parsedCountryCode);
        }

        /// <summary>
        /// Get the weekend provider for the specified country
        /// </summary>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Specialized weekend provider for country if exists, universal weekend provider otherwise</returns>
        public static IWeekendProvider GetWeekendProvider(CountryCode countryCode)
        {
            if (_nonUniversalWeekendProviders.TryGetValue(countryCode, out var provider))
            {
                return provider.Value;
            }

            return WeekendProvider.Universal;
        }

        /// <summary>
        /// Checks if a given date falls on a weekend in the specified country
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="countryCode">The country code (ISO 3166-1 ALPHA-2) to determine weekend rules</param>
        /// <returns>True if the given date is a weekend in the specified country, false otherwise</returns>
        /// <exception cref="ArgumentException">Thrown when the provided country code is not recognized as valid</exception>
        public static bool IsWeekend(DateTime date, string countryCode)
        {
            if (!CountryCodeHelper.TryParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return IsWeekend(date, parsedCountryCode);
        }

        /// <summary>
        /// Checks if a given date falls on a weekend in the specified country
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="countryCode">The country code (ISO 3166-1 ALPHA-2) to determine weekend rules</param>
        /// <returns>True if the given date is a weekend in the specified country, false otherwise</returns>
        public static bool IsWeekend(DateTime date, CountryCode countryCode)
        {
            var provider = GetWeekendProvider(countryCode);
            return provider.IsWeekend(date);
        }
    }
}
