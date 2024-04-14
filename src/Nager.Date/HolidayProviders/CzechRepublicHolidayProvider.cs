using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Czech Republic HolidayProvider
    /// </summary>
    internal sealed class CzechRepublicHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// CzechRepublic HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CzechRepublicHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.CZ)
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
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Den obnovy samostatného českého státu; Nový rok",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Svátek práce",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 8),
                    EnglishName = "Liberation Day",
                    LocalName = "Den vítězství",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 5),
                    EnglishName = "Saints Cyril and Methodius Day",
                    LocalName = "Den slovanských věrozvěstů Cyrila a Metoděje",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 6),
                    EnglishName = "Jan Hus Day",
                    LocalName = "Den upálení mistra Jana Husa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 28),
                    EnglishName = "St. Wenceslas Day",
                    LocalName = "Den české státnosti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 28),
                    EnglishName = "Independent Czechoslovak State Day",
                    LocalName = "Den vzniku samostatného československého státu",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 17),
                    EnglishName = "Struggle for Freedom and Democracy Day",
                    LocalName = "Den boje za svobodu a demokracii a Mezinárodní den studentstva",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Štědrý den",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "1. svátek vánoční",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "2. svátek vánoční",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Velký pátek", year),
                this._catholicProvider.EasterMonday("Velikonoční pondělí", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Czech_Republic",
            ];
        }
    }
}
