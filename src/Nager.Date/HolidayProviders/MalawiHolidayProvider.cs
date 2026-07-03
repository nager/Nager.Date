using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Malawi HolidayProvider
    /// </summary>
    internal sealed class MalawiHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Malawi HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MalawiHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.MW)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var weekendObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
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
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "JOHNCHILEMBWEDAY-01",
                    Date = new DateTime(year, 1, 15),
                    EnglishName = "John Chilembwe Day",
                    LocalName = "John Chilembwe Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "MARTYRSDAY-01",
                    Date = new DateTime(year, 3, 3),
                    EnglishName = "Martyrs' Day",
                    LocalName = "Martyrs' Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "PRESIDENTBIRTHDAY-01",
                    Date = new DateTime(year, 5, 14),
                    EnglishName = "President Kamuzu Banda's Birthday",
                    LocalName = "President Kamuzu Banda's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 7, 6),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "MOTHERSDAY-01",
                    Date = new DateTime(year, 10, 15),
                    EnglishName = "Mother's Day",
                    LocalName = "Mother's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
            };

            //TODO: Add Eid al-Fitr

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Malawi",
            ];
        }
    }
}
