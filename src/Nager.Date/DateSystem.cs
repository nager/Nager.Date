using Nager.Date.Contract;
using Nager.Date.Model;
using Nager.Date.PublicHolidays;
using Nager.Date.Weekends;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date
{
    /// <summary>
    /// DateSystem
    /// </summary>
    public static class DateSystem
    {
        private const string CountryCodeParsingError = "Country code {0} is not valid according to ISO 3166-1 ALPHA-2";

        private static readonly ICatholicProvider _catholicProvider = new CatholicProvider();
        private static readonly IOrthodoxProvider _orthodoxProvider = new OrthodoxProvider();

        private static readonly Dictionary<CountryCode, Lazy<IPublicHolidayProvider>> _publicHolidaysProviders =
            new Dictionary<CountryCode, Lazy<IPublicHolidayProvider>>
            {
                { CountryCode.AL, new Lazy<IPublicHolidayProvider>(() => new AlbaniaProvider(_orthodoxProvider))},
                { CountryCode.AD, new Lazy<IPublicHolidayProvider>(() => new AndorraProvider())},
                { CountryCode.AR, new Lazy<IPublicHolidayProvider>(() => new ArgentinaProvider(_catholicProvider))},
                { CountryCode.AT, new Lazy<IPublicHolidayProvider>(() => new AustriaProvider(_catholicProvider))},
                { CountryCode.AU, new Lazy<IPublicHolidayProvider>(() => new AustraliaProvider(_catholicProvider))},
                { CountryCode.AX, new Lazy<IPublicHolidayProvider>(() => new AlandProvider(_catholicProvider))},
                { CountryCode.BA, new Lazy<IPublicHolidayProvider>(() => new BosniaAndHerzegovinaProvider(_orthodoxProvider))},
                { CountryCode.BB, new Lazy<IPublicHolidayProvider>(() => new BarbadosProvider(_catholicProvider))},
                { CountryCode.BE, new Lazy<IPublicHolidayProvider>(() => new BelgiumProvider(_catholicProvider))},
                { CountryCode.BG, new Lazy<IPublicHolidayProvider>(() => new BulgariaProvider(_orthodoxProvider))},
                { CountryCode.BJ, new Lazy<IPublicHolidayProvider>(() => new BeninProvider(_catholicProvider))},
                { CountryCode.BO, new Lazy<IPublicHolidayProvider>(() => new BoliviaProvider(_catholicProvider))},
                { CountryCode.BR, new Lazy<IPublicHolidayProvider>(() => new BrazilProvider(_catholicProvider))},
                { CountryCode.BS, new Lazy<IPublicHolidayProvider>(() => new BahamasProvider(_catholicProvider))},
                { CountryCode.BW, new Lazy<IPublicHolidayProvider>(() => new BotswanaProvider(_catholicProvider))},
                { CountryCode.BY, new Lazy<IPublicHolidayProvider>(() => new BelarusProvider(_orthodoxProvider))},
                { CountryCode.BZ, new Lazy<IPublicHolidayProvider>(() => new BelizeProvider(_catholicProvider))},
                { CountryCode.CA, new Lazy<IPublicHolidayProvider>(() => new CanadaProvider(_catholicProvider))},
                { CountryCode.CH, new Lazy<IPublicHolidayProvider>(() => new SwitzerlandProvider(_catholicProvider))},
                { CountryCode.CL, new Lazy<IPublicHolidayProvider>(() => new ChileProvider(_catholicProvider))},
                { CountryCode.CN, new Lazy<IPublicHolidayProvider>(() => new ChinaProvider())},
                { CountryCode.CO, new Lazy<IPublicHolidayProvider>(() => new ColombiaProvider(_catholicProvider))},
                { CountryCode.CR, new Lazy<IPublicHolidayProvider>(() => new CostaRicaProvider(_catholicProvider))},
                { CountryCode.CU, new Lazy<IPublicHolidayProvider>(() => new CubaProvider(_catholicProvider))},
                { CountryCode.CY, new Lazy<IPublicHolidayProvider>(() => new CyprusProvider(_orthodoxProvider))},
                { CountryCode.CZ, new Lazy<IPublicHolidayProvider>(() => new CzechRepublicProvider(_catholicProvider))},
                { CountryCode.DE, new Lazy<IPublicHolidayProvider>(() => new GermanyProvider(_catholicProvider))},
                { CountryCode.DK, new Lazy<IPublicHolidayProvider>(() => new DenmarkProvider(_catholicProvider))},
                { CountryCode.DO, new Lazy<IPublicHolidayProvider>(() => new DominicanRepublicProvider(_catholicProvider))},
                { CountryCode.EC, new Lazy<IPublicHolidayProvider>(() => new EcuadorProvider(_catholicProvider))},
                { CountryCode.EE, new Lazy<IPublicHolidayProvider>(() => new EstoniaProvider(_catholicProvider))},
                { CountryCode.EG, new Lazy<IPublicHolidayProvider>(() => new EgyptProvider())},
                { CountryCode.ES, new Lazy<IPublicHolidayProvider>(() => new SpainProvider(_catholicProvider))},
                { CountryCode.FI, new Lazy<IPublicHolidayProvider>(() => new FinlandProvider(_catholicProvider))},
                { CountryCode.FO, new Lazy<IPublicHolidayProvider>(() => new FaroeIslandsProvider(_catholicProvider))},
                { CountryCode.FR, new Lazy<IPublicHolidayProvider>(() => new FranceProvider(_catholicProvider))},
                { CountryCode.GA, new Lazy<IPublicHolidayProvider>(() => new GabonProvider(_catholicProvider))},
                { CountryCode.GB, new Lazy<IPublicHolidayProvider>(() => new UnitedKingdomProvider(_catholicProvider))},
                { CountryCode.GD, new Lazy<IPublicHolidayProvider>(() => new GrenadaProvider(_catholicProvider))},
                { CountryCode.GI, new Lazy<IPublicHolidayProvider>(() => new GibraltarProvider(_catholicProvider))},
                { CountryCode.GL, new Lazy<IPublicHolidayProvider>(() => new GreenlandProvider(_catholicProvider))},
                { CountryCode.GM, new Lazy<IPublicHolidayProvider>(() => new GambiaProvider(_catholicProvider))},
                { CountryCode.GR, new Lazy<IPublicHolidayProvider>(() => new GreeceProvider(_orthodoxProvider))},
                { CountryCode.GT, new Lazy<IPublicHolidayProvider>(() => new GuatemalaProvider(_catholicProvider))},
                { CountryCode.GG, new Lazy<IPublicHolidayProvider>(() => new GuernseyProvider(_catholicProvider))},
                { CountryCode.GY, new Lazy<IPublicHolidayProvider>(() => new GuyanaProvider(_catholicProvider))},
                { CountryCode.HN, new Lazy<IPublicHolidayProvider>(() => new HondurasProvider(_catholicProvider))},
                { CountryCode.HR, new Lazy<IPublicHolidayProvider>(() => new CroatiaProvider(_catholicProvider))},
                { CountryCode.HT, new Lazy<IPublicHolidayProvider>(() => new HaitiProvider(_catholicProvider))},
                { CountryCode.HU, new Lazy<IPublicHolidayProvider>(() => new HungaryProvider(_catholicProvider))},
                { CountryCode.IE, new Lazy<IPublicHolidayProvider>(() => new IrelandProvider(_catholicProvider))},
                { CountryCode.ID, new Lazy<IPublicHolidayProvider>(() => new IndonesiaProvider(_catholicProvider))},
                { CountryCode.IM, new Lazy<IPublicHolidayProvider>(() => new IsleOfManProvider(_catholicProvider))},
                { CountryCode.IS, new Lazy<IPublicHolidayProvider>(() => new IcelandProvider(_catholicProvider))},
                { CountryCode.IT, new Lazy<IPublicHolidayProvider>(() => new ItalyProvider(_catholicProvider))},
                { CountryCode.LI, new Lazy<IPublicHolidayProvider>(() => new LiechtensteinProvider(_catholicProvider))},
                { CountryCode.LS, new Lazy<IPublicHolidayProvider>(() => new LesothoProvider(_catholicProvider))},
                { CountryCode.LT, new Lazy<IPublicHolidayProvider>(() => new LithuaniaProvider(_catholicProvider))},
                { CountryCode.LU, new Lazy<IPublicHolidayProvider>(() => new LuxembourgProvider(_catholicProvider))},
                { CountryCode.LV, new Lazy<IPublicHolidayProvider>(() => new LatviaProvider(_catholicProvider))},
                { CountryCode.JE, new Lazy<IPublicHolidayProvider>(() => new JerseyProvider(_catholicProvider))},
                { CountryCode.JM, new Lazy<IPublicHolidayProvider>(() => new JamaicaProvider(_catholicProvider))},
                { CountryCode.JP, new Lazy<IPublicHolidayProvider>(() => new JapanProvider())},
                { CountryCode.KR, new Lazy<IPublicHolidayProvider>(() => new SouthKoreaProvider())},
                { CountryCode.MA, new Lazy<IPublicHolidayProvider>(() => new MoroccoProvider())},
                { CountryCode.MC, new Lazy<IPublicHolidayProvider>(() => new MonacoProvider(_catholicProvider))},
                { CountryCode.MD, new Lazy<IPublicHolidayProvider>(() => new MoldovaProvider(_orthodoxProvider))},
                { CountryCode.ME, new Lazy<IPublicHolidayProvider>(() => new MontenegroProvider(_orthodoxProvider, _catholicProvider))},
                { CountryCode.MG, new Lazy<IPublicHolidayProvider>(() => new MadagascarProvider(_catholicProvider))},
                { CountryCode.MK, new Lazy<IPublicHolidayProvider>(() => new MacedoniaProvider(_orthodoxProvider))},
                { CountryCode.MN, new Lazy<IPublicHolidayProvider>(() => new MongoliaProvider())},
                { CountryCode.MS, new Lazy<IPublicHolidayProvider>(() => new MontserratProvider(_catholicProvider))},
                { CountryCode.MT, new Lazy<IPublicHolidayProvider>(() => new MaltaProvider(_catholicProvider))},
                { CountryCode.MX, new Lazy<IPublicHolidayProvider>(() => new MexicoProvider())},
                { CountryCode.MZ, new Lazy<IPublicHolidayProvider>(() => new MozambiqueProvider())},
                { CountryCode.NA, new Lazy<IPublicHolidayProvider>(() => new NamibiaProvider(_catholicProvider))},
                { CountryCode.NE, new Lazy<IPublicHolidayProvider>(() => new NigerProvider(_catholicProvider))},
                { CountryCode.NG, new Lazy<IPublicHolidayProvider>(() => new NigeriaProvider(_catholicProvider)) },
                { CountryCode.NI, new Lazy<IPublicHolidayProvider>(() => new NicaraguaProvider(_catholicProvider))},
                { CountryCode.NL, new Lazy<IPublicHolidayProvider>(() => new NetherlandsProvider(_catholicProvider))},
                { CountryCode.NO, new Lazy<IPublicHolidayProvider>(() => new NorwayProvider(_catholicProvider))},
                { CountryCode.NZ, new Lazy<IPublicHolidayProvider>(() => new NewZealandProvider(_catholicProvider))},
                { CountryCode.PA, new Lazy<IPublicHolidayProvider>(() => new PanamaProvider(_catholicProvider))},
                { CountryCode.PE, new Lazy<IPublicHolidayProvider>(() => new PeruProvider(_catholicProvider))},
                { CountryCode.PG, new Lazy<IPublicHolidayProvider>(() => new PapuaNewGuineaProvider(_catholicProvider))},
                { CountryCode.PL, new Lazy<IPublicHolidayProvider>(() => new PolandProvider(_catholicProvider))},
                { CountryCode.PR, new Lazy<IPublicHolidayProvider>(() => new PuertoRicoProvider(_catholicProvider))},
                { CountryCode.PT, new Lazy<IPublicHolidayProvider>(() => new PortugalProvider(_catholicProvider))},
                { CountryCode.PY, new Lazy<IPublicHolidayProvider>(() => new ParaguayProvider(_catholicProvider))},
                { CountryCode.RO, new Lazy<IPublicHolidayProvider>(() => new RomaniaProvider(_orthodoxProvider))},
                { CountryCode.RS, new Lazy<IPublicHolidayProvider>(() => new SerbiaProvider(_orthodoxProvider))},
                { CountryCode.RU, new Lazy<IPublicHolidayProvider>(() => new RussiaProvider())},
                { CountryCode.SE, new Lazy<IPublicHolidayProvider>(() => new SwedenProvider(_catholicProvider))},
                { CountryCode.SG, new Lazy<IPublicHolidayProvider>(() => new SingaporeProvider(_catholicProvider))},
                { CountryCode.SI, new Lazy<IPublicHolidayProvider>(() => new SloveniaProvider(_catholicProvider))},
                { CountryCode.SJ, new Lazy<IPublicHolidayProvider>(() => new SvalbardAndJanMayenProvider(_catholicProvider))},
                { CountryCode.SK, new Lazy<IPublicHolidayProvider>(() => new SlovakiaProvider(_catholicProvider))},
                { CountryCode.SM, new Lazy<IPublicHolidayProvider>(() => new SanMarinoProvider(_catholicProvider))},
                { CountryCode.SR, new Lazy<IPublicHolidayProvider>(() => new SurinameProvider(_catholicProvider))},
                { CountryCode.SV, new Lazy<IPublicHolidayProvider>(() => new ElSalvadorProvider(_catholicProvider))},
                { CountryCode.TN, new Lazy<IPublicHolidayProvider>(() => new TunisiaProvider())},
                { CountryCode.TR, new Lazy<IPublicHolidayProvider>(() => new TurkeyProvider())},
                { CountryCode.UA, new Lazy<IPublicHolidayProvider>(() => new UkraineProvider(_orthodoxProvider))},
                { CountryCode.US, new Lazy<IPublicHolidayProvider>(() => new UnitedStatesProvider(_catholicProvider))},
                { CountryCode.UY, new Lazy<IPublicHolidayProvider>(() => new UruguayProvider(_catholicProvider))},
                { CountryCode.VA, new Lazy<IPublicHolidayProvider>(() => new VaticanCityProvider(_catholicProvider))},
                { CountryCode.VE, new Lazy<IPublicHolidayProvider>(() => new VenezuelaProvider(_catholicProvider))},
                { CountryCode.VN, new Lazy<IPublicHolidayProvider>(() => new VietnamProvider())},
                //Not officially assigned https://www.iso.org/obp/ui/#iso:pub:PUB500001:en
                //{ CountryCode.XK, new Lazy<IPublicHolidayProvider>(() => new KosovoProvider(_orthodoxProvider, _catholicProvider))},
                { CountryCode.ZA, new Lazy<IPublicHolidayProvider>(() => new SouthAfricaProvider(_catholicProvider))},
                { CountryCode.ZW, new Lazy<IPublicHolidayProvider>(() => new ZimbabweProvider(_catholicProvider))}
            };

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
                { CountryCode.YE, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) },
            };

        /// <summary>
        /// GetPublicHolidayProvider
        /// </summary>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Public holiday provider for given country</returns>
        /// <exception cref="System.ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static IPublicHolidayProvider GetPublicHolidayProvider(string countryCode)
        {
            if (!ParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return GetPublicHolidayProvider(parsedCountryCode);
        }

        /// <summary>
        /// GetPublicHolidayProvider
        /// </summary>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Public holiday provider for given country</returns>
        public static IPublicHolidayProvider GetPublicHolidayProvider(CountryCode countryCode)
        {
            if (_publicHolidaysProviders.TryGetValue(countryCode, out var provider))
            {
                return provider.Value;
            }

            return NoHolidaysProvider.Instance;
        }

        /// <summary>
        /// GetWeekendProvider
        /// </summary>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Specialized weekend provider for country if exists, universal weekend provider otherwise</returns>
        /// <exception cref="System.ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static IWeekendProvider GetWeekendProvider(string countryCode)
        {
            if (!ParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return GetWeekendProvider(parsedCountryCode);
        }

        /// <summary>
        /// GetWeekendProvider
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
        /// Parse given string to CountryCode
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="parsedCountryCode"></param>
        /// <returns>
        /// True for existing country code, false for non existent.
        /// Parsed country code is returned in out parameter.
        /// </returns>
        public static bool ParseCountryCode(string countryCode, out CountryCode parsedCountryCode)
        {
            return Enum.TryParse(countryCode, true, out parsedCountryCode) && Enum.IsDefined(typeof(CountryCode), parsedCountryCode);
        }

        #region Public Holidays for a given year

        /// <summary>
        /// Get Public Holidays of a given year
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Set of public holidays for given country and year</returns>
        /// <exception cref="System.ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static IEnumerable<PublicHoliday> GetPublicHolidays(int year, string countryCode)
        {
            if (!ParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return GetPublicHolidays(year, parsedCountryCode);
        }

        /// <summary>
        /// Get Public Holidays of a given year
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Set of public holidays for given country and year</returns>
        public static IEnumerable<PublicHoliday> GetPublicHolidays(int year, CountryCode countryCode)
        {
            var provider = GetPublicHolidayProvider(countryCode);
            return provider.Get(year);
        }

        #endregion

        #region Public Holidays for a date range

        /// <summary>
        /// Get Public Holidays of a given date range
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Set of public holidays for given country and date range</returns>
        /// <exception cref="System.ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static IEnumerable<PublicHoliday> GetPublicHolidays(DateTime startDate, DateTime endDate, string countryCode)
        {
            if (!ParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return GetPublicHolidays(startDate, endDate, parsedCountryCode);
        }

        /// <summary>
        /// Get Public Holidays of a given date range
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Set of public holidays for given country and date range</returns>
        /// <exception cref="System.ArgumentException">Thrown when given end date is before given start date</exception>
        public static IEnumerable<PublicHoliday> GetPublicHolidays(DateTime startDate, DateTime endDate, CountryCode countryCode)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException($"{nameof(endDate)} is before {nameof(startDate)}", nameof(endDate));
            }

            var currentYear = startDate.Year;
            var endYear = endDate.Year;

            while (currentYear <= endYear)
            {
                var items = GetPublicHolidays(currentYear, countryCode);
                foreach (var item in items)
                {
                    if (item.Date.Date >= startDate.Date && item.Date.Date <= endDate.Date)
                    {
                        yield return item;
                    }
                }
                currentYear++;
            }
        }

        /// <summary>
        /// Get Worldwide Public Holidays of a given date range
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <returns>Set of public holidays for date range</returns>
        public static IEnumerable<PublicHoliday> GetPublicHolidays(DateTime startDate, DateTime endDate)
        {
            var items = new List<PublicHoliday>();

            foreach (var publicHolidayProvider in _publicHolidaysProviders.Keys)
            {
                items.AddRange(GetPublicHolidays(startDate, endDate, publicHolidayProvider));
            }

            return items;
        }

        #endregion

        #region Check if a date is a Public Holiday

        private static Func<PublicHoliday, bool> GetPublicHolidayFilter(DateTime date, string countyCode = null)
        {
            return o => o.Date == date.Date
                        && (o.Counties == null || countyCode != null && o.Counties.Contains(countyCode))
                        && (o.LaunchYear == null || date.Year >= o.LaunchYear)
                        && o.Type.HasFlag(PublicHolidayType.Public);
        }

        /// <summary>
        /// Check is a given date a Public Holiday
        /// </summary>
        /// <param name="date">The date</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>True if given date is public holiday in given country, false otherwise</returns>
        /// <exception cref="System.ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static bool IsPublicHoliday(DateTime date, string countryCode)
        {
            if (!ParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return IsPublicHoliday(date, parsedCountryCode);
        }

        /// <summary>
        /// Check is a given date a Public Holiday
        /// </summary>
        /// <param name="date">The date</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>True if given date is public holiday in given country, false otherwise</returns>
        public static bool IsPublicHoliday(DateTime date, CountryCode countryCode)
        {
            var items = GetPublicHolidays(date.Year, countryCode);
            return items.Any(GetPublicHolidayFilter(date));
        }

        /// <summary>
        /// Check is a given date a Public Holiday
        /// </summary>
        /// <param name="date">The date</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <param name="publicHolidays">if available the public holidays on this date</param>
        /// <returns>
        /// True if given date is public holiday in given country, false otherwise.
        /// Set of public holidays for given day is returned in out parameter.
        /// </returns>
        public static bool IsPublicHoliday(DateTime date, CountryCode countryCode, out PublicHoliday[] publicHolidays)
        {
            var items = GetPublicHolidays(date.Year, countryCode);
            publicHolidays = items.Where(GetPublicHolidayFilter(date)).ToArray();
            return publicHolidays.Any();
        }

        /// <summary>
        /// Check is a given date a Public Holiday
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <param name="countyCode">Federal state</param>
        /// <returns>True if given date is public holiday in given country and county, false otherwise</returns>
        /// <exception cref="System.ArgumentException">Thrown when given county code is not recognized valid</exception>
        public static bool IsPublicHoliday(DateTime date, CountryCode countryCode, string countyCode)
        {
            var provider = GetPublicHolidayProvider(countryCode);
            if (provider is ICountyProvider countryProvider && !countryProvider.GetCounties().ContainsKey(countyCode))
            {
                throw new ArgumentException($"Invalid countyCode {countyCode}");
            }

            var items = GetPublicHolidays(date.Year, countryCode);
            return items.Any(GetPublicHolidayFilter(date, countyCode));
        }

        #endregion

        #region Check a date is a Weekend

        /// <summary>
        /// Check is a give date in the Weekend
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>True if given date is weekend in given country, false otherwise</returns>
        /// <exception cref="System.ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static bool IsWeekend(DateTime date, string countryCode)
        {
            if (!ParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return IsWeekend(date, parsedCountryCode);
        }

        /// <summary>
        /// Check is a give date in the Weekend
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>True if given date is weekend in given country, false otherwise</returns>
        public static bool IsWeekend(DateTime date, CountryCode countryCode)
        {
            var provider = GetWeekendProvider(countryCode);
            return provider.IsWeekend(date);
        }

        #endregion

        #region Day Finding

        /// <summary>
        /// Find the latest weekday for example monday in a month
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The name of the day</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindLastDay(int year, Month month, DayOfWeek day)
        {
            return FindLastDay(year, (int)month, day);
        }

        /// <summary>
        /// Find the latest weekday for example monday in a month
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The name of the day</param>
        /// <returns>Date of day found</returns>
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
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day</param>
        /// <param name="dayOfWeek">The name of the day</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindDay(int year, Month month, int day, DayOfWeek dayOfWeek)
        {
            return FindDay(year, (int)month, day, dayOfWeek);
        }

        /// <summary>
        /// Find the next weekday for example monday from a specific date
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day</param>
        /// <param name="dayOfWeek">The name of the day</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindDay(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            return FindDay(new DateTime(year, month, day), dayOfWeek);
        }

        /// <summary>
        /// Find the next weekday for example monday from a specific date
        /// </summary>
        /// <param name="date">The search date</param>
        /// <param name="dayOfWeek">The name of the day</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindDay(DateTime date, DayOfWeek dayOfWeek)
        {
            var daysNeeded = (int)dayOfWeek - (int)date.DayOfWeek;

            if ((int)dayOfWeek >= (int)date.DayOfWeek)
            {
                return date.AddDays(daysNeeded);
            }

            return date.AddDays(daysNeeded + 7);
        }

        /// <summary>
        /// Find a day between two dates
        /// </summary>
        /// <param name="yearStart">The start year</param>
        /// <param name="monthStart">The start month</param>
        /// <param name="dayStart">The start day</param>
        /// <param name="yearEnd">The end year</param>
        /// <param name="monthEnd">The end month</param>
        /// <param name="dayEnd">The end day</param>
        /// <param name="dayOfWeek">The name of the day</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindDayBetween(int yearStart, int monthStart, int dayStart, int yearEnd, int monthEnd, int dayEnd, DayOfWeek dayOfWeek)
        {
            var startDay = new DateTime(yearStart, monthStart, dayStart);
            var endDay = new DateTime(yearEnd, monthEnd, dayEnd);
            var diff = endDay - startDay;
            var days = diff.Days;
            for (var i = 0; i <= days; i++)
            {
                var specificDayDate = startDay.AddDays(i);
                if (specificDayDate.DayOfWeek == dayOfWeek)
                {
                    return specificDayDate;
                }

            }
            return startDay;
        }

        /// <summary>
        /// Find a day between two dates
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <param name="dayOfWeek">The name of the day</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindDayBetween(DateTime startDate, DateTime endDate, DayOfWeek dayOfWeek)
        {
            return FindDayBetween(startDate.Year, startDate.Month, startDate.Day, endDate.Year, endDate.Month, endDate.Day, dayOfWeek);
        }

        /// <summary>
        /// Find the next weekday for example monday before a specific date
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day</param>
        /// <param name="dayOfWeek">The name of the day</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindDayBefore(int year, Month month, int day, DayOfWeek dayOfWeek)
        {
            return FindDayBefore(year, (int)month, day, dayOfWeek);
        }

        /// <summary>
        /// Find the next weekday for example monday before a specific date
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day</param>
        /// <param name="dayOfWeek">The name of the day</param>
        /// <returns>Date of day found</returns>
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
        /// <param name="date">The date where the search starts</param>
        /// <param name="dayOfWeek">The name of the day</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindDayBefore(DateTime date, DayOfWeek dayOfWeek)
        {
            return FindDayBefore(date.Year, date.Month, date.Day, dayOfWeek);
        }

        /// <summary>
        /// Find for example the 3rd monday in a month
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day</param>
        /// <param name="occurrence"></param>
        /// <returns>Date of day found</returns>
        /// <exception cref="System.ArgumentException">Thrown when given occurrence number is either too low or too high</exception>
        public static DateTime FindDay(int year, int month, DayOfWeek day, int occurrence)
        {
            if (occurrence == 0 || occurrence > 5)
            {
                throw new ArgumentException("Occurance is invalid", nameof(occurrence));
            }

            var firstDayOfMonth = new DateTime(year, month, 1);

            //Substract first day of the month with the required day of the week
            var daysNeeded = (int)day - (int)firstDayOfMonth.DayOfWeek;

            //if it is less than zero we need to get the next week day (add 7 days)
            if (daysNeeded < 0)
            {
                daysNeeded += 7;
            }

            //DayOfWeek is zero index based; multiply by the Occurance to get the day
            var resultedDay = (daysNeeded + 1) + (7 * (occurrence - 1));

            if (resultedDay > DateTime.DaysInMonth(year, month))
            {
                return DateTime.MinValue;
            }

            return new DateTime(year, month, resultedDay);
        }

        /// <summary>
        /// Find for example the 3rd monday in a month
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day</param>
        /// <param name="occurrence">The occurrence e.g. First</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindDay(int year, Month month, DayOfWeek day, Occurrence occurrence)
        {
            return FindDay(year, (int)month, day, (int)occurrence);
        }

        #endregion

        #region Long Weekends

        /// <summary>
        /// Get long weekends of a country and a given year
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Set of long weekends for given country in a given year</returns>
        public static IEnumerable<LongWeekend> GetLongWeekend(int year, CountryCode countryCode)
        {
            var calculator = new LongWeekendCalculator(GetWeekendProvider(countryCode));
            return calculator.Calculate(GetPublicHolidays(year, countryCode));
        }

        #endregion
    }
}
