using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Malta HolidayProvider
    /// </summary>
    internal sealed class MaltaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Malta HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MaltaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.MT)
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
                    LocalName = "L-Ewwel tas-Sena",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 10),
                    EnglishName = "Feast of St. Paul's Shipwreck",
                    LocalName = "In-Nawfraġju ta’ San Pawl",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 19),
                    EnglishName = "Feast of St. Joseph",
                    LocalName = "San Ġużepp",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 31),
                    EnglishName = "Freedom Day",
                    LocalName = "Jum il-Ħelsien",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Worker's Day",
                    LocalName = "Jum il-Ħaddiem",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 7),
                    EnglishName = "Sette Giugno",
                    LocalName = "Sette Giugno",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 29),
                    EnglishName = "Feast of St.Peter and St.Paul",
                    LocalName = "L-Imnarja",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Santa Marija",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 8),
                    EnglishName = "Feast of Our Lady of Victories",
                    LocalName = "Il-Vittorja",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 21),
                    EnglishName = "Independence Day",
                    LocalName = "L-Indipendenza",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Feast of the Immaculate Conception",
                    LocalName = "L-Immakulata Kunċizzjoni",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 13),
                    EnglishName = "Republic Day",
                    LocalName = "Jum ir-Repubblika",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "​Christmas Day",
                    LocalName = "Il-Milied​",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Il-Ġimgħa l-Kbira", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Malta"
            ];
        }
    }
}
