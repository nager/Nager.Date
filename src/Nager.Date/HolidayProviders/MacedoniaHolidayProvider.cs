using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Macedonia HolidayProvider
    /// </summary>
    internal sealed class MacedoniaHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Macedonia HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public MacedoniaHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.MK)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Нова Година, Nova Godina",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Christmas Day",
                    LocalName = "Прв ден Божик, Prv den Božik",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Ден на трудот, Den na trudot",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 24),
                    EnglishName = "Saints Cyril and Methodius Day",
                    LocalName = "Св. Кирил и Методиј, Ден на сèсловенските просветители",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 2),
                    EnglishName = "Day of the Republic",
                    LocalName = "Ден на Републиката, Den na Republikata",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 8),
                    EnglishName = "Independence Day",
                    LocalName = "Ден на независноста, Den na nezavisnosta",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 11),
                    EnglishName = "Revolution Day",
                    LocalName = "Ден на востанието, Den na vostanieto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 23),
                    EnglishName = "Day of the Macedonian Revolutionary Struggle",
                    LocalName = "Ден на македонската револуционерна борба,Den na makedonskata revolucionarna borba",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Saint Clement of Ohrid Day",
                    LocalName = "Св. Климент Охридски, Sv. Kliment Ohridski",
                    HolidayTypes = HolidayTypes.Public
                },
                this._orthodoxProvider.GoodFriday("Велики Петок, Veliki Petok", year),
                this._orthodoxProvider.EasterSunday("Прв ден Велигден, Prv den Veligden", year),
                this._orthodoxProvider.EasterMonday("Втор ден Велигден, Vtor den Veligden", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Macedonia"
            ];
        }
    }
}
