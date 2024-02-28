using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Belarus
    /// </summary>
    internal class BelarusProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// BelarusProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public BelarusProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BY;
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Новы год", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 2, "Новы год", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 7, "Каляды праваслаўныя", "Orthodox Christmas Day", countryCode));
            items.Add(new Holiday(year, 3, 8, "Мiжнародны жаночы дзень", "International Women's Day", countryCode));
            items.Add(new Holiday(year, 5, 1, "Дзень працы", "Labour Day", countryCode));
            items.Add(new Holiday(year, 5, 9, "Дзень Перамогi", "Victory Day", countryCode));
            items.Add(new Holiday(year, 7, 3, "Дзень Незалежнасцi", "Independence Day", countryCode));
            items.Add(new Holiday(year, 11, 7, "Дзень Кастрычніцкай рэвалюцыі", "October Revolution Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Каляды каталiцкiя", "Catholic Christmas Day", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(9), "Радунiца", "Commemoration Day", countryCode));
            
            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Belarus"
            };
        }
    }
}
