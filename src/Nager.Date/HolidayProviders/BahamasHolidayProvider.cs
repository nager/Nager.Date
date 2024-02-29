using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bahamas HolidayProvider
    /// </summary>
    internal class BahamasHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Bahamas HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BahamasHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BS;

            var observedRuleSet = new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(2),
                Thursday = date => date.AddDays(1),
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 10),
                    EnglishName = "Majority Rule Day",
                    LocalName = "Majority Rule Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 1),
                    EnglishName = "Perry Christie Day",
                    LocalName = "Perry Christie Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 10),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 5),
                    EnglishName = "Emancipation Day",
                    LocalName = "Emancipation Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "National Heroes' Day",
                    LocalName = "National Heroes' Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Good Friday", year, observedRuleSet),
                this._catholicProvider.EasterMonday("Easter Monday", year, observedRuleSet),
                this._catholicProvider.WhitMonday("Whit Monday", year, observedRuleSet)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode)));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 1, 10, "Majority Rule Day", "Majority Rule Day", countryCode)));
            //items.Add(this.ApplyShiftingRules(this._catholicProvider.GoodFriday("Good Friday", year, countryCode)));
            //items.Add(this.ApplyShiftingRules(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode)));
            //items.Add(this.ApplyShiftingRules(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode)));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 4, 1, "Perry Christie Day", "Perry Christie Day", countryCode)));
            //items.Add(new Holiday(year, 7, 10, "Independence Day", "Independence Day", countryCode));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 8, 5, "Emancipation Day", "Emancipation Day", countryCode)));
            //items.Add(this.ApplyShiftingRules(new Holiday(year, 10, 12, "National Heroes' Day", "National Heroes' Day", countryCode)));
            //items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        //private Holiday ApplyShiftingRules(Holiday holiday)
        //{

        //    var t = new ObservedRuleSet
        //    {
        //        Tuesday = date => date.AddDays(-1),
        //        Wednesday = date => date.AddDays(2),
        //        Thursday = date => date.AddDays(1),
        //        Saturday = date => date.AddDays(2),
        //        Sunday = date => date.AddDays(1),
        //    };

        //    return holiday
        //        .Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1))
        //        .ShiftWeekdays(tuesday: tuesday => tuesday.AddDays(-1), wednesday: wednesday => wednesday.AddDays(2), thursday: thursday => thursday.AddDays(1));
        //}

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Bahamas"
            };
        }
    }
}
