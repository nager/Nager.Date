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
        static Dictionary<CountryCode, IPublicHolidayProvider> _countries;

        static DateSystem() //static constructor
        {
            _countries = new Dictionary<CountryCode, IPublicHolidayProvider>();

            _countries.Add(CountryCode.AD, new AndorraProvider());
            _countries.Add(CountryCode.AR, new ArgentinaProvider());
            _countries.Add(CountryCode.AT, new AustriaProvider());
            _countries.Add(CountryCode.AU, new AustraliaProvider());
            _countries.Add(CountryCode.AX, new AlandProvider());
            _countries.Add(CountryCode.BB, new BarbadosProvider());
            _countries.Add(CountryCode.BE, new BelgiumProvider());
            _countries.Add(CountryCode.BG, new BulgariaProvider());
            _countries.Add(CountryCode.BO, new BoliviaProvider());
            _countries.Add(CountryCode.BR, new BrazilProvider());
            _countries.Add(CountryCode.BS, new BahamasProvider());
            _countries.Add(CountryCode.BW, new BotswanaProvider());
            _countries.Add(CountryCode.BY, new BelarusProvider());
            _countries.Add(CountryCode.BZ, new BelizeProvider());
            _countries.Add(CountryCode.CA, new CanadaProvider());
            _countries.Add(CountryCode.CH, new SwitzerlandProvider());
            _countries.Add(CountryCode.CL, new ChileProvider());
            _countries.Add(CountryCode.CN, new ChinaProvider());
            _countries.Add(CountryCode.CO, new ColombiaProvider());
            _countries.Add(CountryCode.CR, new CostaRicaProvider());
            _countries.Add(CountryCode.CU, new CubaProvider());
            _countries.Add(CountryCode.CY, new CyprusProvider());
            _countries.Add(CountryCode.CZ, new CzechRepublicProvider());
            _countries.Add(CountryCode.DE, new GermanyProvider());
            _countries.Add(CountryCode.DK, new DenmarkProvider());
            _countries.Add(CountryCode.DO, new DominicanRepublicProvider());
            _countries.Add(CountryCode.EC, new EcuadorProvider());
            _countries.Add(CountryCode.EG, new EgyptProvider());
            _countries.Add(CountryCode.EE, new EstoniaProvider());
            _countries.Add(CountryCode.ES, new SpainProvider());
            _countries.Add(CountryCode.FI, new FinlandProvider());
            _countries.Add(CountryCode.FR, new FranceProvider());
            _countries.Add(CountryCode.GA, new GabonProvider());
            _countries.Add(CountryCode.GB, new UnitedKingdomProvider());
            _countries.Add(CountryCode.GD, new GrenadaProvider());
            _countries.Add(CountryCode.GL, new GreenlandProvider());
            _countries.Add(CountryCode.GR, new GreeceProvider());
            _countries.Add(CountryCode.GT, new GuatemalaProvider());
            _countries.Add(CountryCode.GY, new GuyanaProvider());
            _countries.Add(CountryCode.HN, new HondurasProvider());
            _countries.Add(CountryCode.HR, new CroatiaProvider());
            _countries.Add(CountryCode.HT, new HaitiProvider());
            _countries.Add(CountryCode.HU, new HungaryProvider());
            _countries.Add(CountryCode.IE, new IrelandProvider());
            _countries.Add(CountryCode.IM, new IsleOfManProvider());
            _countries.Add(CountryCode.IS, new IcelandProvider());
            _countries.Add(CountryCode.IT, new ItalyProvider());
            _countries.Add(CountryCode.LI, new LiechtensteinProvider());
            _countries.Add(CountryCode.LT, new LithuaniaProvider());
            _countries.Add(CountryCode.LU, new LuxembourgProvider());
            _countries.Add(CountryCode.LV, new LatviaProvider());
            _countries.Add(CountryCode.JE, new JerseyProvider());
            _countries.Add(CountryCode.JM, new JamaicaProvider());
            _countries.Add(CountryCode.MA, new MoroccoProvider());
            _countries.Add(CountryCode.MC, new MonacoProvider());
            _countries.Add(CountryCode.MD, new MoldovaProvider());
            _countries.Add(CountryCode.MG, new MadagascarProvider());
            _countries.Add(CountryCode.MK, new MacedoniaProvider());
            _countries.Add(CountryCode.MT, new MaltaProvider());
            _countries.Add(CountryCode.MZ, new MozambiqueProvider());
            _countries.Add(CountryCode.MX, new MexicoProvider());
            _countries.Add(CountryCode.NA, new NamibiaProvider());
            _countries.Add(CountryCode.NI, new NicaraguaProvider());
            _countries.Add(CountryCode.NL, new NetherlandsProvider());
            _countries.Add(CountryCode.NO, new NorwayProvider());
            _countries.Add(CountryCode.NZ, new NewZealandProvider());
            _countries.Add(CountryCode.PA, new PanamaProvider());
            _countries.Add(CountryCode.PE, new PeruProvider());
            _countries.Add(CountryCode.PL, new PolandProvider());
            _countries.Add(CountryCode.PR, new PuertoRicoProvider());
            _countries.Add(CountryCode.PT, new PortugalProvider());
            _countries.Add(CountryCode.PY, new ParaguayProvider());
            _countries.Add(CountryCode.RO, new RomaniaProvider());
            _countries.Add(CountryCode.RU, new RussiaProvider());
            _countries.Add(CountryCode.SM, new SanMarinoProvider());
            _countries.Add(CountryCode.RS, new SerbiaProvider());
            _countries.Add(CountryCode.SI, new SloveniaProvider());
            _countries.Add(CountryCode.SJ, new SvalbardUndJanMayenProvider());
            _countries.Add(CountryCode.SE, new SwedenProvider());
            _countries.Add(CountryCode.SK, new SlovakiaProvider());
            _countries.Add(CountryCode.SR, new SurinameProvider());
            _countries.Add(CountryCode.SV, new ElSalvadorProvider());
            _countries.Add(CountryCode.TN, new TunisiaProvider());
            _countries.Add(CountryCode.TR, new TurkeyProvider());
            _countries.Add(CountryCode.UA, new UkraineProvider());
            _countries.Add(CountryCode.VA, new VaticanCityProvider());
            _countries.Add(CountryCode.VE, new VenezuelaProvider());
            _countries.Add(CountryCode.US, new UnitedStatesProvider());
            _countries.Add(CountryCode.UY, new UruguayProvider());
            _countries.Add(CountryCode.ZA, new SouthAfricaProvider());
        }

        public static IPublicHolidayProvider GetProvider(CountryCode countryCode)
        {
            _countries.TryGetValue(countryCode, out IPublicHolidayProvider provider);
            return provider;
        }

        #region Public Holidays for a given year

        /// <summary>
        /// Get Public Holidays of given year
        /// </summary>
        /// <param name="countryCode">ISO 3166-1 ALPHA-2</param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static IEnumerable<PublicHoliday> GetPublicHoliday(string countryCode, int year)
        {
            if (!Enum.TryParse(countryCode, true, out CountryCode parsedCountryCode))
            {
                return null;
            }

            return GetPublicHoliday(parsedCountryCode, year);
        }

        /// <summary>
        /// Get Public Holidays of given year
        /// </summary>
        /// <param name="countryCode">ISO 3166-1 ALPHA-2</param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static IEnumerable<PublicHoliday> GetPublicHoliday(CountryCode countryCode, int year)
        {
            var provider = GetProvider(countryCode);
            return provider?.Get(year);
        }

        #endregion

        #region Public Holidays for a date range

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

        #endregion

        #region Check a date is a Public Holiday

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

        #endregion

        #region Day Finding

        /// <summary>
        /// Find the latest weekday for example monday in a month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime FindLastDay(int year, int month, DayOfWeek day)
        {
            var resultedDay = FindDay(year, month, day, 5);
            if (resultedDay == DateTime.MinValue)
            {
                resultedDay = FindDay(year, month, day, 4);
            }

            return resultedDay;
        }

        /// <summary>
        /// Find the next weekday for example monday from a specific date
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Find the next weekday for example monday from a specific date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FindDay(DateTime date, DayOfWeek dayOfWeek)
        {
            return FindDay(date.Year, date.Month, date.Day, dayOfWeek);
        }

        /// <summary>
        /// Find the next weekday for example monday before a specific date
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FindDayBefore(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            var calculationDay = new DateTime(year, month, day);

            if ((int)dayOfWeek < (int)calculationDay.DayOfWeek)
            {
                var daysSubtract = (int)calculationDay.DayOfWeek - (int)dayOfWeek;
                return calculationDay.AddDays(-daysSubtract);
            }
            else
            {
                var daysSubtract = (int)dayOfWeek - (int)calculationDay.DayOfWeek;
                return calculationDay.AddDays(daysSubtract - 7);
            }
        }

        /// <summary>
        /// Find the next weekday for example monday before a specific date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime FindDayBefore(DateTime date, DayOfWeek dayOfWeek)
        {
            return FindDayBefore(date.Year, date.Month, date.Day, dayOfWeek);
        }

        /// <summary>
        /// Find for example the 3th monday in a month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="occurrence"></param>
        /// <returns></returns>
        public static DateTime FindDay(int year, int month, DayOfWeek day, int occurrence)
        {
            if (occurrence == 0 || occurrence > 5)
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
            var resultedDay = (daysNeeded + 1) + (7 * (occurrence - 1));

            if (resultedDay > DateTime.DaysInMonth(year, month))
            {
                return DateTime.MinValue;
            }

            return new DateTime(year, month, resultedDay);
        }

        #endregion

        #region Birthday

        public static int GetAge(DateTime birthdate)
        {
            var today = DateTime.UtcNow;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;

            return age;
        }

        #endregion

        #region Long Weekends

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

        #endregion
    }
}
