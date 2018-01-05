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
        public static IPublicHolidayProvider GetProvider(CountryCode countryCode)
        {
            var countries = new Dictionary<CountryCode, IPublicHolidayProvider>();
            countries.Add(CountryCode.AD, new AndorraProvider());
            countries.Add(CountryCode.AR, new ArgentinaProvider());
            countries.Add(CountryCode.AT, new AustriaProvider());
            countries.Add(CountryCode.AU, new AustraliaProvider());
            countries.Add(CountryCode.AX, new AlandProvider());
            countries.Add(CountryCode.BE, new BelgiumProvider());
            countries.Add(CountryCode.BG, new BulgariaProvider());
            countries.Add(CountryCode.BO, new BoliviaProvider());
            countries.Add(CountryCode.BR, new BrazilProvider());
            countries.Add(CountryCode.BS, new BahamasProvider());
            countries.Add(CountryCode.BW, new BotswanaProvider());
            countries.Add(CountryCode.BY, new BelarusProvider());
            countries.Add(CountryCode.CA, new CanadaProvider());
            countries.Add(CountryCode.CH, new SwitzerlandProvider());
            countries.Add(CountryCode.CL, new ChileProvider());
            countries.Add(CountryCode.CN, new ChinaProvider());
            countries.Add(CountryCode.CO, new ColombiaProvider());
            countries.Add(CountryCode.CR, new CostaRicaProvider());
            countries.Add(CountryCode.CU, new CubaProvider());
            countries.Add(CountryCode.CY, new CyprusProvider());
            countries.Add(CountryCode.CZ, new CzechRepublicProvider());
            countries.Add(CountryCode.DE, new GermanyProvider());
            countries.Add(CountryCode.DK, new DenmarkProvider());
            countries.Add(CountryCode.DO, new DominicanRepublicProvider());
            countries.Add(CountryCode.EC, new EcuadorProvider());
            countries.Add(CountryCode.EE, new EstoniaProvider());
            countries.Add(CountryCode.ES, new SpainProvider());
            countries.Add(CountryCode.FI, new FinlandProvider());
            countries.Add(CountryCode.FR, new FranceProvider());
            countries.Add(CountryCode.GB, new UnitedKingdomProvider());
            countries.Add(CountryCode.GL, new GreenlandProvider());
            countries.Add(CountryCode.GR, new GreeceProvider());
            countries.Add(CountryCode.GT, new GuatemalaProvider());
            countries.Add(CountryCode.GY, new GuyanaProvider());
            countries.Add(CountryCode.HN, new HondurasProvider());
            countries.Add(CountryCode.HR, new CroatiaProvider());
            countries.Add(CountryCode.HT, new HaitiProvider());
            countries.Add(CountryCode.HU, new HungaryProvider());
            countries.Add(CountryCode.IE, new IrelandProvider());
            countries.Add(CountryCode.IM, new IsleOfManProvider());
            countries.Add(CountryCode.IS, new IcelandProvider());
            countries.Add(CountryCode.IT, new ItalyProvider());
            countries.Add(CountryCode.LI, new LiechtensteinProvider());
            countries.Add(CountryCode.LT, new LithuaniaProvider());
            countries.Add(CountryCode.LU, new LuxembourgProvider());
            countries.Add(CountryCode.LV, new LatviaProvider());
            countries.Add(CountryCode.JE, new JerseyProvider());
            countries.Add(CountryCode.JM, new JamaicaProvider());
            countries.Add(CountryCode.MC, new MonacoProvider());
            countries.Add(CountryCode.MG, new MadagascarProvider());
            countries.Add(CountryCode.MT, new MaltaProvider());
            countries.Add(CountryCode.MX, new MexicoProvider());
            countries.Add(CountryCode.NA, new NamibiaProvider());
            countries.Add(CountryCode.NI, new NicaraguaProvider());
            countries.Add(CountryCode.NL, new NetherlandsProvider());
            countries.Add(CountryCode.NO, new NorwayProvider());
            countries.Add(CountryCode.NZ, new NewZealandProvider());
            countries.Add(CountryCode.PA, new PanamaProvider());
            countries.Add(CountryCode.PE, new PeruProvider());
            countries.Add(CountryCode.PL, new PolandProvider());
            countries.Add(CountryCode.PR, new PuertoRicoProvider());
            countries.Add(CountryCode.PT, new PortugalProvider());
            countries.Add(CountryCode.PY, new ParaguayProvider());
            countries.Add(CountryCode.RO, new RomaniaProvider());
            countries.Add(CountryCode.RU, new RussiaProvider());
            countries.Add(CountryCode.SI, new SloveniaProvider());
            countries.Add(CountryCode.SE, new SwedenProvider());
            countries.Add(CountryCode.SK, new SlovakiaProvider());
            countries.Add(CountryCode.SR, new SurinameProvider());
            countries.Add(CountryCode.TR, new TurkeyProvider());
            countries.Add(CountryCode.VE, new VenezuelaProvider());
            countries.Add(CountryCode.US, new UnitedStatesProvider());
            countries.Add(CountryCode.UY, new UruguayProvider());
            countries.Add(CountryCode.ZA, new SouthAfricaProvider());

            countries.TryGetValue(countryCode, out IPublicHolidayProvider provider);
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
