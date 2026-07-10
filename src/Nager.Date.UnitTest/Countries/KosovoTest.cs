using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class KosovoTest
    {
        private const int Year = 2024;

        [TestMethod]
        public void TestKosovoHolidaysFor2024()
        {
            var publicHolidays = HolidaySystem.GetHolidays(Year, CountryCode.XK).ToArray();

            var actual = publicHolidays.Select(publicHoliday => new
            {
                publicHoliday.Date,
                publicHoliday.EnglishName,
                publicHoliday.LocalName
            }).ToArray();

            CollectionAssert.AreEqual(_kosovoBankHolidays2024, actual);
        }

        /// <summary>
        /// List of public holidays in Kosovo for 2024.
        /// </summary>
        /// <remarks>Source: https://gzk.rks-gov.net/ActDocumentDetail.aspx?ActID=2539</remarks>
        private static readonly dynamic[] _kosovoBankHolidays2024 =
        {
            new { Date = new DateTime(Year, 1, 1),   EnglishName = "New Year's Day",                LocalName = "Viti i Ri" },
            new { Date = new DateTime(Year, 1, 2),   EnglishName = "New Year's Day",                LocalName = "Viti i Ri" },
            new { Date = new DateTime(Year, 1, 7),   EnglishName = "Orthodox Christmas",            LocalName = "Krishtlindjet Ortodokse" },
            new { Date = new DateTime(Year, 2, 17),  EnglishName = "Independence Day",              LocalName = "Dita e Pavarësisë së Republikës së Kosovës" },
            new { Date = new DateTime(Year, 4, 1),  EnglishName = "Easter Monday",                  LocalName = "E hëna e Pashkëve Katolike" },
            new { Date = new DateTime(Year, 4, 9),   EnglishName = "Constitution Day",              LocalName = "Dita e Kushtetutës së Republikës së Kosovës" },
            new { Date = new DateTime(Year, 4, 10),  EnglishName = "Eid al-Fitr",                   LocalName = "Bajrami i Madh" },
            new { Date = new DateTime(Year, 5, 1),   EnglishName = "International Workers' Day",    LocalName = "Dita Ndërkombëtare e Punës" },
            new { Date = new DateTime(Year, 5, 6),   EnglishName = "Easter Monday",                 LocalName = "E hëna e Pashkëve Ortodokse" },
            new { Date = new DateTime(Year, 5, 9),   EnglishName = "Europe Day",                    LocalName = "Dita e Evropës" },
            new { Date = new DateTime(Year, 6, 16),  EnglishName = "Eid al-Adha",                   LocalName = "Bajrami i Vogël" },
            new { Date = new DateTime(Year, 12, 25), EnglishName = "Catholic Christmas",            LocalName = "Krishtlindjet Katolike" },
        };
    }
}
