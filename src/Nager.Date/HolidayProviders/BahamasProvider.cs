using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bahamas
    /// </summary>
    internal class BahamasProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// BahamasProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BahamasProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BS;

            var items = new List<Holiday>();
            items.Add(this.ApplyShiftingRules(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 1, 10, "Majority Rule Day", "Majority Rule Day", countryCode)));
            items.Add(this.ApplyShiftingRules(this._catholicProvider.GoodFriday("Good Friday", year, countryCode)));
            items.Add(this.ApplyShiftingRules(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode)));
            items.Add(this.ApplyShiftingRules(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode)));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 4, 1, "Perry Christie Day", "Perry Christie Day", countryCode)));
            items.Add(new Holiday(year, 7, 10, "Independence Day", "Independence Day", countryCode));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 8, 5, "Emancipation Day", "Emancipation Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 10, 12, "National Heroes' Day", "National Heroes' Day", countryCode)));
            items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday ApplyShiftingRules(Holiday holiday)
        {
            return holiday
                .Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1))
                .ShiftWeekdays(tuesday: tuesday => tuesday.AddDays(-1), wednesday: wednesday => wednesday.AddDays(2), thursday: thursday => thursday.AddDays(1));
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Bahamas"
            };
        }
    }
}
