using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// United States of America HolidayProvider
    /// </summary>
    internal class UnitedStatesHolidayProvider : IHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// United States of America HolidayProvider
        /// </summary>
        public UnitedStatesHolidayProvider(
            ICatholicProvider catholicProvider)
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
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.US;

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

            if (year >= 2021)
            {
                holidaySpecifications.AddIfNotNull(new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 19),
                    EnglishName = "Juneteenth",
                    LocalName = "Juneteenth",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                });

                //var juneteenth = new DateTime(year, 6, 19).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
                //items.Add(new Holiday(juneteenth, "Juneteenth", "Juneteenth", countryCode, 2021));
            }

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);


            //var items = new List<Holiday>();

            //#region New Years Day with fallback
            //var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            //items.Add(new Holiday(newYearsDay, "New Year's Day", "New Year's Day", countryCode));
            //#endregion

            //items.Add(new Holiday(thirdMondayInJanuary, "Martin Luther King, Jr. Day", "Martin Luther King, Jr. Day", countryCode));
            //items.Add(new Holiday(thirdMondayInFebruary, "Presidents Day", "Washington's Birthday", countryCode));
            //items.Add(new Holiday(lastMondayInMay, "Memorial Day", "Memorial Day", countryCode));

            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode).SetCounties("US-CT", "US-DE", "US-HI", "US-IN", "US-KY", "US-LA", "US-NC", "US-ND", "US-NJ", "US-TN"));
            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode).SetType(HolidayTypes.Optional).SetCounties("US-TX"));

            //#region Juneteenth

            //if (year >= 2021)
            //{
            //    var juneteenth = new DateTime(year, 6, 19).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            //    items.Add(new Holiday(juneteenth, "Juneteenth", "Juneteenth", countryCode, 2021));
            //}

            //#endregion

            //#region Independence Day with fallback

            //var independenceDay = new DateTime(year, 7, 4).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            //items.Add(new Holiday(independenceDay, "Independence Day", "Independence Day", countryCode));

            //#endregion

            //items.Add(new Holiday(firstMondayInSeptember, "Labor Day", "Labour Day", countryCode));
            //items.Add(new Holiday(secondMondayInOctober, "Columbus Day", "Columbus Day", countryCode, null, new string[] { "US-AL", "US-AZ", "US-CO", "US-CT", "US-GA", "US-ID", "US-IL", "US-IN", "US-IA", "US-KS", "US-KY", "US-LA", "US-ME", "US-MD", "US-MA", "US-MS", "US-MO", "US-MT", "US-NE", "US-NH", "US-NJ", "US-NM", "US-NY", "US-NC", "US-OH", "US-OK", "US-PA", "US-RI", "US-SC", "US-TN", "US-UT", "US-VA", "US-WV" }));

            //#region Veterans Day with fallback//

            //var veteransDay = new DateTime(year, 11, 11).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            //items.Add(new Holiday(veteransDay, "Veterans Day", "Veterans Day", countryCode));

            //#endregion

            //items.Add(new Holiday(fourthThursdayInNovember, "Thanksgiving Day", "Thanksgiving Day", countryCode, 1863));

            //#region Christmas Day with fallback

            //var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(-1), sunday => sunday.AddDays(1));
            //items.Add(new Holiday(christmasDay, "Christmas Day", "Christmas Day", countryCode));

            //#endregion

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Federal_holidays_in_the_United_States",
                "https://www.whitehouse.gov/briefing-room/speeches-remarks/2021/06/17/remarks-by-president-biden-at-signing-of-the-juneteenth-national-independence-day-act/"
            };
        }
    }
}
