using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Montenegro HolidayProvider
    /// </summary>
    internal class MontenegroHolidayProvider : IHolidayProvider
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
            ICatholicProvider catholicProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            //TODO
            //Muslim holidays
            //Jewish holidays

            var countryCode = CountryCode.ME;

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



            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);



            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Nova godina", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 2, "Nova godina", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Praznik rada", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 2, "Praznik rada", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 21, "Dan nezavisnosti", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 5, 22, "Dan nezavisnosti", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 7, 13, "Dan državnosti", "Statehood Day", countryCode));
            //items.Add(new Holiday(year, 7, 14, "Dan državnosti", "Statehood Day", countryCode));

            //#region Orthodox holidays

            //items.Add(new Holiday(year, 1, 6, "Badnji dan", "Orthodox Christmas Eve", countryCode, null, null, HolidayTypes.Optional));
            //items.Add(new Holiday(year, 1, 7, "Božić", "Orthodox Christmas Day", countryCode, null, null, HolidayTypes.Optional));
            //items.Add(new Holiday(year, 1, 8, "Božić", "Orthodox Christmas Day", countryCode, null, null, HolidayTypes.Optional));
            //items.Add(this._orthodoxProvider.GoodFriday("Vaskrs", year, countryCode).SetType(HolidayTypes.Optional));
            //items.Add(this._orthodoxProvider.EasterMonday("Vaskrs", year, countryCode).SetType(HolidayTypes.Optional));

            //#endregion

            #region Catholic holidays

            //items.Add(this._catholicProvider.GoodFriday("Veliki petak", year, countryCode).SetType(HolidayTypes.Optional));
            //items.Add(this._catholicProvider.EasterSunday("Uskrs", year, countryCode).SetType(HolidayTypes.Optional));
            //items.Add(this._catholicProvider.EasterMonday("Uskrs", year, countryCode).SetType(HolidayTypes.Optional));
            //items.Add(new Holiday(year, 11, 1, "Svi Sveti", "Catholic All Saints' Day", countryCode, null, null, HolidayTypes.Optional));
            //items.Add(new Holiday(year, 12, 24, "Badnji dan", "Catholic Christmas Eve", countryCode, null, null, HolidayTypes.Optional));
            //items.Add(new Holiday(year, 12, 25, "Božić", "Catholic Christmas Day", countryCode, null, null, HolidayTypes.Optional));
            //items.Add(new Holiday(year, 12, 26, "Božić", "Catholic St. Stephen's Day", countryCode, null, null, HolidayTypes.Optional));

            #endregion

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Montenegro"
            };
        }
    }
}
