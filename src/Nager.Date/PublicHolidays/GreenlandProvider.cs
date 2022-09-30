using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Greenland
    /// </summary>
    internal class GreenlandProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// GreenlandProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GreenlandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GL;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Ukiortaaq", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Kunngit pingasut ulluat", "Epiphany", countryCode, type: PublicHolidayType.Bank | PublicHolidayType.School | PublicHolidayType.Optional));
            items.Add(this._catholicProvider.MaundyThursday("Sisamanngortoq illernartoq", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Tallimanngorneq tannaartoq", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Poorskip ullua", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Poorskip-aappaa", year, countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(26), "Tussiarfik", "General Prayer Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Qilaliarfik", year, countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(40), "Atuanngiffik", "Bank closing day", countryCode, type: PublicHolidayType.Bank | PublicHolidayType.School | PublicHolidayType.Optional));
            items.Add(this._catholicProvider.Pentecost("Piinsi", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Piinsip-aappaa", year, countryCode));
            items.Add(new PublicHoliday(year, 6, 21, "Ullortuneq", "Ullortuneq", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Juulliaraq", "Christmas Eve", countryCode, type: PublicHolidayType.Bank | PublicHolidayType.School | PublicHolidayType.Optional));
            items.Add(new PublicHoliday(year, 12, 25, "Juullip ullua", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Juullip-aappaa", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "Ukiutoqaq", "New Year's Eve", countryCode, type: PublicHolidayType.Bank | PublicHolidayType.School | PublicHolidayType.Optional));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Greenland"
            };
        }
    }
}
