using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Burkina Faso HolidayProvider
    /// </summary>
    internal sealed class BurkinaFasoHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Burkina Faso HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BurkinaFasoHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.BF)
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
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "REVOLUTIONDAY-01",
                    Date = new DateTime(year, 1, 3),
                    EnglishName = "Revolution Day",
                    LocalName = "Revolution Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women’s Day",
                    LocalName = "International Women’s Day",
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
                    Id = "DAYOFCUSTOMSANDTRADITIONS-01",
                    Date = new DateTime(year, 5, 15),
                    EnglishName = "Day of Customs and Traditions",
                    LocalName = "Day of Customs and Traditions",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 8, 5),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ASSUMPTIONDAY-01",
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Assumption Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MARTYRSDAY-01",
                    Date = new DateTime(year, 10, 31),
                    EnglishName = "Martyrs' Day",
                    LocalName = "Martyrs' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "All Saints' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PROCLAMATIONOFINDEPENDENCEDAY-01",
                    Date = new DateTime(year, 12, 11),
                    EnglishName = "Proclamation of Independence Day",
                    LocalName = "Proclamation of Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.AscensionDay("Ascension Day", year),
            };

            //TODO: Add Islamic holidays

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Burkina_Faso",
            ];
        }
    }
}
