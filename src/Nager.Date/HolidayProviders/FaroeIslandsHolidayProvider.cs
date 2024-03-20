using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Faroe Islands HolidayProvider
    /// </summary>
    /// <remarks>Adaptation of DenmarkProvider</remarks>
    internal sealed class FaroeIslandsHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// FaroeIslands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public FaroeIslandsHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.FO)
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
                    LocalName = "Nýggjársdagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 25),
                    EnglishName = "National Flag Day",
                    LocalName = "Flaggdagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(26),
                    EnglishName = "General Prayer Day",
                    LocalName = "Dýri biðidagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 5),
                    EnglishName = "Constitution Day",
                    LocalName = "Grundlógardagur Danmarkar",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 28),
                    EnglishName = "Saint Olav's Eve",
                    LocalName = "Ólavsøkuaftan",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 29),
                    EnglishName = "Saint Olav's Day",
                    LocalName = "Ólavsøkudagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Jólaaftanskvøld",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Jóladagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "2. Jóladagur",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Nýggjársaftan",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(26),
                    EnglishName = "General Prayer Day",
                    LocalName = "Dýri biðidagur",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.MaundyThursday("Skírhósdagur", year),
                this._catholicProvider.GoodFriday("Langifríggjadagur", year),
                this._catholicProvider.EasterSunday("Páskadagur", year),
                this._catholicProvider.EasterMonday("2. Páskadagur", year),
                this._catholicProvider.AscensionDay("Kristi himmalsferðar dagur", year),
                this._catholicProvider.Pentecost("Hvítasunnudagur", year),
                this._catholicProvider.WhitMonday("2. Hvítasunnudagur", year)
            };

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Nýggjársdagur", "New Year's Day", countryCode));
            //items.Add(this._catholicProvider.MaundyThursday("Skírhósdagur", year, countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Langifríggjadagur", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Páskadagur", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("2. Páskadagur", year, countryCode));
            //items.Add(new Holiday(year, 4, 25, "Flaggdagur", "National Flag Day", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(26), "Dýri biðidagur", "General Prayer Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Kristi himmalsferðar dagur", year, countryCode));
            //items.Add(this._catholicProvider.Pentecost("Hvítasunnudagur", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("2. Hvítasunnudagur", year, countryCode));
            //items.Add(new Holiday(year, 6, 5, "Grundlógardagur Danmarkar", "Constitution Day", countryCode));
            //items.Add(new Holiday(year, 7, 28, "Ólavsøkuaftan", "Saint Olav's Eve", countryCode));
            //items.Add(new Holiday(year, 7, 29, "Ólavsøkudagur", "Saint Olav's Day", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Jólaaftanskvøld", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Jóladagur", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "2. Jóladagur", "St. Stephen's Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "Nýggjársaftan", "New Year's Eve", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Faroe_Islands",
                "https://en.wikipedia.org/wiki/Store_Bededag"
            ];
        }
    }
}
