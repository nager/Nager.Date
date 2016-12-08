using Nager.Date.Data;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date
{
    public static class DateSystem
    {
        /// <summary>
        /// Get Public Holidays
        /// </summary>
        /// <param name="countryCode">ISO 3166-1 ALPHA-2</param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<PublicHoliday> GetPublicHoliday(string countryCode, int year)
        {
            if (String.IsNullOrEmpty(countryCode))
            {
                return null;
            }

            countryCode = countryCode.ToUpper();
            var easterSunday = EasterSunday(year);

            switch (countryCode)
            {
                case "AT":
                    return DataAT.Get(easterSunday, year);
                case "BE":
                    return DataBE.Get(easterSunday, year);
                case "CH":
                    return DataCH.Get(easterSunday, year);
                case "DE":
                    return DataDE.Get(easterSunday, year);
                case "ES":
                    return DataES.Get(easterSunday, year);
                case "FR":
                    return DataFR.Get(easterSunday, year);
                case "IT":
                    return DataIT.Get(easterSunday, year);
                case "LI":
                    return DataLI.Get(easterSunday, year);
                case "NL":
                    return DataNL.Get(easterSunday, year);
                default:
                    break;
            }

            return null;
        }

        public static bool IsPublicHoliday(DateTime date, string countryCode)
        {
            var items = GetPublicHoliday(countryCode, date.Year);
            return items.Where(o => o.Date.Date == date.Date).Any();
        }


        public static bool IsPublicHolidayByCounty(DateTime date, string countryCode, string countyCode)
        {
            var items = GetPublicHoliday(countryCode, date.Year);
            return items.Where(o => o.Date.Date == date.Date && o.Counties.Contains(countyCode)).Any();
        }

        /// <summary>
        /// Get Catholic easter for requested year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime EasterSunday(int year)
        {
            var g = year % 19;
            var c = year / 100;
            var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));
            var j = (year + year / 4 + i + 2 - c + c / 4) % 7;
            var p = i - j;
            var easterDay = 1 + (p + 27 + (p + 6) / 40) % 31;
            var easterMonth = 3 + (p + 26) / 30;

            return new DateTime(year, easterMonth, easterDay);
        }
    }
}