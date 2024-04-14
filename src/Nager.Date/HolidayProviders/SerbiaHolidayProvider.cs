using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Serbia HolidayProvider
    /// </summary>
    internal sealed class SerbiaHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Serbia HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public SerbiaHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.RS)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var observedRuleSet1 = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            // observedRuleSet1 take a sunday shift to monday then shift this holiday to tuesay
            var observedRuleSet2 = new ObservedRuleSet
            {
                Monday = monday => monday.AddDays(1),
                Sunday = date => date.AddDays(1)
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nova Godina",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "Nova Godina",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet2
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Christmas Day",
                    LocalName = "Božić",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 15),
                    EnglishName = "Statehood Day",
                    LocalName = "Dan državnosti Srbije",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 16),
                    EnglishName = "Statehood Day",
                    LocalName = "Dan državnosti Srbije",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet2
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Praznik rada",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 2),
                    EnglishName = "Labour Day",
                    LocalName = "Praznik rada",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet2
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Armistice Day",
                    LocalName = "Dan primirja",
                    HolidayTypes = HolidayTypes.Public
                },
                this._orthodoxProvider.GoodFriday("Veliki petak", year),
                this._orthodoxProvider.EasterSunday("Vaskrs (Uskrs)", year),
                this._orthodoxProvider.EasterMonday("Vaskrsni (Uskrsni) ponedeljak", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Serbia"
            ];
        }
    }
}
