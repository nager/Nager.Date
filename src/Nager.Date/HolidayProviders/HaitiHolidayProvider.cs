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
