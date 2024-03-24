using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Luxembourg HolidayProvider
    /// </summary>
    internal sealed class LuxembourgHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Luxembourg HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public LuxembourgHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.LU)
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
                    LocalName = "Neijoerschdag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Dag vun der Aarbecht",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Europe Day",
                    LocalName = "Europadag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 23),
                    EnglishName = "Sovereign's birthday",
                    LocalName = "Groussherzogsgebuertsdag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Léiffrawëschdag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Allerhellgen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Chrëschtdag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Stiefesdag",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterMonday("Ouschterméindeg", year),
                this._catholicProvider.GoodFriday("Karfreideg", year).SetHolidayTypes(HolidayTypes.Bank),
                this._catholicProvider.AscensionDay("Christi Himmelfaart", year),
                this._catholicProvider.WhitMonday("Péngschtméindeg", year)
            };

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Neijoerschdag", "New Year's Day", countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Ouschterméindeg", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Dag vun der Aarbecht", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 9, "Europadag", "Europe Day", countryCode, 2019));
            //items.Add(this._catholicProvider.GoodFriday("Karfreideg", year, countryCode).SetType(HolidayTypes.Bank));
            //items.Add(this._catholicProvider.AscensionDay("Christi Himmelfaart", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Péngschtméindeg", year, countryCode));
            //items.Add(new Holiday(year, 6, 23, "Groussherzogsgebuertsdag", "Sovereign's birthday", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Léiffrawëschdag", "Assumption Day", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Allerhellgen", "All Saints' Day", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Chrëschtdag", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Stiefesdag", "St. Stephen's Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Luxembourg"
            ];
        }
    }
}
