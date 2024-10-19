using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// United Kingdom HolidayProvider
    /// </summary>
    internal sealed class UnitedKingdomHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// United Kingdom HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public UnitedKingdomHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.GB)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "GB-NIR", "Northern Ireland" },
                { "GB-SCT", "Scotland" },
                { "GB-ENG", "England" },
                { "GB-WLS", "Wales" },
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstMondayInAugust = DateHelper.FindDay(year, Month.August, DayOfWeek.Monday, Occurrence.First);
            var lastMondayInAugust = DateHelper.FindLastDay(year, Month.August, DayOfWeek.Monday);

            var mondayObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var tuesdayObservedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(2),
                Monday = date => date.AddDays(1),
            };

            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(2),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["GB-ENG", "GB-NIR", "GB-SCT", "GB-WLS"],
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "2 January",
                    LocalName = "2 January",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["GB-SCT"],
                    ObservedRuleSet = tuesdayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 17),
                    EnglishName = "Saint Patrick's Day",
                    LocalName = "Saint Patrick's Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["GB-NIR"],
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 30),
                    EnglishName = "Saint Andrew's Day",
                    LocalName = "Saint Andrew's Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["GB-SCT"],
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 12),
                    EnglishName = "Battle of the Boyne",
                    LocalName = "Battle of the Boyne",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["GB-NIR"],
                    ObservedRuleSet = mondayObservedRuleSet
                },
                new HolidaySpecification
                {
                    Date = firstMondayInAugust,
                    EnglishName = "Summer Bank Holiday",
                    LocalName = "Summer Bank Holiday",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["GB-SCT"]
                },
                new HolidaySpecification
                {
                    Date = lastMondayInAugust,
                    EnglishName = "Summer Bank Holiday",
                    LocalName = "Summer Bank Holiday",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["GB-ENG", "GB-WLS", "GB-NIR"]
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
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year).SetSubdivisionCodes("GB-ENG", "GB-WLS", "GB-NIR")
            };

            holidaySpecifications.AddIfNotNull(this.EarlyMayBankHoliday(year));
            holidaySpecifications.AddIfNotNull(this.SpringBankHoliday(year));
            holidaySpecifications.AddIfNotNull(this.QueensPlatinumJubilee(year));
            holidaySpecifications.AddIfNotNull(this.QueensStateFuneral(year));
            holidaySpecifications.AddIfNotNull(this.CoronationBankHoliday(year));

            return holidaySpecifications;
        }

        private HolidaySpecification SpringBankHoliday(int year)
        {
            var name = "Spring Bank Holiday";

            if (year == 2022)
            {
                //https://www.gov.uk/government/news/extra-bank-holiday-to-mark-the-queens-platinum-jubilee-in-2022

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 2),
                    EnglishName = name,
                    LocalName = name,
                    HolidayTypes = HolidayTypes.Public
                };
            }

            var lastMondayInMay = DateHelper.FindLastDay(year, Month.May, DayOfWeek.Monday);

            return new HolidaySpecification
            {
                Date = lastMondayInMay,
                EnglishName = name,
                LocalName = name,
                HolidayTypes = HolidayTypes.Public
            };
        }

        #region Royal family

        private HolidaySpecification? QueensPlatinumJubilee(int year)
        {
            if (year == 2022)
            {
                //Majesty Queen Elizabeth II’s

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 3),
                    EnglishName = "Queen’s Platinum Jubilee",
                    LocalName = "Queen’s Platinum Jubilee",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? QueensStateFuneral(int year)
        {
            if (year == 2022)
            {
                //Majesty Queen Elizabeth II’s (https://www.gov.uk/government/news/bank-holiday-announced-for-her-majesty-queen-elizabeth-iis-state-funeral-on-monday-19-september)

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 19),
                    EnglishName = "Queen’s State Funeral",
                    LocalName = "Queen’s State Funeral",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? CoronationBankHoliday(int year)
        {
            if (year == 2023)
            {
                //Bank holiday proclaimed in honour of the coronation of His Majesty King Charles III
                //https://www.gov.uk/government/news/bank-holiday-proclaimed-in-honour-of-the-coronation-of-his-majesty-king-charles-iii

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 8),
                    EnglishName = "Coronation Bank Holiday",
                    LocalName = "Coronation Bank Holiday",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        #endregion

        private HolidaySpecification EarlyMayBankHoliday(int year)
        {
            var holidayName = "Early May Bank Holiday";

            if (year == 1995)
            {
                // Shifted to mark the 50th anniversary of VE Day
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 8),
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public
                };
            }
            else if (year == 2020)
            {
                // Shifted to mark the 75th anniversary of VE Day
                // https://www.bbc.co.uk/news/uk-48565417
                var secondFridayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Friday, Occurrence.Second);

                return new HolidaySpecification
                {
                    Date = secondFridayInMay,
                    EnglishName = holidayName,
                    LocalName = holidayName,
                    HolidayTypes = HolidayTypes.Public
                };
            }

            var firstMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);

            return new HolidaySpecification
            {
                Date = firstMondayInMay,
                EnglishName = holidayName,
                LocalName = holidayName,
                HolidayTypes = HolidayTypes.Public
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_United_Kingdom",
                "https://de.wikipedia.org/wiki/Feiertage_im_Vereinigten_K%C3%B6nigreich"
            ];
        }
    }
}
