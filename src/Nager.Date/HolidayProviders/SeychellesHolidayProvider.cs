using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Seychelles HolidayProvider
    /// </summary>
    internal sealed class SeychellesHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Seychelles HolidayProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public SeychellesHolidayProvider(ICatholicProvider catholicProvider) : base(CountryCode.SC)
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
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-02",
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year Holiday",
                    LocalName = "New Year Holiday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY",
                    Date = new DateTime(year, 6, 18),
                    EnglishName = "National Day (Constitution Day)",
                    LocalName = "National Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY",
                    Date = new DateTime(year, 6, 29),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ASSUMPTION",
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption of Mary",
                    LocalName = "Assumption of Mary",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAY",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "All Saints' Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "IMMACULATECONCEPTION",
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Immaculate Conception",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            holidaySpecifications.AddRange(this.GetEasterBasedHolidays(year));

            return holidaySpecifications;
        }

        private IEnumerable<HolidaySpecification> GetEasterBasedHolidays(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            return
            [
                new HolidaySpecification
                {
                    Id = "GOODFRIDAY",
                    Date = easterSunday.AddDays(-2),
                    EnglishName = "Good Friday",
                    LocalName = "Good Friday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "EASTERSATURDAY",
                    Date = easterSunday.AddDays(-1),
                    EnglishName = "Easter Saturday",
                    LocalName = "Easter Saturday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "EASTERMONDAY",
                    Date = easterSunday.AddDays(1),
                    EnglishName = "Easter Monday",
                    LocalName = "Easter Monday",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CORPUSCHRISTI",
                    Date = easterSunday.AddDays(60),
                    EnglishName = "Corpus Christi",
                    LocalName = "Corpus Christi",
                    HolidayTypes = HolidayTypes.Public
                }
            ];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://www.psb.gov.sc/public-holidays",
                "https://www.officeholidays.com/countries/seychelles"
            ];
        }
    }
}
