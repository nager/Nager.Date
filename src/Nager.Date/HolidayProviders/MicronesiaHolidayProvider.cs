using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Micronesia HolidayProvider
    /// </summary>
    internal sealed class MicronesiaHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Micronesia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MicronesiaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.FM)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            return new Dictionary<string, string>
            {
                { "FM-KSA", "Kosrae" },
                { "FM-PNI", "Pohnpei" },
                { "FM-TRK", "Chuuk" },
                { "FM-YAP", "Yap" },
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var secondFridayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Friday, Occurrence.Second);
            var fourthThursdayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Thursday, Occurrence.Fourth);

            var weekendObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(-1),
                Sunday = date => date.AddDays(1),
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
                    Id = "CONSTITUTIONDAYKSA-01",
                    Date = new DateTime(year, 1, 11),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-KSA"],
                },
                new HolidaySpecification
                {
                    Id = "YAPDAY-01",
                    Date = new DateTime(year, 3, 1),
                    EnglishName = "Yap Day",
                    LocalName = "Yap Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-YAP"],
                },
                new HolidaySpecification
                {
                    Id = "YAPDAY-02",
                    Date = new DateTime(year, 3, 2),
                    EnglishName = "Yap Day",
                    LocalName = "Yap Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-YAP"],
                },
                new HolidaySpecification
                {
                    Id = "CULTUREDAY-01",
                    Date = new DateTime(year, 3, 31),
                    EnglishName = "Culture Day",
                    LocalName = "Culture Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 5, 10),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "GOSPELDAY-01",
                    Date = new DateTime(year, 8, 21),
                    EnglishName = "Gospel Day",
                    LocalName = "Gospel Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-KSA"],
                },
                new HolidaySpecification
                {
                    Id = "LIBERATIONDAYKSA-01",
                    Date = new DateTime(year, 9, 8),
                    EnglishName = "Liberation Day",
                    LocalName = "Liberation Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-KSA"],
                },
                new HolidaySpecification
                {
                    Id = "LIBERATIONDAYPNI-01",
                    Date = new DateTime(year, 9, 11),
                    EnglishName = "Liberation Day",
                    LocalName = "Liberation Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-PNI"],
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAYTRK-01",
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-TRK"],
                },
                new HolidaySpecification
                {
                    Id = "TEACHERSAPPRECIATIONDAY-01",
                    Date = secondFridayInOctober,
                    EnglishName = "Teachers' Appreciation Day",
                    LocalName = "Teachers' Appreciation Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-TRK"],
                },
                new HolidaySpecification
                {
                    Id = "UNITEDNATIONSDAY-01",
                    Date = new DateTime(year, 10, 24),
                    EnglishName = "United Nations Day",
                    LocalName = "United Nations Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "SATOWANDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "Satowan Day",
                    LocalName = "Satowan Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-TRK"],
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 11, 3),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAYPNI-01",
                    Date = new DateTime(year, 11, 8),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-PNI"],
                },
                new HolidaySpecification
                {
                    Id = "VETERANSDAY-01",
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Veterans Day",
                    LocalName = "Veterans Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PRESIDENTSDAY-01",
                    Date = new DateTime(year, 11, 23),
                    EnglishName = "Presidents Day",
                    LocalName = "Presidents Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "THANKSGIVING-01",
                    Date = fourthThursdayInNovember,
                    EnglishName = "Thanksgiving",
                    LocalName = "Thanksgiving",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-KSA"],
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAYYAP-01",
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                    SubdivisionCodes = ["FM-YAP"],
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
                this._catholicProvider.GoodFriday("Good Friday", year).SetSubdivisionCodes("FM-TRK", "FM-PNI"),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Federated_States_of_Micronesia",
                "https://www.fsmlaw.org/fsm/code/title01/t01ch06.htm",
            ];
        }
    }
}
