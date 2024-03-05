using Nager.Date.HolidayProviders;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using Nager.Date.WeekendProviders;
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

        private static readonly Dictionary<CountryCode, Lazy<IHolidayProvider>> _publicHolidaysProviders =
            new Dictionary<CountryCode, Lazy<IHolidayProvider>>
            {
                { CountryCode.AD, new Lazy<IHolidayProvider>(() => new AndorraHolidayProvider(_catholicProvider))},
                { CountryCode.AL, new Lazy<IHolidayProvider>(() => new AlbaniaHolidayProvider(_catholicProvider, _orthodoxProvider))},
                { CountryCode.AR, new Lazy<IHolidayProvider>(() => new ArgentinaHolidayProvider(_catholicProvider))},
                { CountryCode.AT, new Lazy<IHolidayProvider>(() => new AustriaHolidayProvider(_catholicProvider))},
                { CountryCode.AU, new Lazy<IHolidayProvider>(() => new AustraliaHolidayProvider(_catholicProvider))},
                { CountryCode.AX, new Lazy<IHolidayProvider>(() => new AlandHolidayProvider(_catholicProvider))},
                { CountryCode.BA, new Lazy<IHolidayProvider>(() => new BosniaAndHerzegovinaHolidayProvider(_orthodoxProvider))},
                { CountryCode.BB, new Lazy<IHolidayProvider>(() => new BarbadosHolidayProvider(_catholicProvider))},
                { CountryCode.BE, new Lazy<IHolidayProvider>(() => new BelgiumHolidayProvider(_catholicProvider))},
                { CountryCode.BG, new Lazy<IHolidayProvider>(() => new BulgariaHolidayProvider(_orthodoxProvider))},
                { CountryCode.BJ, new Lazy<IHolidayProvider>(() => new BeninHolidayProvider(_catholicProvider))},
                { CountryCode.BO, new Lazy<IHolidayProvider>(() => new BoliviaHolidayProvider(_catholicProvider))},
                { CountryCode.BR, new Lazy<IHolidayProvider>(() => new BrazilHolidayProvider(_catholicProvider))},
                { CountryCode.BS, new Lazy<IHolidayProvider>(() => new BahamasHolidayProvider(_catholicProvider))},
                { CountryCode.BW, new Lazy<IHolidayProvider>(() => new BotswanaHolidayProvider(_catholicProvider))},
                { CountryCode.BY, new Lazy<IHolidayProvider>(() => new BelarusHolidayProvider(_orthodoxProvider))},
                { CountryCode.BZ, new Lazy<IHolidayProvider>(() => new BelizeHolidayProvider(_catholicProvider))},
                { CountryCode.CA, new Lazy<IHolidayProvider>(() => new CanadaHolidayProvider(_catholicProvider))},
                { CountryCode.CH, new Lazy<IHolidayProvider>(() => new SwitzerlandHolidayProvider(_catholicProvider))},
                { CountryCode.CL, new Lazy<IHolidayProvider>(() => new ChileHolidayProvider(_catholicProvider))},
                { CountryCode.CN, new Lazy<IHolidayProvider>(() => new ChinaHolidayProvider())},
                { CountryCode.CO, new Lazy<IHolidayProvider>(() => new ColombiaHolidayProvider(_catholicProvider))},
                { CountryCode.CR, new Lazy<IHolidayProvider>(() => new CostaRicaHolidayProvider(_catholicProvider))},
                { CountryCode.CU, new Lazy<IHolidayProvider>(() => new CubaHolidayProvider(_catholicProvider))},
                { CountryCode.CY, new Lazy<IHolidayProvider>(() => new CyprusHolidayProvider(_orthodoxProvider))},
                { CountryCode.CZ, new Lazy<IHolidayProvider>(() => new CzechRepublicHolidayProvider(_catholicProvider))},
                { CountryCode.DE, new Lazy<IHolidayProvider>(() => new GermanyHolidayProvider(_catholicProvider))},
                { CountryCode.DK, new Lazy<IHolidayProvider>(() => new DenmarkHolidayProvider(_catholicProvider))},
                { CountryCode.DO, new Lazy<IHolidayProvider>(() => new DominicanRepublicHolidayProvider(_catholicProvider))},
                { CountryCode.EC, new Lazy<IHolidayProvider>(() => new EcuadorHolidayProvider(_catholicProvider))},
                { CountryCode.EE, new Lazy<IHolidayProvider>(() => new EstoniaHolidayProvider(_catholicProvider))},
                { CountryCode.EG, new Lazy<IHolidayProvider>(() => new EgyptHolidayProvider())},
                { CountryCode.ES, new Lazy<IHolidayProvider>(() => new SpainHolidayProvider(_catholicProvider))},
                { CountryCode.FI, new Lazy<IHolidayProvider>(() => new FinlandHolidayProvider(_catholicProvider))},
                { CountryCode.FO, new Lazy<IHolidayProvider>(() => new FaroeIslandsHolidayProvider(_catholicProvider))},
                { CountryCode.FR, new Lazy<IHolidayProvider>(() => new FranceHolidayProvider(_catholicProvider))},
                { CountryCode.GA, new Lazy<IHolidayProvider>(() => new GabonHolidayProvider(_catholicProvider))},
                { CountryCode.GB, new Lazy<IHolidayProvider>(() => new UnitedKingdomHolidayProvider(_catholicProvider))},
                { CountryCode.GD, new Lazy<IHolidayProvider>(() => new GrenadaHolidayProvider(_catholicProvider))},
                { CountryCode.GI, new Lazy<IHolidayProvider>(() => new GibraltarHolidayProvider(_catholicProvider))},
                { CountryCode.GL, new Lazy<IHolidayProvider>(() => new GreenlandHolidayProvider(_catholicProvider))},
                { CountryCode.GM, new Lazy<IHolidayProvider>(() => new GambiaHolidayProvider(_catholicProvider))},
                { CountryCode.GR, new Lazy<IHolidayProvider>(() => new GreeceHolidayProvider(_orthodoxProvider))},
                { CountryCode.GT, new Lazy<IHolidayProvider>(() => new GuatemalaHolidayProvider(_catholicProvider))},
                { CountryCode.GG, new Lazy<IHolidayProvider>(() => new GuernseyHolidayProvider(_catholicProvider))},
                { CountryCode.GY, new Lazy<IHolidayProvider>(() => new GuyanaHolidayProvider(_catholicProvider))},
                { CountryCode.HN, new Lazy<IHolidayProvider>(() => new HondurasHolidayProvider(_catholicProvider))},
                { CountryCode.HR, new Lazy<IHolidayProvider>(() => new CroatiaHolidayProvider(_catholicProvider))},
                { CountryCode.HT, new Lazy<IHolidayProvider>(() => new HaitiHolidayProvider(_catholicProvider))},
                { CountryCode.HU, new Lazy<IHolidayProvider>(() => new HungaryHolidayProvider(_catholicProvider))},
                { CountryCode.IE, new Lazy<IHolidayProvider>(() => new IrelandHolidayProvider(_catholicProvider))},
                { CountryCode.ID, new Lazy<IHolidayProvider>(() => new IndonesiaHolidayProvider(_catholicProvider))},
                { CountryCode.IM, new Lazy<IHolidayProvider>(() => new IsleOfManHolidayProvider(_catholicProvider))},
                { CountryCode.IS, new Lazy<IHolidayProvider>(() => new IcelandHolidayProvider(_catholicProvider))},
                { CountryCode.IT, new Lazy<IHolidayProvider>(() => new ItalyHolidayProvider(_catholicProvider))},
                { CountryCode.LI, new Lazy<IHolidayProvider>(() => new LiechtensteinHolidayProvider(_catholicProvider))},
                { CountryCode.LS, new Lazy<IHolidayProvider>(() => new LesothoHolidayProvider(_catholicProvider))},
                { CountryCode.LT, new Lazy<IHolidayProvider>(() => new LithuaniaHolidayProvider(_catholicProvider))},
                { CountryCode.LU, new Lazy<IHolidayProvider>(() => new LuxembourgHolidayProvider(_catholicProvider))},
                { CountryCode.LV, new Lazy<IHolidayProvider>(() => new LatviaHolidayProvider(_catholicProvider))},
                { CountryCode.JE, new Lazy<IHolidayProvider>(() => new JerseyHolidayProvider(_catholicProvider))},
                { CountryCode.JM, new Lazy<IHolidayProvider>(() => new JamaicaHolidayProvider(_catholicProvider))},
                { CountryCode.JP, new Lazy<IHolidayProvider>(() => new JapanHolidayProvider())},
                { CountryCode.KR, new Lazy<IHolidayProvider>(() => new SouthKoreaHolidayProvider())},
                { CountryCode.MA, new Lazy<IHolidayProvider>(() => new MoroccoHolidayProvider())},
                { CountryCode.MC, new Lazy<IHolidayProvider>(() => new MonacoHolidayProvider(_catholicProvider))},
                { CountryCode.MD, new Lazy<IHolidayProvider>(() => new MoldovaHolidayProvider(_orthodoxProvider))},
                { CountryCode.ME, new Lazy<IHolidayProvider>(() => new MontenegroHolidayProvider(_orthodoxProvider, _catholicProvider))},
                { CountryCode.MG, new Lazy<IHolidayProvider>(() => new MadagascarHolidayProvider(_catholicProvider))},
                { CountryCode.MK, new Lazy<IHolidayProvider>(() => new MacedoniaHolidayProvider(_orthodoxProvider))},
                { CountryCode.MN, new Lazy<IHolidayProvider>(() => new MongoliaHolidayProvider())},
                { CountryCode.MS, new Lazy<IHolidayProvider>(() => new MontserratHolidayProvider(_catholicProvider))},
                { CountryCode.MT, new Lazy<IHolidayProvider>(() => new MaltaHolidayProvider(_catholicProvider))},
                { CountryCode.MX, new Lazy<IHolidayProvider>(() => new MexicoHolidayProvider())},
                { CountryCode.MZ, new Lazy<IHolidayProvider>(() => new MozambiqueHolidayProvider())},
                { CountryCode.NA, new Lazy<IHolidayProvider>(() => new NamibiaHolidayProvider(_catholicProvider))},
                { CountryCode.NE, new Lazy<IHolidayProvider>(() => new NigerHolidayProvider(_catholicProvider))},
                { CountryCode.NG, new Lazy<IHolidayProvider>(() => new NigeriaHolidayProvider(_catholicProvider)) },
                { CountryCode.NI, new Lazy<IHolidayProvider>(() => new NicaraguaHolidayProvider(_catholicProvider))},
                { CountryCode.NL, new Lazy<IHolidayProvider>(() => new NetherlandsHolidayProvider(_catholicProvider))},
                { CountryCode.NO, new Lazy<IHolidayProvider>(() => new NorwayHolidayProvider(_catholicProvider))},
                { CountryCode.NZ, new Lazy<IHolidayProvider>(() => new NewZealandHolidayProvider(_catholicProvider))},
                { CountryCode.PA, new Lazy<IHolidayProvider>(() => new PanamaHolidayProvider(_catholicProvider))},
                { CountryCode.PE, new Lazy<IHolidayProvider>(() => new PeruHolidayProvider(_catholicProvider))},
                { CountryCode.PG, new Lazy<IHolidayProvider>(() => new PapuaNewGuineaHolidayProvider(_catholicProvider))},
                { CountryCode.PL, new Lazy<IHolidayProvider>(() => new PolandHolidayProvider(_catholicProvider))},
                { CountryCode.PR, new Lazy<IHolidayProvider>(() => new PuertoRicoHolidayProvider(_catholicProvider))},
                { CountryCode.PT, new Lazy<IHolidayProvider>(() => new PortugalHolidayProvider(_catholicProvider))},
                { CountryCode.PY, new Lazy<IHolidayProvider>(() => new ParaguayHolidayProvider(_catholicProvider))},
                { CountryCode.RO, new Lazy<IHolidayProvider>(() => new RomaniaHolidayProvider(_orthodoxProvider))},
                { CountryCode.RS, new Lazy<IHolidayProvider>(() => new SerbiaHolidayProvider(_orthodoxProvider))},
                { CountryCode.RU, new Lazy<IHolidayProvider>(() => new RussiaHolidayProvider())},
                { CountryCode.SE, new Lazy<IHolidayProvider>(() => new SwedenHolidayProvider(_catholicProvider))},
                { CountryCode.SG, new Lazy<IHolidayProvider>(() => new SingaporeHolidayProvider(_catholicProvider))},
                { CountryCode.SI, new Lazy<IHolidayProvider>(() => new SloveniaHolidayProvider(_catholicProvider))},
                { CountryCode.SJ, new Lazy<IHolidayProvider>(() => new SvalbardAndJanMayenHolidayProvider(_catholicProvider))},
                { CountryCode.SK, new Lazy<IHolidayProvider>(() => new SlovakiaHolidayProvider(_catholicProvider))},
                { CountryCode.SM, new Lazy<IHolidayProvider>(() => new SanMarinoHolidayProvider(_catholicProvider))},
                { CountryCode.SR, new Lazy<IHolidayProvider>(() => new SurinameHolidayProvider(_catholicProvider))},
                { CountryCode.SV, new Lazy<IHolidayProvider>(() => new ElSalvadorHolidayProvider(_catholicProvider))},
                { CountryCode.TN, new Lazy<IHolidayProvider>(() => new TunisiaHolidayProvider())},
                { CountryCode.TR, new Lazy<IHolidayProvider>(() => new TurkeyHolidayProvider())},
                { CountryCode.UA, new Lazy<IHolidayProvider>(() => new UkraineHolidayProvider(_orthodoxProvider))},
                { CountryCode.US, new Lazy<IHolidayProvider>(() => new UnitedStatesHolidayProvider(_catholicProvider))},
                { CountryCode.UY, new Lazy<IHolidayProvider>(() => new UruguayHolidayProvider(_catholicProvider))},
                { CountryCode.VA, new Lazy<IHolidayProvider>(() => new VaticanCityHolidayProvider(_catholicProvider))},
                { CountryCode.VE, new Lazy<IHolidayProvider>(() => new VenezuelaHolidayProvider(_catholicProvider))},
                { CountryCode.VN, new Lazy<IHolidayProvider>(() => new VietnamHolidayProvider())},
                //Not officially assigned https://www.iso.org/obp/ui/#iso:pub:PUB500001:en
                //{ CountryCode.XK, new Lazy<IPublicHolidayProvider>(() => new KosovoProvider(_orthodoxProvider, _catholicProvider))},
                { CountryCode.ZA, new Lazy<IHolidayProvider>(() => new SouthAfricaHolidayProvider(_catholicProvider))},
                { CountryCode.ZW, new Lazy<IHolidayProvider>(() => new ZimbabweHolidayProvider(_catholicProvider))}
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
                { CountryCode.YE, new Lazy<IWeekendProvider>(() => WeekendProvider.SemiUniversal) }
            };

        /// <summary>
        /// License Key
        /// </summary>
        /// <remarks>
        /// As a GitHub sponsor of <see href="https://github.com/nager">nager</see>, you will receive a <see href="https://github.com/sponsors/nager">license key</see>
        /// </remarks>
        public static string LicenseKey = null;

        /// <summary>
        /// Get the holiday provider for the specified country
        /// </summary>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Holiday provider for given country</returns>
        /// <exception cref="System.ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static IHolidayProvider GetHolidayProvider(string countryCode)
        {
            if (!TryParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return GetHolidayProvider(parsedCountryCode);
        }

        /// <summary>
        /// Get the holiday provider for the specified country
        /// </summary>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Holiday provider for given country</returns>
        public static IHolidayProvider GetHolidayProvider(CountryCode countryCode)
        {
            if (string.IsNullOrEmpty(LicenseKey) ||
                !LicenseKey.Equals("Thank you for supporting open source projects"))
            {
                throw new NoLicenseKeyException();
            }

            if (_publicHolidaysProviders.TryGetValue(countryCode, out var provider))
            {
                return provider.Value;
            }

            return NoHolidaysHolidayProvider.Instance;
        }

        /// <summary>
        /// Get the weekend provider for the specified country
        /// </summary>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Specialized weekend provider for country if exists, universal weekend provider otherwise</returns>
        /// <exception cref="System.ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static IWeekendProvider GetWeekendProvider(string countryCode)
        {
            if (!TryParseCountryCode(countryCode, out var parsedCountryCode))
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
        /// Parse given string to CountryCode
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="parsedCountryCode"></param>
        /// <returns>
        /// True for existing country code, false for non existent.
        /// Parsed country code is returned in out parameter.
        /// </returns>
        public static bool TryParseCountryCode(string countryCode, out CountryCode parsedCountryCode)
        {
            return Enum.TryParse(countryCode, true, out parsedCountryCode) && Enum.IsDefined(typeof(CountryCode), parsedCountryCode);
        }

        #region Holidays for a given year

        /// <summary>
        /// Get holidays of a given year
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Set of holidays for given country and year</returns>
        /// <exception cref="System.ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static IEnumerable<Holiday> GetHolidays(int year, string countryCode)
        {
            if (!TryParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return GetHolidays(year, parsedCountryCode);
        }

        /// <summary>
        /// Get holidays of a given year
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Set of public holidays for given country and year</returns>
        public static IEnumerable<Holiday> GetHolidays(int year, CountryCode countryCode)
        {
            var provider = GetHolidayProvider(countryCode);
            return provider.GetHolidays(year);
        }

        #endregion

        #region Holidays for a date range

        /// <summary>
        /// Get holidays of a given date range for the specified country
        /// </summary>
        /// <param name="startDate">The start date of the range</param>
        /// <param name="endDate">The end date of the range</param>
        /// <param name="countryCode">The country code (ISO 3166-1 ALPHA-2) to retrieve holidays for</param>
        /// <returns>A set of holidays for the specified country and date range</returns>
        /// <exception cref="System.ArgumentException">Thrown when the provided country code is not recognized as valid</exception>
        public static IEnumerable<Holiday> GetHolidays(DateTime startDate, DateTime endDate, string countryCode)
        {
            if (!TryParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            return GetHolidays(startDate, endDate, parsedCountryCode);
        }

        /// <summary>
        /// Get holidays of a given date range for the specified country
        /// </summary>
        /// <param name="startDate">The start date of the range</param>
        /// <param name="endDate">The end date of the range</param>
        /// <param name="countryCode">The country code (ISO 3166-1 ALPHA-2) to retrieve holidays for</param>
        /// <returns>A set of holidays for the specified country and date range</returns>
        /// <exception cref="System.ArgumentException">Thrown when given end date is before given start date</exception>
        public static IEnumerable<Holiday> GetHolidays(DateTime startDate, DateTime endDate, CountryCode countryCode)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException($"{nameof(endDate)} is before {nameof(startDate)}", nameof(endDate));
            }

            var currentYear = startDate.Year;
            var endYear = endDate.Year;

            while (currentYear <= endYear)
            {
                var items = GetHolidays(currentYear, countryCode);
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
        /// Get Worldwide holidays of a given date range
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <returns>Set of holidays for date range</returns>
        public static IEnumerable<Holiday> GetHolidays(DateTime startDate, DateTime endDate)
        {
            var items = new List<Holiday>();

            foreach (var publicHolidayProvider in _publicHolidaysProviders.Keys)
            {
                items.AddRange(GetHolidays(startDate, endDate, publicHolidayProvider));
            }

            return items;
        }

        #endregion

        #region Check if a date is a Public Holiday

        private static Func<Holiday, bool> GetHolidayFilter(DateTime date, string subdivisionCodes = null)
        {
            return o => o.ObservedDate == date.Date
                        && (o.SubdivisionCodes == null || subdivisionCodes != null && o.SubdivisionCodes.Contains(subdivisionCodes))
                        && o.HolidayTypes.HasFlag(HolidayTypes.Public);
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
            if (!TryParseCountryCode(countryCode, out var parsedCountryCode))
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
            var items = GetHolidays(date.Year, countryCode);
            return items.Any(GetHolidayFilter(date));
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
        public static bool IsPublicHoliday(DateTime date, CountryCode countryCode, out Holiday[] publicHolidays)
        {
            var items = GetHolidays(date.Year, countryCode);
            publicHolidays = items.Where(GetHolidayFilter(date)).ToArray();
            return publicHolidays.Any();
        }

        /// <summary>
        /// Check is a given date a Public Holiday
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <param name="subdivisionCode">Subdivision code of a country</param>
        /// <returns>True if given date is public holiday in given country and county, false otherwise</returns>
        /// <exception cref="System.ArgumentException">Thrown when given county code is not recognized valid</exception>
        public static bool IsPublicHoliday(DateTime date, CountryCode countryCode, string subdivisionCode)
        {
            if (subdivisionCode == null)
            {
                throw new ArgumentException($"{nameof(subdivisionCode)} is null");
            }

            var provider = GetHolidayProvider(countryCode);
            if (provider is ISubdivisionCodesProvider countryProvider && !countryProvider.GetSubdivisionCodes().ContainsKey(subdivisionCode))
            {
                throw new ArgumentException($"Invalid {nameof(subdivisionCode)} {subdivisionCode}");
            }

            var items = GetHolidays(date.Year, countryCode);
            return items.Any(GetHolidayFilter(date, subdivisionCode));
        }

        #endregion

        #region Check a date is a Weekend

        /// <summary>
        /// Checks if a given date falls on a weekend in the specified country
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="countryCode">The country code (ISO 3166-1 ALPHA-2) to determine weekend rules</param>
        /// <returns>True if the given date is a weekend in the specified country, false otherwise</returns>
        /// <exception cref="System.ArgumentException">Thrown when the provided country code is not recognized as valid</exception>
        public static bool IsWeekend(DateTime date, string countryCode)
        {
            if (!TryParseCountryCode(countryCode, out var parsedCountryCode))
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
        /// <param name="dayOfWeek">The day of the week</param>
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
        /// <param name="dayOfWeek">The day of the week</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindDay(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            return FindDay(new DateTime(year, month, day), dayOfWeek);
        }

        /// <summary>
        /// Find the next weekday for example monday from a specific date
        /// </summary>
        /// <param name="date">The search date</param>
        /// <param name="dayOfWeek">TThe day of the week</param>
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
        /// <param name="dayOfWeek">The day of the week</param>
        /// <returns>Date of day found</returns>
        public static DateTime? FindDayBetween(int yearStart, int monthStart, int dayStart, int yearEnd, int monthEnd, int dayEnd, DayOfWeek dayOfWeek)
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

            if (startDay.DayOfWeek == dayOfWeek)
            {
                return startDay;
            }

            return null;
        }

        /// <summary>
        /// Find a day between two dates
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <param name="dayOfWeek">The day of the week</param>
        /// <returns>Date of day found</returns>
        public static DateTime? FindDayBetween(DateTime startDate, DateTime endDate, DayOfWeek dayOfWeek)
        {
            return FindDayBetween(startDate.Year, startDate.Month, startDate.Day, endDate.Year, endDate.Month, endDate.Day, dayOfWeek);
        }

        /// <summary>
        /// Find the next weekday for example monday before a specific date
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day</param>
        /// <param name="dayOfWeek">The day of the week</param>
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
        /// <param name="dayOfWeek">The day of the week</param>
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
        /// <param name="dayOfWeek">The day of the week</param>
        /// <returns>Date of day found</returns>
        public static DateTime FindDayBefore(DateTime date, DayOfWeek dayOfWeek)
        {
            return FindDayBefore(date.Year, date.Month, date.Day, dayOfWeek);
        }

        /// <summary>
        /// Finds the date of a specific occurrence of a day within a month, for example, the 3rd Monday
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day of the week</param>
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
        /// Finds the date of a specific occurrence of a day within a month, for example, the 3rd Monday
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day of the week</param>
        /// <param name="occurrence">The occurrence of the day within the month, e.g., First, Second, Third, Fourth</param>
        /// <returns>The date of the found day</returns>
        public static DateTime FindDay(int year, Month month, DayOfWeek day, Occurrence occurrence)
        {
            return FindDay(year, (int)month, day, (int)occurrence);
        }

        #endregion
    }
}
