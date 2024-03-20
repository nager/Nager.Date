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

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Neujahr", "New Year's Day", countryCode, 1967));
            //items.Add(new Holiday(year, 1, 2, "Berchtoldstag", "St. Berchtold's Day", countryCode, type: HolidayTypes.Bank));
            //items.Add(new Holiday(year, 1, 6, "Heilige Drei Könige", "Epiphany", countryCode));
            //items.Add(new Holiday(year, 2, 2, "Mariä Lichtmess", "Candlemas", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-47), "Fasnachtsdienstag", "Shrove Tuesday", countryCode, type: HolidayTypes.Bank));
            //items.Add(new Holiday(year, 3, 19, "Josefstag", "Saint Joseph's Day", countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Karfreitag", year, countryCode).SetType(HolidayTypes.Bank));
            //items.Add(this._catholicProvider.EasterMonday("Ostermontag", year, countryCode).SetLaunchYear(1642));
            //items.Add(new Holiday(year, 5, 1, "Tag der Arbeit", "Labour Day", countryCode));
            //items.Add(this._catholicProvider.Pentecost("Pfingstsonntag", year, countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Auffahrt", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Pfingstmontag", year, countryCode));
            //items.Add(this._catholicProvider.CorpusChristi("Fronleichnam", year, countryCode));
            //items.Add(new Holiday(year, 8, 15, "Staatsfeiertag", "National Holiday", countryCode));
            //items.Add(new Holiday(year, 9, 8, "Maria Geburt", "Nativity of Our Lady", countryCode));
            //items.Add(new Holiday(year, 11, 1, "Allerheiligen", "All Saints Day", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Mariä Empfängnis", "Immaculate Conception", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Heiliger Abend", "Christmas Eve", countryCode, type: HolidayTypes.Bank));
            //items.Add(new Holiday(year, 12, 25, "Weihnachten", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Stephanstag", "St. Stephen's Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "Silvester", "New Year's Eve", countryCode, type: HolidayTypes.Bank));
            //return items.OrderBy(o => o.Date);
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
