using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Burundi HolidayProvider
    /// </summary>
    internal sealed class BurundiHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Burundi HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BurundiHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.BI)
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
                    Id = "UNITYDAY-01",
                    Date = new DateTime(year, 2, 5),
                    EnglishName = "Unity Day",
                    LocalName = "Unity Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NTARYAMIRADAY-01",
                    Date = new DateTime(year, 4, 6),
                    EnglishName = "Ntaryamira Day",
                    LocalName = "Ntaryamira Day",
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
                    Id = "NATIONALPATRIOTISMDAY-01",
                    Date = new DateTime(year, 6, 8),
                    EnglishName = "National Patriotism Day",
                    LocalName = "National Patriotism Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 7, 1),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ASSUMPTIONDAY-01",
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Assumption Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "RWAGASOREDAY-01",
                    Date = new DateTime(year, 10, 13),
                    EnglishName = "Rwagasore Day",
                    LocalName = "Rwagasore Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NDADAYEDAY-01",
                    Date = new DateTime(year, 10, 21),
                    EnglishName = "Ndadaye Day",
                    LocalName = "Ndadaye Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "All Saints' Day",
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
                this._catholicProvider.AscensionDay("Ascension Day", year),
            };

            // TODO: Islamic Holidays
            // CalendarType: Lunar
            // DeterminationType: MoonSighting (By COMIBU - Communauté Islamique du Burundi)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //1 Shawwal - date varies Eid al-Fitr This national holiday celebrates the end of Ramadan.
            //10 Dhu al-Hijjah - date varies Eid al-Adha This national holiday is the holiest day of the Islamic year; it celebrates Abraham′s sacrifice of his son.

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Burundi",
            ];
        }
    }
}
