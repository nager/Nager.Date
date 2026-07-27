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

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
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
                    Id = "YAPDAY-01",
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
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
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
            ];
        }
    }
}
