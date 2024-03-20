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

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Den obnovy samostatného českého státu; Nový rok", "New Year's Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Velký pátek", year, countryCode).SetLaunchYear(2016));
            //items.Add(this._catholicProvider.EasterMonday("Velikonoční pondělí", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Svátek práce", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 8, "Den vítězství", "Liberation Day", countryCode));
            //items.Add(new Holiday(year, 7, 5, "Den slovanských věrozvěstů Cyrila a Metoděje", "Saints Cyril and Methodius Day", countryCode));
            //items.Add(new Holiday(year, 7, 6, "Den upálení mistra Jana Husa", "Jan Hus Day", countryCode));
            //items.Add(new Holiday(year, 9, 28, "Den české státnosti", "St. Wenceslas Day", countryCode));
            //items.Add(new Holiday(year, 10, 28, "Den vzniku samostatného československého státu", "Independent Czechoslovak State Day", countryCode));
            //items.Add(new Holiday(year, 11, 17, "Den boje za svobodu a demokracii a Mezinárodní den studentstva", "Struggle for Freedom and Democracy Day", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Štědrý den", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "1. svátek vánoční", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "2. svátek vánoční", "St. Stephen's Day", countryCode));

            //return items.OrderBy(o => o.Date);
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
