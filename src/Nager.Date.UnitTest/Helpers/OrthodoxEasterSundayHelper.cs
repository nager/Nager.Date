using System;
using System.Collections.Generic;

namespace Nager.Date.UnitTest.Helpers
{
    public static class OrthodoxEasterSundayHelper
    {
        private static readonly Dictionary<int, int> _first2DigitsOfYearMapping = new Dictionary<int, int>
        {
            { 10, 2 },
            { 11, 1 },
            { 12, 0 },
            { 13, 6 },
            { 14, 5 },
            { 15, 4 },
            { 16, 3 },
            { 17, 2 },
            { 18, 1 },
            { 19, 0 },
            { 20, 6 },
            { 21, 5 },
            { 22, 4 },
            { 23, 3 },
            { 24, 2 },
            { 25, 1 },
            { 26, 0 },
            { 27, 6 },
            { 28, 5 },
            { 29, 4 },
            { 30, 3 },
            { 31, 2 },
            { 32, 1 },
            { 33, 0 },
        };

        private static readonly Dictionary<int, int> _second2DigitsOfYearMapping = new Dictionary<int, int>
        {
            { 00, 0 },
            { 01, 1 },
            { 02, 2 },
            { 03, 3 },
            { 04, 5 },
            { 05, 6 },
            { 06, 0 },
            { 07, 1 },
            { 08, 3 },
            { 09, 4 },
            { 10, 5 },
            { 11, 6 },
            { 12, 1 },
            { 13, 2 },
            { 14, 3 },
            { 15, 4 },
            { 16, 6 },
            { 17, 0 },
            { 18, 1 },
            { 19, 2 },
            { 20, 4 },
            { 21, 5 },
            { 22, 6 },
            { 23, 0 },
            { 24, 2 },
            { 25, 3 },
            { 26, 4 },
            { 27, 5 },
            { 28, 0 },
            { 29, 1 },
            { 30, 2 },
            { 31, 3 },
            { 32, 5 },
            { 33, 6 },
            { 34, 0 },
            { 35, 1 },
            { 36, 3 },
            { 37, 4 },
            { 38, 5 },
            { 39, 6 },
            { 40, 1 },
            { 41, 2 },
            { 42, 3 },
            { 43, 4 },
            { 44, 6 },
            { 45, 0 },
            { 46, 1 },
            { 47, 2 },
            { 48, 4 },
            { 49, 5 },
            { 50, 6 },
            { 51, 0 },
            { 52, 2 },
            { 53, 3 },
            { 54, 4 },
            { 55, 5 },
            { 56, 0 },
            { 57, 1 },
            { 58, 2 },
            { 59, 3 },
            { 60, 5 },
            { 61, 6 },
            { 62, 0 },
            { 63, 1 },
            { 64, 3 },
            { 65, 4 },
            { 66, 5 },
            { 67, 6 },
            { 68, 1 },
            { 69, 2 },
            { 70, 3 },
            { 71, 4 },
            { 72, 6 },
            { 73, 0 },
            { 74, 1 },
            { 75, 2 },
            { 76, 4 },
            { 77, 5 },
            { 78, 6 },
            { 79, 0 },
            { 80, 2 },
            { 81, 3 },
            { 82, 4 },
            { 83, 5 },
            { 84, 0 },
            { 85, 1 },
            { 86, 2 },
            { 87, 3 },
            { 88, 5 },
            { 89, 6 },
            { 90, 0 },
            { 91, 1 },
            { 92, 3 },
            { 93, 4 },
            { 94, 5 },
            { 95, 6 },
            { 96, 1 },
            { 97, 2 },
            { 98, 3 },
            { 99, 4 },
        };

        private static readonly Dictionary<int, int> _followingSundayMapping = new Dictionary<int, int>
        {
            { 0, 7 },
            { 1, 6 },
            { 2, 5 },
            { 3, 4 },
            { 4, 3 },
            { 5, 2 },
            { 6, 1 },
            { 7, 7 },
            { 8, 6 },
            { 9, 5 },
            { 10, 4 },
            { 11, 3 },
            { 12, 2 },
            { 13, 1 },
            { 14, 7 },
            { 15, 6 },
            { 16, 5 },
            { 17, 4 },
            { 18, 3 },
        };

