using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Liechtenstein HolidayProvider
    /// </summary>
    internal sealed class LiechtensteinHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Liechtenstein HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public LiechtensteinHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.LI)
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
                    LocalName = "Neujahr",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "St. Berchtold's Day",
                    LocalName = "Berchtoldstag",
                    HolidayTypes = HolidayTypes.Bank
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Heilige Drei Könige",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 2),
                    EnglishName = "Candlemas",
                    LocalName = "Mariä Lichtmess",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 19),
                    EnglishName = "Saint Joseph's Day",
                    LocalName = "Josefstag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Tag der Arbeit",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "National Holiday",
                    LocalName = "Staatsfeiertag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 8),
                    EnglishName = "Nativity of Our Lady",
                    LocalName = "Maria Geburt",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "Allerheiligen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Immaculate Conception",
                    LocalName = "Mariä Empfängnis",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Heiliger Abend",
                    HolidayTypes = HolidayTypes.Bank
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Weihnachten",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Stephanstag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Silvester",
                    HolidayTypes = HolidayTypes.Bank
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-47),
                    EnglishName = "Shrove Tuesday",
                    LocalName = "Fasnachtsdienstag",
                    HolidayTypes = HolidayTypes.Bank
                },
                this._catholicProvider.GoodFriday("Karfreitag", year).SetHolidayTypes(HolidayTypes.Bank),
                this._catholicProvider.EasterMonday("Ostermontag", year),
                this._catholicProvider.Pentecost("Pfingstsonntag", year),
                this._catholicProvider.AscensionDay("Auffahrt", year),
                this._catholicProvider.WhitMonday("Pfingstmontag", year),
                this._catholicProvider.CorpusChristi("Fronleichnam", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Liechtenstein",
                "https://www.llb.li/de/kontakt/bankfeiertage"
            ];
        }
    }
}
