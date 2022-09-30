using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Bahamas
    /// </summary>
    internal class BahamasProvider : IPublicHolidayProvider
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
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BS;

            var items = new List<PublicHoliday>();
            items.Add(this.ApplyShiftingRules(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new PublicHoliday(year, 1, 10, "Majority Rule Day", "Majority Rule Day", countryCode)));
            items.Add(this.ApplyShiftingRules(this._catholicProvider.GoodFriday("Good Friday", year, countryCode)));
            items.Add(this.ApplyShiftingRules(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode)));
            items.Add(this.ApplyShiftingRules(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode)));
            items.Add(this.ApplyShiftingRules(new PublicHoliday(year, 4, 1, "Perry Christie Day", "Perry Christie Day", countryCode)));
            items.Add(new PublicHoliday(year, 7, 10, "Independence Day", "Independence Day", countryCode));
            items.Add(this.ApplyShiftingRules(new PublicHoliday(year, 8, 5, "Emancipation Day", "Emancipation Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new PublicHoliday(year, 10, 12, "National Heroes' Day", "National Heroes' Day", countryCode)));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        private PublicHoliday ApplyShiftingRules(PublicHoliday holiday)
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