        /// <summary>
        /// Calculate Easter Sunday
        /// </summary>
        /// <remarks>https://www.assa.org.au/edm#OrthCalculator</remarks>
        /// <param name="year"></param>
        /// <returns></returns>
        internal static DateTime CalculateEasterSunday(int year)
        {
            var yearDividedBy19 = year / 19.0;
            var decimalPartOfYearDividedBy19 = Math.Round(yearDividedBy19 % 1, 3, MidpointRounding.AwayFromZero);
            var centuryPartOfYear = year / 100;
            var yearInCentury = year % 100;

            var paschalFullMoonMapping = new Dictionary<double, Tuple<int, DateTime>>
            {
                { 0, new Tuple<int, DateTime>(3, new DateTime(year, 4, 5)) },     // A5 -> April 5
                { 0.053, new Tuple<int, DateTime>(6, new DateTime(year, 3, 25)) }, // M25 -> March 25
                { 0.105, new Tuple<int, DateTime>(4, new DateTime(year, 4, 13)) }, // A13 -> April 13
                { 0.158, new Tuple<int, DateTime>(0, new DateTime(year, 4, 2)) }, // A2 -> April 2
                { 0.211, new Tuple<int, DateTime>(3, new DateTime(year, 3, 22)) }, // M22 -> March 22
                { 0.263, new Tuple<int, DateTime>(1, new DateTime(year, 4, 10)) }, // A10 -> April 10
                { 0.316, new Tuple<int, DateTime>(4, new DateTime(year, 3, 30)) }, // M30 -> March 30
                { 0.368, new Tuple<int, DateTime>(2, new DateTime(year, 4, 18)) }, // A18 -> April 18
                { 0.421, new Tuple<int, DateTime>(5, new DateTime(year, 4, 7)) }, // A7 -> April 7
                { 0.474, new Tuple<int, DateTime>(1, new DateTime(year, 3, 27)) }, // M27 -> March 27
                { 0.526, new Tuple<int, DateTime>(6, new DateTime(year, 4, 15)) }, // A15 -> April 15
                { 0.579, new Tuple<int, DateTime>(2, new DateTime(year, 4, 4)) }, // A4 -> April 4
                { 0.632, new Tuple<int, DateTime>(5, new DateTime(year, 3, 24)) }, // M24 -> March 24
                { 0.684, new Tuple<int, DateTime>(3, new DateTime(year, 4, 12)) }, // A12 -> April 12
                { 0.737, new Tuple<int, DateTime>(6, new DateTime(year, 4, 1)) }, // A1 -> April 1
                { 0.789, new Tuple<int, DateTime>(2, new DateTime(year, 3, 21)) }, // M21 -> March 21
                { 0.842, new Tuple<int, DateTime>(0, new DateTime(year, 4, 9)) }, // A9 -> April 9
                { 0.895, new Tuple<int, DateTime>(3, new DateTime(year, 3, 29)) }, // M29 -> March 29
                { 0.947, new Tuple<int, DateTime>(1, new DateTime(year, 4, 17)) }  // A17 -> April 17
            };

            var paschalFullMoon = paschalFullMoonMapping[decimalPartOfYearDividedBy19];
            var dayToAdd1 = _first2DigitsOfYearMapping[centuryPartOfYear];
            var dayToAdd2 = _second2DigitsOfYearMapping[yearInCentury];

            var daysToAddForGregorianCalendar = year switch
            {
                int y when (y >= 1583 && y <= 1699) => 10,
                int y when (y >= 1700 && y <= 1799) => 11,
                int y when (y >= 1800 && y <= 1899) => 12,
                int y when (y >= 1900 && y <= 2099) => 13,
                int y when (y >= 2100 && y <= 2199) => 14,
                int y when (y >= 2200 && y <= 2299) => 15,
                int y when (y >= 2300 && y <= 2499) => 16,
                int y when (y >= 2500 && y <= 2599) => 17,
                int y when (y >= 2600 && y <= 2699) => 18,
                int y when (y >= 2700 && y <= 2899) => 19,
                int y when (y >= 2900 && y <= 2999) => 20,
                int y when (y >= 3000 && y <= 3099) => 21,
                int y when (y >= 3100 && y <= 3299) => 22,
                int y when (y >= 3300 && y <= 3399) => 23,
                _ => 0,
            };

            var followingSunday = _followingSundayMapping[paschalFullMoon.Item1 + dayToAdd1 + dayToAdd2];

            return paschalFullMoon.Item2.AddDays(followingSunday).AddDays(daysToAddForGregorianCalendar);
        }
    }
}
