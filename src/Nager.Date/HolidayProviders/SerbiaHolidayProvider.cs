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

            //var newYearsDay1 = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            //var newYearsDay2 = new DateTime(year, 1, 2).Shift(saturday => saturday, sunday => sunday.AddDays(1), monday => monday.AddDays(1));

            //var statehoodDay1 = new DateTime(year, 2, 15).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            //var statehoodDay2 = new DateTime(year, 2, 16).Shift(saturday => saturday, sunday => sunday.AddDays(1), monday => monday.AddDays(1));

            //var labourDay1 = new DateTime(year, 5, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            //var labourDay2 = new DateTime(year, 5, 2).Shift(saturday => saturday, sunday => sunday.AddDays(1), monday => monday.AddDays(1));

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

            //var items = new List<Holiday>();
            //items.Add(new Holiday(newYearsDay1, "Nova Godina", "New Year's Day", countryCode));
            //items.Add(new Holiday(newYearsDay2, "Nova Godina", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 7, "Božić", "Christmas Day", countryCode));
            //items.Add(new Holiday(statehoodDay1, "Dan državnosti Srbije", "Statehood Day", countryCode));
            //items.Add(new Holiday(statehoodDay2, "Dan državnosti Srbije", "Statehood Day", countryCode));
            //items.Add(this._orthodoxProvider.GoodFriday("Veliki petak", year, countryCode));
            //items.Add(this._orthodoxProvider.EasterSunday("Vaskrs (Uskrs)", year, countryCode));
            //items.Add(this._orthodoxProvider.EasterMonday("Vaskrsni (Uskrsni) ponedeljak", year, countryCode));
            //items.Add(new Holiday(labourDay1, "Praznik rada", "Labour Day", countryCode));
            //items.Add(new Holiday(labourDay2, "Praznik rada", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 11, 11, "Dan primirja", "Armistice Day", countryCode));
            //return items.OrderBy(o => o.Date);
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
