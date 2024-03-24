using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Australia HolidayProvider
    /// </summary>
    internal sealed class AustraliaHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Australia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AustraliaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.AU)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "AU-ACT", "Australian Capital Territory" },
                { "AU-NSW", "New South Wales" },
                { "AU-NT", "Northern Territory" },
                { "AU-QLD", "Queensland" },
                { "AU-SA", "South Australia" },
                { "AU-TAS", "Tasmania" },
                { "AU-VIC", "Victoria" },
                { "AU-WA", "Western Australia" }
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var secondMondayInMarch = DateHelper.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second);
            var firstMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            var firstMondayAfterOr27May = DateHelper.FindDay(year, Month.May, 27, DayOfWeek.Monday);
            var firstMondayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.First);
            
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var firstMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.First);
            var firstTuesdayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Tuesday, Occurrence.First);

            //var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            //var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            //var boxingDay = new DateTime(year, 12, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(2));
            //var australiaDay = new DateTime(year, 1, 26).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));

            var weekendObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2), Sunday = date => date.AddDays(1),
            };

            var weekendSequenceObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2), Sunday = date => date.AddDays(2),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 26),
                    EnglishName = "Australia Day",
                    LocalName = "Australia Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = secondMondayInMarch,
                    EnglishName = "Canberra Day",
                    LocalName = "Canberra Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-ACT"]
                },
                new HolidaySpecification
                {
                    Date = secondMondayInMarch,
                    EnglishName = "March Public Holiday",
                    LocalName = "March Public Holiday",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-SA"]
                },
                new HolidaySpecification
                {
                    Date = secondMondayInMarch,
                    EnglishName = "Eight Hours Day",
                    LocalName = "Eight Hours Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-TAS"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 25),
                    EnglishName = "Anzac Day",
                    LocalName = "Anzac Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstMondayInMay,
                    EnglishName = "May Day",
                    LocalName = "May Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-NT"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayAfterOr27May,
                    EnglishName = "Reconciliation Day",
                    LocalName = "Reconciliation Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-ACT"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInJune,
                    EnglishName = "Western Australia Day",
                    LocalName = "Western Australia Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-WA"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "Picnic Day",
                    LocalName = "Picnic Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-NT"]
                },
                new HolidaySpecification
                {
                    Date = firstTuesdayInNovember,
                    EnglishName = "Melbourne Cup",
                    LocalName = "Melbourne Cup",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-VIC"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendSequenceObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendSequenceObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-1),
                    EnglishName = "Holy Saturday",
                    LocalName = "Easter Eve",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-ACT", "AU-NSW", "AU-NT", "AU-QLD", "AU-SA", "AU-VIC"]
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this.EasterSunday(year),
            };

            holidaySpecifications.AddRangeIfNotNull(this.LabourDay(year));
            holidaySpecifications.AddRangeIfNotNull(this.MonarchBirthday(year));
            holidaySpecifications.AddIfNotNull(this.MourningForQueenElizabeth(year));

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(newYearsDay, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(australiaDay, "Australia Day", "Australia Day", countryCode));
            //items.Add(new Holiday(secondMondayInMarch, "Canberra Day", "Canberra Day", countryCode, null, new string[] { "AU-ACT" }));
            //items.Add(new Holiday(secondMondayInMarch, "March Public Holiday", "March Public Holiday", countryCode, null, new string[] { "AU-SA" }));
            //items.Add(new Holiday(secondMondayInMarch, "Eight Hours Day", "Eight Hours Day", countryCode, null, new string[] { "AU-TAS" }));

            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-1), "Easter Eve", "Holy Saturday", countryCode, null, new string[] { "AU-ACT", "AU-NSW", "AU-NT", "AU-QLD", "AU-SA", "AU-VIC" }));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            //items.Add(new Holiday(year, 4, 25, "Anzac Day", "Anzac Day", countryCode));
            //items.Add(new Holiday(firstMondayInMay, "May Day", "May Day", countryCode, null, new string[] { "AU-NT" }));

            //items.Add(new Holiday(firstMondayAfterOr27May, "Reconciliation Day", "Reconciliation Day", countryCode, 2018, new string[] { "AU-ACT" }));
            //items.Add(new Holiday(firstMondayInJune, "Western Australia Day", "Western Australia Day", countryCode, null, new string[] { "AU-WA" }));
            //items.Add(new Holiday(firstMondayInAugust, "Picnic Day", "Picnic Day", countryCode, null, new string[] { "AU-NT" }));

            //items.Add(new Holiday(firstTuesdayInNovember, "Melbourne Cup", "Melbourne Cup", countryCode, null, new string[] { "AU-VIC" }));

            //items.Add(new Holiday(christmasDay, "Christmas Day", "Christmas Day", countryCode));
            //items.Add(new Holiday(boxingDay, "Boxing Day", "St. Stephen's Day", countryCode));

            //items.AddRangeIfNotNull(this.LabourDay(year, countryCode));
            //items.AddIfNotNull(this.MourningForQueenElizabeth(year, countryCode));
            //items.AddRangeIfNotNull(this.MonarchBirthday(year, countryCode));
            //items.AddIfNotNull(this.EasterSunday(year, countryCode));

            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification EasterSunday(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday("Easter Sunday", year);

            string[] subdivisionCodes = year switch
            {
                < 2010 => [],
                >= 2010 and <= 2015 => ["AU-NSW"],
                2016 => ["AU-ACT", "AU-NSW", "AU-VIC"],
                >= 2017 and <= 2021 => ["AU-ACT", "AU-NSW", "AU-QLD", "AU-VIC"],
                2022 => ["AU-ACT", "AU-NSW", "AU-QLD", "AU-VIC", "AU-WA"],
                2023 => ["AU-ACT", "AU-NSW", "AU-NT", "AU-QLD", "AU-VIC", "AU-WA"],
                >= 2024 => ["AU-ACT", "AU-NSW", "AU-NT", "AU-QLD", "AU-SA", "AU-VIC", "AU-WA"]
            };

            easterSunday.SubdivisionCodes = subdivisionCodes;
            return easterSunday;
        }

        private HolidaySpecification[] LabourDay(int year)
        {
            var firstMondayInMarch = DateHelper.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInMarch = DateHelper.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Second);
            var firstMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            var firstMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.First);

            return
            [
                new HolidaySpecification
                {
                    Date = firstMondayInMarch,
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-WA"]
                },
                new HolidaySpecification
                {
                    Date = secondMondayInMarch,
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-VIC"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInMay,
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-QLD"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInOctober,
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-ACT", "AU-NSW", "AU-SA"]
                }
            ];

            //new Holiday(firstMondayInMarch, "Labour Day", "Labour Day", countryCode, null, new string[] { "AU-WA" }),
            //new Holiday(secondMondayInMarch, "Labour Day", "Labour Day", countryCode, null, new string[] { "AU-VIC" }),
            //new Holiday(firstMondayInMay, "Labour Day", "Labour Day", countryCode, null, new string[] { "AU-QLD" }),
            //new Holiday(firstMondayInOctober, "Labour Day", "Labour Day", countryCode, null, new string[] { "AU-ACT", "AU-NSW", "AU-SA" })
        }

        private HolidaySpecification[] MonarchBirthday(int year)
        {
            var name = "Queen's Birthday";
            if (year >= 2023)
            {
                name = "King's Birthday";
            }

            var secondMondayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second);
            var firstMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.First);

            return
            [
                new HolidaySpecification
                {
                    Date = secondMondayInJune,
                    EnglishName = name,
                    LocalName = name,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-ACT", "AU-NSW", "AU-NT", "AU-SA", "AU-TAS", "AU-VIC"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInOctober,
                    EnglishName = name,
                    LocalName = name,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["AU-QLD"]
                }
            ];

            //return new Holiday[]
            //{
            //    new Holiday(secondMondayInJune, name, name, countryCode, null, new string[] { "AU-ACT", "AU-NSW", "AU-NT", "AU-SA", "AU-TAS", "AU-VIC" }),
            //    new Holiday(firstMondayInOctober, name, name, countryCode, null, new string[] { "AU-QLD" })
            //};
        }

        private HolidaySpecification MourningForQueenElizabeth(int year)
        {
            if (year == 2022)
            {
                //Australia's national day of mourning for Queen Elizabeth II to be public holiday
                //https://www.abc.net.au/news/2022-09-11/national-day-of-mourning-queen-death-to-be-public-holiday/101427050

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 22),
                    EnglishName = "National Day of Mourning",
                    LocalName = "National Day of Mourning",
                    HolidayTypes = HolidayTypes.Public
                };

                //return new Holiday(year, 9, 22, "National Day of Mourning", "National Day of Mourning", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Australia"
            ];
        }
    }
}
