using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Curaçao HolidayProvider
    /// </summary>
    internal sealed class CuracaoHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Curaçao HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CuracaoHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.CW)
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
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nieuwjaarsdag",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CARNIVAL-01",
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Carnival Monday",
                    LocalName = "Carnaval Maandag",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "nld", "Carnaval Maandag" },
                        { "pap", "Dialuna Carnaval" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "KINGSDAY-01",
                    Date = new DateTime(year, 4, 27),
                    EnglishName = "King's Day",
                    LocalName = "Koningsdag",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CURACAONATIONALFLAGDAY-01",
                    Date = new DateTime(year, 7, 2),
                    EnglishName = "Curaçao National Flag and Anthem Day",
                    LocalName = "Curaçao Nationale Vlag en Volkslied Dag",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Kerstmis",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Tweede kerstdag",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSEVE-01",
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Oudejaarsavond",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Goede Vrijdag", year),
                this._catholicProvider.EasterSunday("Pasen", year),
                this._catholicProvider.EasterMonday("Pasenmaandag", year),
                this._catholicProvider.AscensionDay("Hemelvaartsdag", year),
                this._catholicProvider.Pentecost("Pinksteren", year),
            };

            holidaySpecifications.AddIfNotNull(this.CuracaoDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? CuracaoDay(
            int year)
        {
            if (year >= 2010)
            {
                return new HolidaySpecification
                {
                    Id = "CURACAODAY-01",
                    Date = new DateTime(year, 10, 10),
                    EnglishName = "Curaçao Day",
                    LocalName = "Dag van Curaçao",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Cura%C3%A7ao",
            ];
        }
    }
}
