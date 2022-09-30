using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Indonesia
    /// </summary>
    internal class IndonesiaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// IndonesiaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public IndonesiaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            //TODO: Add chinise calendar
            //TODO: Add Balinese Saka calendar support
            //TODO: Add islamic calendar support
            //TODO: Add Buddhist calendar

            //Add Chinese New Year (Tahun Baru Imlek)
            //Add Day of Silence (Hari Raya Nyepi-Tahun Baru Saka)
            //Add Ascension of the Prophet (Isra Mi'raj Nabi Muhammad)
            //Add Eid al-Fitr (Hari Raya Idul Fitri)
            //Add Feast of the Sacrifice (Hari Raya Idul Adha)
            //Add Islamic New Year (Tahun Baru Islam 1440 Hijriah)
            //Add Birth of the Prophet (Maulid Nabi Muhammad)

            var countryCode = CountryCode.ID;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Tahun Baru Masehi", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.GoodFriday("Wafat Isa Almasih", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Paskah", year, countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Hari Buruh Internasional", "Labour Day", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Kenaikan Isa Almasih", year, countryCode));
            items.Add(new PublicHoliday(year, 6, 1, "Hari Lahir Pancasila", "Pancasila Day", countryCode, launchYear: 2017));
            items.Add(new PublicHoliday(year, 8, 17, "Hari Ulang Tahun Kemerdekaan Republik Indonesia", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Hari Raya Natal", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Indonesia",
            };
        }
    }
}
