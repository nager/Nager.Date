using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Belize HolidayProvider
    /// </summary>
    internal sealed class BelizeHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Belize HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BelizeHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.BZ)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var saturday2MondayObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2)
            };

            var mondayObservedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(-2),
                Thursday = date => date.AddDays(-3),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 9),
                    EnglishName = "Baron Bliss Day",
                    LocalName = "Baron Bliss Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 24),
                    EnglishName = "Commonwealth Day",
                    LocalName = "Commonwealth Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 10),
                    EnglishName = "Saint George's Caye Day",
                    LocalName = "Saint George's Caye Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 21),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Day of the Americas",
                    LocalName = "Day of the Americas",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 19),
                    EnglishName = "Garifuna Settlement Day",
                    LocalName = "Garifuna Settlement Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = saturday2MondayObservedRuleSet
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterSaturday("Holy Saturday", year),
                this._catholicProvider.EasterSunday("Easter Sunday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Belize"
            ];
        }
    }
}
