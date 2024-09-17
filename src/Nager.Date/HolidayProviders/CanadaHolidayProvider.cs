using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Canada HolidayProvider
    /// </summary>
    internal sealed class CanadaHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Canada HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CanadaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.CA)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "CA-AB", "Alberta" },
                { "CA-BC", "British Columbia" },
                { "CA-MB", "Manitoba" },
                { "CA-NB", "New Brunswick" },
                { "CA-NL", "Newfoundland and Labrador" },
                { "CA-NS", "Nova Scotia" },
                { "CA-ON", "Ontario" },
                { "CA-PE", "Prince Edward Island" },
                { "CA-QC", "Québec" },
                { "CA-SK", "Saskatchewan" },
                { "CA-NT", "Northwest Territories" },
                { "CA-NU", "Nunavut" },
                { "CA-YT", "Yukon" }
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var thirdMondayInFebruary = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third);
            var mondayOnOrBeforeMay24 = DateHelper.FindDayBefore(year, Month.May, 25, DayOfWeek.Monday);
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var thirdMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.Third);
            var firstMondayInSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.First);
            var secondMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);

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
                    Date = thirdMondayInFebruary,
                    EnglishName = "Louis Riel Day",
                    LocalName = "Louis Riel Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-MB"]
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInFebruary,
                    EnglishName = "Islander Day",
                    LocalName = "Islander Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-PE"]
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInFebruary,
                    EnglishName = "Heritage Day",
                    LocalName = "Heritage Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-NS"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 17),
                    EnglishName = "Saint Patrick's Day",
                    LocalName = "Saint Patrick's Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-NL"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 23),
                    EnglishName = "Saint George's Day",
                    LocalName = "Saint George's Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-NL"]
                },
                new HolidaySpecification
                {
                    Date = mondayOnOrBeforeMay24,
                    EnglishName = "National Patriots' Day",
                    LocalName = "National Patriots' Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-QC"]
                },
                new HolidaySpecification
                {
                    Date = mondayOnOrBeforeMay24,
                    EnglishName = "Victoria Day",
                    LocalName = "Victoria Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 21),
                    EnglishName = "National Aboriginal Day",
                    LocalName = "National Aboriginal Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-NT"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 24),
                    EnglishName = "Discovery Day",
                    LocalName = "Discovery Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-NL"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 24),
                    EnglishName = "National Holiday",
                    LocalName = "Fête nationale du Québec",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-QC"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 12),
                    EnglishName = "Orangemen's Day",
                    LocalName = "Orangemen's Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-NL"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "Civic Holiday",
                    LocalName = "Civic Holiday",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-MB", "CA-NL", "CA-NT", "CA-NU", "CA-ON"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "British Columbia Day",
                    LocalName = "British Columbia Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-BC"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "Heritage Day",
                    LocalName = "Heritage Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-AB", "CA-YT"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "New Brunswick Day",
                    LocalName = "New Brunswick Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-NB"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "Natal Day",
                    LocalName = "Natal Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-NS"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "Saskatchewan Day",
                    LocalName = "Saskatchewan Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-SK"]
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInAugust,
                    EnglishName = "Gold Cup Parade Day",
                    LocalName = "Gold Cup Parade Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-PE"]
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInAugust,
                    EnglishName = "Discovery Day",
                    LocalName = "Discovery Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-YT"]
                },
                new HolidaySpecification
                {
                    Date = firstMondayInSeptember,
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 30),
                    EnglishName = "National Day for Truth and Reconciliation",
                    LocalName = "National Day for Truth and Reconciliation",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = secondMondayInOctober,
                    EnglishName = "Thanksgiving",
                    LocalName = "Thanksgiving",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Armistice Day",
                    LocalName = "Armistice Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-NL"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Remembrance Day",
                    LocalName = "Remembrance Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-AB", "CA-BC", "CA-NB", "CA-NT", "CA-NS", "CA-NU", "CA-PE", "CA-SK", "CA-YT"]
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-AB", "CA-NB", "CA-NS", "CA-ON", "CA-PE"]
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year).SetSubdivisionCodes("CA-AB", "CA-PE")
            };

            holidaySpecifications.AddRangeIfNotNull(this.CanadaDay(year));
            holidaySpecifications.AddRangeIfNotNull(this.FamilyDay(year));
            holidaySpecifications.AddIfNotNull(this.FuneralForQueenElizabeth(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? FuneralForQueenElizabeth(int year)
        {
            if (year == 2022)
            {
                //Canada announces a national holiday to mark Queen Elizabeth’s death
                //https://globalnews.ca/news/9122726/canada-national-holiday-sept-19-queens-funeral/

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 19),
                    EnglishName = "State Funeral of Queen Elizabeth II",
                    LocalName = "State Funeral of Queen Elizabeth II",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification[] FamilyDay(int year)
        {
            var holidayName = "Family Day";
            var thirdMondayInFebruary = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Third);

            if (year < 2019)
            {
                var secondMondayInFebruary = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.Second);
                return
                [
                    new HolidaySpecification
                    {
                        Date = secondMondayInFebruary,
                        EnglishName = holidayName,
                        LocalName = holidayName,
                        HolidayTypes = HolidayTypes.Public,
                        SubdivisionCodes = ["CA-BC"]
                    },
                    new HolidaySpecification
                    {
                        Date = thirdMondayInFebruary,
                        EnglishName = holidayName,
                        LocalName = holidayName,
                        HolidayTypes = HolidayTypes.Public,
                        SubdivisionCodes = ["CA-AB", "CA-ON", "CA-SK"]
                    }
                ];
            }

            return
            [
                new HolidaySpecification
                {
                    Date = thirdMondayInFebruary,
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["CA-AB", "CA-BC", "CA-NB", "CA-ON", "CA-SK"]
                }
            ];
        }

        private HolidaySpecification[] CanadaDay(int year)
        {
            var holidayName = "Canada Day";
            var canadaDay = new DateTime(year, 7, 1);

            if (canadaDay.DayOfWeek == DayOfWeek.Sunday)
            {
                return
                [
                    new HolidaySpecification
                    {
                        Date = canadaDay,
                        EnglishName = holidayName,
                        LocalName = holidayName,
                        HolidayTypes = HolidayTypes.Public,
                        SubdivisionCodes = ["CA-BC", "CA-MB", "CA-NB", "CA-NL", "CA-NS", "CA-ON", "CA-PE", "CA-QC", "CA-SK", "CA-NT", "CA-NU", "CA-YT"]
                    },
                    new HolidaySpecification
                    {
                        Date = canadaDay.AddDays(1),
                        EnglishName = holidayName,
                        LocalName = holidayName,
                        HolidayTypes = HolidayTypes.Public,
                        SubdivisionCodes = ["CA-AB"]
                    }
                ];
            }

            return
            [
                new HolidaySpecification
                {
                    Date = canadaDay,
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public
                }
            ];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Canada",
                "https://www.canada.ca/en/department-national-defence/maple-leaf/defence/2021/07/federal-statutory-holiday-national-day-for-truth-and-reconciliation.html"
            ];
        }
    }
}
