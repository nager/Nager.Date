using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Montenegro HolidayProvider
    /// </summary>
    internal sealed class MontenegroHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Montenegro HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider">OrthodoxProvider</param>
        /// <param name="catholicProvider">CatholicProvider</param>
        public MontenegroHolidayProvider(
            IOrthodoxProvider orthodoxProvider,
            ICatholicProvider catholicProvider) : base(CountryCode.ME)
        {
            this._orthodoxProvider = orthodoxProvider;
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO
            //Muslim holidays
            //Jewish holidays

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nova godina",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "Nova godina",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Praznik rada",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 2),
                    EnglishName = "Labour Day",
                    LocalName = "Praznik rada",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 21),
                    EnglishName = "Independence Day",
                    LocalName = "Dan nezavisnosti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 22),
                    EnglishName = "Independence Day",
                    LocalName = "Dan nezavisnosti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 13),
                    EnglishName = "Statehood Day",
                    LocalName = "Dan državnosti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 14),
                    EnglishName = "Statehood Day",
                    LocalName = "Dan državnosti",
                    HolidayTypes = HolidayTypes.Public
                },

                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "Catholic All Saints' Day",
                    LocalName = "Svi Sveti",
                    HolidayTypes = HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Catholic Christmas Eve",
                    LocalName = "Badnji dan",
                    HolidayTypes = HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Catholic Christmas Day",
                    LocalName = "Božić",
                    HolidayTypes = HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Catholic St. Stephen's Day",
                    LocalName = "Božić",
                    HolidayTypes = HolidayTypes.Optional
                },
                this._catholicProvider.GoodFriday("Veliki petak", year).SetHolidayTypes(HolidayTypes.Optional),
                this._catholicProvider.EasterSunday("Uskrs", year).SetHolidayTypes(HolidayTypes.Optional),
                this._catholicProvider.EasterMonday("Uskrs", year).SetHolidayTypes(HolidayTypes.Optional),

                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Orthodox Christmas Eve",
                    LocalName = "Badnji dan",
                    HolidayTypes = HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Orthodox Christmas Day",
                    LocalName = "Božić",
                    HolidayTypes = HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 8),
                    EnglishName = "Orthodox Christmas Day",
                    LocalName = "Božić",
                    HolidayTypes = HolidayTypes.Optional
                },
                this._orthodoxProvider.GoodFriday("Vaskrs", year).SetHolidayTypes(HolidayTypes.Optional),
                this._orthodoxProvider.EasterMonday("Vaskrs", year).SetHolidayTypes(HolidayTypes.Optional),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Montenegro"
            ];
        }
    }
}
