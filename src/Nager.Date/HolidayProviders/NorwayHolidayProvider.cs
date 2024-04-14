using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Norway HolidayProvider
    /// </summary>
    internal sealed class NorwayHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Norway HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NorwayHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.NO)
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
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Første nyttårsdag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Første mai",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 17),
                    EnglishName = "Constitution Day",
                    LocalName = "Syttende mai",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Første juledag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Andre juledag",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.MaundyThursday("Skjærtorsdag", year),
                this._catholicProvider.GoodFriday("Langfredag", year),
                this._catholicProvider.EasterSunday("Første påskedag", year),
                this._catholicProvider.EasterMonday("Andre påskedag", year),
                this._catholicProvider.AscensionDay("Kristi himmelfartsdag", year),
                this._catholicProvider.Pentecost("Første pinsedag", year),
                this._catholicProvider.WhitMonday("Andre pinsedag", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Norway"
            ];
        }
    }
}
