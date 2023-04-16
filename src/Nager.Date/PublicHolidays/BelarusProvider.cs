using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Belarus
    /// </summary>
    internal class BelarusProvider : IPublicHolidayProvider
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
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.BY;
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Новы год", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 2, "Новы год", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 7, "Каляды праваслаўныя", "Orthodox Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 8, "Мiжнародны жаночы дзень", "International Women's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Дзень працы", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 9, "Дзень Перамогi", "Victory Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 3, "Дзень Незалежнасцi", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 7, "Дзень Кастрычніцкай рэвалюцыі", "October Revolution Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Каляды каталiцкiя", "Catholic Christmas Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(9), "Радунiца", "Commemoration Day", countryCode));
            
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
