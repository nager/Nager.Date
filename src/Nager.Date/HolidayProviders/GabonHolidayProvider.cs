using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Gabon HolidayProvider
    /// </summary>
    internal sealed class GabonHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Gabon HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GabonHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.GA)
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
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 12),
                    EnglishName = "Renovation Day",
                    LocalName = "Renovation Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 17),
                    EnglishName = "Women's Day",
                    LocalName = "Women's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 6),
                    EnglishName = "Martyr's Day",
                    LocalName = "Martyr's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Assumption Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 17),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "All Saints' Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Božić",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.WhitMonday("Whit Monday", year)
            };

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 3, 12, "Renovation Day", "Renovation Day", countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            //items.Add(new Holiday(year, 4, 17, "Women's Day", "Women's Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 6, "Martyr's Day", "Martyr's Day", countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode));
            //items.Add(new Holiday(year, 8, 15, "Assumption Day", "Assumption Day", countryCode));
            //items.Add(new Holiday(year, 8, 17, "Independence Day", "Independence Day", countryCode));
            //items.Add(new PublicHoliday(year, 8, 8, "Eid al-Fitr", "End of Ramadan", countryCode));
            //items.Add(new Holiday(year, 11, 1, "All Saints' Day", "All Saints' Day", countryCode));
            //items.Add(new PublicHoliday(year, 10, 15, "Eid al-Adha", "Feast of the Sacrifice", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Božić", "Christmas Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Gabon",
            ];
        }
    }
}
