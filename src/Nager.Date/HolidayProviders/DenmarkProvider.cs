using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Denmark
    /// </summary>
    internal class DenmarkProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// DenmarkProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public DenmarkProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.DK;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Nytårsdag", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Skærtorsdag", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Langfredag", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Påskedag", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("2. Påskedag", year, countryCode));
            items.Add(this._catholicProvider.AscensionDay("Kristi Himmelfartsdag", year, countryCode));
            items.Add(new Holiday(easterSunday.AddDays(40), "Banklukkedag", "Bank closing day", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));
            items.Add(this._catholicProvider.Pentecost("Pinsedag", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("2. Pinsedag", year, countryCode));
            items.Add(new Holiday(year, 6, 5, "Grundlovsdag", "Constitution Day", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));
            items.Add(new Holiday(year, 12, 24, "Juleaftensdag", "Christmas Eve", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));
            items.Add(new Holiday(year, 12, 25, "Juledag / 1. juledag", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "2. juledag", "St. Stephen's Day", countryCode));
            items.Add(new Holiday(year, 12, 31, "Nytårsaftensdag", "New Year's Eve", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));

            items.AddIfNotNull(this.GeneralPrayerDay(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday GeneralPrayerDay(int year, CountryCode countryCode)
        {
            if (year < 2024)
            {
                var easterSunday = this._catholicProvider.EasterSunday(year);
                return new Holiday(easterSunday.AddDays(26), "Store bededag", "General Prayer Day", countryCode);
            }

            return null;
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Denmark",
            };
        }
    }
}
