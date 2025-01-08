using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// United States of America HolidayProvider
    /// </summary>
    internal sealed class UnitedStatesHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// United States of America HolidayProvider
        /// </summary>
        public UnitedStatesHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.US)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "US-AL", "Alabama" },
                { "US-AK", "Alaska" },
                { "US-AZ", "Arizona" },
                { "US-AR", "Arkansas" },
                { "US-CA", "California" },
                { "US-CO", "Colorado" },
                { "US-CT", "Connecticut" },
                { "US-DE", "Delaware" },
                { "US-FL", "Florida" },
                { "US-GA", "Georgia" },
                { "US-HI", "Hawaii" },
                { "US-ID", "Idaho" },
                { "US-IL", "Illinois" },
                { "US-IN", "Indiana" },
                { "US-IA", "Iowa" },
                { "US-KS", "Kansas" },
                { "US-KY", "Kentucky" },
                { "US-LA", "Louisiana" },
                { "US-ME", "Maine" },
                { "US-MD", "Maryland" },
                { "US-MA", "Massachusetts" },
                { "US-MI", "Michigan" },
                { "US-MN", "Minnesota" },
                { "US-MS", "Mississippi" },
                { "US-MO", "Missouri" },
                { "US-MT", "Montana" },
                { "US-NE", "Nebraska" },
                { "US-NV", "Nevada" },
                { "US-NH", "New Hampshire" },
                { "US-NJ", "New Jersey" },
                { "US-NM", "New Mexico" },
                { "US-NY", "New York" },
                { "US-NC", "North Carolina" },
                { "US-ND", "North Dakota" },
                { "US-OH", "Ohio" },
                { "US-OK", "Oklahoma" },
                { "US-OR", "Oregon" },
                { "US-PA", "Pennsylvania" },
                { "US-RI", "Rhode Island" },
                { "US-SC", "South Carolina" },
                { "US-SD", "South Dakota" },
                { "US-TN", "Tennessee" },
                { "US-TX", "Texas" },
                { "US-UT", "Utah" },
                { "US-VT", "Vermont" },
                { "US-VA", "Virginia" },
                { "US-WA", "Washington" },
                { "US-WV", "West Virginia" },
                { "US-WI", "Wisconsin" },
                { "US-WY", "Wyoming" }
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var thirdMondayInJanuary = DateHelper.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayInFebruary = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third);
            var lastMondayInMay = DateHelper.FindLastDay(year, Month.May, DayOfWeek.Monday);
            var firstMondayInSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);
            var fourthThursdayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Thursday, Occurrence.Fourth);

            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(-1),
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
                    Date = thirdMondayInJanuary,
                    EnglishName = "Martin Luther King, Jr. Day",
                    LocalName = "Martin Luther King, Jr. Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInFebruary,
                    EnglishName = "Presidents Day",
                    LocalName = "Washington's Birthday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = lastMondayInMay,
                    EnglishName = "Memorial Day",
                    LocalName = "Memorial Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 4),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 8),
                    EnglishName = "Truman Day",
                    LocalName = "Truman Day",
                    HolidayTypes = HolidayTypes.Authorities | HolidayTypes.School,
                    SubdivisionCodes = ["US-MO"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInSeptember,
                    EnglishName = "Labor Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = secondMondayInOctober,
                    EnglishName = "Columbus Day",
                    LocalName = "Columbus Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["US-AL", "US-AZ", "US-CO", "US-CT", "US-GA", "US-ID", "US-IL", "US-IN", "US-IA", "US-KS", "US-KY", "US-LA", "US-ME", "US-MD", "US-MA", "US-MS", "US-MO", "US-MT", "US-NE", "US-NH", "US-NJ", "US-NM", "US-NY", "US-NC", "US-OH", "US-OK", "US-PA", "US-RI", "US-SC", "US-TN", "US-UT", "US-VA", "US-WV"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Veterans Day",
                    LocalName = "Veterans Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = fourthThursdayInNovember,
                    EnglishName = "Thanksgiving Day",
                    LocalName = "Thanksgiving Day",
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
                this._catholicProvider.GoodFriday("Good Friday", year).SetSubdivisionCodes("US-CT", "US-DE", "US-HI", "US-IN", "US-KY", "US-LA", "US-NC", "US-ND", "US-NJ", "US-TN"),
                this._catholicProvider.GoodFriday("Good Friday", year).SetSubdivisionCodes("US-TX").SetHolidayTypes(HolidayTypes.Optional)
            };

            holidaySpecifications.AddIfNotNull(this.JuneteenthNationalIndependenceDay(year, observedRuleSet));
            holidaySpecifications.AddIfNotNull(this.IndigenousPeoplesDay(year));
            holidaySpecifications.AddIfNotNull(this.LincolnsBirthday(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? LincolnsBirthday(int year)
        {
            return new HolidaySpecification
            {
                Date = new DateTime(year, 2, 12),
                EnglishName = "Lincoln's Birthday",
                LocalName = "Lincoln's Birthday",
                HolidayTypes = HolidayTypes.Observance,
                SubdivisionCodes = ["US-CA", "US-CT", "US-IL", "US-IN", "US-KY", "US-MI", "US-NY", "US-MO", "US-OH"],
            };
        }

        private HolidaySpecification? JuneteenthNationalIndependenceDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            if (year >= 2021)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 19),
                    EnglishName = "Juneteenth National Independence Day",
                    LocalName = "Juneteenth National Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification? IndigenousPeoplesDay(int year)
        {
            if (year < 1988)
            {
                return null;
            }

            var secondMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);

            var indigenousPeoplesDay = new HolidaySpecification
            {
                Date = secondMondayInOctober,
                EnglishName = "Indigenous Peoples' Day",
                LocalName = "Indigenous Peoples' Day",
                HolidayTypes = HolidayTypes.Public
            };

            string[] subdivisionCodes = year switch
            {
                1988 => ["US-HI"],
                >= 1989 and < 2015 => ["US-HI", "US-SD"],
                2015 => ["US-AK", "US-HI", "US-SD"],
                >= 2016 and < 2018 => ["US-AK", "US-HI", "US-MN", "US-SD", "US-VT"],
                2018 => ["US-AK", "US-HI", "US-IA", "US-MN", "US-NC", "US-SD", "US-VT"],
                2019 => ["US-AK", "US-AL", "US-CA", "US-HI", "US-IA", "US-LA", "US-ME", "US-MI", "US-MN", "US-NC", "US-NM", "US-OK", "US-SD", "US-VT", "US-WI"],
                2020 => ["US-AK", "US-AL", "US-CA", "US-HI", "US-IA", "US-LA", "US-ME", "US-MI", "US-MN", "US-NC", "US-NE", "US-NM", "US-OK", "US-SD", "US-VA", "US-VT", "US-WI"],
                >= 2021 => ["US-AK", "US-AL", "US-CA", "US-HI", "US-IA", "US-LA", "US-ME", "US-MI", "US-MN", "US-NC", "US-NE", "US-NM", "US-OK", "US-OR", "US-SD", "US-TX", "US-VA", "US-VT", "US-WI"],
                _ => [],
            };

            indigenousPeoplesDay.SubdivisionCodes = subdivisionCodes;
            return indigenousPeoplesDay;

        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Federal_holidays_in_the_United_States",
                "https://www.whitehouse.gov/briefing-room/speeches-remarks/2021/06/17/remarks-by-president-biden-at-signing-of-the-juneteenth-national-independence-day-act/",
                "https://en.wikipedia.org/wiki/Indigenous_Peoples%27_Day_(United_States)#Indigenous_Peoples_Day_observers"
            ];
        }
    }
}
