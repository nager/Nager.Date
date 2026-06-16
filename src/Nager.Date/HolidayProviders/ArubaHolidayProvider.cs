using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Aruba HolidayProvider
    /// </summary>
    internal sealed class ArubaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Aruba HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ArubaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.AW)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var kingsDayObservedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(-1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nieuwjaarsdag",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "nld", "Nieuwjaarsdag" },
                        { "pap", "Aña Nobo" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "BETICOCROESDAY-01",
                    Date = new DateTime(year, 1, 25),
                    EnglishName = "Betico Croes Day",
                    LocalName = "Dag van Betico Croes",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "nld", "Dag van Betico Croes" },
                        { "pap", "Dia di Betico Croes" },
                    },
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
                    Id = "FLAGDAY-01",
                    Date = new DateTime(year, 3, 18),
                    EnglishName = "National Anthem and Flag Day",
                    LocalName = "Dag van het Volkslied en de Vlag",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "nld", "Dag van het Volkslied en de Vlag" },
                        { "pap", "Dia di Himno y Bandera" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "KINGSDAY-01",
                    Date = new DateTime(year, 4, 27),
                    EnglishName = "King's Day",
                    LocalName = "Koningsdag",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = kingsDayObservedRuleSet,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "nld", "Koningsdag" },
                        { "pap", "Dia di Rey" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Dag van de Arbeid",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "nld", "Dag van de Arbeid" },
                        { "pap", "Dia di Labor" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Eerste Kerstdag",
                    HolidayTypes = HolidayTypes.Public,
                    AdditionalTranslations = new Dictionary<string, string>
                    {
                        { "nld", "Eerste Kerstdag" },
                        { "pap", "Pasco di Nacemento" },
                    },
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Tweede Kerstdag",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Goede Vrijdag", year),
                this._catholicProvider.EasterSunday("Eerste Paasdag", year),
                this._catholicProvider.EasterMonday("Tweede Paasedag", year),
                this._catholicProvider.AscensionDay("Hemelvaartsdag", year),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Aruba",
            ];
        }
    }
}
