using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Eswatini HolidayProvider
    /// </summary>
    internal sealed class EswatiniHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Eswatini HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public EswatiniHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.SZ)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var sundayObservedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1),
            };

            var mondayObservedRuleSet = new ObservedRuleSet
            {
                Monday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "KINGSBIRTHDAY-01",
                    Date = new DateTime(year, 4, 19),
                    EnglishName = "King's Birthday",
                    LocalName = "King's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALFLAGDAY-01",
                    Date = new DateTime(year, 4, 25),
                    EnglishName = "National Flag Day",
                    LocalName = "National Flag Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "WORKERSDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Workers' Day",
                    LocalName = "Workers' Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 9, 6),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = mondayObservedRuleSet,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.AscensionDay("Ascension Day", year),
            };

            //TODO: Lutsango Day
            //TODO: Umhlanga (Reed Dance) Day
            //TODO: Incwala Day

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Eswatini",
                "https://www.gov.sz/images/stories/PublicService/Government%20General%20Orders.pdf",
            ];
        }
    }
}
