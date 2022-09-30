using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Mongoli
    /// </summary>
    internal class MongoliaProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// MongoliaProvider
        /// </summary>
        public MongoliaProvider()
        {
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MN;

            //TODO:Add lunar calendar support
            //TODO:Add Mongolian calendar support

            //Add Lunar New Year or Tsagaan Sar (Цагаан сар (Tsagaan sar))
            //Add Genghis Khan's birthday (Чингис хааны төрсөн өдөр (Chingis Khaany törsön ödör))

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Шинэ жил (Shine jil)", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 3, 8, "Олон Улсын Эмэгтэйчүүдийн Баяр", "International Women's Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 1, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new PublicHoliday(year, 7, 11, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new PublicHoliday(year, 7, 12, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new PublicHoliday(year, 7, 13, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new PublicHoliday(year, 7, 14, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new PublicHoliday(year, 7, 15, "Наадам", "Naadam Holiday", countryCode));
            items.Add(new PublicHoliday(year, 11, 26, "Улс тунхагласны өдөр", "Republic Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 29, "Тусгаар Тогтнолын Өдөр ", "Independence Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mongolia"
            };
        }
    }
}
