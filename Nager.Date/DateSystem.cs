using Nager.Date.PublicHolidays;
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
            CountryCode parsedCountryCode;
            if (Enum.TryParse(countryCode, true, out parsedCountryCode))
            {
                return null;
            }

            return GetPublicHoliday(parsedCountryCode, year);
        }

        /// <summary>
        /// Get Public Holidays
        /// </summary>
        /// <param name="countryCode">ISO 3166-1 ALPHA-2</param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<PublicHoliday> GetPublicHoliday(CountryCode countryCode, int year)
        {
            var easterSunday = EasterSunday(year);

            switch (countryCode)
            {
                case CountryCode.AT:
                    return Austria.Get(easterSunday, year);
                case CountryCode.BE:
                    return Belgium.Get(easterSunday, year);
                case CountryCode.CH:
                    return Switzerland.Get(easterSunday, year);
                case CountryCode.DE:
                    return Germany.Get(easterSunday, year);
                case CountryCode.ES:
                    return Spain.Get(easterSunday, year);
                case CountryCode.FR:
                    return France.Get(easterSunday, year);
                case CountryCode.IT:
                    return Italy.Get(easterSunday, year);
                case CountryCode.LI:
                    return Liechtenstein.Get(easterSunday, year);
                case CountryCode.NL:
                    return Netherlands.Get(easterSunday, year);
                case CountryCode.PT:
                    return Portugal.Get(easterSunday, year);
            }

            return null;
        }

        public static bool IsPublicHoliday(DateTime date, CountryCode countryCode)
        {
            var items = GetPublicHoliday(countryCode, date.Year);
            return items.Where(o => o.Date.Date == date.Date).Any();
        }

        public static bool IsOfficialPublicHolidayByCounty(DateTime date, CountryCode countryCode, string countyCode)
        {
            var items = GetPublicHoliday(countryCode, date.Year);
            return items.Where(o => o.Date.Date == date.Date && o.Counties.Contains(countyCode) && o.CountyOfficialHoliday).Any();
        }

        public static bool IsAdministrationPublicHolidayByCounty(DateTime date, CountryCode countryCode, string countyCode)
        {
            var items = GetPublicHoliday(countryCode, date.Year);
            return items.Where(o => o.Date.Date == date.Date && o.Counties.Contains(countyCode) && o.CountyAdministrationHoliday).Any();
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

        public static int FindDay(int year, int month, DayOfWeek day, int occurance)
        {
            if (occurance == 0 || occurance > 5)
            {
                throw new Exception("Occurance is invalid");
            }

            var firstDayOfMonth = new DateTime(year, month, 1);

            //Substract first day of the month with the required day of the week 
            var daysneeded = (int)day - (int)firstDayOfMonth.DayOfWeek;

            //if it is less than zero we need to get the next week day (add 7 days)
            if (daysneeded < 0)
            {
                daysneeded = daysneeded + 7;
            }

            //DayOfWeek is zero index based; multiply by the Occurance to get the day
            var resultedDay = (daysneeded + 1) + (7 * (occurance - 1));

            if (resultedDay > (firstDayOfMonth.AddMonths(1) - firstDayOfMonth).Days)
            {
                throw new Exception($"No {occurance} occurance of {day} in the required month");
            }

            return resultedDay;
        }
    }
}