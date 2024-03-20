using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Haiti HolidayProvider
    /// </summary>
    internal sealed class HaitiHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Haiti HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public HaitiHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.HT)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Jour de l'an",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "Ancestry Day",
                    LocalName = "Jour des Aieux",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Le Jour des Rois",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour and Agriculture Day",
                    LocalName = "Fête du Travail / Fête des Travailleurs",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 18),
                    EnglishName = "Flag and Universities Day",
                    LocalName = "Jour du Drapeau et de l'Université",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption of Mary",
                    LocalName = "L'Assomption de Marie",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 17),
                    EnglishName = "Dessalines Day",
                    LocalName = "Anniversaire de la mort de Dessalines",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "La Toussaint",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "All Souls' Day",
                    LocalName = "Jour des Morts",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 18),
                    EnglishName = "Battle of Vertières Day",
                    LocalName = "Vertières",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 5),
                    EnglishName = "Discovery Day",
                    LocalName = "Découverte d'Haïti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Noël",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-47),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-46),
                    EnglishName = "Ash Wednesday",
                    LocalName = "Mercredi Des Cendres",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.MaundyThursday("Jeudi saint", year),
                this._catholicProvider.GoodFriday("Vendredi saint", year),
                this._catholicProvider.EasterSunday("Pâques", year),
                this._catholicProvider.AscensionDay("Ascension", year),
                this._catholicProvider.CorpusChristi("Fête-Dieu", year)
            };

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Jour de l'an", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 2, "Jour des Aieux", "Ancestry Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Le Jour des Rois", "Epiphany", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-48), "Carnaval", "Carnival", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-47), "Carnaval", "Carnival", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-46), "Mercredi Des Cendres", "Ash Wednesday", countryCode));
            //items.Add(this._catholicProvider.MaundyThursday("Jeudi saint", year, countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Vendredi saint", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Pâques", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Fête du Travail / Fête des Travailleurs", "Labour and Agriculture Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Ascension", year, countryCode));
            //items.Add(this._catholicProvider.CorpusChristi("Fête-Dieu", year, countryCode));
            //items.Add(new Holiday(year, 5, 18, "Jour du Drapeau et de l'Université", "Flag and Universities Day", countryCode));
            //items.Add(new Holiday(year, 8, 15, "L'Assomption de Marie", "Assumption of Mary", countryCode));
            //items.Add(new Holiday(year, 10, 17, "Anniversaire de la mort de Dessalines", "Dessalines Day", countryCode));
            //items.Add(new Holiday(year, 11, 1, "La Toussaint", "All Saints Day", countryCode));
            //items.Add(new Holiday(year, 11, 2, "Jour des Morts", "All Souls' Day", countryCode));
            //items.Add(new Holiday(year, 11, 18, "Vertières", "Battle of Vertières Day", countryCode));
            //items.Add(new Holiday(year, 12, 5, "Découverte d'Haïti", "Discovery Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Noël", "Christmas Day", countryCode));          

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Haiti",
            ];
        }
    }
}
