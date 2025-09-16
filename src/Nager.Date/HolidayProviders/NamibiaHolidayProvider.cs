using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Namibia HolidayProvider
    /// </summary>
    internal sealed class NamibiaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Namibia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NamibiaHolidayProvider(ICatholicProvider catholicProvider) : base(CountryCode.NA)
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
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 3, 21),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "WORKERSDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Workers' Day",
                    LocalName = "Workers' Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CASSINGADAY-01",
                    Date = new DateTime(year, 5, 4),
                    EnglishName = "Cassinga Day",
                    LocalName = "Cassinga Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "AFRICADAY-01",
                    Date = new DateTime(year, 5, 25),
                    EnglishName = "Africa Day",
                    LocalName = "Africa Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "HEROESDAY-01",
                    Date = new DateTime(year, 8, 26),
                    EnglishName = "Heroes' Day",
                    LocalName = "Heroes' Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "HUMANRIGHTSDAY-01",
                    Date = new DateTime(year, 12, 10),
                    EnglishName = "Human Rights Day",
                    LocalName = "Human Rights Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "DAYOFGOODWILL-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Day of Goodwill",
                    LocalName = "St. Stephen's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.AscensionDay("Ascension Day", year)
            };

            holidaySpecifications.AddIfNotNull(this.GenocideRemembranceDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? GenocideRemembranceDay(int year)
        {
            if (year >= 2025)
            {
                return new HolidaySpecification
                {
                    Id = "GENOCIDEREMEMBRANCEDAY-01",
                    Date = new DateTime(year, 5, 28),
                    EnglishName = "Genocide Remembrance Day",
                    LocalName = "Genocide Remembrance Day",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Namibia",
                "https://www.gov.na/documents/146489/243786/Genocide+Remembrance+Day+2025.pdf/943da8fe-f23f-ccf3-0765-522d4797a547"
            ];
        }
    }
}
