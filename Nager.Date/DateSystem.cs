using Nager.Date.PublicHolidays;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Nager.Date.Contract;

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
        public static IEnumerable<PublicHoliday> GetPublicHoliday(string countryCode, int year)
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
        public static IEnumerable<PublicHoliday> GetPublicHoliday(CountryCode countryCode, int year)
        {
            var easterSunday = EasterSunday(year);
            IPublicHolidayProvider provider = null;

            switch (countryCode)
            {
                case CountryCode.AT:
                    provider = new AustriaProvider();
                    break;
                case CountryCode.BE:
                    provider = new BelgiumProvider();
                    break;
                case CountryCode.BG:
                    provider = new BulgariaProvider();
                    break;
                case CountryCode.CH:
                    provider = new SwitzerlandProvider();
                    break;
                case CountryCode.CZ:
                    provider = new CzechRepublicProvider();
                    break;
                case CountryCode.DE:
                    provider = new GermanyProvider();
                    break;
                case CountryCode.DK:
                    provider = new DenmarkProvider();
                    break;
                case CountryCode.ES:
                    provider = new SpainProvider();
                    break;
                case CountryCode.FI:
                    provider = new FinlandProvider();
                    break;
                case CountryCode.FR:
                    provider = new FranceProvider();
                    break;
                case CountryCode.IT:
                    provider = new ItalyProvider();
                    break;
                case CountryCode.LI:
                    provider = new LiechtensteinProvider();
                    break;
                case CountryCode.MT:
                    provider = new MaltaProvider();
                    break;
                case CountryCode.NL:
                    provider = new NetherlandsProvider();
                    break;
                case CountryCode.PL:
                    provider = new PolandProvider();
                    break;
                case CountryCode.PT:
                    provider = new PortugalProvider();
                    break;
                case CountryCode.UK:
                    provider = new UnitedKingdomProvider();
                    break;
            }

            return provider?.Get(easterSunday, year);
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

        public static int FindLastDay(int year, int month, DayOfWeek day)
        {
            var resultedDay = FindDay(year, month, day, 5);
            if (resultedDay == -1)
            {
                resultedDay = FindDay(year, month, day, 4);
            }

            return resultedDay;
        }

        public static DateTime FindDay(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            var calculationDay = new DateTime(year, month, day);

            if ((int)dayOfWeek >= (int)calculationDay.DayOfWeek)
            {
                var daysNeeded = (int)dayOfWeek - (int)calculationDay.DayOfWeek;
                return calculationDay.AddDays(daysNeeded);
            }
            else
            {
                var daysNeeded = (int)dayOfWeek - (int)calculationDay.DayOfWeek;
                return calculationDay.AddDays(daysNeeded + 7);
            }
        }

        public static int FindDay(int year, int month, DayOfWeek day, int occurance)
        {
            if (occurance == 0 || occurance > 5)
            {
                throw new Exception("Occurance is invalid");
            }

            var firstDayOfMonth = new DateTime(year, month, 1);

            //Substract first day of the month with the required day of the week 
            var daysNeeded = (int)day - (int)firstDayOfMonth.DayOfWeek;

            //if it is less than zero we need to get the next week day (add 7 days)
            if (daysNeeded < 0)
            {
                daysNeeded = daysNeeded + 7;
            }

            //DayOfWeek is zero index based; multiply by the Occurance to get the day
            var resultedDay = (daysNeeded + 1) + (7 * (occurance - 1));

            if (resultedDay > DateTime.DaysInMonth(year, month))
            {
                return -1;
            }

            return resultedDay;
        }
    }
}