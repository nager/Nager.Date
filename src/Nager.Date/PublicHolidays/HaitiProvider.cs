using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Haiti
    /// </summary>
    internal class HaitiProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// HaitiProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public HaitiProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.HT;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Jour de l'an", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Jour des Aieux", "Ancestry Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Le Jour des Rois", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-46), "Mercredi Des Cendres", "Ash Wednesday", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Jeudi saint", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Vendredi saint", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Pâques", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Fête du Travail / Fête des Travailleurs", "Labour and Agriculture Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Ascension", year, countryCode));
            items.Add(this._catholicProvider.CorpusChristi("Fête-Dieu", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 18, "Jour du Drapeau et de l'Université", "Flag and Universities Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "L'Assomption de Marie", "Assumption of Mary", countryCode));
            items.Add(new PublicHoliday(year, 10, 17, "Anniversaire de la mort de Dessalines", "Dessalines Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "La Toussaint", "All Saints Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Jour des Morts", "All Souls' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 18, "Vertières", "Battle of Vertières Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 5, "Découverte d'Haïti", "Discovery Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Noël", "Christmas Day", countryCode));          

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Haiti",
            };
        }
    }
}
