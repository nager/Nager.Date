using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// France
    /// </summary>
    internal class FranceProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// FranceProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public FranceProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "FR-ARA", "Auvergne-Rhone-Alpes" },
                { "FR-BFC", "Bourgogne-Franche-Comte" },
                { "FR-BRE", "Bretagne" },
                { "FR-CVL", "Centre-Val de Loire" },
                { "FR-20R", "Corse" },
                { "FR-GES", "Grand-Est" },
                { "FR-HDF", "Hauts-de-France" },
                { "FR-IDF", "Ile-de-France" },
                { "FR-NOR", "Normandie" },
                { "FR-NAQ", "Nouvelle-Aquitaine" },
                { "FR-OCC", "Occitanie" },
                { "FR-PDL", "Pays-de-la-Loire" },
                { "FR-PAC", "Provence-Alpes-Cote-d'Azur" },
            };
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.FR;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Jour de l'an", "New Year's Day", countryCode, 1967));
            items.Add(this._catholicProvider.EasterMonday("Lundi de Pâques", year, countryCode).SetLaunchYear(1642));
            items.Add(new Holiday(year, 5, 1, "Fête du Travail", "Labour Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Ascension", year, countryCode));
            items.Add(new Holiday(year, 5, 8, "Victoire 1945", "Victory in Europe Day", countryCode));
            items.Add(this._catholicProvider.WhitMonday("Lundi de Pentecôte", year, countryCode));
            items.Add(new Holiday(year, 7, 14, "Fête nationale", "Bastille Day", countryCode));
            items.Add(new Holiday(year, 8, 15, "Assomption", "Assumption Day", countryCode));
            items.Add(new Holiday(year, 11, 1, "Toussaint", "All Saints' Day", countryCode));
            items.Add(new Holiday(year, 11, 11, "Armistice 1918", "Armistice Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Noël", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_France",
                "https://en.wikipedia.org/wiki/ISO_3166-2:FR",
                "https://ec.europa.eu/taxation_customs/dds2/rd/publicholidays_consultation.jsp?Screen=0&Expand=true&Country=FR"
            };
        }
    }
}
