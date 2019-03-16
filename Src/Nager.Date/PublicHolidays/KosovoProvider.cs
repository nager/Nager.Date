//using Nager.Date.Contract;
//using Nager.Date.Model;
//using System.Collections.Generic;
//using System.Linq;

//namespace Nager.Date.PublicHolidays
//{
//    /// <summary>
//    /// Kosovo
//    /// https://en.wikipedia.org/wiki/Public_holidays_in_Kosovo
//    /// </summary>
//    public class KosovoProvider : IPublicHolidayProvider
//    {
//        private readonly IOrthodoxProvider _orthodoxProvider;
//        private readonly ICatholicProvider _catholicProvider;

//        /// <summary>
//        /// KosovoProvider
//        /// </summary>
//        /// <param name="orthodoxProvider"></param>
//        /// <param name="catholicProvider"></param>
//        public KosovoProvider(IOrthodoxProvider orthodoxProvider, ICatholicProvider catholicProvider)
//        {
//            this._orthodoxProvider = orthodoxProvider;
//            this._catholicProvider = catholicProvider;
//        }

//        /// <summary>
//        /// Get
//        /// </summary>
//        /// <param name="year">The year</param>
//        /// <returns></returns>
//        public IEnumerable<PublicHoliday> Get(int year)
//        {
//            var countryCode = CountryCode.XK;
//            var orthodoxEasterSunday = this._orthodoxProvider.EasterSunday(year);
//            var catholicEasterSunday = this._catholicProvider.EasterSunday(year);

//            var items = new List<PublicHoliday>();
//            items.Add(new PublicHoliday(year, 1, 1, "Viti i Ri", "New Year's Day", countryCode));
//            items.Add(new PublicHoliday(year, 1, 7, "Krishtlindjet Ortodokse", "Orthodox Christmas", countryCode));
//            items.Add(new PublicHoliday(year, 2, 17, "Dita e Pavarësisë", "Independence Day", countryCode));
//            items.Add(new PublicHoliday(year, 4, 9, "Dita e Kushtetutës", "Constitution Day", countryCode));
//            items.Add(new PublicHoliday(catholicEasterSunday, "Pashkët Katolike", "Catholic Easter", countryCode));
//            items.Add(new PublicHoliday(orthodoxEasterSunday, "Pashkët Ortodokse", "Orthodox Easter", countryCode));
//            items.Add(new PublicHoliday(year, 5, 1, "Dita Ndërkombëtare e Punës", "International Workers' Day", countryCode));
//            items.Add(new PublicHoliday(year, 5, 9, "Dita e Evropës", "Europe Day", countryCode));
//            //TODO:Eid ul-Fitr is not implemented
//            //TODO:Eid ul-Adha is not implemented
//            items.Add(new PublicHoliday(year, 12, 25, "Krishtlindjet Katolike", "Catholic Christmas", countryCode));

//            return items.OrderBy(o => o.Date);
//        }
//    }
//}
