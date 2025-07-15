using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Italy HolidayProvider
    /// </summary>
    internal sealed class ItalyHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Italy HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ItalyHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.IT)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "IT-65", "Abruzzo" },
                { "IT-77", "Basilicata" },
                { "IT-78", "Calabria" },
                { "IT-72", "Campania" },
                { "IT-45", "Emilia-Romagna" },
                { "IT-36", "Friuli-Venezia Giulia" },
                { "IT-62", "Lazio" },
                { "IT-42", "Liguria" },
                { "IT-25", "Lombardia" },
                { "IT-57", "Marche" },
                { "IT-67", "Molise" },
                { "IT-21", "Piemonte" },
                { "IT-75", "Puglia" },
                { "IT-88", "Sardegna" },
                { "IT-82", "Sicilia" },
                { "IT-52", "Toscana" },
                { "IT-32", "Trentino-Alto Adige/Südtirol" },
                { "IT-55", "Umbria" },
                { "IT-23", "Valle d’Aosta/Vallée d’Aoste" },
                { "IT-34", "Veneto" }
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Capodanno",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Epifania",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 25),
                    EnglishName = "Liberation Day",
                    LocalName = "Festa della Liberazione",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers Day",
                    LocalName = "Festa del Lavoro",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 2),
                    EnglishName = "Republic Day",
                    LocalName = "Festa della Repubblica",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Ferragosto o Assunzione",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "Tutti i santi",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Immacolata Concezione",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Natale",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Santo Stefano",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("Pasqua", year),
                this._catholicProvider.EasterMonday("Lunedì dell'Angelo", year),
                this._catholicProvider.WhitMonday("Lunedì di Pentecoste", year).SetSubdivisionCodes("IT-32"),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Italy",
            ];
        }
    }
}
