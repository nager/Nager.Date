using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Faroe Islands, adaptation of DenmarkProvider
    /// </summary>
    internal class FaroeIslandsProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// FaroeIslandsProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public FaroeIslandsProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.FO;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nýggjársdagur", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Skírhósdagur", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Langifríggjadagur", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Páskadagur", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("2. Páskadagur", year, countryCode));
            items.Add(new PublicHoliday(year, 4, 25, "Flaggdagur", "National Flag Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(26), "Dýri biðidagur", "General Prayer Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Kristi himmalsferðar dagur", year, countryCode));
            items.Add(this._catholicProvider.Pentecost("Hvítasunnudagur", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("2. Hvítasunnudagur", year, countryCode));
            items.Add(new PublicHoliday(year, 6, 5, "Grundlógardagur Danmarkar", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 28, "Ólavsøkuaftan", "Saint Olav's Eve", countryCode));
            items.Add(new PublicHoliday(year, 7, 29, "Ólavsøkudagur", "Saint Olav's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Jólaaftanskvøld", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Jóladagur", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "2. Jóladagur", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Nýggjársaftan", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Faroe_Islands",
                "https://en.wikipedia.org/wiki/Store_Bededag"
            };
        }
    }
}
