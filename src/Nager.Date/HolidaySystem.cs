using Nager.Date.Helpers;
using Nager.Date.HolidayProviders;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using Nager.LicenseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Nager.Date
{
    /// <summary>
    /// Holiday System
    /// </summary>
    public static class HolidaySystem
    {
        private const string CountryCodeParsingError = "Country code {0} is not valid according to ISO 3166-1 ALPHA-2";

        private static readonly ICatholicProvider _catholicProvider = new CatholicProvider();
        private static readonly IOrthodoxProvider _orthodoxProvider = new OrthodoxProvider();

        private static readonly Dictionary<CountryCode, Lazy<IHolidayProvider>> _holidaysProviders =
            new Dictionary<CountryCode, Lazy<IHolidayProvider>>
            {
                { CountryCode.AD, new Lazy<IHolidayProvider>(() => new AndorraHolidayProvider(_catholicProvider))},
                { CountryCode.AL, new Lazy<IHolidayProvider>(() => new AlbaniaHolidayProvider(_catholicProvider, _orthodoxProvider))},
                { CountryCode.AM, new Lazy<IHolidayProvider>(() => new ArmeniaHolidayProvider(_catholicProvider))},
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
                { CountryCode.GE, new Lazy<IHolidayProvider>(() => new GeorgiaHolidayProvider(_orthodoxProvider))},
                { CountryCode.GI, new Lazy<IHolidayProvider>(() => new GibraltarHolidayProvider(_catholicProvider))},
                { CountryCode.GL, new Lazy<IHolidayProvider>(() => new GreenlandHolidayProvider(_catholicProvider))},
                { CountryCode.GM, new Lazy<IHolidayProvider>(() => new GambiaHolidayProvider(_catholicProvider))},
                { CountryCode.GR, new Lazy<IHolidayProvider>(() => new GreeceHolidayProvider(_orthodoxProvider))},
                { CountryCode.GT, new Lazy<IHolidayProvider>(() => new GuatemalaHolidayProvider(_catholicProvider))},
                { CountryCode.GG, new Lazy<IHolidayProvider>(() => new GuernseyHolidayProvider(_catholicProvider))},
                { CountryCode.GY, new Lazy<IHolidayProvider>(() => new GuyanaHolidayProvider(_catholicProvider))},
                { CountryCode.HK, new Lazy<IHolidayProvider>(() => new HongKongHolidayProvider(_catholicProvider))},
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
                { CountryCode.KZ, new Lazy<IHolidayProvider>(() => new KazakhstanHolidayProvider(_orthodoxProvider))},
                { CountryCode.MA, new Lazy<IHolidayProvider>(() => new MoroccoHolidayProvider())},
                { CountryCode.MC, new Lazy<IHolidayProvider>(() => new MonacoHolidayProvider(_catholicProvider))},
                { CountryCode.MD, new Lazy<IHolidayProvider>(() => new MoldovaHolidayProvider(_orthodoxProvider))},
                { CountryCode.ME, new Lazy<IHolidayProvider>(() => new MontenegroHolidayProvider(_orthodoxProvider, _catholicProvider))},
                { CountryCode.MG, new Lazy<IHolidayProvider>(() => new MadagascarHolidayProvider(_catholicProvider))},
                { CountryCode.MK, new Lazy<IHolidayProvider>(() => new MacedoniaHolidayProvider(_orthodoxProvider))},
                { CountryCode.MN, new Lazy<IHolidayProvider>(() => new MongoliaHolidayProvider())},
                { CountryCode.MS, new Lazy<IHolidayProvider>(() => new MontserratHolidayProvider(_catholicProvider))},
                { CountryCode.MT, new Lazy<IHolidayProvider>(() => new MaltaHolidayProvider(_catholicProvider))},
                { CountryCode.MX, new Lazy<IHolidayProvider>(() => new MexicoHolidayProvider(_catholicProvider))},
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

        private static bool? _licenseValid;

        /// <summary>
        /// License Key
        /// </summary>
        /// <remarks>
        /// As a GitHub sponsor of <see href="https://github.com/nager">nager</see>, you will receive a <see href="https://github.com/sponsors/nager">license key</see>
        /// </remarks>
        public static string? LicenseKey = null;

        private static void CheckLicense(string? licenseKey)
        {
            if (string.IsNullOrEmpty(licenseKey))
            {
                _licenseValid = false;
                throw new LicenseKeyException("No LicenseKey");
            }

            var licenseInfo = LicenseHelper.CheckLicenseKey(licenseKey);
            if (licenseInfo is null)
            {
                _licenseValid = false;
                throw new LicenseKeyException("Invalid LicenseKey");
            }

            if (licenseInfo.ValidUntil < DateTime.Today)
            {
                _licenseValid = false;
                throw new LicenseKeyException("Expried LicenseKey");
            }

            _licenseValid = true;
        }

        /// <summary>
        /// Get the holiday provider for the specified country
        /// </summary>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Holiday provider for given country</returns>
        /// <exception cref="ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static IHolidayProvider GetHolidayProvider(string countryCode)
        {
            if (!CountryCodeHelper.TryParseCountryCode(countryCode, out var parsedCountryCode))
            {
                throw new ArgumentException(string.Format(CountryCodeParsingError, countryCode));
            }

            TryGetHolidayProvider(parsedCountryCode, out var holidayProvider);
            return holidayProvider;
        }

        /// <summary>
        /// Get the holiday provider for the specified country
        /// </summary>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Holiday provider for given country</returns>
        public static IHolidayProvider GetHolidayProvider(CountryCode countryCode)
        {
            TryGetHolidayProvider(countryCode, out var holidayProvider);
            return holidayProvider;
        }

        /// <summary>
        /// Try get the holiday provider for the specified country
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="holidayProvider"></param>
        /// <returns></returns>
        public static bool TryGetHolidayProvider(CountryCode countryCode, out IHolidayProvider holidayProvider)
        {
            if (_licenseValid is null)
            {
                CheckLicense(LicenseKey);
            }

            if (_licenseValid is not null && !_licenseValid.Value)
            {
                holidayProvider = NoHolidaysHolidayProvider.Instance;
                return false;
            }

            if (_holidaysProviders.TryGetValue(countryCode, out var provider))
            {
                holidayProvider = provider.Value;
                return true;
            }

            holidayProvider = NoHolidaysHolidayProvider.Instance;
            return false;
        }

        #region Holidays for a given year

        /// <summary>
        /// Get holidays of a given year
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>Set of holidays for given country and year</returns>
        /// <exception cref="ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static IEnumerable<Holiday> GetHolidays(int year, string countryCode)
        {
            if (!CountryCodeHelper.TryParseCountryCode(countryCode, out var parsedCountryCode))
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
        /// <exception cref="ArgumentException">Thrown when the provided country code is not recognized as valid</exception>
        public static IEnumerable<Holiday> GetHolidays(DateTime startDate, DateTime endDate, string countryCode)
        {
            if (!CountryCodeHelper.TryParseCountryCode(countryCode, out var parsedCountryCode))
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
        /// <exception cref="ArgumentException">Thrown when given end date is before given start date</exception>
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

            foreach (var publicHolidayProvider in _holidaysProviders.Keys)
            {
                items.AddRange(GetHolidays(startDate, endDate, publicHolidayProvider));
            }

            return items;
        }

        #endregion

        #region Check if a date is a Public Holiday

        private static Func<Holiday, bool> GetHolidayFilter(
            DateTime date,
            HolidayTypes holidayTypes,
            string? subdivisionCodes = null)
        {
            return o => o.ObservedDate == date.Date
                        && (o.SubdivisionCodes is null || subdivisionCodes is not null && o.SubdivisionCodes.Contains(subdivisionCodes))
                        && o.HolidayTypes.HasFlag(holidayTypes);
        }

        /// <summary>
        /// Check is a given date a Public Holiday
        /// </summary>
        /// <param name="date">The date</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <returns>True if given date is public holiday in given country, false otherwise</returns>
        /// <exception cref="ArgumentException">Thrown when given country code is not recognized valid</exception>
        public static bool IsPublicHoliday(DateTime date, string countryCode)
        {
            if (!CountryCodeHelper.TryParseCountryCode(countryCode, out var parsedCountryCode))
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
            return items.Any(GetHolidayFilter(date, HolidayTypes.Public));
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
            publicHolidays = items.Where(GetHolidayFilter(date, HolidayTypes.Public)).ToArray();
            return publicHolidays.Any();
        }

        /// <summary>
        /// Check is a given date a Public Holiday
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <param name="subdivisionCode">Subdivision code of a country</param>
        /// <returns>True if given date is public holiday in given country and county, false otherwise</returns>
        /// <exception cref="ArgumentException">Thrown when given county code is not recognized valid</exception>
        public static bool IsPublicHoliday(DateTime date, CountryCode countryCode, string subdivisionCode)
        {
            if (subdivisionCode is null)
            {
                throw new ArgumentException($"{nameof(subdivisionCode)} is null");
            }

            var provider = GetHolidayProvider(countryCode);
            if (provider is ISubdivisionCodesProvider countryProvider && !countryProvider.GetSubdivisionCodes().ContainsKey(subdivisionCode))
            {
                throw new ArgumentException($"Invalid {nameof(subdivisionCode)} {subdivisionCode}");
            }

            var items = GetHolidays(date.Year, countryCode);
            return items.Any(GetHolidayFilter(date, HolidayTypes.Public, subdivisionCode));
        }

        #endregion

        #region Check if a date is a Holiday

        /// <summary>
        /// Check is a given date a Holiday
        /// </summary>
        /// <param name="date">The date</param>
        /// <param name="countryCode">Country Code (ISO 3166-1 ALPHA-2)</param>
        /// <param name="holidayTypes">The holiday type</param>
        /// <param name="publicHolidays">if available the public holidays on this date</param>
        /// <returns>
        /// True if given date is holiday in given country, false otherwise.
        /// Set of holidays for given day is returned in out parameter.
        /// </returns>
        public static bool IsHoliday(
            DateTime date,
            CountryCode countryCode,
            HolidayTypes holidayTypes,
            out Holiday[] publicHolidays)
        {
            var items = GetHolidays(date.Year, countryCode);
            publicHolidays = items.Where(GetHolidayFilter(date, holidayTypes)).ToArray();
            return publicHolidays.Any();
        }

        #endregion
    }
}
