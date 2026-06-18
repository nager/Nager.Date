using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Saint Martin HolidayProvider
    /// </summary>
    internal sealed class SaintMartinHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Saint Martin HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SaintMartinHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.MF)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Jour de l'An",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Fête du Travail",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "VICTORYDAY-01",
                    Date = new DateTime(year, 5, 8),
                    EnglishName = "Victory Day",
                    LocalName = "Fête de la Victoire 1945",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY-01",
                    Date = new DateTime(year, 7, 14),
                    EnglishName = "National Day",
                    LocalName = "Fête Nationale",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Toussaint",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ARMISTICEDAY-01",
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Armistice Day",
                    LocalName = "Armistice",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Noël",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.EasterMonday("Lundi de Pâques", year),
                this._catholicProvider.AscensionDay("Ascension", year),
                this._catholicProvider.WhitMonday("Lundi de Pentecôte", year),
            };

            holidaySpecifications.AddIfNotNull(this.AbolitionDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? AbolitionDay(
            int year)
        {
            if (year >= 2018)
            {
                return new HolidaySpecification
                {
                    Id = "ABOLITIONDAY-01",
                    Date = new DateTime(year, 5, 28),
                    EnglishName = "Abolition Day",
                    LocalName = "Abolition de l'Esclavage",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Collectivity_of_Saint_Martin",
            ];
        }
    }
}
