using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Saint Helena, Ascension and Tristan da Cunha HolidayProvider
    /// </summary>
    internal sealed class SaintHelenaAscensionTristanDaCunhaHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Saint Helena, Ascension and Tristan da Cunha HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SaintHelenaAscensionTristanDaCunhaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.SH)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "SH-HL", "Saint Helena" },
                { "SH-AC", "Acension" },
                { "SH-TA", "Tristan da Cunha" },
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var lastMondayInAugust = DateHelper.FindLastDay(year, Month.August, DayOfWeek.Monday);
            var thirdFridayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Friday, Occurrence.Third);

            var weekendObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var specialObservedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(2),
                Monday = date => date.AddDays(1),
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
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "SAINTHELENADAY-01",
                    Date = new DateTime(year, 5, 21),
                    EnglishName = "Saint Helena Day",
                    LocalName = "Saint Helena Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ANNIVERSARYDAY-01",
                    Date = new DateTime(year, 8, 14),
                    EnglishName = "Anniversary Day",
                    LocalName = "Anniversary Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["SH-TA"],
                },
                new HolidaySpecification
                {
                    Id = "AUGUSTBANKHOLIDAY-01",
                    Date = lastMondayInAugust,
                    EnglishName = "August Bank Holiday",
                    LocalName = "August Bank Holiday",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["SH-HL", "SH-AC"],
                },
                new HolidaySpecification
                {
                    Id = "KINGSBIRTHDAY-01",
                    Date = thirdFridayInNovember,
                    EnglishName = "King's Birthday",
                    LocalName = "King's Birthday",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = specialObservedRuleSet,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.AscensionDay("Ascension Day", year).SetSubdivisionCodes(["SH-TA"]),
                this._catholicProvider.WhitMonday("Whit Monday", year),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Saint_Helena,_Ascension_and_Tristan_da_Cunha",
            ];
        }
    }
}
