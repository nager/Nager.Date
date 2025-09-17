using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Vatican City HolidayProvider
    /// </summary>
    internal sealed class VaticanCityHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// VaticanCity HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public VaticanCityHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.VA)
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
                    Id = "SOLEMNITYMOTHERGOD-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "Solemnity of Mary, Mother of God",
                    LocalName = "Maria Santissima Madre di Dio",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "EPIPHANY-01",
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Epifania del Signore",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ANNIVERSARYOFTHEFOUNDATION-01",
                    Date = new DateTime(year, 2, 11),
                    EnglishName = "Anniversary of the foundation of Vatican City",
                    LocalName = "Anniversario della istituzione dello Stato della Città del Vaticano",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ANNIVERSARYOFTHEELECTION-01",
                    Date = new DateTime(year, 3, 13),
                    EnglishName = "Anniversary of the election of Pope Francis",
                    LocalName = "Anniversario dell'Elezione del Santo Padre",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "SAINTJOSEPHSDAY-01",
                    Date = new DateTime(year, 3, 19),
                    EnglishName = "Saint Joseph's Day",
                    LocalName = "San Giuseppe",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "SAINTGEORGE-01",
                    Date = new DateTime(year, 4, 23),
                    EnglishName = "Saint George",
                    LocalName = "Onomastico del Santo Padre",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "SAINTJOSEPHWORKER-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Saint Joseph the Worker",
                    LocalName = "San Giuseppe lavoratore",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "SAINTSPETERPAUL-01",
                    Date = new DateTime(year, 6, 29),
                    EnglishName = "Saint Peter and Saint Paul",
                    LocalName = "Santi Pietro e Paolo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ASSUMPTIONDAY-01",
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Assunzione di Maria in Cielo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NATIVITYOFMARY-01",
                    Date = new DateTime(year, 9, 8),
                    EnglishName = "Nativity of Mary",
                    LocalName = "Festa della natività della madonna",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "Tutti i santi, Ognissanti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "IMMACULATECONCEPTION-01",
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Immacolata Concezione",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Natale",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Santo Stefano",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterMonday("Lunedì dell'Angelo", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Vatican_City"
            ];
        }
    }
}
