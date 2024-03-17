using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class AlbaniaTest
    {
        private const int Year = 2024;

        [TestMethod]
        public void TestAlbanianHolidaysFor2024()
        {
            var publicHolidays = HolidaySystem.GetHolidays(Year, CountryCode.AL).ToArray();

            var actual = publicHolidays.Select(publicHoliday => new
            {
                publicHoliday.Date,
                publicHoliday.EnglishName,
                publicHoliday.LocalName
            }).ToArray();

            CollectionAssert.AreEqual(_albaniaBankHolidays2024, actual);
        }

        /// <summary>
        /// List of public holidays in Albania for 2024.
        /// </summary>
        /// <remarks>Source: https://www.bankofalbania.org/Press/2024_Official_Bank_Holiday_Schedule/</remarks>
        private static readonly dynamic[] _albaniaBankHolidays2024 =
        {
            new
            {
                Date = new DateTime(Year, 1, 1),
                EnglishName = "New Year's Day",
                LocalName = "Viti i Ri"
            },
            new
            {
                Date = new DateTime(Year, 1, 2),
                EnglishName = "New Year's Day",
                LocalName = "Viti i Ri"
            },
            new
            {
                Date = new DateTime(Year, 3, 14),
                EnglishName = "Summer Day",
                LocalName = "Dita e Verës"
            },
            new
            {
                Date = new DateTime(Year, 3, 22),
                EnglishName = "Nowruz",
                LocalName = "Dita e Sulltan Nevruzit"
            },
            new
            {
                Date = new DateTime(Year, 03, 31),
                EnglishName = "Easter Sunday",
                LocalName = "Pashkët Katolike"
            },
            new
            {
                Date = new DateTime(Year, 04, 01),
                EnglishName = "Easter Monday",
                LocalName = "E hëna e Pashkëve Katolike"
            },
            new
            {
                Date = new DateTime(Year, 5, 1),
                EnglishName = "May Day",
                LocalName = "Dita Ndërkombëtare e Punonjësve"
            },
            new
            {
                Date = new DateTime(Year, 05, 05),
                EnglishName = "Easter Sunday",
                LocalName = "Pashkët Ortodokse"
            },
            new
            {
                Date = new DateTime(Year, 05, 06),
                EnglishName = "Easter Monday",
                LocalName = "E hëna e Pashkëve Ortodokse"
            },
            new
            {
                Date = new DateTime(Year, 9, 05),
                EnglishName = "Mother Teresa Day",
                LocalName = "Dita e Nënë Terezës"
            },
            new
            {
                Date = new DateTime(Year, 11, 28),
                EnglishName = "Independence Day",
                LocalName = "Dita e Pavarësisë"
            },
            new
            {
                Date = new DateTime(Year, 11, 29),
                EnglishName = "Liberation Day",
                LocalName = "Dita e Çlirimit"
            },
            new
            {
                Date = new DateTime(Year, 12, 8),
                EnglishName = "Youth Day",
                LocalName = "Dita Kombëtare e Rinisë"
            },
            new
            {
                Date = new DateTime(Year, 12, 25),
                EnglishName = "Christmas Day",
                LocalName = "Krishtlindjet"
            }
        };
    }
}
