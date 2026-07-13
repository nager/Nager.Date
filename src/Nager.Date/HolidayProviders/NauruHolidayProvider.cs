using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Nauru HolidayProvider
    /// </summary>
    internal sealed class NauruHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Nauru HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NauruHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.NR)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

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
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 1, 31),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "International Women's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 5, 17),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "RONPHOSHANDOVERDAY-01",
                    Date = new DateTime(year, 7, 1),
                    EnglishName = "RONPhos Handover Day",
                    LocalName = "RONPhos Handover Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "IBUMINEAROENIDAY-01",
                    Date = new DateTime(year, 8, 19),
                    EnglishName = "Ibumin Earoeni Day",
                    LocalName = "Ibumin Earoeni Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "SIRHAMMERDEROBURTDAY-01",
                    Date = new DateTime(year, 9, 25),
                    EnglishName = "Sir Hammer DeRoburt Day",
                    LocalName = "Sir Hammer DeRoburt Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ANGAMDAY-01",
                    Date = new DateTime(year, 10, 26),
                    EnglishName = "Angam Day",
                    LocalName = "Angam Day",
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
                new HolidaySpecification
                {
                    Id = "EASTERTUESDAY-01",
                    Date = easterSunday.AddDays(2),
                    EnglishName = "Easter Tuesday",
                    LocalName = "Easter Tuesday",
                    HolidayTypes = HolidayTypes.Public
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Nauru",
            ];
        }
    }
}
