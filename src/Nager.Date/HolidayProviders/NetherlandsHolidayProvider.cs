using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Netherlands HolidayProvider
    /// </summary>
    internal sealed class NetherlandsHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Netherlands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NetherlandsHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.NL)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var observedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(-1)
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nieuwjaarsdag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 27),
                    EnglishName = "King's Day",
                    LocalName = "Koningsdag",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Eerste Kerstdag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Tweede Kerstdag",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Goede Vrijdag", year),
                this._catholicProvider.EasterSunday("Eerste Paasdag", year),
                this._catholicProvider.EasterMonday("Tweede Paasdag", year),
                this._catholicProvider.AscensionDay("Hemelvaartsdag", year),
                this._catholicProvider.Pentecost("Eerste Pinksterdag", year),
                this._catholicProvider.WhitMonday("Tweede Pinksterdag", year)
            };

            holidaySpecifications.AddIfNotNull(this.LiberationDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? LiberationDay(int year)
        {
            var liberationDay = new HolidaySpecification
            {
                Date = new DateTime(year, 5, 5),
                EnglishName = "Liberation Day",
                LocalName = "Bevrijdingsdag",
                HolidayTypes = HolidayTypes.Public
            };

            if (year >= 1990)
            {
                //in 1990, the day was declared to be a national holiday
                return liberationDay.SetHolidayTypes(HolidayTypes.Authorities | HolidayTypes.School);
            }
            else if (year >= 1945)
            {
                if (year % 5 == 0)
                {
                    return liberationDay;
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Netherlands"
            ];
        }
    }
}
