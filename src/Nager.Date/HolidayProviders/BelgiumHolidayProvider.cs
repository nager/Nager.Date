using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Belgium HolidayProvider
    /// </summary>
    internal sealed class BelgiumHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Belgium HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BelgiumHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.BE)
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
                    LocalName = "Nieuwjaar",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Dag van de arbeid",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 21),
                    EnglishName = "Belgian National Day",
                    LocalName = "Nationale feestdag",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Onze Lieve Vrouw hemelvaart",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Allerheiligen",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Armistice Day",
                    LocalName = "Wapenstilstand",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Kerstdag",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Bank,
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(40),
                    EnglishName = "Day after Ascension Day",
                    LocalName = "Day after Ascension Day",
                    HolidayTypes = HolidayTypes.Bank,
                },
                this._catholicProvider.GoodFriday("Goede Vrijdag", year).SetHolidayTypes(HolidayTypes.Bank),
                this._catholicProvider.EasterSunday("Pasen", year),
                this._catholicProvider.EasterMonday("Paasmaandag", year),
                this._catholicProvider.AscensionDay("Onze Lieve Heer hemel", year),
                this._catholicProvider.WhitMonday("Pinkstermaandag", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Belgium",
                "https://www.nbb.be/en/about-national-bank/national-bank-belgium/public-holidays",
                "https://www.bnpparibasfortis.be/public/nl/public/particulieren/sluitingsdagen"
            ];
        }
    }
}
