using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Denmark HolidayProvider
    /// </summary>
    internal sealed class DenmarkHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Denmark HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public DenmarkHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.DK)
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
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nytårsdag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 5),
                    EnglishName = "Constitution Day",
                    LocalName = "Grundlovsdag",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Juleaftensdag",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Juledag / 1. juledag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "2. juledag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Nytårsaftensdag",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(40),
                    EnglishName = "Bank closing day",
                    LocalName = "Banklukkedag",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                this._catholicProvider.MaundyThursday("Skærtorsdag", year),
                this._catholicProvider.GoodFriday("Langfredag", year),
                this._catholicProvider.EasterSunday("Påskedag", year),
                this._catholicProvider.EasterMonday("2. Påskedag", year),
                this._catholicProvider.AscensionDay("Kristi Himmelfartsdag", year),
                this._catholicProvider.Pentecost("Pinsedag", year),
                this._catholicProvider.WhitMonday("2. Pinsedag", year)
            };

            holidaySpecifications.AddIfNotNull(this.GeneralPrayerDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? GeneralPrayerDay(int year)
        {
            if (year < 2024)
            {
                var easterSunday = this._catholicProvider.EasterSunday(year);

                return new HolidaySpecification
                {
                    Date = easterSunday.AddDays(26),
                    EnglishName = "General Prayer Day",
                    LocalName = "Store bededag",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Denmark",
            ];
        }
    }
}
