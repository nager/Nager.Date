using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Nigeria HolidayProvider
    /// </summary>
    internal sealed class NigeriaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Niger HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NigeriaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.NG)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {

            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1)
            };

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
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Workers' Day",
                    LocalName = "Workers' Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 27),
                    EnglishName = "Children's Day",
                    LocalName = "Children's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 12),
                    EnglishName = "Democracy Day",
                    LocalName = "Democracy Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "National Day",
                    LocalName = "National Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "National Youth Day",
                    LocalName = "National Youth Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            return holidaySpecifications;

            //TODO: Add islamic public holidays

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Workers' Day", "Workers' Day", countryCode).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1)));
            //items.Add(new Holiday(year, 5, 27, "Children's Day", "Children's Day", countryCode));
            //items.Add(new Holiday(year, 6, 12, "Democracy Day", "Democracy Day", countryCode));
            //items.Add(new Holiday(year, 10, 1, "National Day", "National Day", countryCode));
            //items.Add(new Holiday(year, 11, 1, "National Youth Day", "National Youth Day", countryCode, 2020));
            //items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1)));
            //items.Add(new Holiday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2)));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Nigeria",
                "https://www.officeholidays.com/countries/nigeria/"
            ];
        }
    }
}
