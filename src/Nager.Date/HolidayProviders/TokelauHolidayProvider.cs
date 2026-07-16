using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Tokelau HolidayProvider
    /// </summary>
    internal sealed class TokelauHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Tokelau HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public TokelauHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.TK)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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
                    Id = "WAITANGIDAY-01",
                    Date = new DateTime(year, 2, 6),
                    EnglishName = "Waitangi Day",
                    LocalName = "Waitangi Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ANZACDAY-01",
                    Date = new DateTime(year, 4, 25),
                    EnglishName = "Anzac Day",
                    LocalName = "Anzac Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MOTHERSDAY-01",
                    Date = new DateTime(year, 5, 10),
                    EnglishName = "Mother's Day",
                    LocalName = "Mother's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "FATHERSDAY-01",
                    Date = new DateTime(year, 8, 10),
                    EnglishName = "Father's Day",
                    LocalName = "Father's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "TOKEHEGADAY-01",
                    Date = new DateTime(year, 9, 3),
                    EnglishName = "Tokehega Day",
                    LocalName = "Tokehega Day",
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
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Tokelau",
                "https://www.tokelau.org.nz/About+Us/Culture.html",
            ];
        }
    }
}
