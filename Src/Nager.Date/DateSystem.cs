using Nager.Date.Contract;
using Nager.Date.Model;
using Nager.Date.PublicHolidays;
using Nager.Date.Weekends;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date
{
    public static class DateSystem
    {
        static Dictionary<CountryCode, IOffDaysProvider> _countries = new Dictionary<CountryCode, IOffDaysProvider>
        {
            { CountryCode.AD, new AndorraProvider(new UniversalWeekendProvider()) },
            { CountryCode.AR, new ArgentinaProvider(new UniversalWeekendProvider()) },
            { CountryCode.AT, new AustriaProvider(new UniversalWeekendProvider()) },
            { CountryCode.AU, new AustraliaProvider(new UniversalWeekendProvider()) },
            { CountryCode.AX, new AlandProvider(new UniversalWeekendProvider()) },
            { CountryCode.BB, new BarbadosProvider(new UniversalWeekendProvider()) },
            { CountryCode.BE, new BelgiumProvider(new UniversalWeekendProvider()) },
            { CountryCode.BG, new BulgariaProvider(new UniversalWeekendProvider()) },
            { CountryCode.BO, new BoliviaProvider(new UniversalWeekendProvider()) },
            { CountryCode.BR, new BrazilProvider(new UniversalWeekendProvider()) },
            { CountryCode.BS, new BahamasProvider(new UniversalWeekendProvider()) },
            { CountryCode.BW, new BotswanaProvider(new UniversalWeekendProvider()) },
            { CountryCode.BY, new BelarusProvider(new UniversalWeekendProvider()) },
            { CountryCode.BZ, new BelizeProvider(new UniversalWeekendProvider()) },
            { CountryCode.CA, new CanadaProvider(new UniversalWeekendProvider()) },
            { CountryCode.CH, new SwitzerlandProvider(new UniversalWeekendProvider()) },
            { CountryCode.CL, new ChileProvider(new UniversalWeekendProvider()) },
            { CountryCode.CN, new ChinaProvider(new UniversalWeekendProvider()) },
            { CountryCode.CO, new ColombiaProvider(new UniversalWeekendProvider()) },
            { CountryCode.CR, new CostaRicaProvider(new UniversalWeekendProvider()) },
            { CountryCode.CU, new CubaProvider(new UniversalWeekendProvider()) },
            { CountryCode.CY, new CyprusProvider(new UniversalWeekendProvider()) },
            { CountryCode.CZ, new CzechRepublicProvider(new UniversalWeekendProvider()) },
            { CountryCode.DE, new GermanyProvider(new UniversalWeekendProvider()) },
            { CountryCode.DK, new DenmarkProvider(new UniversalWeekendProvider()) },
            { CountryCode.DO, new DominicanRepublicProvider(new UniversalWeekendProvider()) },
            { CountryCode.EC, new EcuadorProvider(new UniversalWeekendProvider()) },
            { CountryCode.EG, new EgyptProvider(new SemiUniversalWeekendProvider()) },
            { CountryCode.EE, new EstoniaProvider(new UniversalWeekendProvider()) },
            { CountryCode.ES, new SpainProvider(new UniversalWeekendProvider()) },
            { CountryCode.FI, new FinlandProvider(new UniversalWeekendProvider()) },
            { CountryCode.FO, new FaroeIslandsProvider(new UniversalWeekendProvider()) },
            { CountryCode.FR, new FranceProvider(new UniversalWeekendProvider()) },
            { CountryCode.GA, new GabonProvider(new UniversalWeekendProvider()) },
            { CountryCode.GB, new UnitedKingdomProvider(new UniversalWeekendProvider()) },
            { CountryCode.GD, new GrenadaProvider(new UniversalWeekendProvider()) },
            { CountryCode.GL, new GreenlandProvider(new UniversalWeekendProvider()) },
            { CountryCode.GR, new GreeceProvider(new UniversalWeekendProvider()) },
            { CountryCode.GT, new GuatemalaProvider(new UniversalWeekendProvider()) },
            { CountryCode.GY, new GuyanaProvider(new UniversalWeekendProvider()) },
            { CountryCode.HN, new HondurasProvider(new UniversalWeekendProvider()) },
            { CountryCode.HR, new CroatiaProvider(new UniversalWeekendProvider()) },
            { CountryCode.HT, new HaitiProvider(new UniversalWeekendProvider()) },
            { CountryCode.HU, new HungaryProvider(new UniversalWeekendProvider()) },
            { CountryCode.IE, new IrelandProvider(new UniversalWeekendProvider()) },
            { CountryCode.IM, new IsleOfManProvider(new UniversalWeekendProvider()) },
            { CountryCode.IS, new IcelandProvider(new UniversalWeekendProvider()) },
            { CountryCode.IT, new ItalyProvider(new UniversalWeekendProvider()) },
            { CountryCode.LI, new LiechtensteinProvider(new UniversalWeekendProvider()) },
            { CountryCode.LS, new LesothoProvider(new UniversalWeekendProvider()) },
            { CountryCode.LT, new LithuaniaProvider(new UniversalWeekendProvider()) },
            { CountryCode.LU, new LuxembourgProvider(new UniversalWeekendProvider()) },
            { CountryCode.LV, new LatviaProvider(new UniversalWeekendProvider()) },
            { CountryCode.JE, new JerseyProvider(new UniversalWeekendProvider()) },
            { CountryCode.JM, new JamaicaProvider(new UniversalWeekendProvider()) },
            { CountryCode.MA, new MoroccoProvider(new UniversalWeekendProvider()) },
            { CountryCode.MC, new MonacoProvider(new UniversalWeekendProvider()) },
            { CountryCode.MD, new MoldovaProvider(new UniversalWeekendProvider()) },
            { CountryCode.MG, new MadagascarProvider(new UniversalWeekendProvider()) },
            { CountryCode.MK, new MacedoniaProvider(new UniversalWeekendProvider()) },
            { CountryCode.MT, new MaltaProvider(new UniversalWeekendProvider()) },
            { CountryCode.MZ, new MozambiqueProvider(new UniversalWeekendProvider()) },
            { CountryCode.MX, new MexicoProvider(new SundayOnlyProvider()) }, // https://en.wikipedia.org/wiki/Workweek_and_weekend#Around_the_world
            { CountryCode.NA, new NamibiaProvider(new UniversalWeekendProvider()) },
            { CountryCode.NI, new NicaraguaProvider(new UniversalWeekendProvider()) },
            { CountryCode.NL, new NetherlandsProvider(new UniversalWeekendProvider()) },
            { CountryCode.NO, new NorwayProvider(new UniversalWeekendProvider()) },
            { CountryCode.NZ, new NewZealandProvider(new UniversalWeekendProvider()) },
            { CountryCode.PA, new PanamaProvider(new UniversalWeekendProvider()) },
            { CountryCode.PE, new PeruProvider(new UniversalWeekendProvider()) },
            { CountryCode.PL, new PolandProvider(new UniversalWeekendProvider()) },
            { CountryCode.PR, new PuertoRicoProvider(new UniversalWeekendProvider()) },
            { CountryCode.PT, new PortugalProvider(new UniversalWeekendProvider()) },
            { CountryCode.PY, new ParaguayProvider(new UniversalWeekendProvider()) },
            { CountryCode.RO, new RomaniaProvider(new UniversalWeekendProvider()) },
            { CountryCode.RU, new RussiaProvider(new UniversalWeekendProvider()) },
            { CountryCode.SM, new SanMarinoProvider(new UniversalWeekendProvider()) },
            { CountryCode.RS, new SerbiaProvider(new UniversalWeekendProvider()) },
            { CountryCode.SI, new SloveniaProvider(new UniversalWeekendProvider()) },
            { CountryCode.SJ, new SvalbardAndJanMayenProvider(new UniversalWeekendProvider()) },
            { CountryCode.SE, new SwedenProvider(new UniversalWeekendProvider()) },
            { CountryCode.SK, new SlovakiaProvider(new UniversalWeekendProvider()) },
            { CountryCode.SR, new SurinameProvider(new UniversalWeekendProvider()) },
            { CountryCode.SV, new ElSalvadorProvider(new UniversalWeekendProvider()) },
            { CountryCode.TN, new TunisiaProvider(new UniversalWeekendProvider()) },
            { CountryCode.TR, new TurkeyProvider(new UniversalWeekendProvider()) },
            { CountryCode.UA, new UkraineProvider(new UniversalWeekendProvider()) },
            { CountryCode.VA, new VaticanCityProvider(new UniversalWeekendProvider()) },
            { CountryCode.VE, new VenezuelaProvider(new UniversalWeekendProvider()) },
            { CountryCode.US, new UnitedStatesProvider(new UniversalWeekendProvider()) },
            { CountryCode.UY, new UruguayProvider(new UniversalWeekendProvider()) },
            { CountryCode.ZA, new SouthAfricaProvider(new UniversalWeekendProvider()) }
        };

        public static IOffDaysProvider GetProvider(CountryCode countryCode)
        {
            _countries.TryGetValue(countryCode, out IOffDaysProvider provider);
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
                var otherItem = items.FirstOrDefault(o => o.StartDate.Equals(item.StartDate));
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
