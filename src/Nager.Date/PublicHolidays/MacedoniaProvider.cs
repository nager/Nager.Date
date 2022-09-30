using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Macedonia
    /// </summary>
    internal class MacedoniaProvider : IPublicHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// MacedoniaProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public MacedoniaProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MK;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Нова Година, Nova Godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 7, "Прв ден Божик, Prv den Božik", "Christmas Day", countryCode));
            items.Add(this._orthodoxProvider.GoodFriday("Велики Петок, Veliki Petok", year, countryCode));
            items.Add(this._orthodoxProvider.EasterSunday("Прв ден Велигден, Prv den Veligden", year, countryCode));
            items.Add(this._orthodoxProvider.EasterMonday("Втор ден Велигден, Vtor den Veligden", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Ден на трудот, Den na trudot", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 24, "Св. Кирил и Методиј, Ден на сèсловенските просветители", "Saints Cyril and Methodius Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 2, "Ден на Републиката, Den na Republikata", "Day of the Republic", countryCode));
            items.Add(new PublicHoliday(year, 9, 8, "Ден на независноста, Den na nezavisnosta", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 11, "Ден на востанието, Den na vostanieto", "Revolution Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 23, "Ден на македонската револуционерна борба,Den na makedonskata revolucionarna borba", "Day of the Macedonian Revolutionary Struggle", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Св. Климент Охридски, Sv. Kliment Ohridski", "Saint Clement of Ohrid Day", countryCode));
            //items.Add(new PublicHoliday(year, ??, ??, "Рамазан Бајрам, Ramazan Bajram", "Eid al-Fitr", countryCode)); //Islamic

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Macedonia"
            };
        }
    }
}
