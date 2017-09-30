using Nager.Date.Contract;
using Nager.Date.Model;
using Nager.Date.PublicHolidays;
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
        public static IEnumerable<PublicHoliday> GetPublicHoliday(string countryCode, int year)
        {
            CountryCode parsedCountryCode;
            if (!Enum.TryParse(countryCode, true, out parsedCountryCode))
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
            IPublicHolidayProvider provider = null;

            switch (countryCode)
            {
                case CountryCode.AR:
                    provider = new ArgentinaProvider();
                    break;
                case CountryCode.AT:
                    provider = new AustriaProvider();
                    break;
                case CountryCode.AU:
                    provider = new AustraliaProvider();
                    break;
                case CountryCode.BE:
                    provider = new BelgiumProvider();
                    break;
                case CountryCode.BG:
                    provider = new BulgariaProvider();
                    break;
                case CountryCode.BO:
                    provider = new BoliviaProvider();
                    break;
                case CountryCode.BR:
                    provider = new BrazilProvider();
                    break;
                case CountryCode.BS:
                    provider = new BahamasProvider();
                    break;
                case CountryCode.BW:
                    provider = new BotswanaProvider();
                    break;
                case CountryCode.BY:
                    provider = new BelarusProvider();
                    break;
                case CountryCode.CA:
                    provider = new CanadaProvider();
                    break;
                case CountryCode.CH:
                    provider = new SwitzerlandProvider();
                    break;
                //case CountryCode.CN:
                //    provider = new ChinaProvider();
                //    break;
                case CountryCode.CY:
                    provider = new CyprusProvider();
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
                case CountryCode.EE:
                    provider = new EstoniaProvider();
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
                case CountryCode.GB:
                    provider = new UnitedKingdomProvider();
                    break;
                case CountryCode.GL:
                    provider = new GreenlandProvider();
                    break;
                case CountryCode.GR:
                    provider = new GreeceProvider();
                    break;
                case CountryCode.GT:
                    provider = new GuatemalaProvider();
                    break;
                case CountryCode.HN:
                    provider = new HondurasProvider();
                    break;
                case CountryCode.HR:
                    provider = new CroatiaProvider();
                    break;
                case CountryCode.HU:
                    provider = new HungaryProvider();
                    break;
                case CountryCode.IE:
                    provider = new IrelandProvider();
                    break;
                case CountryCode.IS:
                    provider = new IcelandProvider();
                    break;
                case CountryCode.IT:
                    provider = new ItalyProvider();
                    break;
                case CountryCode.LI:
                    provider = new LiechtensteinProvider();
                    break;
                case CountryCode.LT:
                    provider = new LithuaniaProvider();
                    break;
                case CountryCode.LU:
                    provider = new LuxembourgProvider();
                    break;
                case CountryCode.LV:
                    provider = new LatviaProvider();
                    break;
                case CountryCode.MG:
                    provider = new MadagascarProvider();
                    break;
                case CountryCode.MT:
                    provider = new MaltaProvider();
                    break;
                case CountryCode.NA:
                    provider = new NamibiaProvider();
                    break;
                case CountryCode.NL:
                    provider = new NetherlandsProvider();
                    break;
                case CountryCode.NO:
                    provider = new NorwayProvider();
                    break;
                case CountryCode.NZ:
                    provider = new NewZealandProvider();
                    break;
                case CountryCode.PA:
                    provider = new PanamaProvider();
                    break;
                case CountryCode.PE:
                    provider = new PeruProvider();
                    break;
                case CountryCode.PL:
                    provider = new PolandProvider();
                    break;
                case CountryCode.PT:
                    provider = new PortugalProvider();
                    break;
                case CountryCode.PY:
                    provider = new ParaguayProvider();
                    break;
                case CountryCode.RO:
                    provider = new RomaniaProvider();
                    break;
                case CountryCode.RU:
                    provider = new RussiaProvider();
                    break;
                case CountryCode.SI:
                    provider = new SloveniaProvider();
                    break;
                case CountryCode.SE:
                    provider = new SwedenProvider();
                    break;
                case CountryCode.SK:
                    provider = new SlovakiaProvider();
                    break;
                case CountryCode.TR:
                    provider = new TurkeyProvider();
                    break;
                case CountryCode.VE:
                    provider = new VenezuelaProvider();
                    break;
                case CountryCode.US:
                    provider = new UnitedStatesProvider();
                    break;
                case CountryCode.UY:
                    provider = new UruguayProvider();
                    break;
                case CountryCode.ZA:
                    provider = new SouthAfricaProvider();
                    break;
            }

            return provider?.Get(year);
        }

        public static IEnumerable<PublicHoliday> GetPublicHoliday(string countryCode, DateTime startDate, DateTime endDate)
        {
            CountryCode parsedCountryCode;
            if (!Enum.TryParse(countryCode, true, out parsedCountryCode))
            {
                return null;
            }

            return GetPublicHoliday(parsedCountryCode, startDate, endDate);
        }

        public static IEnumerable<PublicHoliday> GetPublicHoliday(CountryCode countryCode, DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("startDate is before endDate");
            }

            var currentYear = startDate.Year;
            var endYear = endDate.Year;

            while (currentYear <= endYear)
            {
                var items = GetPublicHoliday(countryCode, currentYear);
                foreach (var item in items)
                {
                    if (item.Date >= startDate && item.Date <= endDate)
                    {
                        yield return item;
                    }
                }
                currentYear++;
            }
        }

        public static bool IsPublicHoliday(DateTime date, CountryCode countryCode)
        {
            var items = GetPublicHoliday(countryCode, date.Year);
            return items.Any(o => o.Date.Date == date.Date);
        }

        public static bool IsOfficialPublicHolidayByCounty(DateTime date, CountryCode countryCode, string countyCode)
        {
            var items = GetPublicHoliday(countryCode, date.Year);
            return items.Any(o => o.Date.Date == date.Date && (o.Counties == null || o.Counties.Contains(countyCode)) && o.CountyOfficialHoliday);
        }

        public static bool IsAdministrationPublicHolidayByCounty(DateTime date, CountryCode countryCode, string countyCode)
        {
            var items = GetPublicHoliday(countryCode, date.Year);
            return items.Any(o => o.Date.Date == date.Date && (o.Counties == null || o.Counties.Contains(countyCode)) && o.CountyAdministrationHoliday);
        }

        public static DateTime FindLastDay(int year, int month, DayOfWeek day)
        {
            var resultedDay = FindDay(year, month, day, 5);
            if (resultedDay == DateTime.MinValue)
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

        public static DateTime FindDay(int year, int month, DayOfWeek day, int occurance)
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
                return DateTime.MinValue;
            }

            return new DateTime(year, month, resultedDay);
        }

        public static int GetAge(DateTime birthdate)
        {
            var today = DateTime.UtcNow;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;

            return age;
        }

        public static IEnumerable<LongWeekend> GetLongWeekend(CountryCode countryCode, int year)
        {
            LongWeekend item;

            var items = new List<LongWeekend>();

            var publicHolidays = GetPublicHoliday(countryCode, year);
            foreach (var publicHoliday in publicHolidays)
            {
                item = null;

                switch (publicHoliday.Date.DayOfWeek)
                {
                    case DayOfWeek.Thursday:
                        item = new LongWeekend();
                        item.StartDate = publicHoliday.Date;
                        item.EndDate = publicHoliday.Date.AddDays(3);
                        item.Bridge = true;
                        break;
                    case DayOfWeek.Friday:
                        item = new LongWeekend();
                        item.StartDate = publicHoliday.Date;
                        item.EndDate = publicHoliday.Date.AddDays(2);
                        item.Bridge = false;
                        break;
                    case DayOfWeek.Monday:
                        item = new LongWeekend();
                        item.StartDate = publicHoliday.Date.AddDays(-2);
                        item.EndDate = publicHoliday.Date;
                        item.Bridge = false;
                        break;
                    case DayOfWeek.Tuesday:
                        item = new LongWeekend();
                        item.StartDate = publicHoliday.Date.AddDays(-3);
                        item.EndDate = publicHoliday.Date;
                        item.Bridge = true;
                        break;
                }

                if (item == null)
                {
                    continue;
                }

                //Other LongWeekend on the same date, update the other
                var otherItem = items.Where(o => o.StartDate.Equals(item.StartDate)).FirstOrDefault();
                if (otherItem != null)
                {
                    otherItem.EndDate = item.EndDate;
                    continue;
                }

                items.Add(item);
            }

            return items;
        }
    }
}
