using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Guernsey HolidayProvider
    /// </summary>
    internal sealed class GuernseyHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Guernsey HolidayProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public GuernseyHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.GG)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var firstMondayInMay = DateHelper.FindDay(year, Month.May, DayOfWeek.Monday, Occurrence.First);
            var lastMondayInMay = DateHelper.FindLastDay(year, Month.May, DayOfWeek.Monday);
            var lastMondayInAugust = DateHelper.FindLastDay(year, Month.August, DayOfWeek.Monday);

            var mondayObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var christmasObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(2),
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
                    ObservedRuleSet = mondayObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "EARLYMAYBANKHOLIDAY-01",
                    Date = firstMondayInMay,
                    EnglishName = "Early May Bank Holiday",
                    LocalName = "Early May Bank Holiday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LIBERATIONDAY-01",
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Liberation Day",
                    LocalName = "Liberation Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "SUMMERBANKHOLIDAY-01",
                    Date = lastMondayInAugust,
                    EnglishName = "Summer Bank Holiday",
                    LocalName = "Summer Bank Holiday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = christmasObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "BOXINGDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "St. Stephen's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = christmasObservedRuleSet,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            holidaySpecifications.AddIfNotNull(this.SpringBankHoliday(year));
            holidaySpecifications.AddIfNotNull(this.QueensPlatinumJubilee(year));
            holidaySpecifications.AddIfNotNull(this.CoronationBankHoliday(year));

            return holidaySpecifications;
        }

        private HolidaySpecification SpringBankHoliday(int year)
        {
            var id = "SPRINGBANKHOLIDAY-01";
            var name = "Spring Bank Holiday";

            if (year == 2022)
            {
                //Moved for the Queen's Platinum Jubilee

                return new HolidaySpecification
                {
                    Id = id,
                    Date = new DateTime(year, 6, 2),
                    EnglishName = name,
                    LocalName = name,
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            var lastMondayInMay = DateHelper.FindLastDay(year, Month.May, DayOfWeek.Monday);

            return new HolidaySpecification
            {
                Id = id,
                Date = lastMondayInMay,
                EnglishName = name,
                LocalName = name,
                HolidayTypes = HolidayTypes.Public,
            };
        }

        private HolidaySpecification? QueensPlatinumJubilee(int year)
        {
            if (year == 2022)
            {
                return new HolidaySpecification
                {
                    Id = "QUEENSPLATINUMJUBILEE-01",
                    Date = new DateTime(year, 6, 3),
                    EnglishName = "Queen's Platinum Jubilee",
                    LocalName = "Queen's Platinum Jubilee",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        private HolidaySpecification? CoronationBankHoliday(int year)
        {
            if (year == 2023)
            {
                //Coronation of King Charles III

                return new HolidaySpecification
                {
                    Id = "CORONATIONBANKHOLIDAY-01",
                    Date = new DateTime(year, 5, 8),
                    EnglishName = "Coronation Bank Holiday",
                    LocalName = "Coronation Bank Holiday",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://www.gov.gg/holidaydates",
                "https://en.wikipedia.org/wiki/Public_holidays_in_Guernsey"
            ];
        }
    }
}
